using System;

namespace Game.Scripts.ContractsInterfaces.Presentation.View
{
    public interface IMainLayoutView
    {
        event Action OnUpgradeClicked;
        void SetInfoText(string text);
    }
}