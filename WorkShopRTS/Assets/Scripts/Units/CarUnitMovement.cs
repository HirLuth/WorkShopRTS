using Inventories_and_Ressources;
using UnityEngine;

public class CarUnitMovement : UnitMovement
{
    private Vector3 destination;
    private float timerFuel;
    public float tickFuel = 1;
    
    
    protected override void Update()
    {
        if (!isMovingAlone)
        {
            if(Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                    {
                        agent.SetDestination(hit.point);
                    }
                    if(hit.transform.gameObject.layer == LayerMask.NameToLayer("RessourcePool"))
                    {
                        agent.SetDestination(hit.point);
                    }
                }

                if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    Debug.Log("ground");
                    agent.SetDestination(hit.point);
                }
            }

            if (agent.velocity.magnitude > 0.1f)
            {
                timerFuel += Time.deltaTime;
                if (timerFuel >= tickFuel)
                {
                    timerFuel = 0;
                    PlayerInventory.instance.DrainFuel();
                }
                
            }

            if (PlayerInventory.instance.ressources[1] == 0)
            {
                agent.speed = 0;
            }
            else
            {
                agent.speed = selfUnit.moveSpeed;
            }
        }
    }
}
