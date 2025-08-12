using Game.Scripts.ContractsInterfaces.Presentation.View;
using UnityEngine.UIElements;

namespace Game.Scripts.Presentation.Views
{
    public class WalletLayoutView : LayoutViewBase, IWalletLayoutView
    {
        private Label _walletText;
        
        public override void Awake()
        {
            base.Awake();
            _walletText = root.Q<Label>("WalletText");
            OnInitialized?.Invoke();
        }
        
        public void SetWalletView(long count)
        {
            if (_walletText != null)
                _walletText.text = $"Wallet: {count}";
        }
    }
}