using System;
using Game.Scripts.ContractsInterfaces.Presentation.View;
using UnityEngine.UIElements;

namespace Game.Scripts.Presentation.Views
{
    public class MainLayoutView : LayoutViewBase, IMainLayoutView
    {
        private Button _upgradeButton;
        private Label _infoText;
        
        public event Action OnUpgrade; 

        public override void Awake()
        {
            base.Awake();
            _upgradeButton = root.Q<Button>("UpgradeButton");
            _upgradeButton.text = "Upgrade";
            _upgradeButton.clicked += OnUpgradeClickedHandler;
            
            _infoText = root.Q<Label>("InfoText");
            _infoText.text = "Empty";
        }

        private void OnUpgradeClickedHandler()
        {
            OnUpgrade?.Invoke();
        }

        public void SetInfoText(string text)
        {
            if(_infoText != null)
                _infoText.text = text;
        }
    }
}