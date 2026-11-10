using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace STP.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, InputActions.ITempleActions
    {
        // Temple
        public event UnityAction<float> moveEvent;

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
        	if (moveEvent != null)
        	{
        		moveEvent?.Invoke(context.ReadValue<float>());
        	}
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
