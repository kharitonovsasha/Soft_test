using UnityEngine;

namespace Game.Scripts.Views
{
    public class UpgradeBuildingView : MonoBehaviour, IUpgradeBuildingView
    {
        public void SetBuildingView(string buildingId)
        {
            Debug.Log($"[UpgradeBuildingView] SetBuildingView: {buildingId}");
        }
    }

    public interface IUpgradeBuildingView
    {
        void SetBuildingView(string buildingId);
    }
}