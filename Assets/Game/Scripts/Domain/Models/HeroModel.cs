using UniRx;

namespace Game.Scripts.Domain.Models
{
    public class HeroModel
    {
        public ReactiveProperty<long> Wallet = new(0);
        public ReactiveProperty<string> SelectedBuildingId = new(string.Empty);
        public ReactiveCollection<BuildingModel> Buildings = new();
    }
}