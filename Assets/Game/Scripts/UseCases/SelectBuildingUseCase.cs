using System;
using Game.Scripts.ContractsInterfaces.Domain;
using Game.Scripts.Domain.MessageDTO;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.UseCases
{
    public class SelectBuildingUseCase : IInitializable, IDisposable
    {
        private readonly ISubscriber<SelectBuildingDTO> _subscriber;
        private IDisposable _subscription;
        
        [Inject] private readonly IProfileModel _profileModel;

        public SelectBuildingUseCase(ISubscriber<SelectBuildingDTO> subscriber)
        {
            _subscriber = subscriber;
        }
        
        void IInitializable.Initialize()
        {
            _subscription = _subscriber.Subscribe(Handle);
        }

        void IDisposable.Dispose()
        {
            _subscription?.Dispose();
        }
        
        private void Handle(SelectBuildingDTO message)
        {
            if (_profileModel.SelectedBuildingId.Value != message.BuildingId)
            {
                _profileModel.SelectedBuildingId.Value = message.BuildingId;
            }
        }
    }
}