using UnityEngine;
using UnityEngine.AI;


public class swampScript : MonoBehaviour
{
    public float baseValue, slowValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("UnitPlayerClan"))
        {
            other.GetComponent<NavMeshAgent>().speed = slowValue;
        }
    }
     private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("UnitPlayerClan"))
        {
            other.GetComponent<NavMeshAgent>().speed = baseValue;
        }
    }
}
