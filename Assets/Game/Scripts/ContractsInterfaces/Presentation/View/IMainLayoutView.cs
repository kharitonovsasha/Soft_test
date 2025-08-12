using System;

namespace Game.Scripts.ContractsInterfaces.Presentation.View
{
    public interface IMainLayoutView
    {
        event Action OnUpgrade;
        void SetInfoText(string text);
    }
}