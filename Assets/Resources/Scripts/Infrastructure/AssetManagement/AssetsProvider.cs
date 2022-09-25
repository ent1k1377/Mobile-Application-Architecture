using UnityEngine;

namespace Resources.Scripts.Infrastructure.AssetManagement
{
    public class AssetsProvider : IAssets
    {
        public GameObject Instantiate(string path)
        {
            var prefab = UnityEngine.Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = UnityEngine.Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}