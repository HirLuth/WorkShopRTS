using Inventories_and_Ressources;
using UnityEngine;

public class CarInteractible : Interactible
{
    public override void Interact(Unit unit)
    {
        PlayerInventory.instance.Unload(unit);
        StopInteracting(unit);
    }
}
