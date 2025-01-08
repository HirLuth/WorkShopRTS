using System.Collections.Generic;

namespace Inventories_and_Ressources
{
    public class UnitInventory : Inventory
    {
        public Unit myUnit;
        public List<int> maxStocks;
    
        public override void AddResources(RessourcesManager.Ressource ressourceToAdd, int amountToAdd)
        {
            base.AddResources(ressourceToAdd, amountToAdd);
            if (ressources[(int)ressourceToAdd] > maxStocks[(int)ressourceToAdd])
            {
                ressources[(int)ressourceToAdd] = maxStocks[(int)ressourceToAdd];
                OnMax();
            }
        }

        private void OnMax()
        {
            
        }
    }
}
