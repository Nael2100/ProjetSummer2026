using System;
using System.Collections.Generic;
using NUnit.Framework;
using Plate.Gameplay.Orders;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class OrderPhaseUI : MonoBehaviour
    {
        [SerializeField] private OrderPhase phase;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private List<TextMeshProUGUI> effectTexts;
        [SerializeField] private Button continueButton;

        private void Awake()
        {
            phase.OrderChanged += DisplayOrder;
        }

        private void DisplayOrder(BaseOrder order)
        {
            titleText.text = order.ReturnOrderTitle();
            descriptionText.text = order.ReturnOrderDescription();
            int effectsToDisplay = order.ReturnOrderEffectsTexts().Count;
            for (int i = 0; i < effectTexts.Count; i++)
            {
                if (i < effectsToDisplay)
                {
                    effectTexts[i].text = order.ReturnOrderEffectsTexts()[i];
                }
                else
                {
                    effectTexts[i].text = "";
                }
            }
        }

        public void Continue()
        {
            phase.OrderRead();
        }
    }
}