using Resources.Scripts.Data;

namespace Resources.Scripts.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress progress);
    }
}