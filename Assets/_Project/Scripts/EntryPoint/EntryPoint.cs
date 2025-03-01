using System;
using UnityEngine;

namespace MyCode
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] protected FactoryContainer _dataContainer;

        protected virtual void Awake()
        {
            Factory.Initialize();
            ServiceLocator.Initialize();
            EventBus.Initialize();
        }

        protected virtual void Start()
        {
            Factory.SetupContainer(_dataContainer);
            Initialize();
            RegistControllers();
            InitEventInvoke();
        }

        private void InitEventInvoke()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.InvokeSignal(ConstSignal.INITIALIZE);
            eventBus.InvokeSignal(ConstSignal.INJECT_SERVICES);
            eventBus.InvokeSignal(ConstSignal.START_GAME);
        }

        protected virtual void RegistControllers() { }
        protected virtual void Initialize() { }

        private void OnDestroy()
        {
            ServiceLocator.Clear();
            Factory.Clear();
            EventBus.Clear();
        }
    }
}