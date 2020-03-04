using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public List<InventotySlot> container = new List<InventotySlot>();
    public void add(Items _item,int _amount)
    {
        bool ishave = false;
        for (int i = 0; i < container.Count; i++)
        {
            if(container[i].item==_item)
            {
                ishave = true;
                container[i].addAmount(_amount);
            }
        }
        if(!ishave)
        {
            container.Add(new InventotySlot(_item, _amount));
        }
    }
}
[System.Serializable]
public class InventotySlot
{
    public Items item;
    public int amount;
    public InventotySlot(Items _item,int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void addAmount(int _amount)
    {
        amount += _amount;
    }
}
