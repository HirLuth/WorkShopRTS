using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{

    private Camera cam;
    NavMeshAgent agent;
    public LayerMask ground, ressourcePool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
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
        }
    }
}
