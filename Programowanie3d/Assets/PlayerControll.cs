using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed = 10f;
    CharacterController controller;
    [SerializeField] Camera cam;
    float fovDefault = 70;

    public float climbingSpeed = 2f;

    Vector3 velocity;
    public float gravity = (-9.81f);

    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundRayDistance = 0.4f;
    bool IsGrounded = false;
    bool CanClimb = false;
    public float highJump = 3f;
    float gravityConstant = -2f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
        Move();
        Sprint();
        Jump();
        Gravity();

    }


    public void Move()
    {
        float dirx = Input.GetAxis("Horizontal");
        float dirz = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * dirz * speed * Time.deltaTime + transform.right * dirx * speed * Time.deltaTime;
        controller.Move(move);
    }

    public void Gravity()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundRayDistance, groundMask);
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(highJump * gravityConstant * gravity);
        }

        
    }

    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
            cam.fieldOfView = 90;
            Debug.Log("Sprinting");
        }
        else
        {
            speed = 10f;
            cam.fieldOfView = fovDefault;

        }
    }

    void RayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1.5f))
        {
            //Debug.Log(hit.transform.gameObject.name);
            //Debug.Log(hit.collider.gameObject.layer);
            if (hit.transform.gameObject.layer == 6)
            {
                CanClimb = true;
                if(Input.GetKey(KeyCode.Space) && CanClimb)
                {
                    velocity.y = climbingSpeed;
                }
            }
            else
            {
                CanClimb = false;
            }
        }
    }
}
