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
        }

        protected virtual void Start()
        {
            Initialize();
            ServiceLocatorRegister();
            Create();
            StartScene();
        }

        protected virtual void Initialize() { }

        protected virtual void ServiceLocatorRegister() { }

        protected virtual void Create() { }
        protected virtual void StartScene() { }

        protected virtual void OnDestroy()
        {
            ServiceLocator.ClearContainer();
            ResourcesManager.ClearContainer();
        }
    }
}