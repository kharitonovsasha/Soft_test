using Game.Scripts.Domain.Models;
using Game.Scripts.MessagePipe;
using VContainer;

namespace Game.Scripts.Domain.UseCases
{
    public class SelectBuildingUseCase : BaseUseCase<SelectBuildingEvent>
    {
        [Inject] private readonly HeroModel _heroModel;

        protected override void OnEventCalledHandler(SelectBuildingEvent selectBuildingEvent)
        {
            if (_heroModel.SelectedBuildingId.Value != selectBuildingEvent.BuildingId)
            {
                _heroModel.SelectedBuildingId.Value = selectBuildingEvent.BuildingId;
            }
        }
    }
}