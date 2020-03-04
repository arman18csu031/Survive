using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    AudioSource audioSource;
    player p;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (p.isDead == false)
            {
                audioSource.Play();
            }
            if (p.health == 0f)
            {
                audioSource.Stop();
            }
        }
       
    }
}
