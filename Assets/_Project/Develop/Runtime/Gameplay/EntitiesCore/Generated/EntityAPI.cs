namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team TeamC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> Team => TeamC.Value;

		public bool TryGetTeam(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Teams> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.BaseStats BaseStatsC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.BaseStats>();

		public System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single> BaseStats => BaseStatsC.Value;

		public bool TryGetBaseStats(out System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.BaseStats component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBaseStats()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.BaseStats() {Value = new System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBaseStats(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.BaseStats() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.ModifiesStats ModifiesStatsC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.ModifiesStats>();

		public System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single> ModifiesStats => ModifiesStatsC.Value;

		public bool TryGetModifiesStats(out System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.ModifiesStats component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddModifiesStats()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.ModifiesStats() {Value = new System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddModifiesStats(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes, System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.ModifiesStats() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffects StatsEffectsC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffects>();

		public Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffectsList StatsEffects => StatsEffectsC.Value;

		public bool TryGetStatsEffects(out Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffectsList value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffects component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffectsList);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStatsEffects()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffects() {Value = new Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffectsList() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStatsEffects(Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffectsList value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatsEffects() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnInitialTime SpawnInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> SpawnInitialTime => SpawnInitialTimeC.Value;

		public bool TryGetSpawnInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpawnInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpawnInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnCurrentTime SpawnCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> SpawnCurrentTime => SpawnCurrentTimeC.Value;

		public bool TryGetSpawnCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpawnCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddSpawnCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.SpawnCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.InSpawnProcess InSpawnProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.InSpawnProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InSpawnProcess => InSpawnProcessC.Value;

		public bool TryGetInSpawnProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.InSpawnProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInSpawnProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.InSpawnProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInSpawnProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature.InSpawnProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CapsuleCollider);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.BodyCollider() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public bool TryGetContactCollidersBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetContactEntitiesBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask DeathMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.DeathMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam IsTouchAnotherTeamC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchAnotherTeam => IsTouchAnotherTeamC.Value;

		public bool TryGetIsTouchAnotherTeam(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Sensors.IsTouchAnotherTeam() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced PlaceableIsPlacedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> PlaceableIsPlaced => PlaceableIsPlacedC.Value;

		public bool TryGetPlaceableIsPlaced(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddPlaceableIsPlaced()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddPlaceableIsPlaced(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney PlaceableIsEnoughMoneyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> PlaceableIsEnoughMoney => PlaceableIsEnoughMoneyC.Value;

		public bool TryGetPlaceableIsEnoughMoney(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddPlaceableIsEnoughMoney()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddPlaceableIsEnoughMoney(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableToRelease PlaceableToReleaseC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableToRelease>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddPlaceableToRelease()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature.PlaceableToRelease() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetMoveSpeed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving IsMovingC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection RotationDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed RotationSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public bool TryGetRotationSpeed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate CanRotateC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero IsMainHeroC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMainHero()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MainHero.IsMainHero() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.IsPullable IsPullableC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.IsPullable>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsPullable()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.IsPullable() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.InPullingProcess InPullingProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.InPullingProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InPullingProcess => InPullingProcessC.Value;

		public bool TryGetInPullingProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.InPullingProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInPullingProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.InPullingProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInPullingProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.InPullingProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.IsCollected IsCollectedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.IsCollected>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsCollected => IsCollectedC.Value;

		public bool TryGetIsCollected(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.IsCollected component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsCollected()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.IsCollected() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsCollected(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.IsCollected() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.Coins CoinsC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.Coins>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> Coins => CoinsC.Value;

		public bool TryGetCoins(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.Coins component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCoins()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.Coins() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCoins(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.Coins() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.LootIsDropped LootIsDroppedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.LootIsDropped>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> LootIsDropped => LootIsDroppedC.Value;

		public bool TryGetLootIsDropped(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.LootIsDropped component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddLootIsDropped()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.LootIsDropped() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddLootIsDropped(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.LootIsDropped() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.CanDropLoot CanDropLootC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.CanDropLoot>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanDropLoot => CanDropLootC.Value;

		public bool TryGetCanDropLoot(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.CanDropLoot component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanDropLoot(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature.CanDropLoot() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public bool TryGetMaxHealth(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.HealthBarPoint HealthBarPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.HealthBarPoint>();

		public UnityEngine.Transform HealthBarPoint => HealthBarPointC.Value;

		public bool TryGetHealthBarPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.HealthBarPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddHealthBarPoint(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.HealthBarPoint() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public bool TryGetIsDead(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public bool TryGetMustDie(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public bool TryGetDeathProcessCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess InDeathProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public bool TryGetInDeathProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetDisableCollidersOnDeath(out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = new System.Collections.Generic.List<UnityEngine.Collider>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Experience ExperienceC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Experience>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> Experience => ExperienceC.Value;

		public bool TryGetExperience(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Experience component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExperience()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Experience() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExperience(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Experience() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Level LevelC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Level>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> Level => LevelC.Value;

		public bool TryGetLevel(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Level component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddLevel()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Level() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddLevel(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature.Level() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickGroundPosition InputMouseClickGroundPositionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickGroundPosition>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> InputMouseClickGroundPosition => InputMouseClickGroundPositionC.Value;

		public bool TryGetInputMouseClickGroundPosition(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickGroundPosition component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputMouseClickGroundPosition()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickGroundPosition() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputMouseClickGroundPosition(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickGroundPosition() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest InputFindMouseClickPositionRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent InputFindMouseClickPositionRequest => InputFindMouseClickPositionRequestC.Value;

		public bool TryGetInputFindMouseClickPositionRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputFindMouseClickPositionRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputFindMouseClickPositionRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickPositionFindedEvent InputMouseClickPositionFindedEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickPositionFindedEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent InputMouseClickPositionFindedEvent => InputMouseClickPositionFindedEventC.Value;

		public bool TryGetInputMouseClickPositionFindedEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickPositionFindedEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputMouseClickPositionFindedEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickPositionFindedEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputMouseClickPositionFindedEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMouseClickPositionFindedEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputIsPositionFound InputIsPositionFoundC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputIsPositionFound>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InputIsPositionFound => InputIsPositionFoundC.Value;

		public bool TryGetInputIsPositionFound(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputIsPositionFound component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputIsPositionFound()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputIsPositionFound() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputIsPositionFound(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputIsPositionFound() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetBodyContactDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyContactDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsProjectile IsProjectileC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsProjectile>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsProjectile()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsProjectile() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetStartAttackRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetStartAttackEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddStartAttackEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.StartAttackEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetCanStartAttack(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartAttack(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.CanStartAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddEndAttackEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.EndAttackEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackProcessInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackProcessCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public bool TryGetInAttackProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackProcess() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetAttackDelayTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetAttackDelayEndEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public bool TryGetInstantAttackDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantAttackDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint ShootPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootPoint() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public bool TryGetMustCancelAttack(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustCancelAttack(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.MustCancelAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent AttackCancelEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackCancelEvent => AttackCancelEventC.Value;

		public bool TryGetAttackCancelEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCancelEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCancelEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCancelEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public bool TryGetAttackCooldownInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public bool TryGetAttackCooldownCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public bool TryGetInAttackCooldown(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInAttackCooldown(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InAttackCooldown() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantShootingDirections InstantShootingDirectionsC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantShootingDirections>();

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Shoot.InstantShootingDirectionArgs InstantShootingDirections => InstantShootingDirectionsC.Value;

		public bool TryGetInstantShootingDirections(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Shoot.InstantShootingDirectionArgs value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantShootingDirections component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Shoot.InstantShootingDirectionArgs);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInstantShootingDirections(Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Shoot.InstantShootingDirectionArgs value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.InstantShootingDirections() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootingMinDistance ShootingMinDistanceC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootingMinDistance>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ShootingMinDistance => ShootingMinDistanceC.Value;

		public bool TryGetShootingMinDistance(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootingMinDistance component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootingMinDistance()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootingMinDistance() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootingMinDistance(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.ShootingMinDistance() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsMinDistanceToAttack IsMinDistanceToAttackC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsMinDistanceToAttack>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsMinDistanceToAttack => IsMinDistanceToAttackC.Value;

		public bool TryGetIsMinDistanceToAttack(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsMinDistanceToAttack component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMinDistanceToAttack()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsMinDistanceToAttack() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMinDistanceToAttack(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.IsMinDistanceToAttack() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableDamage TickableDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TickableDamage => TickableDamageC.Value;

		public bool TryGetTickableDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableRadius TickableRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableRadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TickableRadius => TickableRadiusC.Value;

		public bool TryGetTickableRadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableRadius() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableRadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableRadius() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCollidersBuffer TickableCollidersBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> TickableCollidersBuffer => TickableCollidersBufferC.Value;

		public bool TryGetTickableCollidersBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableCollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCollidersBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableEntitiesBuffer TickableEntitiesBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> TickableEntitiesBuffer => TickableEntitiesBufferC.Value;

		public bool TryGetTickableEntitiesBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableEntitiesBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableTakeDamageMask TickableTakeDamageMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableTakeDamageMask>();

		public UnityEngine.LayerMask TickableTakeDamageMask => TickableTakeDamageMaskC.Value;

		public bool TryGetTickableTakeDamageMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableTakeDamageMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableTakeDamageMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableTakeDamageMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableInitialTime TickableInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TickableInitialTime => TickableInitialTimeC.Value;

		public bool TryGetTickableInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableInitialTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime TickableCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TickableCurrentTime => TickableCurrentTimeC.Value;

		public bool TryGetTickableCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTickableCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.PointClickExplosion.CanExplode CanExplodeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.PointClickExplosion.CanExplode>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanExplode => CanExplodeC.Value;

		public bool TryGetCanExplode(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.PointClickExplosion.CanExplode component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanExplode(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.PointClickExplosion.CanExplode() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineDamage MineDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MineDamage => MineDamageC.Value;

		public bool TryGetMineDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTriggerRadius MineTriggerRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTriggerRadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MineTriggerRadius => MineTriggerRadiusC.Value;

		public bool TryGetMineTriggerRadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTriggerRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineTriggerRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTriggerRadius() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineTriggerRadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTriggerRadius() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineCollidersBuffer MineCollidersBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineCollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> MineCollidersBuffer => MineCollidersBufferC.Value;

		public bool TryGetMineCollidersBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineCollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineCollidersBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineEntitiesBuffer MineEntitiesBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> MineEntitiesBuffer => MineEntitiesBufferC.Value;

		public bool TryGetMineEntitiesBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineEntitiesBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTakeDamageMask MineTakeDamageMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTakeDamageMask>();

		public UnityEngine.LayerMask MineTakeDamageMask => MineTakeDamageMaskC.Value;

		public bool TryGetMineTakeDamageMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTakeDamageMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineTakeDamageMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineTakeDamageMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsPlaced MineIsPlacedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsPlaced>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> MineIsPlaced => MineIsPlacedC.Value;

		public bool TryGetMineIsPlaced(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsPlaced component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineIsPlaced()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsPlaced() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineIsPlaced(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsPlaced() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsExploded MineIsExplodedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsExploded>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> MineIsExploded => MineIsExplodedC.Value;

		public bool TryGetMineIsExploded(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsExploded component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineIsExploded()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsExploded() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineIsExploded(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsExploded() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsEnoughGold MineIsEnoughGoldC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsEnoughGold>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> MineIsEnoughGold => MineIsEnoughGoldC.Value;

		public bool TryGetMineIsEnoughGold(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsEnoughGold component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineIsEnoughGold()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsEnoughGold() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMineIsEnoughGold(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.MineIsEnoughGold() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.CanMining CanMiningC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.CanMining>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanMining => CanMiningC.Value;

		public bool TryGetCanMining(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.CanMining component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMining(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining.CanMining() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDamage AOEDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AOEDamage => AOEDamageC.Value;

		public bool TryGetAOEDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOERadius AOERadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOERadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AOERadius => AOERadiusC.Value;

		public bool TryGetAOERadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOERadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOERadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOERadius() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOERadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOERadius() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage AOEDelayBeforeTakeDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AOEDelayBeforeTakeDamage => AOEDelayBeforeTakeDamageC.Value;

		public bool TryGetAOEDelayBeforeTakeDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEDelayBeforeTakeDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEDelayBeforeTakeDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer AOEDelayCurrentTimerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AOEDelayCurrentTimer => AOEDelayCurrentTimerC.Value;

		public bool TryGetAOEDelayCurrentTimer(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEDelayCurrentTimer()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEDelayCurrentTimer(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOETakeDamageMask AOETakeDamageMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOETakeDamageMask>();

		public UnityEngine.LayerMask AOETakeDamageMask => AOETakeDamageMaskC.Value;

		public bool TryGetAOETakeDamageMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOETakeDamageMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOETakeDamageMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOETakeDamageMask() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOECollidersBuffer AOECollidersBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOECollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> AOECollidersBuffer => AOECollidersBufferC.Value;

		public bool TryGetAOECollidersBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOECollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOECollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOECollidersBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEEntitiesBuffer AOEEntitiesBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> AOEEntitiesBuffer => AOEEntitiesBufferC.Value;

		public bool TryGetAOEEntitiesBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEEntitiesBuffer() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackRequest AOEAttackRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEInfoStruct> AOEAttackRequest => AOEAttackRequestC.Value;

		public bool TryGetAOEAttackRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEInfoStruct> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEInfoStruct>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEAttackRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEInfoStruct>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEAttackRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEInfoStruct> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackEvent AOEAttackEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AOEAttackEvent => AOEAttackEventC.Value;

		public bool TryGetAOEAttackEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEAttackEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEAttackEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.IsAOEAttackEnded IsAOEAttackEndedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.IsAOEAttackEnded>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsAOEAttackEnded => IsAOEAttackEndedC.Value;

		public bool TryGetIsAOEAttackEnded(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.IsAOEAttackEnded component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAOEAttackEnded()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.IsAOEAttackEnded() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAOEAttackEnded(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.IsAOEAttackEnded() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint AOEAttackTargetPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> AOEAttackTargetPoint => AOEAttackTargetPointC.Value;

		public bool TryGetAOEAttackTargetPoint(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEAttackTargetPoint()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAOEAttackTargetPoint(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public bool TryGetTakeDamageRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public bool TryGetTakeDamageEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public bool TryGetCanApplyDamage(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplyDamage(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.Allies.IsTower IsTowerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.Allies.IsTower>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTower()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.Allies.IsTower() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbility IsAbilityC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbility>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAbility()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbility() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsOnAddAbility IsOnAddAbilityC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsOnAddAbility>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsOnAddAbility()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsOnAddAbility() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsPerWaveAbility IsPerWaveAbilityC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsPerWaveAbility>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsPerWaveAbility()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsPerWaveAbility() );
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner AbilityOwnerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> AbilityOwner => AbilityOwnerC.Value;

		public bool TryGetAbilityOwner(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityOwner()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityOwner(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities AbilitiesC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities>();

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.AbilitiesList Abilities => AbilitiesC.Value;

		public bool TryGetAbilities(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.AbilitiesList value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.AbilitiesList);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilities()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities() {Value = new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.AbilitiesList() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilities(Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.AbilitiesList value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest AbilityOnAddActivatorRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AbilityOnAddActivatorRequest => AbilityOnAddActivatorRequestC.Value;

		public bool TryGetAbilityOnAddActivatorRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityOnAddActivatorRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityOnAddActivatorRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest AbilityPerWaveActivatorRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AbilityPerWaveActivatorRequest => AbilityPerWaveActivatorRequestC.Value;

		public bool TryGetAbilityPerWaveActivatorRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityPerWaveActivatorRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityPerWaveActivatorRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest AbilityActivateRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AbilityActivateRequest => AbilityActivateRequestC.Value;

		public bool TryGetAbilityActivateRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityActivateRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityActivateRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed IsAbilityUsedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsAbilityUsed => IsAbilityUsedC.Value;

		public bool TryGetIsAbilityUsed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAbilityUsed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAbilityUsed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent AbilityHealPercentC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> AbilityHealPercent => AbilityHealPercentC.Value;

		public bool TryGetAbilityHealPercent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityHealPercent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityHealPercent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent AbilityTakeDamagePercentC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> AbilityTakeDamagePercent => AbilityTakeDamagePercentC.Value;

		public bool TryGetAbilityTakeDamagePercent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityTakeDamagePercent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityTakeDamagePercent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent AbilityIncreaseDamagePercentC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> AbilityIncreaseDamagePercent => AbilityIncreaseDamagePercentC.Value;

		public bool TryGetAbilityIncreaseDamagePercent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityIncreaseDamagePercent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityIncreaseDamagePercent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatType AbilityStatTypeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatType>();

		public Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes AbilityStatType => AbilityStatTypeC.Value;

		public bool TryGetAbilityStatType(out Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatType component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityStatType(Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.StatTypes value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatType() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOperation AbilityOperationC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOperation>();

		public System.Func<System.Single, System.Single> AbilityOperation => AbilityOperationC.Value;

		public bool TryGetAbilityOperation(out System.Func<System.Single, System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOperation component);
			if(result)
				value = component.Value;
			else
				value = default(System.Func<System.Single, System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityOperation(System.Func<System.Single, System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOperation() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue AbilityStatChangeValueC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AbilityStatChangeValue => AbilityStatChangeValueC.Value;

		public bool TryGetAbilityStatChangeValue(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityStatChangeValue()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityStatChangeValue(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop IsAbilityAvailableToDropC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsAbilityAvailableToDrop => IsAbilityAvailableToDropC.Value;

		public bool TryGetIsAbilityAvailableToDrop(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAbilityAvailableToDrop()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAbilityAvailableToDrop(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID AbilityIDC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> AbilityID => AbilityIDC.Value;

		public bool TryGetAbilityID(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityID()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityID(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel AbilityMaxLevelC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> AbilityMaxLevel => AbilityMaxLevelC.Value;

		public bool TryGetAbilityMaxLevel(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityMaxLevel()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityMaxLevel(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel AbilityCurrentLevelC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> AbilityCurrentLevel => AbilityCurrentLevelC.Value;

		public bool TryGetAbilityCurrentLevel(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCurrentLevel()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCurrentLevel(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName AbilityNameC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> AbilityName => AbilityNameC.Value;

		public bool TryGetAbilityName(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityName()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityName(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription AbilityDescriptionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> AbilityDescription => AbilityDescriptionC.Value;

		public bool TryGetAbilityDescription(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityDescription()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityDescription(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.String> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIcon AbilityIconC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIcon>();

		public UnityEngine.Sprite AbilityIcon => AbilityIconC.Value;

		public bool TryGetAbilityIcon(out UnityEngine.Sprite value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIcon component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Sprite);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityIcon(UnityEngine.Sprite value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIcon() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable IsAbilityUpgradableC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsAbilityUpgradable => IsAbilityUpgradableC.Value;

		public bool TryGetIsAbilityUpgradable(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAbilityUpgradable()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAbilityUpgradable(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrencyType AbilityCurrencyTypeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrencyType>();

		public Assets._Project.Develop.Runtime.Meta.Features.Wallet.CurrencyTypes AbilityCurrencyType => AbilityCurrencyTypeC.Value;

		public bool TryGetAbilityCurrencyType(out Assets._Project.Develop.Runtime.Meta.Features.Wallet.CurrencyTypes value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrencyType component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Meta.Features.Wallet.CurrencyTypes);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCurrencyType(Assets._Project.Develop.Runtime.Meta.Features.Wallet.CurrencyTypes value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrencyType() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice AbilityPriceC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> AbilityPrice => AbilityPriceC.Value;

		public bool TryGetAbilityPrice(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityPrice()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityPrice(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget CurrentTargetC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.AI.CurrentTarget() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.RigidbodyComponent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public bool TryGetCharacterController(out UnityEngine.CharacterController value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CharacterController);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.CharacterControllerComponent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.TransformComponent TransformC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.TransformComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.TransformComponent() {Value = value});
		}

		public Assets._Project.Develop.Runtime.Gameplay.Common.Owner OwnerC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Common.Owner>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> Owner => OwnerC.Value;

		public bool TryGetOwner(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Common.Owner component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddOwner()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.Owner() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddOwner(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Common.Owner() {Value = value});
		}

	}
}
