using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreToInventory : MonoBehaviour
{
    public static StoreToInventory instance;

    private void Awake()
    {
        instance = this;
    }

    public  List<Item> AllItems = new List<Item>();


}
