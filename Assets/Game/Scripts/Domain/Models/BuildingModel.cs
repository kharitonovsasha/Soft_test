using UniRx;

namespace Game.Scripts.Domain.Models
{
    public class BuildingModel
    {
        public ReactiveProperty<string> Id = new(string.Empty);
        public ReactiveProperty<int> Level = new (0);
    }
}