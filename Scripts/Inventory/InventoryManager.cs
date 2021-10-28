using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory;
    public GameObject slotPanel;

    private int allSlots; 
    private int enabledSlots;
    private GameObject[] slot;

    void Start()
    {
        allSlots = slotPanel.transform.childCount; // Valor = 18
        slot = new GameObject[allSlots];

        for (int i = 0; i < this.allSlots; i++)
        {
            slot[i] = slotPanel.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().isEmpty = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
            inventory.SetActive(inventoryEnabled);

            //if (!inventoryEnabled)
            //{
            //    inventory.SetActive(true);
            //    inventoryEnabled = true;
            //}
            //else
            //{
            //    inventory.SetActive(false);
            //    inventoryEnabled = false;
            //}
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item" ) // other.CompareTag("Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
            AddItem(itemPickedUp, item.ID, item.type, item.info, item.icon);
        }
    }

    public void AddItem(GameObject item, int ID, string type, string info, Sprite icon)
    {
        for (int i = 0; i < this.allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().isEmpty)
            {
                item.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().createSlot(item, ID, type, info, icon);

                item.transform.parent = slot[i].transform;
                item.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                return;
            }
        }
    }
}
