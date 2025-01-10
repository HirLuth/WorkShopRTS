using System;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;

    public enum Orders
    {
        Drink,
        Build
    }

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GiveOrder(Orders.Drink);
        }
    }

    public void GiveOrder(Orders order)
    {
        switch (order)
        {
            case Orders.Drink: DrinkOrder();
                break;
            case Orders.Build: BuildOrder();
                break;
        }
    }

    private void DrinkOrder()
    {
        foreach (var currentUnitObj in UnitSelectionManager.Instance.unitsSelected)
        {
            currentUnitObj.GetComponent<Unit>().Drink();
        }
    }
    
    private void BuildOrder()
    {
        
    }
}
