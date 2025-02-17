using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdder : MonoBehaviour
{
    public static ItemAdder instance;

    private void Start()
    {
        instance = this;
    }

    public GameObject ItemPrefab;

    public void AddItem(Item Item)
    {
        ItemHandler itemHandler = ItemPrefab.GetComponent<ItemHandler>();
        itemHandler.Item = Item;
        Instantiate(ItemPrefab, transform);


    }
}
