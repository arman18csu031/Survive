using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INVENTDISPLAY : MonoBehaviour
{
    inventory Inventory;
    public Dictionary<InventotySlot, GameObject> dic = new Dictionary<InventotySlot, GameObject>();
    void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    void Update()
    {
        UpdateDisplay();
    }
    void UpdateDisplay()
    {
        for (int i = 0; i < Inventory.container.Count; i++)
        {
            if(dic.ContainsKey(Inventory.container[i]))
            {
                Inventory.container[i].amount++;
            }
            else
            {
                GameObject instance = Instantiate(Inventory.container[i].item.ImagePrefab, Vector3.zero, Quaternion.identity, transform); ;
                dic.Add(Inventory.container[i],instance) ;
            }
        }
    }
}
