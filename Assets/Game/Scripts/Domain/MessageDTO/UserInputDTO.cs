using UnityEngine;

namespace Game.Scripts.Domain.MessageDTO
{
    public enum InputGroup
    {
        Move, // WASD 
        Attack, // enter // select next building
        Interact, // E // upgrade selected building
        Crouch, // C // add wallet
        Jump, // space // spent wallet
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