using UnityEngine;

public class Unit : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
