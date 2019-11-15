using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 4;
    public float rotSpeed = 80;
    public float rot = 0f;
    float gravity = 8;

    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Animator animator;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (animator.GetBool("attacking") == true)
                {
                    return;
                }
                else if (animator.GetBool("attacking") == false)
                {
                    animator.SetBool("running", true);
                    animator.SetInteger("condition", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("running", false);
                animator.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
     
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void GetInput()
    {
        if (controller.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(animator.GetBool("running") == true)
                {
                    animator.SetBool("running", false);
                }
                if (animator.GetBool("running") == false)
                {
                    Attacking();
                }
            }
        }
    }
    void Attacking()
    {    
        StartCoroutine(AttackRoutine());       
    }
    IEnumerator AttackRoutine()
    {
        animator.SetBool("attacking", true);
        animator.SetInteger("condition", 2);
        yield return new WaitForSeconds(1);
        animator.SetInteger("condition", 0);
        animator.SetBool("attacking", false);
    }
}
