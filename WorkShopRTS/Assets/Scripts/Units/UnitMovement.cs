using Inventories_and_Ressources;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{

    protected Camera cam;
    protected NavMeshAgent agent;
    public LayerMask ground, ressourcePool;
    public bool isMovingAlone;
    protected Unit selfUnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        selfUnit = GetComponent<Unit>();

        agent.speed = selfUnit.moveSpeed;
    }

    // Update is called once per frame
    protected virtual void Update()
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

    public void GoBackToTheCar()
    {
        agent.destination = PlayerInventory.instance.unitObjSelfReference.transform.localPosition;
    }

    public void StopGoingToTheCar()
    {
        agent.destination = transform.position;
    }
}
