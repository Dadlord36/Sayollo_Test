using TMPro;
using UnityEngine;

namespace UI_Elements
{
    public class LabeledInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        public string FieldText => inputField.text;
    }
}