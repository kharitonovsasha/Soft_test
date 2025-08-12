using Game.Scripts.ContractsInterfaces.Presentation.View;
using UnityEngine;

namespace Game.Scripts.Presentation.Views
{
    public class UpgradeBuildingView : MonoBehaviour, IUpgradeBuildingView
    {
        public void ShowLevels(string text)
        {
            Debug.LogError($"[UpgradeBuildingView] ShopBuildingsLevel: {text}");
        }
    }
}