using Inventories_and_Ressources;
using UnityEngine;

public class CarUnit : Unit
{
    private float timerFuel;
    public float tickFuel;
    protected override void Update()
    {
        if(isTakingDamage)
        {
            currentHealth -= sufferDamage * Time.deltaTime;
            unitCanvas.UpdateLifeJauge(currentHealth, maxHealth);
        }
        
        if (unitMovement.agent.velocity.magnitude > 0.1f)
        {
            timerFuel += Time.deltaTime;
            if (timerFuel >= tickFuel)
            {
                timerFuel = 0;
                PlayerInventory.instance.DrainFuel();
            }
                
        }
        
        if (PlayerInventory.instance.ressources[1] == 0)
        {
            unitMovement.agent.speed = 0;
        }
        else
        {
            unitMovement.agent.speed = moveSpeed;
        }
    }
    

    public override void AddHydratation(int hydratationToAdd)
    {
        
    }

    public override void SetInteraction(GameObject interactableObj, bool isGoingToTheCar = false)
    {
        
    }
}
