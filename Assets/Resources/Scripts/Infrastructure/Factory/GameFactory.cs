using System.Collections.Generic;
using Resources.Scripts.Infrastructure.AssetManagement;
using Resources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Resources.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();
        
        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void CreateHUD() => 
            InstantiateRegistered(AssetPath.HUDPath);

        public GameObject CreateHero(GameObject at) => 
            InstantiateRegistered(AssetPath.HeroPath, at.transform.position);

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            var gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 position)
        {
            var gameObject = _assets.Instantiate(prefabPath, position);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (var progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            ProgressReaders.Add(progressReader);
        }
    }
}