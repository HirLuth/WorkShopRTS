using Inventories_and_Ressources;
using UnityEngine;

public class CommunityManager : MonoBehaviour
{
    [SerializeField]
    private Transform playerCommunity;
    public Material playerUnitMat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void AddNewMember(GameObject newMember)
   {
      CommunityPatrol comPatrol = newMember.transform.parent.parent.GetComponent<CommunityPatrol>();
      UnitCommunityMovement unitMove = newMember.GetComponent<UnitCommunityMovement>();

      unitMove.enabled = false;
      newMember.GetComponent<Unit>().enabled = true;
      newMember.GetComponent<UnitInventory>().enabled = true;

      for(int i = 0; i < comPatrol.unitChild.Count ; i++)
      {
        if(comPatrol.unitChild[i].gameObject == newMember)
        {
            comPatrol.unitChild.Remove(newMember);
        }
      }
      
      newMember.transform.SetParent(playerCommunity);
      newMember.GetComponent<MeshRenderer>().material = playerUnitMat;

      newMember.layer = 7;
   }
}

