namespace Inventories_and_Ressources
{
    public class PlayerInventory : Inventory
    {
        public static PlayerInventory instance;

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
