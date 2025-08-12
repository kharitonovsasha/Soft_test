using UnityEngine;

namespace Game.Scripts.Domain.MessageDTO
{
    public enum InputGroup
    {
        Move, // WASD 
        Attack, // enter
        Interact, // E
        Crouch, // C // select next building
        Jump, // space // upgrade selected building
    }
    
    public struct UserInputDTO
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