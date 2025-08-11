using System;
using Game.Scripts.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts
{
    public class ControllersLifetimeScope : LifetimeScope
    {
        [SerializeField] private PlayerInput _playerInput;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerInput);
            builder.Register<UserInputController>(Lifetime.Singleton)
                .AsSelf()
                .As<IStartable>()
                .As<IDisposable>();
        }
    }
}