using UnityEngine;

public class CarUnitMovement : UnitMovement
{
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
                        Debug.Log(gameObject.name);
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
        }
    }
}
