using System;
using Game.Scripts.Controllers;
using Game.Scripts.Domain.MessageDTO;
using Game.Scripts.Domain.Models;
using Game.Scripts.Presentation.Views;
using MessagePipe;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presentation.Presenters
{
    public class UpgradeBuildingPresenter : IInitializable, IDisposable
    {
        [Inject] private readonly HeroModel _heroModel;
        [Inject] private readonly IUpgradeBuildingView _upgradeBuildingView;
        
        private readonly ISubscriber<UserInputDTO> _userEventSubscriber;
        private readonly IPublisher<UpgradeBuildingDTO> _upgradeBuildingPublisher;
        
        private CompositeDisposable _disposables;
        
        public UpgradeBuildingPresenter(ISubscriber<UserInputDTO> subscriber, IPublisher<UpgradeBuildingDTO> publisher)
        {
            _userEventSubscriber = subscriber;
            _upgradeBuildingPublisher = publisher;
        }
        
        void IInitializable.Initialize()
        {
            _disposables = new CompositeDisposable();
            SubscribeToWalletChange();
            SubscribeToUserInputEvent();
        }

        void IDisposable.Dispose()
        {
            _disposables?.Dispose();
        }

        private void SubscribeToWalletChange()
        {
            _heroModel.SelectedBuildingId
                .Subscribe(_upgradeBuildingView.SetBuildingView)
                .AddTo(_disposables);
        }

        private void SubscribeToUserInputEvent()
        {
            _disposables.Add(_userEventSubscriber.Subscribe(Handle));
        }

        private void Handle(UserInputDTO message)
        {
            if (message.InputGroup == InputGroup.Interact)
            {
                _upgradeBuildingPublisher.Publish(
                    new UpgradeBuildingDTO(_heroModel.SelectedBuildingId.Value, 100));
            }
        }
    }
}