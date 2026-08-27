using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace STP.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, InputActions.IGameplayActions, InputActions.ITempleActions
    {
        // Gameplay
        public event UnityAction<Vector2> mouseMoveEvent;
        public event UnityAction mouseClickEvent;
        public event UnityAction fireEvent;
        public event UnityAction toggleDoorsEvent;

        // Temple
        public event UnityAction<float> moveEvent;

        private InputActions inputActions;

        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new InputActions();
                inputActions.Gameplay.SetCallbacks(this);
                inputActions.Temple.SetCallbacks(this);
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

        public void OnToggleDoors(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                toggleDoorsEvent?.Invoke();
        }

        // Temple

        public void OnMoveCharacter(InputAction.CallbackContext context)
        {
        	if (moveEvent != null)
        	{
        		moveEvent?.Invoke(context.ReadValue<float>());
        	}
        }

        // Enable/Disable

        public void EnableGameplayInput()
        {
            inputActions.Gameplay.Enable();
            inputActions.Temple.Disable();
        }

        public void EnableTempleInput()
        {
            inputActions.Temple.Enable();
            inputActions.Gameplay.Disable();
        }

        public void DisableAllInput()
        {
            inputActions.Gameplay.Disable();
            inputActions.Temple.Disable();
        }
    }
}
