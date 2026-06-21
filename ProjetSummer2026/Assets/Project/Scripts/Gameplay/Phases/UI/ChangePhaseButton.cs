using System;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Plate.Gameplay.Phases.UI
{
    public class ChangePhaseButton : MonoBehaviour
    {
        [SerializeField] private PhaseManager phaseManager;
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public void SetPhase(Phase phase)
        {
            Debug.Log(phase);
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => phaseManager.CheckCanChangePhase(phase));
        }
    }
}