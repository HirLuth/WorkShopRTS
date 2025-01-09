using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


public class CommunityPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    public List<GameObject> patrolPoints = new List<GameObject>();
    public List<GameObject> unitChild = new List<GameObject>();
    private int currentPatrolIndex = 0;
    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < unitChild.Count; i++)
        {
            unitChild[i].GetComponent<UnitCommunityMovement>().unitPatrolPoint = patrolPoints[0].transform.position;
            unitChild[i].GetComponent<UnitCommunityMovement>().isPatroling = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckChildren()
    {
        float countValid = 0;
        for(int i = 0; i < unitChild.Count; i++)
        {
            if(unitChild[i].GetComponent<UnitCommunityMovement>().isArrived == true)
            {
                countValid ++;
            }
            else
            {
                countValid = 0;
                return;
            }
        }

        if(countValid == unitChild.Count)
        {
            currentPatrolIndex ++;
            if(currentPatrolIndex > patrolPoints.Count - 1)
            {
                currentPatrolIndex = 0;
            }

            for(int i = 0; i < unitChild.Count; i++)
            {
                unitChild[i].GetComponent<UnitCommunityMovement>().newPatrolPoint(patrolPoints[currentPatrolIndex]);
            }
        }
    }

     private IEnumerator WaitAndLeave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        currentPatrolIndex += 1;
        if(currentPatrolIndex > patrolPoints.Count)
        {
            currentPatrolIndex = 0;
        }
    }
}
