using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class UnitSelectionManager : MonoBehaviour
{

    public static UnitSelectionManager Instance { get; set;}

    [Header("List")]
    public List<GameObject> allUnitsList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();
    public List<GameObject> RessourcesList = new List<GameObject>();

    [Header("Click Variable")]
    public LayerMask clickable, ground, ressourcePool, fogOfWar, carLayer;
    public GameObject groundMarker;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !UIManager.instance.isInMenu)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            // If we are hitting a clickable object
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable) || Physics.Raycast(ray, out hit, Mathf.Infinity, carLayer))
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    MultiSelect(hit.collider.gameObject);
                }
                else
                {
                    SelectByClicking(hit.collider.gameObject);
                }
            }
            // If we are NOT hitting a clickable object
            else
            {
                if(Input.GetKey(KeyCode.LeftShift) == false)
                {
                    DeselectAll();
                    if (UnitCanvas.UnitCanvasOpen != null)
                    {
                        UnitCanvas.UnitCanvasOpen.ShowOrder(false);
                    }
                }
            }
        }

        // If you Click on the ground
         if(Input.GetMouseButtonDown(1) && unitsSelected.Count > 0)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            // If we are hitting a clickable object
            if(Physics.Raycast(ray, out hit, Mathf.Infinity,ground))
            {

                    GroundSelection(hit);
                    ClearRessourceList();
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ressourcePool) || Physics.Raycast(ray, out hit, Mathf.Infinity, carLayer))
            {
                    RessourcesSelection(hit);
            }
            
        }

        // Fog Of war Clickable
 /*        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            // If we are hitting a clickable object
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, fogOfWar))
            {
                GroundSelection(hit);
            }
        } */
    }

    // Selection Function for each layer
    public void GroundSelection(RaycastHit hit)
        {
            groundMarker.SetActive(false);
            groundMarker.SetActive(true);
            groundMarker.transform.position = hit.point;
            foreach (var unit in unitsSelected)
            {
                unit.GetComponent<Unit>().ExitInteraction(Unit.State.Moving);
            }
        }
    public void RessourcesSelection(RaycastHit hit)
        {
            groundMarker.SetActive(false);
            groundMarker.transform.position = hit.point;
            RessourcesList.Add(hit.transform.gameObject);
            hit.transform.GetChild(0).gameObject.SetActive(true);
            foreach (var unit in unitsSelected)
            {
                unit.GetComponent<Unit>().SetInteraction(hit.collider.gameObject);
            }
        }
    private void ClearRessourceList()
    {
        foreach(var ressource in RessourcesList)
        {
            ressource.transform.GetChild(0).gameObject.SetActive(false);
        }
        RessourcesList.Clear();
    }

    private void SelectByClicking(GameObject unit)
    {
        // Reset the selection and select the new element
        DeselectAll();
        unitsSelected.Add(unit);

        SelectUnit(unit, true);
    }

    // Select Function 
    // Make appear the indicator and allow the movement of element
    private void SelectUnit(GameObject unit, bool isSelected)
    {
        TriggerSelectionIndicator(unit, isSelected);
        EnableUnitMovement(unit,isSelected);
        Unit currentUnit = unit.GetComponent<Unit>();
        currentUnit.isSelected = isSelected;
        if (isSelected)
        {
            currentUnit.ExitInteraction(Unit.State.Moving);
        }
    }
    // Function of the selection reset 
    public void DeselectAll()
    {
        foreach(var unit in unitsSelected)
        {
            SelectUnit(unit, false);
        }
        
        groundMarker.SetActive(false);
        unitsSelected.Clear();

        ClearRessourceList();
    }
    // Multi selection
    private void MultiSelect(GameObject unit)
    {
        if(unitsSelected.Contains(unit) == false)
        {
            unitsSelected.Add(unit);
            SelectUnit(unit, true);
        }
        else
        {
            SelectUnit(unit, false);
            unitsSelected.Remove(unit);
        }
    }

    // Select function with drag
    internal void DragSelect(GameObject unit)
    {
        if(unitsSelected.Contains(unit) == false)
        {
            unitsSelected.Add(unit);
            SelectUnit(unit, true);
        }
   }

    // Allow movement
    public void EnableUnitMovement(GameObject unit, bool shouldMove)
    {
        unit.GetComponent<UnitMovement>().enabled = shouldMove;
    }

    // Make appear the indicator of unit
    private void TriggerSelectionIndicator(GameObject unit, bool isVisible)
    {
        unit.transform.GetChild(0).gameObject.SetActive(isVisible);
    }
}
