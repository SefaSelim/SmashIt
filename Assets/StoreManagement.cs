using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManagement : MonoBehaviour
{
    public Item Item;

    [SerializeField] Image Image;
    [SerializeField] TextMeshProUGUI Price;
    [SerializeField] TextMeshProUGUI Description;


    private void Start()
    {
        Image.sprite = Item.itemSprite;
        Price.text = Item.Price.ToString();
        Description.text = Item.Description.ToString();
    }
}
