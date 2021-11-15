using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    // Declaración de variables referente a los objetos
    public GameObject item;
    public int ID;
    public string type;
    public string info;
    public Sprite icon;
    // Variables propias del Slot
    public bool isEmpty = true;
    public Transform slotIconGO;

    public void createSlot(GameObject item, int ID, string type, string info, Sprite icon)
    {
        this.item = item;
        this.ID = ID;
        this.type = type;
        this.info = info;
        this.icon = icon;
    }


    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
        isEmpty = false;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("Estoy usando este botón");
        UseItem();
    }


}
