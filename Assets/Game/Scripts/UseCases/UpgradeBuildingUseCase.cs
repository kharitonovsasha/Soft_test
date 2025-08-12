using System;
using Game.Scripts.ContractsInterfaces.Domain;
using Game.Scripts.Domain.MessageDTO;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.UseCases
{
    public class UpgradeBuildingUseCase : IInitializable, IDisposable
    {
        [Inject] private readonly IProfileModel _profileModel;
        [Inject] private readonly ISubscriber<UpgradeBuildingDTO> _subscriber;

        private IDisposable _subscription;

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
            if (_profileModel.Wallet.Value >= message.UpgradePrice)
            {
                _profileModel.Wallet.Value -= message.UpgradePrice;
                foreach (var buildingModel in _profileModel.Buildings)
                {
                    if (buildingModel.Id.Value == message.BuildingId)
                    {
                        buildingModel.Level.Value++;
                    }
                }
            }
            else
            {
                Debug.LogError("Not enough wallet!");
            }
        }
    }
}