using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Plate.Core.Scriptable.Ingredients;
using Plate.Gameplay.Phases;
using Plate.Gameplay.Phases.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plate.Gameplay.Ingredients
{
    public abstract class BaseIngredient : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        [SerializeField] protected BaseIngredientData dataRef;
        private List<PlateSlot> availableSlots;
        private InventoryPlateSlot inventorySlot;
        private PlateSlot tempSlot;
        private PlateSlot baseSlot;
        private Vector2 basePosition;
        private bool isBeingDragged;

        public event Action<BaseIngredient> OnClicked;
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

        public PlateSlot GetSlot()
        {
            return baseSlot;
        }

        public void AddAvailableSlot(PlateSlot slot)
        {
            availableSlots.Add(slot);
        }
        public void SetInventorySlot(InventoryPlateSlot slot)
        {
            inventorySlot = slot;
            baseSlot = slot;
            slot.SetIngredient(this, true);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            isBeingDragged = true;
            tempSlot = null;
            StopAllCoroutines();
            StartCoroutine(CheckSlots(eventData));
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (tempSlot == null)
            {
                transform.position = eventData.position;
            }
            else
            {
                transform.position = tempSlot.transform.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isBeingDragged = false;
            if (tempSlot != null)
            {
                basePosition = tempSlot.transform.position;
                baseSlot = tempSlot;
            }
            transform.position = basePosition;
            baseSlot.SetIngredient(this, true);
            inventorySlot.ResetOccupation();
            if (baseSlot is InventoryPlateSlot newInventorySlot)
            {
                if (baseSlot != inventorySlot)
                {
                    inventorySlot.IngredientDisconnected(this);
                    newInventorySlot.Associate(this);
                }
            }
            if (baseSlot == inventorySlot)
            {
                inventorySlot.SetOccupied();
                transform.localPosition = Vector2.zero;
            }
            
        }

        IEnumerator CheckSlots(PointerEventData eventData)
        {
            tempSlot = null;
            baseSlot.SetIngredient(this, false);
            List<PlateSlot> potentials = new List<PlateSlot>();
            while (isBeingDragged)
            {
                potentials.Clear();
                foreach (PlateSlot slot in availableSlots)
                {
                    if (slot != baseSlot)
                    {
                        if (slot.ReturnSnap(eventData.position))
                        {
                            potentials.Add(slot);
                        }
                    }

                }

                if (potentials.Count > 1)
                {
                    float closestDistance = Vector2.Distance(eventData.position, baseSlot.transform.position);
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
                    Debug.Log("no potential found");
                    tempSlot = null;
                }
                yield return new WaitForSeconds(0.2f);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(this);
        }

        public IngredientsTypes[] GetTypes()
        {
            return dataRef.types;
        }

        public string GetName()
        {
            return dataRef.ingredientName;
        }
        public TasteValue[] GetTastes()
        {
            return dataRef.tasteValues;
        }
        public abstract int CalculatePoints(PlateRef plate);
    }
}