using UnityEngine;
using VContainer;

namespace Core
{
    public abstract class DomainInstaller : ScriptableObject
    {
        public abstract void Install(IContainerBuilder builder);
    }
}