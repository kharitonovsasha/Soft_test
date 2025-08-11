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

    public interface IUpgradeBuildingView
    {
        void ShowLevels(string text);
    }
}