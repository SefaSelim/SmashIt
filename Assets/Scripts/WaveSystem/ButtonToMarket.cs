using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToMarket : MonoBehaviour
{
    public void ChangeTheScreen()
    {
        SceneManager.LoadScene (sceneName: "Inventory");
    }
}
