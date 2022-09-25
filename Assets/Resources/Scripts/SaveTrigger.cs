using Resources.Scripts.Infrastructure.Services;
using Resources.Scripts.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Resources.Scripts
{
    public class SaveTrigger : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;
        
        private ISaveLoadService _saveLoadService;

        private void Start()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            
            Debug.Log("Progress Saved.");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!_collider)
                return;
            
            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}