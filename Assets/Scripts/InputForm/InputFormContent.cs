using UnityEngine;

namespace InputForm
{
    [CreateAssetMenu(fileName = "InputFormContent", menuName = "Content/InputForm")]
    public class InputFormContent : ScriptableObject
    {
        [field: SerializeField] public InputFormView Prefab { get; private set; }
    }
}