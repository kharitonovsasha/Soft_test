using System;
using Game.Scripts.ContractsInterfaces.Presentation.View;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts.Presentation.Views
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class LayoutViewBase : MonoBehaviour, ILayoutView
    {
        private UIDocument _uiDocument;
        protected VisualElement root;
        public Action OnInitialized;

        public virtual void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            root = _uiDocument.rootVisualElement;
        }

        public virtual void Show()
        {
        }

        public virtual void Hide()
        {
        }
    }
}