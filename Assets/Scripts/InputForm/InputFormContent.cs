using Core;
using UnityEngine;

namespace InputForm
{
    [CreateAssetMenu(fileName = "InputFormContent", menuName = "Content/InputForm")]
    public class InputFormContent : Content
    {
        [field: SerializeField] public InputFormView Prefab { get; private set; }
    }
}