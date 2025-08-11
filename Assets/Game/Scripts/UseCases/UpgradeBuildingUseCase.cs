using System;
using Game.Scripts.Domain.MessageDTO;
using Game.Scripts.Domain.Models;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.UseCases
{
    public class UpgradeBuildingUseCase : IInitializable, IDisposable
    {
        private readonly ISubscriber<UpgradeBuildingDTO> _subscriber;
        private IDisposable _subscription;

        [Inject] private readonly HeroModel _heroModel;

        public UpgradeBuildingUseCase(ISubscriber<UpgradeBuildingDTO> subscriber)
        {
            _subscriber = subscriber;
        }

        void IInitializable.Initialize()
        {
            _subscription = _subscriber.Subscribe(Handle);
        }

        void IDisposable.Dispose()
        {
            _subscription?.Dispose();
        }

        private void Handle(UpgradeBuildingDTO message)
        {
            Debug.LogError($"UpgradeBuildingUseCase: {message.BuildingId} - {message.UpgradePrice}");

            if (_heroModel.Wallet.Value >= message.UpgradePrice)
            {
                _heroModel.Wallet.Value -= message.UpgradePrice;
                foreach (var buildingModel in _heroModel.Buildings)
                {
                    if (buildingModel.Id.Value == message.BuildingId)
                    {
                        buildingModel.Level.Value++;
                    }
                }
            }
        }
    }
}