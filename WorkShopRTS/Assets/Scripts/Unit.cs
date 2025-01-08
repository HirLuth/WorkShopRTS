using System;
using Inventories_and_Ressources;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum State
    {
        Still,
        Moving,
        MovingToInteract,
        Interacting,
    }
    
    public State state = State.Still;
    public GameObject currentInteractibleObj;
    public Interactible currentInteractible;
    [SerializeField] private Collider interactibleDetectionBox;
    
    [Header("Units Values")]
    public string UnitName;
    public int level;
    public float health;
    public float damage;
    public float moveSpeed;
    public float thirstValue;
    public UnitInventory inventory;
    
    void Start()
    {
        UnitSelectionManager.Instance.allUnitsList.Add(gameObject);
    }

    private void OnDestroy() 
    {
        UnitSelectionManager.Instance.allUnitsList.Remove(gameObject);
    }

    public void SetInteraction(GameObject interactableObj)
    {
        state = State.MovingToInteract;
        currentInteractibleObj = interactableObj;
        currentInteractible = interactableObj.GetComponent<Interactible>();
        interactibleDetectionBox.enabled = true;
        if (currentInteractible.currentPopulation == currentInteractible.maxPopulation)
        {
            Debug.Log("Too Many Units !!");
            ExitInteraction();
        }
    }

    public void ExitInteraction()
    {
        if (state == State.Interacting)
        {
            currentInteractible.StopInteracting(this);
        }
        currentInteractibleObj = null;
        interactibleDetectionBox.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("oui");
        if (other.gameObject == currentInteractibleObj)
        {
            state = State.Interacting;
            currentInteractible.Interact(this);
        }
    }
    
}
