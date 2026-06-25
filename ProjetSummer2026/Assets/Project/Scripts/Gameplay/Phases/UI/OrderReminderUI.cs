using System;
using System.Collections.Generic;
using Plate.Gameplay.Orders;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plate.Gameplay.Phases.UI
{
    public class OrderReminderUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI orderTitle;
        [SerializeField] private TextMeshProUGUI orderDescription;
        [SerializeField] private TextMeshProUGUI[] orderEffects;
        
        private BaseOrder currentOrder;
        public event Action<BaseOrder> OnOrderClicked;

        public void DisplayOrderReminder(BaseOrder order, bool displatEffects = true)
        {
            currentOrder = order;
            orderTitle.text = order.ReturnOrderTitle();
            orderDescription.text = order.ReturnOrderDescription();
            List<string> effects = order.ReturnOrderEffectsTexts();
            for (int i = 0; i < orderEffects.Length; i++)
            {
                orderEffects[i].text = "";
                if (i < effects.Count && displatEffects)
                {
                    orderEffects[i].text = effects[i];
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnOrderClicked?.Invoke(currentOrder);
        }
    }
}