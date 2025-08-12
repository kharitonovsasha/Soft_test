using System;
using Game.Scripts.ContractsInterfaces.Presentation.Presenter;
using Game.Scripts.ContractsInterfaces.Presentation.View;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presentation.Presenters
{
    public abstract class LayoutPresenterBase<TView> : ILayoutPresenter,
        IInitializable, IDisposable
        where TView : ILayoutView
    {
        [Inject] protected TView layoutView;

        public virtual void Initialize()
        {
        }
        
        public virtual void Dispose()
        {
        }
        
        public virtual void Show()
        {
            layoutView.Show();
        }

        public virtual void Hide()
        {
            layoutView.Hide();
        }
    }
}