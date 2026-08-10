using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Wizard
{
    [CreateAssetMenu(menuName = "InputReader")]
    public class InputReader : ScriptableObject, PlayerMovement.IPlayerInputActions, PlayerMovement.IUIActions
    {
        private PlayerMovement _playerMovement;

        private void OnEnable()
        {
            if (_playerMovement == null)
            {
                _playerMovement = new PlayerMovement();
                _playerMovement.PlayerInput.SetCallbacks(instance:this);
                _playerMovement.UI.SetCallbacks(instance:this);

                SetGameplay();
            }
        }

        public void SetGameplay()
        {
            _playerMovement.PlayerInput.Enable();
            _playerMovement.UI.Disable();
        }

        public void SetUI()
        {
            _playerMovement.PlayerInput.Disable();
            _playerMovement.UI.Enable();
        }

        public event Action<Vector2> MoveEvent;
        public event Action JumpEvent;
        public event Action JumpCanceledEvent;
        public event Action PauseEvent;
        public event Action ResumeEvent;
        
        public void  OnMove(InputAction.CallbackContext context)
        {
            //Debug.Log(message:$"Phase{context.phase} Value:{context.ReadValue<Vector2>()}");
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                JumpEvent?.Invoke();
            }
            if (context.phase == InputActionPhase.Canceled)
            {
                JumpCanceledEvent?.Invoke();
            }
        }
        
        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PauseEvent?.Invoke();
                SetUI();
            }
        }
        public void OnRepause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ResumeEvent?.Invoke();
                SetGameplay();
            }
        }
    }
}


