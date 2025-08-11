using UnityEngine;

namespace Game.Scripts.Presentation.Views
{
    public class WalletWidgetView : MonoBehaviour, IWalletWidgetView
    {
        public void SetWalletView(long count)
        {
            Debug.Log($"[WalletWidgetView] SetWalletView: {count}");
        }
    }

    public interface IWalletWidgetView
    {
        public void SetWalletView(long count);
    }
}