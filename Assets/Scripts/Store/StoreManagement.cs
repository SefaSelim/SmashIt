using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class StoreManagement : MonoBehaviour
{
    public Item Item;

    [SerializeField] Image Image;
    [SerializeField] TextMeshProUGUI Price;
    [SerializeField] TextMeshProUGUI Description;


    private void Start()
    {
      SpawnNewItem();
    }

    public void BoughtItem()
    {
        if (PlayerStats.CoinAmount >= Item.Price)
        {
            PlayerStats.CoinAmount -= Item.Price;
            ItemAdder.instance.AddItem(Item);



            gameObject.SetActive(false);
        }
        else
        {
            //COULDNT BUY

        }
    }

    public void SpawnNewItem()
    {
        gameObject.SetActive(true);
        Item = StoreToInventory.instance.AllItems[Random.Range(0, StoreToInventory.instance.AllItems.Count)];

        Image.sprite = Item.itemSprite;
        Price.text = Item.Price.ToString();
        Description.text = Item.Description.ToString();

    }
}
