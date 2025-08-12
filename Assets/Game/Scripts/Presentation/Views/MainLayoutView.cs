using System;
using Game.Scripts.ContractsInterfaces.Presentation.View;
using UnityEngine.UIElements;

namespace Game.Scripts.Presentation.Views
{
    public class MainLayoutView : LayoutViewBase, IMainLayoutView
    {
        private Label _infoText;
        private Label _controlText;
        private Button _upgradeButton;
        
        public event Action OnUpgradeClicked; 

        public override void Awake()
        {
            base.Awake();
            _infoText = root.Q<Label>("InfoText");
            _controlText = root.Q<Label>("ControlText");
            _upgradeButton = root.Q<Button>("UpgradeButton");
            _upgradeButton.text = "Upgrade";
            _upgradeButton.clicked += OnUpgradeClickedHandler;
            OnInitialized?.Invoke();
        }

        private void OnUpgradeClickedHandler()
        {
            OnUpgradeClicked?.Invoke();
        }

        public void SetInfoText(string text)
        {
            if(_infoText != null)
                _infoText.text = text;
        }
        
        public void SetControlText(string text)
        {
            if(_controlText != null)
                _controlText.text = text;
        }
    }
}