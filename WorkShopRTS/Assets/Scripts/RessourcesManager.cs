using System;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesManager : MonoBehaviour
{
    public static RessourcesManager instance;

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

    public enum Ressource
    {
        Water,
        Fuel,
        Iron,
        Food
    }
    public int numberOfRessources = 4;
}
