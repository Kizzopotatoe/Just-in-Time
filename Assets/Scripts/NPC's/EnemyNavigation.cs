using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float checkDistance = 0.5f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) return;

        agent.destination = target.position;

        if(Vector3.Distance(transform.position, target.position) < checkDistance)
        {
            Debug.Log("Civilian Reached");
            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void TimeSlow()
    {
        agent.speed = 1.1f;
    }
    public void TimeUnslow()
    {
        agent.speed = 3.1f;
    }
}
