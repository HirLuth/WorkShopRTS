using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public OrderManager.Orders order;
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.instance.isInMenu = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.instance.isInMenu = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        OrderManager.instance.GiveOrder(order);
    }
}
