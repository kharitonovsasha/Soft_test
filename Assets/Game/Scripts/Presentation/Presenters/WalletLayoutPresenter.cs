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
            layoutView.OnInitialized += OnViewInitialized;
            SubscribeToWalletChange();
        }

        public override void Dispose()
        {
            layoutView.OnInitialized -= OnViewInitialized;
            _disposables?.Dispose();
            base.Dispose();
        }
        
        private void OnViewInitialized()
        {
            layoutView.SetWalletView(_profileModel.Wallet.Value);
        }

        private void SubscribeToWalletChange()
        {
            _profileModel.Wallet
                .Subscribe(layoutView.SetWalletView)
                .AddTo(_disposables);
        }
    }
}