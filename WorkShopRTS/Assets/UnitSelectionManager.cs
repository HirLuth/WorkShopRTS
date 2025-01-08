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

    [Header("Click Variable")]
    public LayerMask clickable;
    public LayerMask ground;
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
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            // If we are hitting a clickable object
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
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
                }
            }
        }


         if(Input.GetMouseButtonDown(1) && unitsSelected.Count > 0)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            // If we are hitting a clickable object
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
            }
        }
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
    private void EnableUnitMovement(GameObject unit, bool shouldMove)
    {
        unit.GetComponent<UnitMovement>().enabled = shouldMove;
    }

    // Make appear the indicator of unit
    private void TriggerSelectionIndicator(GameObject unit, bool isVisible)
    {
        unit.transform.GetChild(0).gameObject.SetActive(isVisible);
    }
}
