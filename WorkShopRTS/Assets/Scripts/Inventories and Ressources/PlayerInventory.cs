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
            Debug.Log("oui");
            foreach (var ressource in baseRessources)
            {
                ressources.Add(ressource);
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
    }
}
