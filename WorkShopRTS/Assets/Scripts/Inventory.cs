using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Main Resources")] 
    private List<int> ressources;

    private void Start()
    {
        ressources = new List<int>();
        for (int i = 0; i < RessourcesManager.instance.numberOfRessources; i++)
        {
            ressources.Add(0);
        }
    }

    public virtual void AddResources(RessourcesManager.Ressource ressourceToAdd, int amountToAdd)
    {
        ressources[(int)ressourceToAdd] += amountToAdd;
    }

    public virtual void RemoveResources(RessourcesManager.Ressource ressourceToRemove, int amountToRemove)
    {
        ressources[(int)ressourceToRemove] -= amountToRemove;
    }
}
