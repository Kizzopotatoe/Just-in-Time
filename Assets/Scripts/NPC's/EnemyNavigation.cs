using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float checkDistance = 0.5f;
    public Transform target;

    [Header("Effects"), HideInInspector]
    private MinionEffects minionEffects;

    // Start is called before the first frame update
    void Start()
    {
        minionEffects = GetComponent<MinionEffects>();
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
            minionEffects.SpawnBlastEffect();

            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void TimeSlow()
    {
        agent.speed = 1.5f;
    }
    public void TimeUnslow()
    {
        agent.speed = 3.5f;
    }
}
