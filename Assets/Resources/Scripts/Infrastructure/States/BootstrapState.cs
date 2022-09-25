using Resources.Scripts.Infrastructure.AssetManagement;
using Resources.Scripts.Infrastructure.Factory;
using Resources.Scripts.Infrastructure.Services;
using Resources.Scripts.Infrastructure.Services.SaveLoad;
using Resources.Scripts.Services.Input;
using Resources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Resources.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string _initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(_initial, onLoaded: EnterLoadLevel);
        }
        
        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(InputService());
            _services.RegisterSingle<IAssets>(new AssetsProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
        }
        
        private IInputService InputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            return new MobileInputService();
        }
    }
}