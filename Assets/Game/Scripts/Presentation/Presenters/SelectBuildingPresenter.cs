using System;
using System.Linq;
using Game.Scripts.ContractsInterfaces.Domain;
using Game.Scripts.ContractsInterfaces.Presentation.View;
using Game.Scripts.Domain.MessageDTO;
using MessagePipe;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presentation.Presenters
{
    public class SelectBuildingPresenter : IInitializable, IDisposable
    {
        [Inject] private readonly IHeroModel _heroModel;
        [Inject] private readonly ISelectBuildingView _selectBuildingView;

        private readonly ISubscriber<UserInputDTO> _userEventSubscriber;
        private readonly IPublisher<SelectBuildingDTO> _selectBuildingPublisher;

        private CompositeDisposable _disposables;

        public SelectBuildingPresenter(ISubscriber<UserInputDTO> subscriber, IPublisher<SelectBuildingDTO> publisher)
        {
            _userEventSubscriber = subscriber;
            _selectBuildingPublisher = publisher;
        }

        void IInitializable.Initialize()
        {
            _disposables = new CompositeDisposable();
            SubscribeToSelectedBuildingChange();
            SubscribeToUserInputEvent();
        }

        void IDisposable.Dispose()
        {
            _disposables?.Dispose();
        }

        private void SubscribeToSelectedBuildingChange()
        {
            _heroModel.SelectedBuildingId.Subscribe(_selectBuildingView.ShowSelectedBuilding)
                .AddTo(_disposables);
        }

        private void SubscribeToUserInputEvent()
        {
            _disposables.Add(_userEventSubscriber.Subscribe(Handle));
        }

        private void Handle(UserInputDTO message)
        {
            if (message.InputGroup == InputGroup.Attack)
            {
                //select next building
                var selectedModel = _heroModel.Buildings.First(m => m.Id.Value == _heroModel.SelectedBuildingId.Value);
                var index = _heroModel.Buildings.IndexOf(selectedModel);
                index++;
                if (index >= _heroModel.Buildings.Count)
                    index = 0;
                var nextBuilding = _heroModel.Buildings[index];
                
                _selectBuildingPublisher.Publish(
                    new SelectBuildingDTO(nextBuilding.Id.Value)
                );
            }
        }
    }
}