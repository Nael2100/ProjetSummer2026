using System;
using System.Collections;
using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using Plate.Gameplay.Phases;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plate.Gameplay.Ingredients
{
    public class BaseIngredient : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private BaseIngredientData dataRef;
        [SerializeField] private List<PlateSlot> availableSlots;
        private PlateSlot tempSlot;

        private Vector2 basePosition;

        private bool isBeingDragged;

        private void Awake()
        {
            availableSlots = new List<PlateSlot>();
        }

        public void SetBasePosition(Vector2 position)
        {
            basePosition = position;
        }
        
        public Sprite ReturnImage()
        {
            return dataRef.sprite;
        }

        public string ReturnName()
        {
            return dataRef.name;
        }

        public void SetSlot(PlateSlot slot)
        {
            availableSlots.Add(slot);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            isBeingDragged = true;
            tempSlot = null;
            StopAllCoroutines();
            StartCoroutine(CheckSlots(eventData));
            Debug.Log("OnBeginDrag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            if (tempSlot == null)
            {
                transform.position = eventData.position;
            }
            else
            {
                transform.position = tempSlot.transform.position;
                basePosition = tempSlot.transform.position;
            }
            
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isBeingDragged = false;
            if (tempSlot == null)
            {
                transform.position = basePosition;
            }
            else
            {
                transform.position = tempSlot.transform.position;
            }
            Debug.Log("OnEndDrag");
        }

        IEnumerator CheckSlots(PointerEventData eventData)
        {
            List<PlateSlot> potentials = new List<PlateSlot>();
            
            while (isBeingDragged)
            {
                potentials.Clear();
                foreach (PlateSlot slot in availableSlots)
                {
                    if (slot != tempSlot )
                    {
                        if (slot.ReturnSnap(eventData.position))
                        {
                            potentials.Add(slot);
                        }
                    }
                    
                }

                if (potentials.Count > 1)
                {
                    tempSlot = potentials[0];
                    float closestDistance = Vector2.Distance(eventData.position, tempSlot.transform.position);
                    foreach (PlateSlot slot in potentials)
                    {
                        float newDistance = Vector2.Distance(eventData.position, slot.transform.position);
                        if (newDistance < closestDistance)
                        {
                            tempSlot = slot;
                            closestDistance = newDistance;
                        }
                    }
                }
                else if (potentials.Count == 1)
                {
                    tempSlot = potentials[0];
                }
                else if (potentials.Count == 0)
                {
                    tempSlot = null;
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
        
    }
}