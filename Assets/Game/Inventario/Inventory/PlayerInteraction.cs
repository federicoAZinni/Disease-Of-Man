using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Inventory inventory;
    public Inventory equipment;

    public void OnTriggerEnter(Collider other)
    {
        var groundItem = other.GetComponent<GroundItem>();
        if (groundItem)
        {
            Item _item = new Item(groundItem.item);
            if (inventory.AddItem(_item, 1))
            {
                Destroy(other.gameObject);
            }
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown("s"))
    //    {
    //        inventory.SaveItems();
    //        equipment.SaveItems();
    //    }
    //    if (Input.GetKeyDown("l"))
    //    {
    //        inventory.LoadItems();
    //        equipment.LoadItems();
    //    }
    //}

    //private void OnApplicationQuit()
    //{
    //    inventory.Container.Clear();
    //    equipment.Container.Clear();
    //}
}