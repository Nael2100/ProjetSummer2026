using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class TypeIconUI : MonoBehaviour
    {
        [SerializeField] private Image bg;
        [SerializeField] private TextMeshProUGUI text;

        public void Display(string newText)
        {
            text.text = newText;
            bg.gameObject.SetActive(true);
        }

        public void Hide()
        {
            bg.gameObject.SetActive(false);
            text.text = "";
        }
    }
}