﻿using UnityEngine;

namespace Resources.Scripts.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                var axis = SimpleInputAxis();
                
                if (axis == Vector2.zero)
                    axis = UnityAxis();
                
                return axis;
            }
        }
        
        private static Vector2 UnityAxis() => 
            new (UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}