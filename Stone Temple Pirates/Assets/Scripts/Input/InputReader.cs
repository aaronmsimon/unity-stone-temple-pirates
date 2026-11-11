using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace STP.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, InputActions.ITempleActions
    {
        // Temple
        public event UnityAction<float> moveCharacterEvent;
        public event UnityAction<bool> stonePowerActivatedEvent;

        private InputActions inputActions;

        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new InputActions();
                inputActions.Temple.SetCallbacks(this);
            }

            EnableTempleInput();
        }

        private void OnDisable()
        {
            DisableAllInput();
        }

        // Temple

        public void OnMoveCharacter(InputAction.CallbackContext context)
        {
        	if (moveCharacterEvent != null)
        	{
        		moveCharacterEvent?.Invoke(context.ReadValue<float>());
        	}
        }

        public void OnActivateStonePower(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
                stonePowerActivatedEvent?.Invoke(true);
            if (context.phase == InputActionPhase.Canceled)
                stonePowerActivatedEvent?.Invoke(false);
        }

        // Enable/Disable

        public void EnableTempleInput()
        {
            inputActions.Temple.Enable();
        }

        public void DisableAllInput()
        {
            inputActions.Temple.Disable();
        }
    }
}
