using System;
using Game.Scripts.Controllers;
using Game.Scripts.Domain.Models;
using Game.Scripts.MessagePipe;
using Game.Scripts.Views;
using MessagePipe;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presenters
{
    public class UpgradeBuildingPresenter : IStartable, IDisposable
    {
        [Inject] private readonly HeroModel _heroModel;
        [Inject] private readonly IUpgradeBuildingView _upgradeBuildingView;
        
        private readonly ISubscriber<UserInputEvent> _userEventSubscriber;
        private IDisposable _userEventSubscription;
        
        private readonly IPublisher<UpgradeBuildingEvent> _upgradeBuildingPublisher;
        
        private CompositeDisposable _disposables;
        
        void IStartable.Start()
        {
            _disposables = new CompositeDisposable();
            SubscribeToWalletChange();
            SubscribeToUserInputEvent();
        }

        void IDisposable.Dispose()
        {
            _disposables?.Dispose();
            _userEventSubscription?.Dispose();
        }

        private void SubscribeToWalletChange()
        {
            _heroModel.SelectedBuildingId
                .Subscribe(_upgradeBuildingView.SetBuildingView)
                .AddTo(_disposables);
        }

        private void SubscribeToUserInputEvent()
        {
            _userEventSubscription = _userEventSubscriber.Subscribe(OnUserInputEventHandler);
        }

        private void OnUserInputEventHandler(UserInputEvent userInputEvent)
        {
            Debug.LogError($"OnUserInputEventHandler: {userInputEvent.InputGroup.ToString()}");
            if (userInputEvent.InputGroup == InputGroup.Interact)
            {
                _upgradeBuildingPublisher.Publish(
                    new UpgradeBuildingEvent(_heroModel.SelectedBuildingId.Value, 100));
            }
        }
    }
}