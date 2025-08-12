using Game.Scripts.ContractsInterfaces.Domain;
using UniRx;

namespace Game.Scripts.Domain.Models
{
    public class HeroModel : IHeroModel
    {
        public ReactiveProperty<long> Wallet { get; set; } = new(0);
        public ReactiveProperty<string> SelectedBuildingId { get; set; } = new(string.Empty);
        public ReactiveCollection<IBuildingModel> Buildings { get; set; } = new();
    }
}