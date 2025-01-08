using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform terrain;
    private float terrainWidth = 100;
    private float terrainHeight = 100;
    private Vector3 currentGoal;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToPosition();
    }

    void Update()
    {
       float distance = Vector3.Distance(currentGoal,transform.position);
       if(distance <= 1 )
       {
         GoToPosition();
       }
    }

    private void GoToPosition()
    {
        Vector3 goalPos = new Vector3(Random.Range(0, terrainWidth),0,Random.Range(0, terrainHeight));
        Debug.Log(goalPos);
        agent.SetDestination(goalPos);
        currentGoal = goalPos;
    }
}
