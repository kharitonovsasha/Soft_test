using System;
using Game.Scripts.MessagePipe;
using MessagePipe;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Controllers
{
    public enum InputGroup
    {
        None = 0,
        Move, // WASD / левый стик
        Look, // мышь / правый стик
        Attack, // enter // west
        Interact, // E // north
        Crouch, // C // east
        Jump, // space // southc
    }
    
    public class UserInputController : IStartable, IDisposable
    {
        [Inject] private readonly PlayerInput _playerInput;
        private readonly IPublisher<UserInputEvent> _publisher;

        
        void IStartable.Start()
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

            _playerInput.actions[InputGroup.Look.ToString()].performed += OnLookPressHandler;
            _playerInput.actions[InputGroup.Look.ToString()].canceled += OnLookPressHandler;

            _playerInput.actions[InputGroup.Attack.ToString()].started += OnAttackPressHandler;
            _playerInput.actions[InputGroup.Interact.ToString()].started += OnInteractPressHandler;
            _playerInput.actions[InputGroup.Crouch.ToString()].started += OnCrouchPressHandler;
            _playerInput.actions[InputGroup.Jump.ToString()].started += OnJumpPressHandler;
        }

        private void UnsubscribeFromActions()
        {
            _playerInput.actions[InputGroup.Move.ToString()].performed -= OnMovePressHandler;
            _playerInput.actions[InputGroup.Move.ToString()].canceled -= OnMovePressHandler;

            _playerInput.actions[InputGroup.Look.ToString()].performed -= OnLookPressHandler;
            _playerInput.actions[InputGroup.Look.ToString()].canceled -= OnLookPressHandler;

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
                    _publisher.Publish(new UserInputEvent(InputGroup.Move, input));
                    break;
                case InputActionPhase.Canceled:
                    _publisher.Publish(new UserInputEvent(InputGroup.Move, Vector2.zero));
                    break;
            }
        }

        private void OnLookPressHandler(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    _publisher.Publish(new UserInputEvent(InputGroup.Look, input));
                    break;
                case InputActionPhase.Canceled:
                    _publisher.Publish(new UserInputEvent(InputGroup.Look, Vector2.zero));
                    break;
            }
        }

        private void OnAttackPressHandler(InputAction.CallbackContext context)
        {
            _publisher.Publish(new UserInputEvent(InputGroup.Attack, Vector2.zero));
        }

        private void OnInteractPressHandler(InputAction.CallbackContext context)
        {
            _publisher.Publish(new UserInputEvent(InputGroup.Interact, Vector2.zero));
        }

        private void OnCrouchPressHandler(InputAction.CallbackContext context)
        {
            _publisher.Publish(new UserInputEvent(InputGroup.Crouch, Vector2.zero));
        }

        private void OnJumpPressHandler(InputAction.CallbackContext context)
        {
            _publisher.Publish(new UserInputEvent(InputGroup.Jump, Vector2.zero));
        }
    }
}

