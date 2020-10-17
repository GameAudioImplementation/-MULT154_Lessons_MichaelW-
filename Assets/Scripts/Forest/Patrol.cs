using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public List<GameObject> waypoints;
    private const float WP_THRESHOLD = 3.0f;
    private GameObject currentWP;
    private NavMeshAgent agent;
    private int currentWPIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWP = GetNextWaypoint();
         agent.SetDestination(currentWP.transform.position);
    }

    // Update is called once per frame
    GameObject GetNextWaypoint(){ //restart list if index == max waypoint size
        if(currentWPIndex == waypoints.Count){
            currentWPIndex = 0;
        }
        else{
            currentWPIndex++;
        }
        return waypoints[currentWPIndex];
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, currentWP.transform.position) < WP_THRESHOLD){
            currentWP = GetNextWaypoint();
            agent.SetDestination(currentWP.transform.position);
        }
        
    }
}
