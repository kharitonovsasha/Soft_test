namespace Game.Scripts.MessagePipe
{
    public struct SelectBuildingEvent : IEvent
    {
        public string BuildingId { get; }

        public SelectBuildingEvent(string buildingId)
        {
            BuildingId = buildingId;
        }
    }
}