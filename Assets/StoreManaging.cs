using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class StoreManaging : MonoBehaviour
{
    [SerializeField] GameObject Store;
    private bool isOpen = false;
    public static StoreManaging Instance;

    private void Start()
    {
        Instance = this;
    }

    public void Onclick()
    {
        if (isOpen)
        {
            isOpen = !isOpen;
            Store.SetActive(false);

        }
        else
        {
            isOpen = !isOpen;
            Store.SetActive(true);
        }
    }

}
