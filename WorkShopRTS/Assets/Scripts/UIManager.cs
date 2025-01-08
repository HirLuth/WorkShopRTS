using System;
using System.Collections.Generic;
using Inventories_and_Ressources;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public List<TMP_Text> ressourcesTexts;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateRessources(RessourcesManager.Ressource ressourceToUpdate)
    {
        ressourcesTexts[(int)ressourceToUpdate].text = PlayerInventory.instance.ressources[(int)ressourceToUpdate].ToString();
    }
}
