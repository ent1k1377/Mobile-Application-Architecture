using Resources.Scripts.Data;

namespace Resources.Scripts.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        public void SaveProgress();
        public PlayerProgress LoadProgress();
    }
}