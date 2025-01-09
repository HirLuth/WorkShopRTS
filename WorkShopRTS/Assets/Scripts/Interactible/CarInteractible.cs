using Inventories_and_Ressources;
using UnityEngine;

public class CarInteractible : Interactible
{
    public override void Interact(Unit unit)
    {
        Debug.Log("Car interactible");
        PlayerInventory.instance.Unload(unit);
        PlayerInventory.instance.DrinkAtCar(unit);
        unit.ExitInteraction(Unit.State.Still);
    }
}
