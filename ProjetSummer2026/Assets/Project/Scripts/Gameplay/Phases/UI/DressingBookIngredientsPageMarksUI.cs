using System;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingBookIngredientsPageMarksUI : MonoBehaviour
    {
        [SerializeField] private Button effectsButton;
        [SerializeField] private Button tastesButton;
        public event Action SwitchToEffects;
        public event Action SwitchToTastes;
        private int currentPage = 0;

        private void Awake()
        {
            effectsButton.interactable = false;
        }

        public void Switch()
        {
            if (currentPage == 0)
            {
                currentPage = 1;
                effectsButton.interactable = true;
                tastesButton.interactable = false;
                SwitchToTastes?.Invoke();
            }
            else
            {
                currentPage = 0;
                effectsButton.interactable = false;
                tastesButton.interactable = true;
                SwitchToEffects?.Invoke();
            }
        }
    }
}