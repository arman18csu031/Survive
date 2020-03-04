using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("enemy1"))
        {
            other.GetComponent<enemy>().EminusHealth(5f);
            Debug.Log("health reduced");
            
        }
    }
}
