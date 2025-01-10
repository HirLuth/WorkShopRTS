using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UnitCanvas : MonoBehaviour
{
    public static UnitCanvas UnitCanvasOpen;
    private Quaternion _baseRotation;
    public Image hydratationJauge;
    public Image lifeJauge;
    public GameObject orderMenu;

    private void Start()
    {
        _baseRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = _baseRotation;
    }

    public void UpdateLifeJauge(float life, float maxLife)
    {
        lifeJauge.fillAmount = (float)life/(float)maxLife;
    }
    
    public void UpdateHydratationJauge(int hydratation, int maxHydratation)
    {
        hydratationJauge.fillAmount = (float)hydratation/(float)maxHydratation;
    }
    
    public void ShowOrder(bool show)
    {
        orderMenu.SetActive(show);
        if (show)
        {
            if (UnitCanvasOpen != null)
            {
                UnitCanvasOpen.ShowOrder(false); 
            }
            UnitCanvasOpen = this;
        }
    }

    public void OnDrinkPressed()
    {
        Debug.Log("OnDrinkPressed");
        OrderManager.instance.GiveOrder(OrderManager.Orders.Drink);
        ShowOrder(false);
        UnitCanvasOpen = null;
        UIManager.instance.isInMenu = false;
    }
    
    public void OnBuildPressed()
    {
        OrderManager.instance.GiveOrder(OrderManager.Orders.Build);
        ShowOrder(false);
        UnitCanvasOpen = null;
        UIManager.instance.isInMenu = false;
    }
}
