using UnityEngine;
using UnityEngine.AI;

public class CivilianNavigation : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float checkDistance = 0.05f;

    [SerializeField] private Transform targetWaypoint;
    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        targetWaypoint = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = targetWaypoint.position;

        if(Vector3.Distance(transform.position, targetWaypoint.position) < checkDistance)
        {
            Debug.Log("Waypoint Reached");
            targetWaypoint = GetNextWaypoint();
        }
    }

    //Returns the transform component of the next waypoint in the array
    private Transform GetNextWaypoint()
    {
        currentWaypointIndex++;
        if(currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }

        return waypoints[currentWaypointIndex];
    }
}
