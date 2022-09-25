using Resources.Scripts.Infrastructure.States;
using UnityEngine;

namespace Resources.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtainPrefab;
        
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this, Instantiate(_loadingCurtainPrefab));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
