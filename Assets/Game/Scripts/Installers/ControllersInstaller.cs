using System;
using Game.Scripts.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class ControllersInstaller : LifetimeScope
    {
        [SerializeField] private PlayerInput _playerInput;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.LogError("ControllersInstaller Configure");

            builder.RegisterInstance(_playerInput);
            builder.RegisterEntryPoint<UserInputController>(Lifetime.Singleton)
                .As<IInitializable>()
                .As<IDisposable>();
        }
    }
}