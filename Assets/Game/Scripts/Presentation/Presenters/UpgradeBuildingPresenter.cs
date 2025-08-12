using System;
using Game.Scripts.ContractsInterfaces.Domain;
using Game.Scripts.ContractsInterfaces.Presentation.View;
using Game.Scripts.ContractsInterfaces.Repositories;
using Game.Scripts.Domain.MessageDTO;
using MessagePipe;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presentation.Presenters
{
    public class UpgradeBuildingPresenter : IInitializable, IDisposable
    {
        [Inject] private readonly IHeroModel _heroModel;
        [Inject] private readonly IUpgradeBuildingView _upgradeBuildingView;
        [Inject] private readonly IBuildingsDataRepository _buildingsDataRepository;

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
            SubscribeToBuildingLevelChange();
            SubscribeToUserInputEvent();
        }

        void IDisposable.Dispose()
        {
            _disposables?.Dispose();
        }

        private void SubscribeToBuildingLevelChange()
        {
            foreach (var buildingModel in _heroModel.Buildings)
            {
                buildingModel.Level.Subscribe(level => { ShopBuildingsLevel(); })
                    .AddTo(_disposables);
            }
        }

        private void ShopBuildingsLevel()
        {
            var result = string.Empty;
            foreach (var buildingModel in _heroModel.Buildings)
            {
                result += $"ID: {buildingModel.Id} -> Level: {buildingModel.Level.Value}\n";
            }

            _upgradeBuildingView.ShowLevels(result);
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
                    new UpgradeBuildingDTO(
                        _heroModel.SelectedBuildingId.Value,
                        _buildingsDataRepository.GetBuildingUpgradePrice(_heroModel.SelectedBuildingId.Value)
                    ));
            }
        }
    }
}