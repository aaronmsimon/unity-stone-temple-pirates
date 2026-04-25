using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace STP.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, InputActions.IGameplayActions
    {
        // Gameplay
        public event UnityAction<Vector2> mouseMoveEvent;
        public event UnityAction mouseClickEvent;
        public event UnityAction fireEvent;

        private InputActions inputActions;

        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new InputActions();
                inputActions.Gameplay.SetCallbacks(this);
            }

            EnableGameplayInput();
        }

        private void OnDisable()
        {
            DisableAllInput();
        }

        // Gameplay

        public void OnMouseMove(InputAction.CallbackContext context)
        {
        	if (mouseMoveEvent != null)
        	{
        		mouseMoveEvent?.Invoke(context.ReadValue<Vector2>());
        	}
        }

        public void OnMouseClick(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                mouseClickEvent?.Invoke();
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                fireEvent?.Invoke();
        }

        // Enable/Disable

        public void EnableGameplayInput()
        {
            inputActions.Gameplay.Enable();
        }

        public void DisableAllInput()
        {
            inputActions.Gameplay.Disable();
        }
    }
}
