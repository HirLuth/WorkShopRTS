using UnityEngine;

public class DayAndNightLogic : MonoBehaviour
{
    [SerializeField]
    private LightingManager lightingManager;
    public bool isDayRessource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightingManager = GameObject.Find("LightingManager").GetComponent<LightingManager>();
        lightingManager.ressourcesList.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
