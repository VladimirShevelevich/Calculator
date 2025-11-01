using UnityEngine;
using VContainer;

namespace Core
{
    [CreateAssetMenu(fileName = "ContentHolder", menuName = "Content/ContentHolder", order = 0)]
    public class ContentHolder : ScriptableObject
    {
        [SerializeField] private Content[] _contents;
        
        public void RegisterContent(IContainerBuilder builder)
        {
            foreach (var content in _contents)
            {
                builder.RegisterInstance(content);
            }
        }
    }
}