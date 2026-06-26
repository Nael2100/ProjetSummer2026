using System.Collections.Generic;
using Plate.Gameplay.Orders;
using TMPro;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingBookOrderUI : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> orderTexts;
        
        public void Display(BaseOrder order)
        {
            gameObject.SetActive(true);
            List<string> texts = order.ReturnOrderEffectsTexts();
            for (int i = 0; i < orderTexts.Count; i++)
            {
                orderTexts[i].text = "";
                if (i < texts.Count)
                {
                    orderTexts[i].text = texts[i];
                }
            }
        }
    }
}