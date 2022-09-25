using System.Collections.Generic;
using Resources.Scripts.Infrastructure.Services;
using Resources.Scripts.Services.PersistentProgress;
using UnityEngine;

namespace Resources.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        public void CreateHUD();
        public GameObject CreateHero(GameObject at);
        public List<ISavedProgressReader> ProgressReaders { get; }
        public List<ISavedProgress> ProgressWriters { get; }
        public void CleanUp();
    }
}