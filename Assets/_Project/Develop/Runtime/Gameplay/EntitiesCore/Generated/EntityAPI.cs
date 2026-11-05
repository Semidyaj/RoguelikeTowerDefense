namespace RoguelikeTD.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public RoguelikeTD.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<RoguelikeTD.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public bool TryGetCharacterController(out UnityEngine.CharacterController value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Common.CharacterControllerComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CharacterController);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Common.CharacterControllerComponent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Common.Owner OwnerC => GetComponent<RoguelikeTD.Gameplay.Common.Owner>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> Owner => OwnerC.Value;

		public bool TryGetOwner(out RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Common.Owner component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddOwner()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Common.Owner() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddOwner(RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Common.Owner() {Value = value});
		}

		public RoguelikeTD.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<RoguelikeTD.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Common.RigidbodyComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Common.RigidbodyComponent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Common.TransformComponent TransformC => GetComponent<RoguelikeTD.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Common.TransformComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Common.TransformComponent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities AbilitiesC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities>();

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesList Abilities => AbilitiesC.Value;

		public bool TryGetAbilities(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesList value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesList);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilities()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities() {Value = new RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesList() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilities(RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesList value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.Abilities() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest AbilityActivateRequestC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent AbilityActivateRequest => AbilityActivateRequestC.Value;

		public bool TryGetAbilityActivateRequest(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityActivateRequest()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityActivateRequest(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityActivateRequest() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityBounceCountByLevel AbilityBounceCountByLevelC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityBounceCountByLevel>();

		public System.Func<System.Int32, System.Int32> AbilityBounceCountByLevel => AbilityBounceCountByLevelC.Value;

		public bool TryGetAbilityBounceCountByLevel(out System.Func<System.Int32, System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityBounceCountByLevel component);
			if(result)
				value = component.Value;
			else
				value = default(System.Func<System.Int32, System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityBounceCountByLevel(System.Func<System.Int32, System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityBounceCountByLevel() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityBounceLayerMask AbilityBounceLayerMaskC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityBounceLayerMask>();

		public UnityEngine.LayerMask AbilityBounceLayerMask => AbilityBounceLayerMaskC.Value;

		public bool TryGetAbilityBounceLayerMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityBounceLayerMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityBounceLayerMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityBounceLayerMask() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrencyType AbilityCurrencyTypeC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrencyType>();

		public RoguelikeTD.Meta.Features.Wallet.CurrencyTypes AbilityCurrencyType => AbilityCurrencyTypeC.Value;

		public bool TryGetAbilityCurrencyType(out RoguelikeTD.Meta.Features.Wallet.CurrencyTypes value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrencyType component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Meta.Features.Wallet.CurrencyTypes);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityCurrencyType(RoguelikeTD.Meta.Features.Wallet.CurrencyTypes value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrencyType() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel AbilityCurrentLevelC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> AbilityCurrentLevel => AbilityCurrentLevelC.Value;

		public bool TryGetAbilityCurrentLevel(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityCurrentLevel()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityCurrentLevel(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityCurrentLevel() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription AbilityDescriptionC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> AbilityDescription => AbilityDescriptionC.Value;

		public bool TryGetAbilityDescription(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.String>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityDescription()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.String>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityDescription(RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityDescription() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent AbilityHealPercentC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> AbilityHealPercent => AbilityHealPercentC.Value;

		public bool TryGetAbilityHealPercent(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityHealPercent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityHealPercent(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityHealPercent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIcon AbilityIconC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIcon>();

		public UnityEngine.Sprite AbilityIcon => AbilityIconC.Value;

		public bool TryGetAbilityIcon(out UnityEngine.Sprite value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIcon component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Sprite);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityIcon(UnityEngine.Sprite value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIcon() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID AbilityIDC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> AbilityID => AbilityIDC.Value;

		public bool TryGetAbilityID(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.String>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityID()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.String>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityID(RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityID() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent AbilityIncreaseDamagePercentC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> AbilityIncreaseDamagePercent => AbilityIncreaseDamagePercentC.Value;

		public bool TryGetAbilityIncreaseDamagePercent(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityIncreaseDamagePercent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityIncreaseDamagePercent(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityIncreaseDamagePercent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel AbilityMaxLevelC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> AbilityMaxLevel => AbilityMaxLevelC.Value;

		public bool TryGetAbilityMaxLevel(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityMaxLevel()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityMaxLevel(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityMaxLevel() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName AbilityNameC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> AbilityName => AbilityNameC.Value;

		public bool TryGetAbilityName(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.String>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityName()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.String>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityName(RoguelikeTD.Core.Reactive.ReactiveVariable<System.String> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityName() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest AbilityOnAddActivatorRequestC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent AbilityOnAddActivatorRequest => AbilityOnAddActivatorRequestC.Value;

		public bool TryGetAbilityOnAddActivatorRequest(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityOnAddActivatorRequest()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityOnAddActivatorRequest(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOnAddActivatorRequest() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOperation AbilityOperationC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOperation>();

		public System.Func<System.Single, System.Single> AbilityOperation => AbilityOperationC.Value;

		public bool TryGetAbilityOperation(out System.Func<System.Single, System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOperation component);
			if(result)
				value = component.Value;
			else
				value = default(System.Func<System.Single, System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityOperation(System.Func<System.Single, System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOperation() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner AbilityOwnerC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> AbilityOwner => AbilityOwnerC.Value;

		public bool TryGetAbilityOwner(out RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityOwner()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityOwner(RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityOwner() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest AbilityPerWaveActivatorRequestC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent AbilityPerWaveActivatorRequest => AbilityPerWaveActivatorRequestC.Value;

		public bool TryGetAbilityPerWaveActivatorRequest(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityPerWaveActivatorRequest()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityPerWaveActivatorRequest(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPerWaveActivatorRequest() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice AbilityPriceC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> AbilityPrice => AbilityPriceC.Value;

		public bool TryGetAbilityPrice(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityPrice()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityPrice(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityPrice() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityShotDirectionsByLevel AbilityShotDirectionsByLevelC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityShotDirectionsByLevel>();

		public System.Func<System.Int32, System.Collections.Generic.List<RoguelikeTD.Configs.Gameplay.Abilities.DirectionShotConfig>> AbilityShotDirectionsByLevel => AbilityShotDirectionsByLevelC.Value;

		public bool TryGetAbilityShotDirectionsByLevel(out System.Func<System.Int32, System.Collections.Generic.List<RoguelikeTD.Configs.Gameplay.Abilities.DirectionShotConfig>> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityShotDirectionsByLevel component);
			if(result)
				value = component.Value;
			else
				value = default(System.Func<System.Int32, System.Collections.Generic.List<RoguelikeTD.Configs.Gameplay.Abilities.DirectionShotConfig>>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityShotDirectionsByLevel(System.Func<System.Int32, System.Collections.Generic.List<RoguelikeTD.Configs.Gameplay.Abilities.DirectionShotConfig>> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityShotDirectionsByLevel() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue AbilityStatChangeValueC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AbilityStatChangeValue => AbilityStatChangeValueC.Value;

		public bool TryGetAbilityStatChangeValue(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityStatChangeValue()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityStatChangeValue(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatChangeValue() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatType AbilityStatTypeC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatType>();

		public RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes AbilityStatType => AbilityStatTypeC.Value;

		public bool TryGetAbilityStatType(out RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatType component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityStatType(RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityStatType() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent AbilityTakeDamagePercentC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> AbilityTakeDamagePercent => AbilityTakeDamagePercentC.Value;

		public bool TryGetAbilityTakeDamagePercent(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityTakeDamagePercent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAbilityTakeDamagePercent(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.AbilityTakeDamagePercent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbility IsAbilityC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbility>();

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAbility()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbility() );
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop IsAbilityAvailableToDropC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsAbilityAvailableToDrop => IsAbilityAvailableToDropC.Value;

		public bool TryGetIsAbilityAvailableToDrop(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAbilityAvailableToDrop()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAbilityAvailableToDrop(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityAvailableToDrop() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable IsAbilityUpgradableC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsAbilityUpgradable => IsAbilityUpgradableC.Value;

		public bool TryGetIsAbilityUpgradable(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAbilityUpgradable()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAbilityUpgradable(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUpgradable() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed IsAbilityUsedC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsAbilityUsed => IsAbilityUsedC.Value;

		public bool TryGetIsAbilityUsed(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAbilityUsed()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAbilityUsed(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsAbilityUsed() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsOnAddAbility IsOnAddAbilityC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsOnAddAbility>();

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsOnAddAbility()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsOnAddAbility() );
		}

		public RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsPerWaveAbility IsPerWaveAbilityC => GetComponent<RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsPerWaveAbility>();

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsPerWaveAbility()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS.IsPerWaveAbility() );
		}

		public RoguelikeTD.Gameplay.Features.AI.CurrentTarget CurrentTargetC => GetComponent<RoguelikeTD.Gameplay.Features.AI.CurrentTarget>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.AI.CurrentTarget component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AI.CurrentTarget() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCurrentTarget(RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.AI.CurrentTarget() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Allies.IsTower IsTowerC => GetComponent<RoguelikeTD.Gameplay.Features.Allies.IsTower>();

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsTower()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Allies.IsTower() );
		}

		public RoguelikeTD.Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<RoguelikeTD.Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public bool TryGetCanApplyDamage(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.ApplyDamage.CanApplyDamage component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCanApplyDamage(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.ApplyDamage.CanApplyDamage() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public bool TryGetTakeDamageEvent(out RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageEvent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public bool TryGetTakeDamageRequest(out RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageRequest component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(RoguelikeTD.Core.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackEvent AOEAttackEventC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackEvent>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent AOEAttackEvent => AOEAttackEventC.Value;

		public bool TryGetAOEAttackEvent(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEAttackEvent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackEvent() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEAttackEvent(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackEvent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackRequest AOEAttackRequestC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackRequest>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEInfoStruct> AOEAttackRequest => AOEAttackRequestC.Value;

		public bool TryGetAOEAttackRequest(out RoguelikeTD.Core.Reactive.ReactiveEvent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEInfoStruct> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackRequest component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEInfoStruct>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEAttackRequest()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackRequest() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEInfoStruct>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEAttackRequest(RoguelikeTD.Core.Reactive.ReactiveEvent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEInfoStruct> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackRequest() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint AOEAttackTargetPointC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> AOEAttackTargetPoint => AOEAttackTargetPointC.Value;

		public bool TryGetAOEAttackTargetPoint(out RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEAttackTargetPoint()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEAttackTargetPoint(RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEAttackTargetPoint() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOECollidersBuffer AOECollidersBufferC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOECollidersBuffer>();

		public RoguelikeTD.Core.Buffer<UnityEngine.Collider> AOECollidersBuffer => AOECollidersBufferC.Value;

		public bool TryGetAOECollidersBuffer(out RoguelikeTD.Core.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOECollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Buffer<UnityEngine.Collider>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOECollidersBuffer(RoguelikeTD.Core.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOECollidersBuffer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDamage AOEDamageC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDamage>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AOEDamage => AOEDamageC.Value;

		public bool TryGetAOEDamage(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDamage component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEDamage()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDamage() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEDamage(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDamage() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage AOEDelayBeforeTakeDamageC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AOEDelayBeforeTakeDamage => AOEDelayBeforeTakeDamageC.Value;

		public bool TryGetAOEDelayBeforeTakeDamage(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEDelayBeforeTakeDamage()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEDelayBeforeTakeDamage(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayBeforeTakeDamage() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer AOEDelayCurrentTimerC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AOEDelayCurrentTimer => AOEDelayCurrentTimerC.Value;

		public bool TryGetAOEDelayCurrentTimer(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEDelayCurrentTimer()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEDelayCurrentTimer(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEDelayCurrentTimer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOEEntitiesBuffer AOEEntitiesBufferC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOEEntitiesBuffer>();

		public RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> AOEEntitiesBuffer => AOEEntitiesBufferC.Value;

		public bool TryGetAOEEntitiesBuffer(out RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOEEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOEEntitiesBuffer(RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOEEntitiesBuffer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOERadius AOERadiusC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOERadius>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AOERadius => AOERadiusC.Value;

		public bool TryGetAOERadius(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOERadius component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOERadius()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOERadius() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOERadius(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOERadius() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.AOETakeDamageMask AOETakeDamageMaskC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.AOETakeDamageMask>();

		public UnityEngine.LayerMask AOETakeDamageMask => AOETakeDamageMaskC.Value;

		public bool TryGetAOETakeDamageMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.AOETakeDamageMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAOETakeDamageMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.AOETakeDamageMask() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AOE.IsAOEAttackEnded IsAOEAttackEndedC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AOE.IsAOEAttackEnded>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsAOEAttackEnded => IsAOEAttackEndedC.Value;

		public bool TryGetIsAOEAttackEnded(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AOE.IsAOEAttackEnded component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAOEAttackEnded()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.IsAOEAttackEnded() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsAOEAttackEnded(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AOE.IsAOEAttackEnded() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackCancelEvent AttackCancelEventC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackCancelEvent>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent AttackCancelEvent => AttackCancelEventC.Value;

		public bool TryGetAttackCancelEvent(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackCancelEvent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackCancelEvent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackCancelEvent() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackCancelEvent(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackCancelEvent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackCooldownCurrentTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public bool TryGetAttackCooldownCurrentTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackCooldownCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public bool TryGetAttackCooldownInitialTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackCooldownInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackCooldownModifiedTime AttackCooldownModifiedTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackCooldownModifiedTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackCooldownModifiedTime => AttackCooldownModifiedTimeC.Value;

		public bool TryGetAttackCooldownModifiedTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackCooldownModifiedTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackCooldownModifiedTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackCooldownModifiedTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackCooldownModifiedTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackCooldownModifiedTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackDelayEndEvent>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetAttackDelayEndEvent(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackDelayEndEvent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackDelayModifiedTime AttackDelayModifiedTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackDelayModifiedTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackDelayModifiedTime => AttackDelayModifiedTimeC.Value;

		public bool TryGetAttackDelayModifiedTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackDelayModifiedTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackDelayModifiedTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackDelayModifiedTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackDelayModifiedTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackDelayModifiedTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackDelayTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetAttackDelayTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackDelayTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackDelayTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackDelayTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackDelayTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackProcessCurrentTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackProcessInitialTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackProcessInitialTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackProcessModifiedTime AttackProcessModifiedTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackProcessModifiedTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackProcessModifiedTime => AttackProcessModifiedTimeC.Value;

		public bool TryGetAttackProcessModifiedTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackProcessModifiedTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackProcessModifiedTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackProcessModifiedTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackProcessModifiedTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackProcessModifiedTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.AttackRange AttackRangeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.AttackRange>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttackRange => AttackRangeC.Value;

		public bool TryGetAttackRange(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.AttackRange component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackRange()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackRange() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttackRange(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.AttackRange() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.CanStartAttack>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetCanStartAttack(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.CanStartAttack component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCanStartAttack(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.CanStartAttack() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.EndAttackEvent>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.EndAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.EndAttackEvent() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddEndAttackEvent(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.EndAttackEvent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.InAttackCooldown>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public bool TryGetInAttackCooldown(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.InAttackCooldown component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.InAttackCooldown() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInAttackCooldown(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.InAttackCooldown() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.InAttackProcess>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public bool TryGetInAttackProcess(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.InAttackProcess component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.InAttackProcess() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInAttackProcess(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.InAttackProcess() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.InstantAttackDamage>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public bool TryGetInstantAttackDamage(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.InstantAttackDamage component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.InstantAttackDamage() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.InstantAttackDamage() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.InstantShootingDirections InstantShootingDirectionsC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.InstantShootingDirections>();

		public RoguelikeTD.Gameplay.Features.Attack.Shoot.InstantShootingDirectionArgs InstantShootingDirections => InstantShootingDirectionsC.Value;

		public bool TryGetInstantShootingDirections(out RoguelikeTD.Gameplay.Features.Attack.Shoot.InstantShootingDirectionArgs value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.InstantShootingDirections component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Gameplay.Features.Attack.Shoot.InstantShootingDirectionArgs);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInstantShootingDirections(RoguelikeTD.Gameplay.Features.Attack.Shoot.InstantShootingDirectionArgs value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.InstantShootingDirections() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.IsMinDistanceToAttack IsMinDistanceToAttackC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.IsMinDistanceToAttack>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsMinDistanceToAttack => IsMinDistanceToAttackC.Value;

		public bool TryGetIsMinDistanceToAttack(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.IsMinDistanceToAttack component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsMinDistanceToAttack()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.IsMinDistanceToAttack() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsMinDistanceToAttack(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.IsMinDistanceToAttack() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.IsProjectile IsProjectileC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.IsProjectile>();

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsProjectile()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.IsProjectile() );
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.CanMining CanMiningC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.CanMining>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition CanMining => CanMiningC.Value;

		public bool TryGetCanMining(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.CanMining component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCanMining(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.CanMining() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.MineCollidersBuffer MineCollidersBufferC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.MineCollidersBuffer>();

		public RoguelikeTD.Core.Buffer<UnityEngine.Collider> MineCollidersBuffer => MineCollidersBufferC.Value;

		public bool TryGetMineCollidersBuffer(out RoguelikeTD.Core.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.MineCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Buffer<UnityEngine.Collider>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineCollidersBuffer(RoguelikeTD.Core.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineCollidersBuffer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.MineDamage MineDamageC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.MineDamage>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> MineDamage => MineDamageC.Value;

		public bool TryGetMineDamage(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.MineDamage component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineDamage()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineDamage() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineDamage(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineDamage() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.MineEntitiesBuffer MineEntitiesBufferC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.MineEntitiesBuffer>();

		public RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> MineEntitiesBuffer => MineEntitiesBufferC.Value;

		public bool TryGetMineEntitiesBuffer(out RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.MineEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineEntitiesBuffer(RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineEntitiesBuffer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsEnoughGold MineIsEnoughGoldC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsEnoughGold>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> MineIsEnoughGold => MineIsEnoughGoldC.Value;

		public bool TryGetMineIsEnoughGold(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsEnoughGold component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineIsEnoughGold()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsEnoughGold() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineIsEnoughGold(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsEnoughGold() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsExploded MineIsExplodedC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsExploded>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> MineIsExploded => MineIsExplodedC.Value;

		public bool TryGetMineIsExploded(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsExploded component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineIsExploded()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsExploded() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineIsExploded(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsExploded() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsPlaced MineIsPlacedC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsPlaced>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> MineIsPlaced => MineIsPlacedC.Value;

		public bool TryGetMineIsPlaced(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsPlaced component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineIsPlaced()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsPlaced() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineIsPlaced(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineIsPlaced() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.MineTakeDamageMask MineTakeDamageMaskC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.MineTakeDamageMask>();

		public UnityEngine.LayerMask MineTakeDamageMask => MineTakeDamageMaskC.Value;

		public bool TryGetMineTakeDamageMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.MineTakeDamageMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineTakeDamageMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineTakeDamageMask() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.Mining.MineTriggerRadius MineTriggerRadiusC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.Mining.MineTriggerRadius>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> MineTriggerRadius => MineTriggerRadiusC.Value;

		public bool TryGetMineTriggerRadius(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.Mining.MineTriggerRadius component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineTriggerRadius()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineTriggerRadius() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMineTriggerRadius(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.Mining.MineTriggerRadius() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.MustCancelAttack>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public bool TryGetMustCancelAttack(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.MustCancelAttack component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMustCancelAttack(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.MustCancelAttack() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.ShootingMinDistance ShootingMinDistanceC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.ShootingMinDistance>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> ShootingMinDistance => ShootingMinDistanceC.Value;

		public bool TryGetShootingMinDistance(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.ShootingMinDistance component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddShootingMinDistance()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.ShootingMinDistance() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddShootingMinDistance(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.ShootingMinDistance() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.ShootPoint ShootPointC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.ShootPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.ShootPoint() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.StartAttackEvent>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetStartAttackEvent(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.StartAttackEvent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.StartAttackEvent() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddStartAttackEvent(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.StartAttackEvent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.StartAttackRequest>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetStartAttackRequest(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.StartAttackRequest component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.StartAttackRequest() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddStartAttackRequest(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.StartAttackRequest() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCollidersBuffer TickableCollidersBufferC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCollidersBuffer>();

		public RoguelikeTD.Core.Buffer<UnityEngine.Collider> TickableCollidersBuffer => TickableCollidersBufferC.Value;

		public bool TryGetTickableCollidersBuffer(out RoguelikeTD.Core.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Buffer<UnityEngine.Collider>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableCollidersBuffer(RoguelikeTD.Core.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCollidersBuffer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime TickableCurrentTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> TickableCurrentTime => TickableCurrentTimeC.Value;

		public bool TryGetTickableCurrentTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableCurrentTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableCurrentTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableCurrentTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableDamage TickableDamageC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableDamage>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> TickableDamage => TickableDamageC.Value;

		public bool TryGetTickableDamage(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableDamage component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableDamage()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableDamage() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableDamage(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableDamage() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableEntitiesBuffer TickableEntitiesBufferC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableEntitiesBuffer>();

		public RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> TickableEntitiesBuffer => TickableEntitiesBufferC.Value;

		public bool TryGetTickableEntitiesBuffer(out RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableEntitiesBuffer(RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableEntitiesBuffer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableInitialTime TickableInitialTimeC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableInitialTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> TickableInitialTime => TickableInitialTimeC.Value;

		public bool TryGetTickableInitialTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableInitialTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableInitialTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableInitialTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableInitialTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableRadius TickableRadiusC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableRadius>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> TickableRadius => TickableRadiusC.Value;

		public bool TryGetTickableRadius(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableRadius component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableRadius()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableRadius() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableRadius(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableRadius() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableTakeDamageMask TickableTakeDamageMaskC => GetComponent<RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableTakeDamageMask>();

		public UnityEngine.LayerMask TickableTakeDamageMask => TickableTakeDamageMaskC.Value;

		public bool TryGetTickableTakeDamageMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableTakeDamageMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTickableTakeDamageMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Attack.TickableDamage.TickableTakeDamageMask() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.BounceFeature.BounceCount BounceCountC => GetComponent<RoguelikeTD.Gameplay.Features.BounceFeature.BounceCount>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> BounceCount => BounceCountC.Value;

		public bool TryGetBounceCount(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.BounceFeature.BounceCount component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBounceCount()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.BounceFeature.BounceCount() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBounceCount(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.BounceFeature.BounceCount() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.BounceFeature.BounceEvent BounceEventC => GetComponent<RoguelikeTD.Gameplay.Features.BounceFeature.BounceEvent>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent<UnityEngine.RaycastHit> BounceEvent => BounceEventC.Value;

		public bool TryGetBounceEvent(out RoguelikeTD.Core.Reactive.ReactiveEvent<UnityEngine.RaycastHit> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.BounceFeature.BounceEvent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent<UnityEngine.RaycastHit>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBounceEvent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.BounceFeature.BounceEvent() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent<UnityEngine.RaycastHit>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBounceEvent(RoguelikeTD.Core.Reactive.ReactiveEvent<UnityEngine.RaycastHit> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.BounceFeature.BounceEvent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.BounceFeature.LayerToBounceReaction LayerToBounceReactionC => GetComponent<RoguelikeTD.Gameplay.Features.BounceFeature.LayerToBounceReaction>();

		public UnityEngine.LayerMask LayerToBounceReaction => LayerToBounceReactionC.Value;

		public bool TryGetLayerToBounceReaction(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.BounceFeature.LayerToBounceReaction component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddLayerToBounceReaction(UnityEngine.LayerMask value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.BounceFeature.LayerToBounceReaction() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<RoguelikeTD.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetBodyContactDamage(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.ContactTakeDamage.BodyContactDamage component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBodyContactDamage(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest InputFindMouseClickPositionRequestC => GetComponent<RoguelikeTD.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent InputFindMouseClickPositionRequest => InputFindMouseClickPositionRequestC.Value;

		public bool TryGetInputFindMouseClickPositionRequest(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInputFindMouseClickPositionRequest()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInputFindMouseClickPositionRequest(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.InputFeature.InputFindMouseClickPositionRequest() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.InputFeature.InputIsPositionFound InputIsPositionFoundC => GetComponent<RoguelikeTD.Gameplay.Features.InputFeature.InputIsPositionFound>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> InputIsPositionFound => InputIsPositionFoundC.Value;

		public bool TryGetInputIsPositionFound(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.InputFeature.InputIsPositionFound component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInputIsPositionFound()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.InputFeature.InputIsPositionFound() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInputIsPositionFound(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.InputFeature.InputIsPositionFound() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickGroundPosition InputMouseClickGroundPositionC => GetComponent<RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickGroundPosition>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> InputMouseClickGroundPosition => InputMouseClickGroundPositionC.Value;

		public bool TryGetInputMouseClickGroundPosition(out RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickGroundPosition component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInputMouseClickGroundPosition()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickGroundPosition() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInputMouseClickGroundPosition(RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickGroundPosition() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickPositionFoundEvent InputMouseClickPositionFoundEventC => GetComponent<RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickPositionFoundEvent>();

		public RoguelikeTD.Core.Reactive.ReactiveEvent InputMouseClickPositionFoundEvent => InputMouseClickPositionFoundEventC.Value;

		public bool TryGetInputMouseClickPositionFoundEvent(out RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickPositionFoundEvent component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveEvent);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInputMouseClickPositionFoundEvent()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickPositionFoundEvent() {Value = new RoguelikeTD.Core.Reactive.ReactiveEvent() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInputMouseClickPositionFoundEvent(RoguelikeTD.Core.Reactive.ReactiveEvent value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.InputFeature.InputMouseClickPositionFoundEvent() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LevelUpFeature.Experience ExperienceC => GetComponent<RoguelikeTD.Gameplay.Features.LevelUpFeature.Experience>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> Experience => ExperienceC.Value;

		public bool TryGetExperience(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LevelUpFeature.Experience component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddExperience()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LevelUpFeature.Experience() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddExperience(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LevelUpFeature.Experience() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LevelUpFeature.Level LevelC => GetComponent<RoguelikeTD.Gameplay.Features.LevelUpFeature.Level>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> Level => LevelC.Value;

		public bool TryGetLevel(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LevelUpFeature.Level component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddLevel()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LevelUpFeature.Level() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddLevel(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LevelUpFeature.Level() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.CurrentHealth>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.CurrentHealth component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.CurrentHealth() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCurrentHealth(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public bool TryGetDeathProcessCurrentTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessInitialTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetDisableCollidersOnDeath(out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.DisableCollidersOnDeath component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = new System.Collections.Generic.List<UnityEngine.Collider>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.HealthBarPoint HealthBarPointC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.HealthBarPoint>();

		public UnityEngine.Transform HealthBarPoint => HealthBarPointC.Value;

		public bool TryGetHealthBarPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.HealthBarPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddHealthBarPoint(UnityEngine.Transform value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.HealthBarPoint() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.InDeathProcess InDeathProcessC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.InDeathProcess>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public bool TryGetInDeathProcess(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.InDeathProcess component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.InDeathProcess() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInDeathProcess(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.InDeathProcess() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.IsDead>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public bool TryGetIsDead(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.IsDead component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.IsDead() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsDead(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.IsDead() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.MaxHealth>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public bool TryGetMaxHealth(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.MaxHealth component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.MaxHealth() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMaxHealth(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.MaxHealth() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.MustDie>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public bool TryGetMustDie(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.MustDie component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMustDie(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.MustDie() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<RoguelikeTD.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LifeCycle.MustSelfRelease component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMustSelfRelease(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LootFeature.CanDropLoot CanDropLootC => GetComponent<RoguelikeTD.Gameplay.Features.LootFeature.CanDropLoot>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition CanDropLoot => CanDropLootC.Value;

		public bool TryGetCanDropLoot(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LootFeature.CanDropLoot component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCanDropLoot(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.CanDropLoot() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LootFeature.Coins CoinsC => GetComponent<RoguelikeTD.Gameplay.Features.LootFeature.Coins>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> Coins => CoinsC.Value;

		public bool TryGetCoins(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LootFeature.Coins component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCoins()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.Coins() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCoins(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.Coins() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LootFeature.InPullingProcess InPullingProcessC => GetComponent<RoguelikeTD.Gameplay.Features.LootFeature.InPullingProcess>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> InPullingProcess => InPullingProcessC.Value;

		public bool TryGetInPullingProcess(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LootFeature.InPullingProcess component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInPullingProcess()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.InPullingProcess() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInPullingProcess(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.InPullingProcess() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LootFeature.IsCollected IsCollectedC => GetComponent<RoguelikeTD.Gameplay.Features.LootFeature.IsCollected>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsCollected => IsCollectedC.Value;

		public bool TryGetIsCollected(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LootFeature.IsCollected component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsCollected()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.IsCollected() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsCollected(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.IsCollected() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.LootFeature.IsPullable IsPullableC => GetComponent<RoguelikeTD.Gameplay.Features.LootFeature.IsPullable>();

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsPullable()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.IsPullable() );
		}

		public RoguelikeTD.Gameplay.Features.LootFeature.LootIsDropped LootIsDroppedC => GetComponent<RoguelikeTD.Gameplay.Features.LootFeature.LootIsDropped>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> LootIsDropped => LootIsDroppedC.Value;

		public bool TryGetLootIsDropped(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.LootFeature.LootIsDropped component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddLootIsDropped()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.LootIsDropped() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddLootIsDropped(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.LootFeature.LootIsDropped() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.MainHero.IsMainHero IsMainHeroC => GetComponent<RoguelikeTD.Gameplay.Features.MainHero.IsMainHero>();

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsMainHero()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MainHero.IsMainHero() );
		}

		public RoguelikeTD.Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<RoguelikeTD.Gameplay.Features.MovementFeature.CanMove>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.MovementFeature.CanMove component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCanMove(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.CanMove() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.MovementFeature.CanRotate CanRotateC => GetComponent<RoguelikeTD.Gameplay.Features.MovementFeature.CanRotate>();

		public RoguelikeTD.Core.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.MovementFeature.CanRotate component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Conditions.ICompositeCondition);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddCanRotate(RoguelikeTD.Core.Conditions.ICompositeCondition value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.CanRotate() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.MovementFeature.IsMoving IsMovingC => GetComponent<RoguelikeTD.Gameplay.Features.MovementFeature.IsMoving>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.MovementFeature.IsMoving component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.IsMoving() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsMoving(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.IsMoving() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<RoguelikeTD.Gameplay.Features.MovementFeature.MoveDirection>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.MovementFeature.MoveDirection component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.MoveDirection() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMoveDirection(RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.MoveDirection() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<RoguelikeTD.Gameplay.Features.MovementFeature.MoveSpeed>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetMoveSpeed(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.MovementFeature.MoveSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.MoveSpeed() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddMoveSpeed(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.MoveSpeed() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.MovementFeature.RotationDirection RotationDirectionC => GetComponent<RoguelikeTD.Gameplay.Features.MovementFeature.RotationDirection>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection(out RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.MovementFeature.RotationDirection component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.RotationDirection() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddRotationDirection(RoguelikeTD.Core.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.RotationDirection() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.MovementFeature.RotationSpeed RotationSpeedC => GetComponent<RoguelikeTD.Gameplay.Features.MovementFeature.RotationSpeed>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public bool TryGetRotationSpeed(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.MovementFeature.RotationSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.RotationSpeed() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddRotationSpeed(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.MovementFeature.RotationSpeed() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney PlaceableIsEnoughMoneyC => GetComponent<RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> PlaceableIsEnoughMoney => PlaceableIsEnoughMoneyC.Value;

		public bool TryGetPlaceableIsEnoughMoney(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddPlaceableIsEnoughMoney()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddPlaceableIsEnoughMoney(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsEnoughMoney() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced PlaceableIsPlacedC => GetComponent<RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> PlaceableIsPlaced => PlaceableIsPlacedC.Value;

		public bool TryGetPlaceableIsPlaced(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddPlaceableIsPlaced()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddPlaceableIsPlaced(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableIsPlaced() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableToRelease PlaceableToReleaseC => GetComponent<RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableToRelease>();

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddPlaceableToRelease()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.PlaceableFeature.PlaceableToRelease() );
		}

		public RoguelikeTD.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<RoguelikeTD.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Sensors.BodyCollider component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CapsuleCollider);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.BodyCollider() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<RoguelikeTD.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public RoguelikeTD.Core.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public bool TryGetContactCollidersBuffer(out RoguelikeTD.Core.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Sensors.ContactCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Buffer<UnityEngine.Collider>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(RoguelikeTD.Core.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<RoguelikeTD.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetContactEntitiesBuffer(out RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Sensors.ContactEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(RoguelikeTD.Core.Buffer<RoguelikeTD.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<RoguelikeTD.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Sensors.ContactsDetectingMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Sensors.DeathMask DeathMaskC => GetComponent<RoguelikeTD.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Sensors.DeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.DeathMask() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Sensors.IsTouchAnotherTeam IsTouchAnotherTeamC => GetComponent<RoguelikeTD.Gameplay.Features.Sensors.IsTouchAnotherTeam>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsTouchAnotherTeam => IsTouchAnotherTeamC.Value;

		public bool TryGetIsTouchAnotherTeam(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Sensors.IsTouchAnotherTeam component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.IsTouchAnotherTeam() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.IsTouchAnotherTeam() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<RoguelikeTD.Gameplay.Features.Sensors.IsTouchDeathMask>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.Sensors.IsTouchDeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.SpawnFeature.InSpawnProcess InSpawnProcessC => GetComponent<RoguelikeTD.Gameplay.Features.SpawnFeature.InSpawnProcess>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> InSpawnProcess => InSpawnProcessC.Value;

		public bool TryGetInSpawnProcess(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.SpawnFeature.InSpawnProcess component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInSpawnProcess()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.SpawnFeature.InSpawnProcess() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddInSpawnProcess(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.SpawnFeature.InSpawnProcess() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnCurrentTime SpawnCurrentTimeC => GetComponent<RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnCurrentTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> SpawnCurrentTime => SpawnCurrentTimeC.Value;

		public bool TryGetSpawnCurrentTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddSpawnCurrentTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnCurrentTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddSpawnCurrentTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnCurrentTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnInitialTime SpawnInitialTimeC => GetComponent<RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnInitialTime>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> SpawnInitialTime => SpawnInitialTimeC.Value;

		public bool TryGetSpawnInitialTime(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddSpawnInitialTime()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnInitialTime() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddSpawnInitialTime(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.SpawnFeature.SpawnInitialTime() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.StatsFeature.AttacksPerSecond AttacksPerSecondC => GetComponent<RoguelikeTD.Gameplay.Features.StatsFeature.AttacksPerSecond>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> AttacksPerSecond => AttacksPerSecondC.Value;

		public bool TryGetAttacksPerSecond(out RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.StatsFeature.AttacksPerSecond component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttacksPerSecond()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.StatsFeature.AttacksPerSecond() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddAttacksPerSecond(RoguelikeTD.Core.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.StatsFeature.AttacksPerSecond() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.StatsFeature.BaseStats BaseStatsC => GetComponent<RoguelikeTD.Gameplay.Features.StatsFeature.BaseStats>();

		public System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single> BaseStats => BaseStatsC.Value;

		public bool TryGetBaseStats(out System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.StatsFeature.BaseStats component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBaseStats()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.StatsFeature.BaseStats() {Value = new System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddBaseStats(System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.StatsFeature.BaseStats() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.StatsFeature.ModifiesStats ModifiesStatsC => GetComponent<RoguelikeTD.Gameplay.Features.StatsFeature.ModifiesStats>();

		public System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single> ModifiesStats => ModifiesStatsC.Value;

		public bool TryGetModifiesStats(out System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.StatsFeature.ModifiesStats component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddModifiesStats()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.StatsFeature.ModifiesStats() {Value = new System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddModifiesStats(System.Collections.Generic.Dictionary<RoguelikeTD.Gameplay.Features.StatsFeature.StatTypes, System.Single> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.StatsFeature.ModifiesStats() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffects StatsEffectsC => GetComponent<RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffects>();

		public RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffectsList StatsEffects => StatsEffectsC.Value;

		public bool TryGetStatsEffects(out RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffectsList value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffects component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffectsList);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddStatsEffects()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffects() {Value = new RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffectsList() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddStatsEffects(RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffectsList value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.StatsFeature.StatsEffects() {Value = value});
		}

		public RoguelikeTD.Gameplay.Features.TeamsFeature.Team TeamC => GetComponent<RoguelikeTD.Gameplay.Features.TeamsFeature.Team>();

		public RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.Features.TeamsFeature.Teams> Team => TeamC.Value;

		public bool TryGetTeam(out RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.Features.TeamsFeature.Teams> value)
		{
			bool result = TryGetComponent(out RoguelikeTD.Gameplay.Features.TeamsFeature.Team component);
			if(result)
				value = component.Value;
			else
				value = default(RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.Features.TeamsFeature.Teams>);
			return result;
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTeam()
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.TeamsFeature.Team() {Value = new RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.Features.TeamsFeature.Teams>() });
		}

		public RoguelikeTD.Gameplay.EntitiesCore.Entity AddTeam(RoguelikeTD.Core.Reactive.ReactiveVariable<RoguelikeTD.Gameplay.Features.TeamsFeature.Teams> value)
		{
			return AddComponent(new RoguelikeTD.Gameplay.Features.TeamsFeature.Team() {Value = value});
		}

	}
}
