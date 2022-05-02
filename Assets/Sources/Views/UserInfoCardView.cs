using System;
using TMPro;
using UnityEngine;

namespace Views
{
    public sealed class UserInfoCardView : MonoBehaviour
    {
        public event Action SubmitRequested;

        [SerializeField] private TMP_InputField emailField;
        [SerializeField] private TMP_InputField creditCardNumberField;
        [SerializeField] private TMP_InputField expirationDateField;


        public void Confirm()
        {
            OnSubmitRequested();
        }

        private void OnSubmitRequested()
        {
            SubmitRequested?.Invoke();
        }

        public string Email => emailField.text;
        public string CreditCardNumber => creditCardNumberField.text;
        public string ExpirationDate => expirationDateField.text;
    }
}