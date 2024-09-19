using System;
using TMPro;
using UnityEngine;

namespace Services
{
    public class FactoryStateDebug : MonoBehaviour
    {
        public Factory factory;
        public TMP_Text _factoryMessage;
        private void ShowMessage(Factory factory)
        {
            _factoryMessage.text = factory.debugInfo;
        }

        private void Update()
        {
            ShowMessage(factory);
        }
    }
}