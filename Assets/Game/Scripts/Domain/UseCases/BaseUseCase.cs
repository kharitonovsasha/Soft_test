using System;
using Game.Scripts.Domain.Models;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Domain.UseCases
{
    public abstract class BaseUseCase<T> : IStartable, IDisposable
    {
        [Inject] private readonly HeroModel _heroModel;
        
        private readonly ISubscriber<T> _subscriber;
        private IDisposable _subscription;
        
        void IStartable.Start()
        {
            _subscription = _subscriber.Subscribe(OnEventCalledHandler);
        }

        void IDisposable.Dispose()
        {
            _subscription?.Dispose();
        }

        protected abstract void OnEventCalledHandler(T message);
    }
}