//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/PlayerController/Controller.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controller : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""a6c155e0-5b2d-4e2e-b6d1-2497041d5083"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""14f7f86e-ec66-49e5-9970-d3f9ad96be3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""79ecf05a-4916-4089-9719-9a50e0059744"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9b8e2ce6-2739-42fc-a06f-bb32a8fefd4c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b855d8e6-3d25-407a-8bce-9e71e3663d87"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c8fcfa9c-36c6-49cc-ac52-1c75189e94fb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9891e301-c823-4725-80f2-26cf63782c48"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ed1d72a-008e-4631-b810-bbc3b0a99be5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""24288e34-68c7-4fe8-9b6b-153c3a4e2a94"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Vampire"",
            ""id"": ""755b6d90-4ec6-4d04-ab51-8667f644e64a"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""37fe984a-fdef-49cd-a870-0f90d36ad387"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""386c8263-43da-4d41-b644-be20674417e8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Sheep"",
            ""id"": ""60dd2900-4de0-42cb-b597-627e9878d88b"",
            ""actions"": [
                {
                    ""name"": ""Eat"",
                    ""type"": ""Button"",
                    ""id"": ""7b00da9a-f783-404d-8718-c37f50ef70fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""72c12fd9-dfef-43a5-8ea7-0d9a81461696"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Eat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Cat"",
            ""id"": ""0c98e8c7-28cd-48d2-9563-a11d5f898a5c"",
            ""actions"": [
                {
                    ""name"": ""Scratch"",
                    ""type"": ""Button"",
                    ""id"": ""b387eb7f-6a5a-4213-a479-0b4e7cbb8512"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""12ead424-09e6-408a-879d-285a90a9c247"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scratch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Chicken"",
            ""id"": ""8f8eee1d-f98d-41ca-a98d-b76bec91d98e"",
            ""actions"": [
                {
                    ""name"": ""Fly"",
                    ""type"": ""Button"",
                    ""id"": ""532650ef-82e1-4828-93d2-0cc9dcef4669"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4dc3dad3-036a-46ee-8797-d8688267a8a8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_Movement = m_General.FindAction("Movement", throwIfNotFound: true);
        m_General_Jump = m_General.FindAction("Jump", throwIfNotFound: true);
        // Vampire
        m_Vampire = asset.FindActionMap("Vampire", throwIfNotFound: true);
        m_Vampire_Attack = m_Vampire.FindAction("Attack", throwIfNotFound: true);
        // Sheep
        m_Sheep = asset.FindActionMap("Sheep", throwIfNotFound: true);
        m_Sheep_Eat = m_Sheep.FindAction("Eat", throwIfNotFound: true);
        // Cat
        m_Cat = asset.FindActionMap("Cat", throwIfNotFound: true);
        m_Cat_Scratch = m_Cat.FindAction("Scratch", throwIfNotFound: true);
        // Chicken
        m_Chicken = asset.FindActionMap("Chicken", throwIfNotFound: true);
        m_Chicken_Fly = m_Chicken.FindAction("Fly", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_Movement;
    private readonly InputAction m_General_Jump;
    public struct GeneralActions
    {
        private @Controller m_Wrapper;
        public GeneralActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_General_Movement;
        public InputAction @Jump => m_Wrapper.m_General_Jump;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);

    // Vampire
    private readonly InputActionMap m_Vampire;
    private IVampireActions m_VampireActionsCallbackInterface;
    private readonly InputAction m_Vampire_Attack;
    public struct VampireActions
    {
        private @Controller m_Wrapper;
        public VampireActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Vampire_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Vampire; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VampireActions set) { return set.Get(); }
        public void SetCallbacks(IVampireActions instance)
        {
            if (m_Wrapper.m_VampireActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_VampireActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_VampireActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_VampireActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_VampireActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public VampireActions @Vampire => new VampireActions(this);

    // Sheep
    private readonly InputActionMap m_Sheep;
    private ISheepActions m_SheepActionsCallbackInterface;
    private readonly InputAction m_Sheep_Eat;
    public struct SheepActions
    {
        private @Controller m_Wrapper;
        public SheepActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Eat => m_Wrapper.m_Sheep_Eat;
        public InputActionMap Get() { return m_Wrapper.m_Sheep; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SheepActions set) { return set.Get(); }
        public void SetCallbacks(ISheepActions instance)
        {
            if (m_Wrapper.m_SheepActionsCallbackInterface != null)
            {
                @Eat.started -= m_Wrapper.m_SheepActionsCallbackInterface.OnEat;
                @Eat.performed -= m_Wrapper.m_SheepActionsCallbackInterface.OnEat;
                @Eat.canceled -= m_Wrapper.m_SheepActionsCallbackInterface.OnEat;
            }
            m_Wrapper.m_SheepActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Eat.started += instance.OnEat;
                @Eat.performed += instance.OnEat;
                @Eat.canceled += instance.OnEat;
            }
        }
    }
    public SheepActions @Sheep => new SheepActions(this);

    // Cat
    private readonly InputActionMap m_Cat;
    private ICatActions m_CatActionsCallbackInterface;
    private readonly InputAction m_Cat_Scratch;
    public struct CatActions
    {
        private @Controller m_Wrapper;
        public CatActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Scratch => m_Wrapper.m_Cat_Scratch;
        public InputActionMap Get() { return m_Wrapper.m_Cat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CatActions set) { return set.Get(); }
        public void SetCallbacks(ICatActions instance)
        {
            if (m_Wrapper.m_CatActionsCallbackInterface != null)
            {
                @Scratch.started -= m_Wrapper.m_CatActionsCallbackInterface.OnScratch;
                @Scratch.performed -= m_Wrapper.m_CatActionsCallbackInterface.OnScratch;
                @Scratch.canceled -= m_Wrapper.m_CatActionsCallbackInterface.OnScratch;
            }
            m_Wrapper.m_CatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Scratch.started += instance.OnScratch;
                @Scratch.performed += instance.OnScratch;
                @Scratch.canceled += instance.OnScratch;
            }
        }
    }
    public CatActions @Cat => new CatActions(this);

    // Chicken
    private readonly InputActionMap m_Chicken;
    private IChickenActions m_ChickenActionsCallbackInterface;
    private readonly InputAction m_Chicken_Fly;
    public struct ChickenActions
    {
        private @Controller m_Wrapper;
        public ChickenActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fly => m_Wrapper.m_Chicken_Fly;
        public InputActionMap Get() { return m_Wrapper.m_Chicken; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ChickenActions set) { return set.Get(); }
        public void SetCallbacks(IChickenActions instance)
        {
            if (m_Wrapper.m_ChickenActionsCallbackInterface != null)
            {
                @Fly.started -= m_Wrapper.m_ChickenActionsCallbackInterface.OnFly;
                @Fly.performed -= m_Wrapper.m_ChickenActionsCallbackInterface.OnFly;
                @Fly.canceled -= m_Wrapper.m_ChickenActionsCallbackInterface.OnFly;
            }
            m_Wrapper.m_ChickenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fly.started += instance.OnFly;
                @Fly.performed += instance.OnFly;
                @Fly.canceled += instance.OnFly;
            }
        }
    }
    public ChickenActions @Chicken => new ChickenActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IGeneralActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IVampireActions
    {
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface ISheepActions
    {
        void OnEat(InputAction.CallbackContext context);
    }
    public interface ICatActions
    {
        void OnScratch(InputAction.CallbackContext context);
    }
    public interface IChickenActions
    {
        void OnFly(InputAction.CallbackContext context);
    }
}
