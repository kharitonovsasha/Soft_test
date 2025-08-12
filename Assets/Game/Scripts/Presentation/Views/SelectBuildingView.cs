using Game.Scripts.ContractsInterfaces.Presentation.View;
using UnityEngine;

namespace Game.Scripts.Presentation.Views
{
    public class SelectBuildingView : MonoBehaviour, ISelectBuildingView
    {
        public void ShowSelectedBuilding(string text)
        {
            Debug.LogError($"[SelectedBuildingView] ShowSelectedBuilding: {text}");
        }
    }
}