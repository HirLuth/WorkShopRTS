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
        MovingUnselected,
        Interacting
    }

    public bool isSelected;
    public State state = State.Still;
    public GameObject currentInteractibleObj;
    public Interactible currentInteractible;
    [SerializeField] private Collider interactibleDetectionBox;
    
    [Header("Units Values")]
    public string UnitName;
    public int level;
    public int currentHealth;
    public int maxHealth;
    public int damage;
    public float moveSpeed;
    public int maxHydratation;
    public int currentHydratation;
    public float heatValue;
    public UnitInventory inventory;
    public UnitMovement unitMovement;
    public UnitCanvas unitCanvas;
    
    private float _timerHydratation;
    public float tickDehydration;
    public int dehydrationConst;

    
    void Start()
    {
        UnitSelectionManager.Instance.allUnitsList.Add(gameObject);
        currentHydratation = maxHydratation;
    }
    
    private void Update()
    {
        _timerHydratation += Time.deltaTime;
        if (_timerHydratation >= tickDehydration)
        {
            _timerHydratation = 0;
            AddHydratation(- Mathf.RoundToInt(heatValue*dehydrationConst));
        }
    }

    public void AddHydratation(int hydratationToAdd)
    {
       ChangeHydratation(Mathf.Clamp(currentHydratation + hydratationToAdd ,0,maxHydratation));
    }

    public void ChangeHydratation(int newHydratation)
    {
        currentHydratation = newHydratation;
        unitCanvas.UpdateHydratationJauge(currentHydratation, maxHydratation);
        if (currentHydratation <= 0)
        {
            Death();
        }
    }
    
    

    private void OnDestroy() 
    {
        UnitSelectionManager.Instance.allUnitsList.Remove(gameObject);
    }

    public void SetInteraction(GameObject interactableObj, bool isGoingToTheCar = false)
    {
        state = isGoingToTheCar ? State.MovingUnselected : State.MovingToInteract;
        currentInteractibleObj = interactableObj;
        currentInteractible = interactableObj.GetComponent<Interactible>();
        interactibleDetectionBox.enabled = true;
        if (currentInteractible.currentPopulation == currentInteractible.maxPopulation)
        {
            Debug.Log("Too Many Units !!");
            ExitInteraction(State.Moving);
        }
    }

    public void ExitInteraction(State nextState)
    {
        if (state == State.Interacting)
        {
            currentInteractible.StopInteracting(this);
            if (currentInteractible.gameObject==PlayerInventory.instance.unitObjSelfReference)
            {
                unitMovement.enabled = false;
                unitMovement.isMovingAlone = false;
                unitMovement.StopGoingToTheCar();
            }
        }

        if (state == State.MovingUnselected)
        {
            unitMovement.enabled = false;
            unitMovement.isMovingAlone = false;
            unitMovement.StopGoingToTheCar();
        }
        currentInteractibleObj = null;
        interactibleDetectionBox.enabled = false;
        state = nextState;
    }

    public void BackToBase()
    {
        state = State.MovingUnselected;
        unitMovement.enabled = true;
        unitMovement.isMovingAlone = true;
        unitMovement.GoBackToTheCar();
        SetInteraction(PlayerInventory.instance.unitObjSelfReference,true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == currentInteractibleObj)
        {
            if (state==State.MovingToInteract || state == State.MovingUnselected)
            {
                state = State.Interacting;
            }
            currentInteractible.Interact(this);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
    
}
