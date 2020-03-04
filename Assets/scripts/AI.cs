using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform Destination;
    public GameObject cubePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        var navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(Destination.position);
        
    }

    // Update is called once per frame
    void spawn()
    {
        var cubeprefabs = Instantiate(cubePrefab, new Vector3(954.64f, 467.19f, 830.6f), Quaternion.identity);
    }
}
