using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class PillarsSystem : MonoBehaviour
{
    public List<GameObject> pillarsList = new List<GameObject>();
    public GameObject currentPillar;
    public Mesh repairedMesh;
    public GameObject restorePillarsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RepairPillar()
    {
        currentPillar.GetComponent<Pillar>().isRepaired = true;
        currentPillar.GetComponent<MeshFilter>().sharedMesh = repairedMesh;
        restorePillarsPanel.SetActive(false);
    }

    public void ClosePanel()
    {
        restorePillarsPanel.SetActive(false);
    }
}
