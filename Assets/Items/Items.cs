using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Inventory/Item")]
public class Items :ScriptableObject
{
    public string Itemname;
    public float weight;
    public float healthIncrease;
    public float HungerDecrease;
    public GameObject ImagePrefab;
    [TextArea(1,3)]
    public string Description;
   // public void Use()
    //{
        //GameObject.FindGameObjectWithTag("Player").GetComponent<player>().healthIncrease(healthIncrease);
    //}
}
