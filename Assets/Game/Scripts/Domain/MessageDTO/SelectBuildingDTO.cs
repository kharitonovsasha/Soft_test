namespace Game.Scripts.Domain.MessageDTO
{
    public struct SelectBuildingDTO : IDTO
    {
        public string BuildingId { get; }

        public SelectBuildingDTO(string buildingId)
        {
            BuildingId = buildingId;
        }
    }
}