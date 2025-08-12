using System;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Scripts.UseCases
{
    public class BootstrapUseCase : IInitializable, IDisposable
    {
        void IInitializable.Initialize()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }

        void IDisposable.Dispose()
        {
        }
    }
}