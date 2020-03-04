using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    private CharacterController characterController;
    private Animator animator;
    inventory Inventory;
    
    
    private Vector3 moveDirection = Vector3.zero;

    public float walkSpeed = 5f;
    public float rotationSpeed = 30.0f;
    public float jumpSpeed = 20.0f;
    public float sprintSpeed = 20.0f;
    public float health;
    public float hunger;


    public Slider healthbar;
    public Slider hungerbar;
    public Slider Energybar;

   

    
    private bool canJump;
    private bool canSprint;
    private bool canPunch;
    private bool canKick;
    public bool isDead;

    private float speed;
    private float rotX, rotY;

    private float ElapsedTime = 0f, fixedTime = 2f;
    public float Energy = 0f;
    public float EnergyIncreaseFactor = 10f;

    


    //public GameObject popup;


    private void Start()
    {
        health = 100;
        hunger = 0;

        canSprint = false;
        canPunch = false;
        canKick = false;

        InvokeRepeating("updateHungerLevel", 5.0f, 5.0f);
        Inventory = GetComponent<inventory>();

    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    //---------------------------------------------------------------PLAYERMOVEMENT-----------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        speed = walkSpeed;
        canSprint = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            canSprint = true;
        }

        Debug.Log(characterController.isGrounded);

        if (characterController.isGrounded && !isDead)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            animator.SetFloat("speed", characterController.velocity.magnitude);
        }

            Debug.Log(characterController.velocity);


            if (Input.GetKeyDown(KeyCode.Space))
            {

                animator.SetBool("canJump", true);
                moveDirection.y = jumpSpeed;
            }


            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("canJump", false);
            }

            if (Input.GetMouseButtonDown(0))
            {

                Debug.Log("hit");
                animator.SetBool("canPunch", true);
            }

            if (Input.GetMouseButtonUp(0))
            {

                Debug.Log("didn'thit");
                animator.SetBool("canPunch", false);
            }

          
//--------------------------------------------------------------------------MOUSEROTATION--------------------------------------------------------------------------------------------
        if (!isDead)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0));

            moveDirection.y -= 9.8f * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);

            var magnitude = new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;
            animator.SetFloat("speed", magnitude);
            animator.SetBool("canSprint", canSprint);

            rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
            rotY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
            if (rotX < -90)
            {
                rotX = -90;
            }
            else if (rotX > 90)
            {
                rotX = 90;
            }
            transform.rotation = Quaternion.Euler(0, rotY, 0);
            GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        }

        Energy = Mathf.Clamp(Energy, 0, 100);
        if (ElapsedTime > fixedTime)
        {
            Energy += EnergyIncreaseFactor;
            ElapsedTime = 0f;
        }
        else
            ElapsedTime += Time.deltaTime;

        withEnergy();

    }
//----------------------------------------------------------------------PLAYER HEALTH SYSTEM---------------------------------------------------------------------------------------------
            void OnControllerColliderHit(ControllerColliderHit hit)
            {
              
                healthbar.value = health / 100f;
                if (hit.gameObject.CompareTag("Food"))
                {
                  //  Inventory.add(hit.gameObject.GetComponent<ItemScript>().item, 1);
                    Destroy(hit.gameObject);
                    health += 10;
                   
                   
                }

                if (hit.gameObject.CompareTag("cactus"))
                {
                    health -= 1;
                }
                

                hungerbar.value = hunger / 100f;

                if (health == 0f)
                {
                    Debug.Log("player is dead");
                    animator.SetBool("isDead", true);
                    isDead = true;
                    
                    
                }

                else
                    animator.SetBool("isDead", false);

            }
            public void minusHealth(float damage)
            {
                health = health - damage;
            }


//-------------------------------------------------------------------HUNGER SYSTEM----------------------------------------------------------------------------------------
    public void increaseHungerLevel(int factor)
    {
        hunger = Mathf.Clamp(hunger + factor, 0, 100);
    }

    public void decreaseHungerLevel(int factor)
    {
        hunger = Mathf.Clamp(hunger - factor, 0, 100);
    }

    public void updateHungerLevel()
    {
        increaseHungerLevel(10);
        if (hunger >= 80)
        {
            health -= 10;
        }
    }  

    public void powerMove()
    {
        Energybar.value = Energy / 100f;
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("canKick", true);
            Energy -= 30f;
        }

        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("canKick", false);
        }
    }
    public void withEnergy()
    {
        if (Energy >= 50)
        {
            powerMove();
        }
    }

}
       
    




