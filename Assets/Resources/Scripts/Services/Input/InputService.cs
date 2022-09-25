using UnityEngine;

namespace Resources.Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string _button = "Fire";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp() => SimpleInput.GetButtonUp(_button);
        
        protected static Vector2 SimpleInputAxis() => 
            new (SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}