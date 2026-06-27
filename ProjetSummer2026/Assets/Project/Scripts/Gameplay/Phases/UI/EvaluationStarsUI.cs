using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class EvaluationStarsUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] stars;
        [SerializeField] private GameObject clientReaction;
        private bool ready = false;

        public event Action OnStarsCompleted;
        public void ReadyToDisplay(bool display)
        {
            ready = display;
            foreach (GameObject star in stars)
            {
                star.SetActive(false);
            }
            clientReaction.SetActive(false);
        }

        public void DisplayStars(int amount, string reaction)
        {
            StartCoroutine(DisplayStarsOneByOne(amount, reaction));
        }

        IEnumerator DisplayStarsOneByOne(int amount, string reaction)
        {
            while (!ready)
            {
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < amount; i++)
            {
                stars[i].SetActive(true);
                yield return new WaitForSeconds(1f);
            }
            DisplayClientReaction(reaction);
            OnStarsCompleted?.Invoke();
        }
        
        public void DisplayClientReaction(string text)
        {
            clientReaction.SetActive(true);
            clientReaction.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }
}