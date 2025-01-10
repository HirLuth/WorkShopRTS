using UnityEngine;
using UnityEngine.UI;

public class Pillar : MonoBehaviour
{
    [SerializeField]
    public PillarsSystem pillarsSystem;
    public bool isRepaired;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pillarsSystem = transform.parent.GetComponent<PillarsSystem>();
        pillarsSystem.restorePillarsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Car") && !isRepaired)
        {
            pillarsSystem.restorePillarsPanel.SetActive(true);
            pillarsSystem.currentPillar = transform.gameObject;
        }
    }
    private void OnTriggerExit(Collider col) 
    {
        if(col.CompareTag("Car") && !isRepaired)
        {
            pillarsSystem.restorePillarsPanel.SetActive(false);
        }
    }
}
