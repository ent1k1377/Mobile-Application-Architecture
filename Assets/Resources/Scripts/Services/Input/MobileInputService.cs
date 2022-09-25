using UnityEngine;

namespace Resources.Scripts.Services.Input
{
    class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}