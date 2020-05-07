using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class Player : MonoBehaviour
{
    public Text CollectText;
    public Text CollectText2;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 1.2f;
    private PlayerHealth playerhealth;
    public bool isClimb;
    public Animator anim;
    public BoxCollider ladClimb;
    public float jumpSpeed = 40f;
    private bool IsCollided= false;
    public GameObject Gem;
    public GameObject FakeGem;
    private bool IsHit= false;
    public GameObject GemCo;
    public Text GameOver;
    private bool IsWrong;
    public Image Bar;
    public GameObject Particle;
    public GameObject Sparkling;
    private AudioSource audio;
    public AudioClip Chime;
    public AudioClip robin;
    public AudioClip wronggem;
    public AudioClip sword;
    private void Awake()
    {
        Sparkling.SetActive(false);
        Particle.SetActive(false);
        controller = GetComponent<CharacterController>();
       
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        playerhealth = GetComponent<PlayerHealth>();
        CollectText.gameObject.SetActive(false);
        CollectText2.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
    }


    void Update()
    {



        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
                Invoke("Jump", 1f);
            }
            
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Jump", false);
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

        if(Input.GetKeyDown(KeyCode.F))
        {
            isClimb = true;
            controller.enabled = false;
            anim.SetBool("Climb", true);
            
           
        }
        else if(Input.GetKeyUp(KeyCode.F))
        {
            isClimb = false;
            controller.enabled = true;
            anim.SetBool("Climb", false);
        }

        if (!isClimb)
        {
            moveDirection.y -= 6f;
            controller.Move(moveDirection * speed * Time.deltaTime);
            var magnitude = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
            anim.SetFloat("Speed", magnitude);
        }
        else
        {
            transform.Translate(Vector3.up * 1.02f * Time.deltaTime);
        }




        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Slash",true);            
            Invoke("Slash", 1.4f);
            audio.PlayOneShot(sword);
        }
       
        if(Input.GetMouseButtonDown(1))
        {
            anim.SetBool("ComboAttack", true);
            Invoke("ComboAttack", 3.1f);
        }       

        

        if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("Crouch", false);
        }
       
        if(IsCollided)
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                Destroy(Gem);
                GameOver.gameObject.SetActive(true);
                GemCo.GetComponent<Exit>().GemCollected = true;
                Sparkling.SetActive(true);
                audio.PlayOneShot(Chime);
            }
        }

        if (IsWrong)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Destroy(FakeGem);
                Invoke("GameEnd", 6f);
                Particle.SetActive(true);
                anim.SetBool("Death", true);
                audio.PlayOneShot(wronggem);
            }
        }

       /* if (IsHit)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                playerhealth.IncreaseHealth(food.Health);
                playerhealth.IncreaseHealth(firstAid.Health);

                Destroy(gameObject);
            }
        }*/

        Bar.fillAmount = playerhealth.Health / 100;
        if(playerhealth.Health == 0f)
        {
            anim.SetBool("Death", true);
            Invoke("GameEnd", 3f);
            audio.PlayOneShot(robin);
        }
    }

    private void GameEnd()
    {
         SceneManager.LoadScene("EndScene");
         //Debug.Log("New Scene Opeing....");     
    }
    private void Jump()
    {
        moveDirection.y = jumpSpeed;
    }
    private void Slash()
    {
        anim.SetBool("Slash", false);
    }

    private void ComboAttack()
    {
        anim.SetBool("ComboAttack", false);
    }

    private void Run()
    {
        anim.SetBool("Run", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gem"))
        {
            CollectText.gameObject.SetActive(true);
            IsCollided = true;
        }

        if (other.gameObject.CompareTag("Fake"))
        {
            CollectText2.gameObject.SetActive(true);
            IsWrong = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Gem"))
        {
            CollectText.gameObject.SetActive(false);
            IsCollided = false;            
        }

        if (other.gameObject.CompareTag("Fake"))
        {
            CollectText2.gameObject.SetActive(false);
            IsWrong = false;
        }
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var food = hit.gameObject.GetComponent<Eatables>();
        var firstaid = hit.gameObject.GetComponent<FirstAid>();
        if(food && firstaid)
        {
            Debug.Log("Collided");
            playerhealth.IncreaseHealth(food.health);
            playerhealth.IncreaseHealth(firstaid.health);
        }
    }*/
}
