using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public int maxPopulation;
    [HideInInspector] public List<Unit> unitsInteracting;
    [HideInInspector] public bool isInteractedWith;

    void Interact(Unit unit)
    {
        unitsInteracting.Add(unit);
        isInteractedWith = true;
    }

    void StopInteracting(Unit unit)
    {
        unitsInteracting.Remove(unit);
        if (unitsInteracting.Count == 0)
        {
            isInteractedWith = false;
        }
    }
}


