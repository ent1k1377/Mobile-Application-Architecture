using Resources.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Resources.Scripts.Services.Input
{
    public interface IInputService : IService
    {
        public Vector2 Axis { get; }
        
        public bool IsAttackButtonUp();
    }
}