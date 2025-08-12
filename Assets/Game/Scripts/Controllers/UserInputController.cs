using System;
using Game.Scripts.Domain.MessageDTO;
using MessagePipe;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Controllers
{
    public class UserInputController : IInitializable, IDisposable
    {
        [Inject] private readonly PlayerInput _playerInput;
        [Inject] private readonly IPublisher<UserInputDTO> _publisher;

        void IInitializable.Initialize()
        {
            SubscribeToActions();
        }

        void IDisposable.Dispose()
        {
            UnsubscribeFromActions();
        }
        
         private void SubscribeToActions()
        {
            _playerInput.actions[InputGroup.Move.ToString()].performed += OnMovePressHandler;
            _playerInput.actions[InputGroup.Move.ToString()].canceled += OnMovePressHandler;

            _playerInput.actions[InputGroup.Attack.ToString()].started += OnAttackPressHandler;
            _playerInput.actions[InputGroup.Interact.ToString()].started += OnInteractPressHandler;
            _playerInput.actions[InputGroup.Crouch.ToString()].started += OnCrouchPressHandler;
            _playerInput.actions[InputGroup.Jump.ToString()].started += OnJumpPressHandler;
        }

        private void UnsubscribeFromActions()
        {
            _playerInput.actions[InputGroup.Move.ToString()].performed -= OnMovePressHandler;
            _playerInput.actions[InputGroup.Move.ToString()].canceled -= OnMovePressHandler;

            _playerInput.actions[InputGroup.Attack.ToString()].started -= OnAttackPressHandler;
            _playerInput.actions[InputGroup.Interact.ToString()].started -= OnInteractPressHandler;
            _playerInput.actions[InputGroup.Crouch.ToString()].started -= OnCrouchPressHandler;
            _playerInput.actions[InputGroup.Jump.ToString()].started -= OnJumpPressHandler;
        }

        private void OnMovePressHandler(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    _publisher.Publish(new UserInputDTO(InputGroup.Move, input));
                    break;
                case InputActionPhase.Canceled:
                    _publisher.Publish(new UserInputDTO(InputGroup.Move, Vector2.zero));
                    break;
            }
        }

        private void OnAttackPressHandler(InputAction.CallbackContext context)
        {
            _publisher.Publish(new UserInputDTO(InputGroup.Attack, Vector2.zero));
        }

        private void OnInteractPressHandler(InputAction.CallbackContext context)
        {
            _publisher.Publish(new UserInputDTO(InputGroup.Interact, Vector2.zero));
        }

        private void OnCrouchPressHandler(InputAction.CallbackContext context)
        {
            _publisher.Publish(new UserInputDTO(InputGroup.Crouch, Vector2.zero));
        }

        private void OnJumpPressHandler(InputAction.CallbackContext context)
        {
            _publisher.Publish(new UserInputDTO(InputGroup.Jump, Vector2.zero));
        }
    }
}

