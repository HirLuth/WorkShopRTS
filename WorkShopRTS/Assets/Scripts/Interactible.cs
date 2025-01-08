using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public int maxPopulation;
    public int currentPopulation;
    /*[HideInInspector]*/ public List<Unit> unitsInteracting;
    /*[HideInInspector]*/ public bool isInteractedWith;

    public void Interact(Unit unit)
    {
        if (currentPopulation < maxPopulation)
        {
            unitsInteracting.Add(unit);
            isInteractedWith = true;
            currentPopulation += 1;
        }
        else
        {
            Debug.Log("Max population reached");
        }
        
    }

    public void StopInteracting(Unit unit)
    {
        unitsInteracting.Remove(unit);
        if (unitsInteracting.Count == 0)
        {
            isInteractedWith = false;
        }
    }
}


