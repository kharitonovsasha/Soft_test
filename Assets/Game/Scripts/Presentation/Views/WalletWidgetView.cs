using Game.Scripts.ContractsInterfaces.Presentation.View;
using UnityEngine;

namespace Game.Scripts.Presentation.Views
{
    public class WalletWidgetView : MonoBehaviour, IWalletWidgetView
    {
        public void SetWalletView(long count)
        {
            Debug.LogError($"[WalletWidgetView] SetWalletView: {count}");
        }
    }
}