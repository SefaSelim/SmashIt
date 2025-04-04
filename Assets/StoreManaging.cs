using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Inventory");
    }

}
