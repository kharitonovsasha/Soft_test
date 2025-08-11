using Game.Scripts.Controllers;
using UnityEngine;

namespace Game.Scripts.Domain.MessageDTO
{
    public struct UserInputDTO : IDTO
    {
        public InputGroup InputGroup { get; }
        public Vector2 InputDirection { get; }

        public UserInputDTO(InputGroup group, Vector2 inputDirection)
        {
            InputGroup = group;
            InputDirection = inputDirection;
        }
    }
}