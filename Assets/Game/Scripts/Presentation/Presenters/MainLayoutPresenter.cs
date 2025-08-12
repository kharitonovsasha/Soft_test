using Game.Scripts.ContractsInterfaces.Domain;
using Game.Scripts.Presentation.Views;
using VContainer;
using System.Linq;
using Game.Scripts.ContractsInterfaces.Repositories;
using Game.Scripts.Domain.MessageDTO;
using MessagePipe;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Presentation.Presenters
{
    public class MainLayoutPresenter : LayoutPresenterBase<MainLayoutView>
    {
        [Inject] private readonly IProfileModel _profileModel;
        [Inject] private readonly IBuildingsDataRepository _buildingsDataRepository;

        private readonly ISubscriber<UserInputDTO> _userEventSubscriber;
        private readonly IPublisher<SelectBuildingDTO> _selectBuildingPublisher;
        private readonly IPublisher<UpgradeBuildingDTO> _upgradeBuildingPublisher;

        private CompositeDisposable _disposables;
        private const string _selectedColor = "FFF400";
        private const string _defaultColor = "B1B1B";

        public MainLayoutPresenter(
            ISubscriber<UserInputDTO> subscriber,
            IPublisher<SelectBuildingDTO> selectBuildingPublisher,
            IPublisher<UpgradeBuildingDTO> upgradeBuildingPublisher)
        {
            _userEventSubscriber = subscriber;
            _selectBuildingPublisher = selectBuildingPublisher;
            _upgradeBuildingPublisher = upgradeBuildingPublisher;
        }

        public override void Initialize()
        {
            Debug.LogError("MainLayoutPresenter: Initialize");
            base.Initialize();
            _disposables = new CompositeDisposable();
            layoutView.OnUpgrade += PublishUpgradeBuilding;
            SubscribeToSelectedBuildingChange();
            SubscribeToBuildingLevelChange();
            SubscribeToUserInputEvent();
        }

        public override void Dispose()
        {
            base.Dispose();
            layoutView.OnUpgrade -= PublishUpgradeBuilding;
            _disposables?.Dispose();
        }

        private void SubscribeToSelectedBuildingChange()
        {
            _profileModel.SelectedBuildingId.Subscribe(_ => UpdateInfoText())
                .AddTo(_disposables);
        }
        
        private void SubscribeToBuildingLevelChange()
        {
            foreach (var buildingModel in _profileModel.Buildings)
            {
                buildingModel.Level.Subscribe(level => { UpdateInfoText(); })
                    .AddTo(_disposables);
            }
        }

        private void UpdateInfoText()
        {
            var result = string.Empty;
            foreach (var buildingModel in _profileModel.Buildings)
            {
                var isSelected = buildingModel.Id.Value == _profileModel.SelectedBuildingId.Value;
                var color = isSelected ? _selectedColor : _defaultColor;
                result += $"<color=#{color}>ID: {buildingModel.Id.Value}  |  Level: {buildingModel.Level.Value}</color>\n";
            }
            layoutView.SetInfoText(result);
        }

        private void SubscribeToUserInputEvent()
        {
            _disposables.Add(_userEventSubscriber.Subscribe(Handle));
        }

        private void Handle(UserInputDTO message)
        {
            if (message.InputGroup == InputGroup.Crouch)
            {
                PublishSelectNextBuilding();
            }
            
            if (message.InputGroup == InputGroup.Jump)
            {
                PublishUpgradeBuilding();
            }
        }

        private void PublishSelectNextBuilding()
        {
            var selectedModel = _profileModel.Buildings.First(m => m.Id.Value == _profileModel.SelectedBuildingId.Value);
            var index = _profileModel.Buildings.IndexOf(selectedModel);
            index++;
            if (index >= _profileModel.Buildings.Count)
                index = 0;
            var nextBuilding = _profileModel.Buildings[index];

            _selectBuildingPublisher.Publish(
                new SelectBuildingDTO(nextBuilding.Id.Value)
            );
        }

        private void PublishUpgradeBuilding()
        {
            _upgradeBuildingPublisher.Publish(
                new UpgradeBuildingDTO(
                    _profileModel.SelectedBuildingId.Value,
                    _buildingsDataRepository.GetBuildingUpgradePrice(_profileModel.SelectedBuildingId.Value)
                ));
        }
    }
}