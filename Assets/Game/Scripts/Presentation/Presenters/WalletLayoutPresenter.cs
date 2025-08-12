using Game.Scripts.ContractsInterfaces.Domain;
using Game.Scripts.Presentation.Views;
using UniRx;
using VContainer;

namespace Game.Scripts.Presentation.Presenters
{
    public class WalletLayoutPresenter : LayoutPresenterBase<WalletLayoutView>
    {
        [Inject] private readonly IProfileModel _profileModel;
        
        private CompositeDisposable _disposables;
        
        public override void Initialize()
        {
            base.Initialize();
            _disposables = new CompositeDisposable();
            SubscribeToWalletChange();
        }

        public override void Dispose()
        {
            base.Dispose();
            _disposables?.Dispose();
        }

        private void SubscribeToWalletChange()
        {
            _profileModel.Wallet
                .Subscribe(layoutView.SetWalletView)
                .AddTo(_disposables);
        }
    }
}