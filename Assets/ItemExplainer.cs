using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemExplainer : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = StaticItemExplainer.Explanation;
    }

}
