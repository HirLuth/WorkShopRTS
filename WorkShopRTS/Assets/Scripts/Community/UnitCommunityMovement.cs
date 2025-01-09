using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitCommunityMovement : MonoBehaviour
{
    [SerializeField]
    private CommunityPatrol communityPatrol;
    NavMeshAgent agent;

    public bool isPatroling;
    private float distance;
    public Vector3 unitPatrolPoint;
    public bool isArrived;
   // [HideInInspector]
    public int IndexInHierarchy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IndexInHierarchy = transform.GetSiblingIndex();
        agent = GetComponent<NavMeshAgent>();
        communityPatrol = transform.parent.parent.GetComponent<CommunityPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(unitPatrolPoint,transform.position);
        if(distance <= 2)
            {
                if(isArrived == false)
                {
                    isArrived = true;
                    communityPatrol.CheckChildren();
                }
            }

        if(isPatroling)
        {
            agent.SetDestination(unitPatrolPoint);
        }
    }

    public void newPatrolPoint(GameObject parentPatrolPoint)
    {
        unitPatrolPoint = parentPatrolPoint.transform.position;
        isArrived = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if(other.CompareTag("UnitPlayerClan"))
        {
            Debug.Log("Detect");
            GameObject.Find("CommunityManager").GetComponent<CommunityManager>().AddNewMemberClanPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("UnitPlayerClan"))
        {
            GameObject.Find("CommunityManager").GetComponent<CommunityManager>().AddNewMemberClanPanel.SetActive(false);
        }
    }
}
