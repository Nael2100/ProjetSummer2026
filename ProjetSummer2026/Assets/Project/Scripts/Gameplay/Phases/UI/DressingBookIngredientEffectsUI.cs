using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using TMPro;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingBookIngredientEffectsUI : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> effectsTexts = new List<TextMeshProUGUI>();

        public void Display(BaseIngredient ingredient)
        {
            List<string> effects = ingredient.ReturnEffects();
            for (int i = 0; i < effectsTexts.Count; i++)
            {
                effectsTexts[i].text = "";
                if (i < effects.Count)
                {
                    effectsTexts[i].text = effects[i];
                }
            }
        }
    }
}