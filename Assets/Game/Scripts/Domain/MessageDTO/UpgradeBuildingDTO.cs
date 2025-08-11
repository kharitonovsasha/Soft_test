namespace Game.Scripts.Domain.MessageDTO
{
    public struct UpgradeBuildingDTO
    {
        public string BuildingId { get; }
        public long UpgradePrice { get; }

        public UpgradeBuildingDTO(string buildingId, long upgradePrice)
        {
            BuildingId = buildingId;
            UpgradePrice = upgradePrice;
        }
    }
}