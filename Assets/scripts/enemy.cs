using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    player play;

    public Transform Destination;

    private bool isWalk;
    public bool isPunch;
    private bool eDead;
    private bool isPower;

  

    public Slider eHealthbar;
    public Slider eEnergybar;

    public float ehealth;
    

    private float eElapsedTime = 0f, efixedTime = 2f;
    public float eEnergy = 100f;
    public float eEnergyIncreaseFactor = 10f;

    //--------------------------------------------------------------------MOVEMENT-----------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        play = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();




        ehealth = 100;


        isWalk = false;
        isPunch = false;
        isPower = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isWalk = true;
        }

    }

    // Update is called once per frame


    void afterIdle()
    {
        isWalk = true;
    }

    public void Update()
    {
        if (play != null)
        {

            if (isWalk)
            {
                anim.SetFloat("speed", agent.velocity.magnitude);
                var navAgent = GetComponent<NavMeshAgent>();
                navAgent.SetDestination(Destination.position);
            }

            if (ehealth == 0f)
            {
                anim.SetBool("eDead", true);
            }

            if (play.isDead == true)
            {
                Debug.Log("player is dead");
                agent.isStopped = true;
                anim.SetBool("isPunch", false);
                anim.SetBool("isWalk", false);
                anim.SetFloat("speed", 0.0f);
            }

            eHealthbar.value = ehealth / 100f;
        }

        
    }
//--------------------------------------------------------------------------------ACTIONS----------------------------------------------------------------------------------------------------
    private void OnTriggerStay(Collider other)
    {
            var dis = Vector3.Distance(gameObject.transform.position, other.transform.position);
            Debug.Log(dis);
            if (dis <= 3.9f)
            {
                isWalk = false;
                anim.SetBool("isPunch", true);
                Debug.Log("is walk is false");
            }

            else
            {
                isWalk = true;
                anim.SetBool("isPunch", false);

            }
        eEnergy = Mathf.Clamp(eEnergy, 0, 100);
        if (eElapsedTime > efixedTime)
        {
            eEnergy += eEnergyIncreaseFactor;
            eElapsedTime = 0f;
        }
        else
            eElapsedTime += Time.deltaTime;

        ewithEnergy();
    }
//-----------------------------------------------------------------------------ENEMYHEALTH-------------------------------------------------------------------------------------------------------
    public void EminusHealth(float edamage)
    {
        ehealth = ehealth - edamage;
        eHealthbar.value = ehealth / 100f;

        if(ehealth == 0)
        {
            anim.SetBool("imDead", true);
            agent.isStopped = true;
            anim.SetBool("isPunch", false);
            anim.SetBool("isWalk", false);
            anim.SetFloat("speed", 0.0f);

        }
    }

   
    public void ewithEnergy()
    {   
        eEnergybar.value = eEnergy / 100f;
        if (eEnergy >= 50)
        {
            anim.SetBool("isPower", true);
            anim.SetBool("isPunch", false);
            eEnergy -= 30f;
        }

        else
            anim.SetBool("isPower", false);
    }

}






