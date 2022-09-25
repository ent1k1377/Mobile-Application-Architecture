using Resources.Scripts.Data;
using Resources.Scripts.Infrastructure.Factory;
using Resources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Resources.Scripts.Infrastructure.Services.SaveLoad
{
    class SaveLoadService : ISaveLoadService
    {
        private const string _progressKey = "Progress";
        
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (var progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);
            
            PlayerPrefs.SetString(_progressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(_progressKey)?.ToDeserialized<PlayerProgress>();
    }
}