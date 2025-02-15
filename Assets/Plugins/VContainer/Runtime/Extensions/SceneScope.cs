using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace VContainer.Extensions
{
    public class SceneScope : LifetimeScope
    {
        [Header("Installer")]
        [SerializeField] private List<MonoInstaller> _monoInstallers = new List<MonoInstaller>();

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _monoInstallers)
            {
                if (Parent != null)
                    Parent.Container.Inject(installer);

                installer.Install(builder);
            }
        }
    }
}