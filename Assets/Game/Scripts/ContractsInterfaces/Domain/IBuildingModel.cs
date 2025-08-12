using UniRx;

namespace Game.Scripts.ContractsInterfaces.Domain
{
    public interface IBuildingModel
    {
        public ReactiveProperty<string> Id { get; set; }
        public ReactiveProperty<int> Level { get; set; }
    }
}