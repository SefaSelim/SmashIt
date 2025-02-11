using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{
      public Transform target; 

    void Update()
    {
        if (target != null)
        {
           
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
