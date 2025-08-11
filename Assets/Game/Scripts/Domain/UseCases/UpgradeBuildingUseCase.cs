using Game.Scripts.Domain.Models;
using Game.Scripts.MessagePipe;
using VContainer;

namespace Game.Scripts.Domain.UseCases
{
    public class UpgradeBuildingUseCase : BaseUseCase<UpgradeBuildingEvent>
    {
        [Inject] private readonly HeroModel _heroModel;

        protected override void OnEventCalledHandler(UpgradeBuildingEvent upgradeBuildingEvent)
        {
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