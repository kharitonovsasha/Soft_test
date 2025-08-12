using Game.Scripts.ContractsInterfaces.Domain;
using UniRx;

namespace Game.Scripts.Domain.Models
{
    public class BuildingModel : IBuildingModel
    {
        public ReactiveProperty<string> Id { get; set; } = new(string.Empty);
        public ReactiveProperty<int> Level { get; set; } = new(0);
    }
}