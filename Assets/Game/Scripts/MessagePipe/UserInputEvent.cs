using Game.Scripts.Controllers;
using UnityEngine;

namespace Game.Scripts.MessagePipe
{
    public struct UserInputEvent : IEvent
    {
        public InputGroup InputGroup { get; }
        public Vector2 InputDirection { get; }

        public UserInputEvent(InputGroup group, Vector2 inputDirection)
        {
            InputGroup = group;
            InputDirection = inputDirection;
        }
    }
}