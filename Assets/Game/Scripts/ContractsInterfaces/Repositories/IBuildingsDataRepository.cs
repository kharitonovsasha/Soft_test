namespace Game.Scripts.ContractsInterfaces.Repositories
{
    public interface IBuildingsDataRepository
    {
        long GetBuildingUpgradePrice(string buildingId);
    }
}