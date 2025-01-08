/*using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public RectTransform selectionBox;
    public LayerMask unitLayerMask;

    private List<Unit> selectedUnits = new List<Unit>();
    private Vector2 startPos;

    [Header("Componenent")]
    private Camera cam;
    private Player player;

    void Awake() 
    {
        cam = Camera.main;
        player = GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ToggleSelectionVisual(false);
            selectedUnits = new List<Unit>();

            TrySelect(Input.mousePosition);
            startPos = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {

        }
        if(Input.GetMouseButton(0))
        {
            UpdateSelectionBox(Input.mousePosition);
        }
    }

    void TrySelect(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, unitLayerMask))
        {
            Unit unit = hit.collider.GetComponent<Unit>();

            if(Player.isMyUnit(unit))
            {
                selectedUnits.Add(unit);
                unit.ToggleSelectionVisual(true);
            }
        }
    }

    void UpdateSelectionBox(Vector2 curMousePos)
    {
        if(!selectionBox.gameObject.activeInHierarchy)
        selectionBox.gameObject.SetActive(true);

        float width = curMousePos.x - startPos.x;
        float height = curMousePos.y - startPos.y;

        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = startPos + new Vector2(width / 2, height / 2);
    }

    void ToggleSelectionVisual(bool selected)
    {
        foreach(Unit unit in selectedUnits)
        {
            unit.ToggleSelectionVisual(selected);
        }
    }
} */
