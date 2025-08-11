using UnityEngine;

namespace Game.Scripts.Presentation.Views
{
    public class UpgradeBuildingView : MonoBehaviour, IUpgradeBuildingView
    {
        public void SetBuildingView(string buildingId)
        {
            Debug.LogError($"[UpgradeBuildingView] SetBuildingView: {buildingId}");
        }
    }

    public interface IUpgradeBuildingView
    {
        void SetBuildingView(string buildingId);
    }
}