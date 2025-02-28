using System;
using UnityEngine;

namespace MyCode
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] protected ResourcesContainer _dataContainer;

        protected virtual void Awake()
        {
            ResourcesManager.SetupContainer(_dataContainer);
            ServiceLocator.Initialize();
            EventBus.Initialize();
        }

        protected virtual void Start()
        {
            Initialize();
            RegistControllers();
            InitEventInvoke();
        }

        private void InitEventInvoke()
        {
            EventContainer eventContainer = EventBus.EventContainer;
            eventContainer.Invoke(ConstSignal.INITIALIZE);
            eventContainer.Invoke(ConstSignal.INJECT_SERVICES);
            eventContainer.Invoke(ConstSignal.START_GAME);
        }

        protected virtual void RegistControllers() { }
        protected virtual void Initialize() { }

        private void OnDestroy()
        {
            ServiceLocator.Clear();
            ResourcesManager.Clear();
            EventBus.Clear();
        }
    }
}