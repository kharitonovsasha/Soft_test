using UniRx;

namespace Game.Scripts.ContractsInterfaces.Domain
{
    public interface IHeroModel
    {
        public ReactiveProperty<long> Wallet { get; set; }
        public ReactiveProperty<string> SelectedBuildingId { get; set; }
        public ReactiveCollection<IBuildingModel> Buildings { get; set; }
    }
}