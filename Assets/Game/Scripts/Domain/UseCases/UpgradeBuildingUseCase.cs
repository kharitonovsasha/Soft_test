using Game.Scripts.Domain.Models;
using Game.Scripts.MessagePipe;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Domain.UseCases
{
    public class UpgradeBuildingUseCase : SubscriberUseCase<UpgradeBuildingEvent>
    {
        [Inject] private readonly HeroModel _heroModel;

        protected override void OnEventCalledHandler(UpgradeBuildingEvent upgradeBuildingEvent)
        {
            Debug.LogError($"UpgradeBuildingUseCase: {upgradeBuildingEvent.BuildingId}, {upgradeBuildingEvent.UpgradePrice}");

            if (_heroModel.Wallet.Value >= upgradeBuildingEvent.UpgradePrice)
            {
                _heroModel.Wallet.Value -= upgradeBuildingEvent.UpgradePrice;
                foreach (var buildingModel in _heroModel.Buildings)
                {
                    if (buildingModel.Id.Value == upgradeBuildingEvent.BuildingId)
                    {
                        buildingModel.Level.Value++;
                    }
                }
            }
        }
    }
}