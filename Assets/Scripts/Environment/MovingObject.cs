using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private Transform waypoint;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);
    }

    public void TimeSlow()
    {
        speed = 1;
    }
    public void TimeUnslow()
    {
        speed = 3;
    }
}
