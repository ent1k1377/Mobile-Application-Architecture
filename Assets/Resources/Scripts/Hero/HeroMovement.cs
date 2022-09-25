using Resources.Scripts.Data;
using Resources.Scripts.Infrastructure.Services;
using Resources.Scripts.Services.Input;
using Resources.Scripts.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Resources.Scripts.Hero
{
    public class HeroMovement : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        
        private IInputService _inputService;
        private Camera _camera;

        public float MovementSpeed => _movementSpeed;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_inputService.Axis.sqrMagnitude <= Constans.Epsilon)
                return;
            
            var movementVector = _camera.transform.TransformDirection(_inputService.Axis);
            movementVector.y = 0;
            movementVector.Normalize();

            transform.forward = movementVector;

            var axis = new Vector3(_inputService.Axis.x, 0, _inputService.Axis.y);
            axis += Physics.gravity;
            
            _characterController.Move(axis * (_movementSpeed * Time.deltaTime));
        }

        public void UpdateProgress(PlayerProgress progress) => 
            progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel, transform.position.AsVectorData());

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel == progress.WorldData.PositionOnLevel.Level)
            {
                var savedPosition = progress.WorldData.PositionOnLevel.Position;
                if (progress.WorldData.PositionOnLevel.Position != null)
                    Warp(to: savedPosition);
            }
        }

        private static string CurrentLevel => 
            SceneManager.GetActiveScene().name;

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.AsUnityVector().AddY(_characterController.height);
            _characterController.enabled = true;
        }
    }
}
