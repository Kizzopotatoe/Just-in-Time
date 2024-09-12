using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;

    private Rigidbody myRigidbody;
    private Vector3 velocity;

    public Animator animator;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = inputVector.normalized;
        velocity = direction * moveSpeed;

        transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);

        if(inputVector.x != 0 || inputVector.z != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
