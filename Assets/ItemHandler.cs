using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    public Item Item;


    Image image;
    Button button;

    public void ShowItemExplanation()
    {
             StaticItemExplainer.Explanation = Item.Description;
    }

    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        image.sprite = Item.itemSprite;
        button.onClick.AddListener(ShowItemExplanation);
    }

}