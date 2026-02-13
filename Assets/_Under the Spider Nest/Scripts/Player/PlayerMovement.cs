using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;

    float rotSpeed = 10f;

    private Animator animator;

    [SerializeField] LayerMask groundMask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();   
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(horizontal, 0, vertical);

        controller.Move(move * speed * Time.deltaTime);

        bool isMoving = move.magnitude > 0.01f;

        animator.SetBool("Walking", isMoving);
        UpddateAnimator(move);


	}

    void Rotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            Vector3 target = hit.point;

            target.y = transform.position.y;

            Vector3 direction = target - transform.position;

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
            }
        }

    }

    void UpddateAnimator(Vector3 movementVector)
    {
		animator.SetFloat("MoveX", movementVector.x);
		animator.SetFloat("MoveZ", movementVector.z);
	}

}
