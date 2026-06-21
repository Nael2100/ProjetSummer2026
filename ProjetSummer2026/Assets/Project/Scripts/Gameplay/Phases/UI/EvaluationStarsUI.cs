using System;
using System.Collections;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class EvaluationStarsUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] stars;
        private bool ready = false;

        public event Action OnStarsCompleted;
        public void ReadyToDisplay(bool display)
        {
            ready = display;
            foreach (GameObject star in stars)
            {
                star.SetActive(false);
            }
        }

        public void DisplayStars(int amount)
        {
            StartCoroutine(DisplayStarsOneByOne(amount));
        }

        IEnumerator DisplayStarsOneByOne(int amount)
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
            OnStarsCompleted?.Invoke();
        }
    }
}