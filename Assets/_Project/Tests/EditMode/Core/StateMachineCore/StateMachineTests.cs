using System;
using System.Collections.Generic;
using NUnit.Framework;
using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.StateMachineCore;

namespace RoguelikeTD.Tests.Core.StateMachineCore
{
    public class StateMachineTests
    {
        private List<string> _log;

        [SetUp]
        public void SetUp()
        {
            _log = new List<string>();
        }

        [Test]
        public void Enter_FirstTime_EntersFirstAddedState()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            TestStateMachine machine = CreateMachine(a, b);

            machine.Enter();

            Assert.AreSame(a, machine.Current);
            CollectionAssert.AreEqual(new[] { "A:enter" }, _log);
        }

        [Test]
        public void Update_BeforeEnter_DoesNotSwitch()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            TestStateMachine machine = CreateMachine(a, b);
            machine.AddTransition(a, b, new FuncCondition(() => true));

            machine.Update(0.1f);

            CollectionAssert.IsEmpty(_log);
        }

        [Test]
        public void Update_WhenConditionTrue_ExitsCurrentAndEntersNext()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            TestStateMachine machine = CreateMachine(a, b);
            machine.AddTransition(a, b, new FuncCondition(() => true));
            machine.Enter();

            machine.Update(0.1f);

            Assert.AreSame(b, machine.Current);
            CollectionAssert.AreEqual(new[] { "A:enter", "A:exit", "B:enter" }, _log);
        }

        [Test]
        public void Update_WhenConditionFalse_StaysInState()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            TestStateMachine machine = CreateMachine(a, b);
            machine.AddTransition(a, b, new FuncCondition(() => false));
            machine.Enter();

            machine.Update(0.1f);

            Assert.AreSame(a, machine.Current);
            CollectionAssert.AreEqual(new[] { "A:enter" }, _log);
        }

        [Test]
        public void Update_SeveralTransitionsTrue_TakesFirstAddedOnly()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            TestState c = new TestState("C", _log);
            TestStateMachine machine = CreateMachine(a, b, c);
            machine.AddTransition(a, b, new FuncCondition(() => true));
            machine.AddTransition(a, c, new FuncCondition(() => true));
            machine.AddTransition(b, c, new FuncCondition(() => true));
            machine.Enter();

            machine.Update(0.1f);

            Assert.AreSame(b, machine.Current);
            CollectionAssert.AreEqual(new[] { "A:enter", "A:exit", "B:enter" }, _log);
        }

        [Test]
        public void Update_WhenSwitched_UpdateLogicSeesNewState()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            TestStateMachine machine = CreateMachine(a, b);
            machine.AddTransition(a, b, new FuncCondition(() => true));
            machine.Enter();

            machine.Update(0.1f);

            Assert.AreSame(b, machine.StateSeenByUpdateLogic);
        }

        [Test]
        public void Update_AfterExit_DoesNotSwitch()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            TestStateMachine machine = CreateMachine(a, b);
            machine.AddTransition(a, b, new FuncCondition(() => true));
            machine.Enter();
            machine.Exit();

            machine.Update(0.1f);

            Assert.AreSame(a, machine.Current);
            CollectionAssert.AreEqual(new[] { "A:enter", "A:exit" }, _log);
        }

        [Test]
        public void Enter_AfterExit_ResumesLastState()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            bool canSwitch = true;
            TestStateMachine machine = CreateMachine(a, b);
            machine.AddTransition(a, b, new FuncCondition(() => canSwitch));
            machine.Enter();
            machine.Update(0.1f);
            machine.Exit();
            canSwitch = false;
            _log.Clear();

            machine.Enter();

            Assert.AreSame(b, machine.Current);
            CollectionAssert.AreEqual(new[] { "B:enter" }, _log);
        }

        [Test]
        public void Dispose_DisposesStatesAndPassedDisposables()
        {
            DisposableTestState disposableState = new DisposableTestState("A", _log);
            FakeDisposable passedDisposable = new FakeDisposable();
            TestStateMachine machine = new TestStateMachine(new List<IDisposable> { passedDisposable });
            machine.AddState(disposableState);

            machine.Dispose();

            Assert.AreEqual(1, disposableState.DisposeCallCount);
            Assert.AreEqual(1, passedDisposable.DisposeCallCount);
        }

        [Test]
        public void AddTransition_WithUnknownState_Throws()
        {
            TestState a = new TestState("A", _log);
            TestState unknown = new TestState("Unknown", _log);
            TestStateMachine machine = CreateMachine(a);

            Assert.Throws<InvalidOperationException>(() => machine.AddTransition(a, unknown, new FuncCondition(() => true)));
        }

        [Test]
        public void ParallelState_EnterAndExit_AppliesToAllStates()
        {
            TestState a = new TestState("A", _log);
            TestState b = new TestState("B", _log);
            TestParallelState parallel = new TestParallelState(a, b);

            parallel.Enter();
            parallel.Exit();

            CollectionAssert.AreEqual(new[] { "A:enter", "B:enter", "A:exit", "B:exit" }, _log);
        }

        private static TestStateMachine CreateMachine(params TestState[] states)
        {
            TestStateMachine machine = new TestStateMachine(new List<IDisposable>());

            foreach (TestState state in states)
                machine.AddState(state);

            return machine;
        }

        private class TestState : State
        {
            private readonly string _name;
            private readonly List<string> _log;

            public TestState(string name, List<string> log)
            {
                _name = name;
                _log = log;
            }

            public override void Enter()
            {
                base.Enter();
                _log.Add($"{_name}:enter");
            }

            public override void Exit()
            {
                base.Exit();
                _log.Add($"{_name}:exit");
            }
        }

        private class DisposableTestState : TestState, IDisposable
        {
            public DisposableTestState(string name, List<string> log) : base(name, log)
            {
            }

            public int DisposeCallCount { get; private set; }

            public void Dispose() => DisposeCallCount++;
        }

        private class TestStateMachine : StateMachine<TestState>
        {
            public TestStateMachine(List<IDisposable> disposables) : base(disposables)
            {
            }

            public TestState Current => CurrentState;
            public TestState StateSeenByUpdateLogic { get; private set; }

            protected override void UpdateLogic(float deltaTime) => StateSeenByUpdateLogic = CurrentState;
        }

        private class TestParallelState : ParallelState<TestState>
        {
            public TestParallelState(params TestState[] states) : base(states)
            {
            }
        }

        private class FakeDisposable : IDisposable
        {
            public int DisposeCallCount { get; private set; }

            public void Dispose() => DisposeCallCount++;
        }
    }
}
