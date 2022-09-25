using UnityEngine;

namespace Resources.Scripts.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int _movementSpeed = Animator.StringToHash("MovementSpeed");
        
        [SerializeField] private Animator _animator;
        [SerializeField] private HeroMovement _heroMovement;
        [SerializeField] private CharacterController _characterController;

        private void Update()
        {
            var speed = _characterController.velocity.magnitude / _heroMovement.MovementSpeed;
            _animator.SetFloat(_movementSpeed, speed, 0.1f, Time.deltaTime);
        }
    }
}