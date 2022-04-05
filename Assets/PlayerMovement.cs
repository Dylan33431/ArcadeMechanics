using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public bool IsSprinting = false;
    public float SprintingMultiplier;

    public Transform GroundCheck;
    public float GroundDistance = 0.5f;
    public LayerMask GroundMask;

    Vector3 velocity;
    bool isGrounded;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            IsSprinting = true;
        }
        else
        {
            IsSprinting = false;
        }


        Vector3 Move = transform.right * x + transform.forward * z;

        if (IsSprinting == true)
        {
            Move *= SprintingMultiplier;
        }

        controller.Move(Move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
