namespace Game.Scripts.Domain.MessageDTO
{
    public struct SelectBuildingDTO
    {
        public string BuildingId { get; }

        public SelectBuildingDTO(string buildingId)
        {
            BuildingId = buildingId;
        }
    }
}