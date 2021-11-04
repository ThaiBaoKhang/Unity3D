using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveHandle : MonoBehaviour
{

    public CharacterController controller;

    private Animator ant;

    public float speed = 10f;

    public float gravity = -9.8f;

    public float jumpHeight = 3f;

    Vector3 velocity1;

    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        ant = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity1.y < 0)
        {
            velocity1.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity1.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity1.y += gravity * Time.deltaTime;

        controller.Move(velocity1 * Time.deltaTime);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            ant.SetInteger("AniRun", 1);
        }
        else
        {
            ant.SetInteger("AniRun", 0);
        }

        if (!isGrounded)
        {
            ant.SetInteger("AniJump", 1);
            ant.SetInteger("AniDes", 1);
            ant.SetInteger("AniLand", 1);
        }
        else
        {
            ant.SetInteger("AniJump", 0);
            ant.SetInteger("AniDes", 0);
            ant.SetInteger("AniIdle", 1);
            
        }


    }
}
