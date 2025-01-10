using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    public Transform terrain;
    private float terrainWidth = 200;
    private float terrainHeight = 200;
    private Vector3 currentGoal;
    [SerializeField]
    private GameObject carPlayer; 
    [SerializeField]
    private float percentagePlayerTarget = 0f;
    private float percentageRandomTarget = 100f;

    [HideInInspector]
    public bool isChasing;
    private GameObject currentTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToPosition();
    }

    void Update()
    {
       float distance = Vector3.Distance(currentGoal,transform.position);
       if(distance <= 7 )
       {
         GoToPosition();
       }
       if(isChasing)
       {
         agent.SetDestination(currentTarget.transform.position);
       }
    }

    public void GoToPosition()
    {
        float percentage = Random.Range(0,percentageRandomTarget);
        if(percentage <= percentagePlayerTarget)
        {
            Vector3 goalPos = carPlayer.transform.position;
            agent.SetDestination(goalPos);
            currentGoal = goalPos;
            percentagePlayerTarget = 0;
        }
        else
        {
            Vector3 goalPos = new Vector3(Random.Range(0, terrainWidth),0,Random.Range(0, terrainHeight));
            agent.SetDestination(goalPos);
            currentGoal = goalPos;
            percentagePlayerTarget += 10;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("UnitPlayerClan"))
        {
            isChasing = true;
            currentTarget = col.gameObject;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("UnitPlayerClan"))
        {
            isChasing = false;
            currentTarget = null;
            GoToPosition();
        }
    }
}
