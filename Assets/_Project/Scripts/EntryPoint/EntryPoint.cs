using System;
using UnityEngine;

namespace MyCode
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] protected FactoryContainer _dataContainer;

        protected virtual void Start()
        {
            Factory.Instance.SetupContainer(_dataContainer);
            Initialize();
            RegistControllers();
            InitEventInvoke();
        }

        private void InitEventInvoke()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.Invoke(ConstSignal.INITIALIZE);
            eventBus.Invoke(ConstSignal.INJECT_SERVICES);
            eventBus.Invoke(ConstSignal.START_GAME);
        }

        protected virtual void RegistControllers() { }
        protected virtual void Initialize() { }

        private void OnDestroy()
        {
            ServiceLocator.Instance.Clear();
            Factory.Instance.Clear();
            EventBus.Instance.Clear();
        }
    }
}