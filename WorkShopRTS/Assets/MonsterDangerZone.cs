using UnityEngine;

public class MonsterDangerZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("UnitPlayerClan"))
        {
            // Search bool ( true ) and function damage in Unit script
            Debug.Log("Damage");
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("UnitPlayerClan"))
        {
            // Search bool (false ) and function damage in Unit script
            Debug.Log("DamageStop");
        }
    }
}
