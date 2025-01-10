using Inventories_and_Ressources;
using UnityEngine;
using UnityEngine.UIElements;

public class CommunityManager : MonoBehaviour
{
    [SerializeField]
    private Transform playerCommunity;
    public Material playerUnitMat;
    [SerializeField]
    private FogOfWarScript fogOfWarScript;

    public int amountToEnrole = 100;

    public GameObject AddNewMemberClanPanel;
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
       if (PlayerInventory.instance.ressources[(int)RessourcesManager.Ressource.Food] >= amountToEnrole)
       {
           PlayerInventory.instance.RemoveResources(RessourcesManager.Ressource.Food, amountToEnrole);
           CommunityPatrol comPatrol = newMember.transform.parent.parent.GetComponent<CommunityPatrol>();
           UnitCommunityMovement unitMove = newMember.GetComponent<UnitCommunityMovement>();

           Destroy (unitMove);
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
           newMember.tag = "UnitPlayerClan";
           fogOfWarScript.playerList.Add(newMember.transform);
       }

       
   }
}

