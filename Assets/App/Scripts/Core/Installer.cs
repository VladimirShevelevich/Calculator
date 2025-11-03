using UnityEngine;
using VContainer;

namespace Core
{
    public abstract class Installer : ScriptableObject
    {
        public abstract void Install(IContainerBuilder builder);
    }
}