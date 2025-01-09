using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RessourcePool : Interactible
{
    public RessourcesManager.Ressource ressourceToGive;
    public int numberOfRessourcesToGive;
    public int maxPossessed;
    public int currentPossessed;
    public float harvestSpeed;
    private float timer;

    private void Start()
    {
        currentPossessed = maxPossessed;
    }

    private void Update()
    {
        if (isInteractedWith)
        {
            if (timer >= harvestSpeed)
            {
                foreach (var unit in unitsInteracting)
                {
                    int toGive = Mathf.Clamp(numberOfRessourcesToGive, 0, currentPossessed);
                    currentPossessed -= toGive;
                    unit.inventory.AddResources(ressourceToGive, toGive);
                }

                if (currentPossessed==0)
                {
                    List<Unit> units = unitsInteracting.ToList();
                    foreach (var unit in units)
                    { 
                        unit.ExitInteraction(Unit.State.Still);
                        unit.BackToBase();
                    }
                    gameObject.SetActive(false);
                }
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            timer = 0;
        }
    }
}
