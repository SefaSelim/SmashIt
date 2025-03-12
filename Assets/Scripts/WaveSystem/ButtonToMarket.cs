using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToMarket : MonoBehaviour
{
    public void ChangeTheScreen()
    {
       StoreManaging.Instance.Onclick();
    }
}
