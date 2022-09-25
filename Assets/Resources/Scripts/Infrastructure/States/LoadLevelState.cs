using Resources.Scripts.CameraLogic;
using Resources.Scripts.Infrastructure.Factory;
using Resources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Resources.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string _initialPoint = "InitialPoint";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, 
            IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
            _gameFactory.CleanUp();
            _loadingCurtain.Show();
        }

        public void Exit() => 
            _loadingCurtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (var progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        private void InitGameWorld()
        {
            var hero = _gameFactory.CreateHero(GameObject.FindWithTag(_initialPoint));
            _gameFactory.CreateHUD();
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}