using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Scripts
{
    public class Bootstrap : IInitializable
    {
        public void Initialize()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }
}