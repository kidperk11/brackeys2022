using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

    public class ButtonTextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        TMP_Text buttonText;

        private void Awake()
        {
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            buttonText.color = new Color32(220, 220, 220, 255);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            buttonText.color = new Color32(255, 255, 255, 255);
        }

        void Update()
        {

        }
    }
