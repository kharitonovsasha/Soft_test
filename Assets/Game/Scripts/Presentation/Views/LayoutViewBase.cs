using Game.Scripts.ContractsInterfaces.Presentation.View;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts.Presentation.Views
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class LayoutViewBase : MonoBehaviour, ILayoutView
    {
        protected VisualElement root;
        protected UIDocument uiDocument;

        public virtual void Awake()
        {
            uiDocument = GetComponent<UIDocument>();
            root = uiDocument.rootVisualElement;
        }

        public virtual void Show()
        {
        }

        public virtual void Hide()
        {
        }
    }
}