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
    public GameObject Monster;

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
        AffectMonster();
    }

    public void ClosePanel()
    {
        restorePillarsPanel.SetActive(false);
    }

    public void AffectMonster()
    {
        int currentRepairedPillard = 0;
        for (int i = 0; i < pillarsList.Count; i++)
        {
            if(pillarsList[i].GetComponent<Pillar>().isRepaired)
            {
                currentRepairedPillard ++;
            }
            if(currentRepairedPillard == 3)
            {
                Destroy(Monster);
            }
        }
        Monster.transform.localScale -= new Vector3(2,0,2);
    }
}
