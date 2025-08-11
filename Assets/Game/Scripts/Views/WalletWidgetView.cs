using UnityEngine;

namespace Game.Scripts.Views
{
    public class WalletWidgetView : MonoBehaviour, IWalletWidgetView
    {
        public void SetWalletView(long count)
        {
            Debug.Log($"[WalletWidgetView] Set wallet view: {count}");
        }
    }

    public interface IWalletWidgetView
    {
        public void SetWalletView(long count);
    }
}