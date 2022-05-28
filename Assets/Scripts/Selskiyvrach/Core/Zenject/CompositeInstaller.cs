using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Selskiyvrach.Core.Zenject
{
    public class CompositeInstaller : MonoInstaller, ICompositeInstaller<MonoInstallerBase>
    {
        private MonoInstallerBase[] _leafInstallers;
        public IReadOnlyList<MonoInstallerBase> LeafInstallers => _leafInstallers;

        public override void InstallBindings()
        {
            CollectInstallersFromGameObject();
            
            Assert.That(this.ValidateLeafInstallers(), "Found some circular references in {0}".Fmt(name));

            foreach (var installer in _leafInstallers)
            {
                Container.Inject(installer);

#if ZEN_INTERNAL_PROFILING
                using (ProfileTimers.CreateTimedBlock("User Code"))
#endif
                {
                    installer.InstallBindings();
                }
            }
        }

        private void CollectInstallersFromGameObject() => 
            _leafInstallers = GetComponents<MonoInstallerBase>().Except(new List<MonoInstallerBase>(){this}).ToArray();
    }
}