using System;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class PhaseUI : MonoBehaviour
    {
        [SerializeField] protected ChangePhaseButton changePhaseButton;
        protected Phase basephase;
        protected virtual void Awake()
        {
            changePhaseButton.gameObject.SetActive(false);
        }

        protected void SetButton()
        {
            changePhaseButton.gameObject.SetActive(true);
            changePhaseButton.SetPhase(basephase);
        }
    }
}