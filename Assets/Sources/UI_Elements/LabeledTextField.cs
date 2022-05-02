using TMPro;
using UnityEngine;

namespace UI_Elements
{
    public class LabeledTextField : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        [SerializeField] private TMP_Text field;

        public string Lable
        {
            get => label.text;
            set => label.text = $"{value} : ";
        }
        
        public string Field
        {
            get => field.text;
            set => field.text = value;
        }
    }
}