using UnityEngine;
using VContainer;

namespace Core
{
    public abstract class DomainInstaller : MonoBehaviour
    {
        public abstract void Install(IContainerBuilder builder);
    }
}