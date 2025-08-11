namespace Game.Scripts.MessagePipe
{
    public struct UpgradeBuildingEvent : IEvent
    {
        public string BuildingId { get; }
        public long UpgradePrice { get; }

        public UpgradeBuildingEvent(string buildingId, long upgradePrice)
        {
            BuildingId = buildingId;
            UpgradePrice = upgradePrice;
        }
    }
}