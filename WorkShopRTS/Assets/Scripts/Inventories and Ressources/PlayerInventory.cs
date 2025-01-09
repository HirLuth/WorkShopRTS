using System.Collections.Generic;
using UnityEngine;

namespace Inventories_and_Ressources
{
    public class PlayerInventory : Inventory
    {
        public static PlayerInventory instance;
        public List<int> baseRessources;
        public GameObject unitObjSelfReference;
        public Interactible carInteractible;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected override void Start()
        {
            base.Start();
            for (int i = 0; i < baseRessources.Count; i++)
            {
                AddResources((RessourcesManager.Ressource)i, baseRessources[i]);
            }
        }

        public override void AddResources(RessourcesManager.Ressource ressourceToAdd, int amountToAdd)
        {
            base.AddResources(ressourceToAdd, amountToAdd);
            UIManager.instance.UpdateRessources(ressourceToAdd);
        }

        public override void RemoveResources(RessourcesManager.Ressource ressourceToRemove, int amountToRemove)
        {
            base.RemoveResources(ressourceToRemove, amountToRemove);
            UIManager.instance.UpdateRessources(ressourceToRemove);
        }

        public void Unload(Unit unitThatUnload)
        {
            Inventory inventoryUnit = unitThatUnload.inventory;
            for (int i = 0; i < RessourcesManager.instance.numberOfRessources; i++)
            {
                AddResources((RessourcesManager.Ressource)i,inventoryUnit.ressources[i]);
                inventoryUnit.RemoveResources((RessourcesManager.Ressource)i,inventoryUnit.ressources[i]);
            }
        }

        public void DrinkAtCar(Unit unitThatDrink)
        {
            Debug.Log("Drink");
            int amountToDrink = Mathf.Clamp(unitThatDrink.maxHydratation - unitThatDrink.currentHydratation, 0, ressources[0]);
            unitThatDrink.AddHydratation(amountToDrink);
            RemoveResources(RessourcesManager.Ressource.Water,amountToDrink);
        }
    }
}
