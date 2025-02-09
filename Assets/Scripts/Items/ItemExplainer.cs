using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemExplainer : MonoBehaviour
{
    public TextMeshProUGUI ItemExplanation;

    //----silinecek----
    public TextMeshProUGUI AttackIncreaser;
    public TextMeshProUGUI HealthIncreaser;
    public TextMeshProUGUI SpeedIncreaser;
    //---silinecek---

    private void Update()
    {
        ItemExplanation.text = StaticItemExplainer.Explanation;


        //----silinecek----
        AttackIncreaser.text = StaticItemExplainer.AttackIncreaser.ToString();
        HealthIncreaser.text = StaticItemExplainer.HealthIncreaser.ToString();
        SpeedIncreaser.text = StaticItemExplainer.SpeedIncreaser.ToString();
        //----silinecek----
    }

}
