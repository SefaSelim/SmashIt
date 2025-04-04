using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextWave : MonoBehaviour
{
  public void StoreToWave()
    {
        SceneManager.LoadScene("Combined");
    }
}
