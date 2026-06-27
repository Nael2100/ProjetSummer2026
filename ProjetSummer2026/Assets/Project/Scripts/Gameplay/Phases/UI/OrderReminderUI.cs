using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Order;
using Plate.Gameplay.Orders;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class OrderReminderUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI orderTitle;
        [SerializeField] private TextMeshProUGUI orderDescription;
        [SerializeField] private TextMeshProUGUI[] orderEffects;
        [SerializeField] private Image clientIcon;
        [SerializeField] private TextMeshProUGUI clientName;
        
        private BaseOrder currentOrder;
        public event Action<BaseOrder> OnOrderClicked;

        public void DisplayOrderReminder(BaseOrder order, bool displayEffects = false, bool displayClient = false)
        {
            currentOrder = order;
            orderTitle.text = order.ReturnOrderTitle();
            orderDescription.text = order.ReturnOrderDescription();
            List<string> effects = order.ReturnOrderEffectsTexts();
            for (int i = 0; i < orderEffects.Length; i++)
            {
                if (orderEffects[i] != null)
                {
                    orderEffects[i].text = "";
                }
                if (i < effects.Count && displayEffects)
                {
                    orderEffects[i].text = effects[i];
                }
            }

            if (displayClient)
            {
                BaseClientData client = order.ReturnOrderClientData();
                clientIcon.sprite = client.clientIcon;
                if (clientName != null)
                {
                    clientName.text = client.clientName;
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnOrderClicked?.Invoke(currentOrder);
        }
    }
}