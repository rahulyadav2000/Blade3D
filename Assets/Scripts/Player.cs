using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 1.2f;

    public Animator anim;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
      
    }

   
    void Update()
    {
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 1.7f;
            anim.SetBool("Run", true);            
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 1.7f;
            anim.SetBool("Run", false);
        }

        moveDirection.y -= 7.1f;
        controller.Move(moveDirection * speed * Time.deltaTime);
        var magnitude = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
        anim.SetFloat("Speed", magnitude);

       
        

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Slash",true);
            Invoke("Slash", 1.4f);
        }
       
        if(Input.GetMouseButtonDown(1))
        {
            anim.SetBool("ComboAttack", true);
            Invoke("ComboAttack", 3.1f);
        }       

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
            Invoke("Jump", 3.2f);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("Crouch", false);
        }
       
    }

    void Jump()
    {
        anim.SetBool("Jump", false);
    }
    void Slash()
    {
        anim.SetBool("Slash", false);
    }

    void ComboAttack()
    {
        anim.SetBool("ComboAttack", false);
    }

    void Run()
    {
        anim.SetBool("Run", false);
    }
        
}
