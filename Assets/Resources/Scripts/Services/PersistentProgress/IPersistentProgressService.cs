using Resources.Scripts.Data;
using Resources.Scripts.Infrastructure.Services;

namespace Resources.Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        public PlayerProgress Progress { get; set; }
    }
}