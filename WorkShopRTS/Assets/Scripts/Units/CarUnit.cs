using UnityEngine;

public class CarUnit : Unit
{
    protected override void Update()
    {
        if(isTakingDamage)
        {
            currentHealth -= sufferDamage * Time.deltaTime;
            unitCanvas.UpdateLifeJauge(currentHealth, maxHealth);
        }
    }
    

    public override void AddHydratation(int hydratationToAdd)
    {
        
    }

    public override void SetInteraction(GameObject interactableObj, bool isGoingToTheCar = false)
    {
        
    }
}
