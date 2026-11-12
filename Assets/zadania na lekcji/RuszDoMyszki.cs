using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuszDoMyszki : MonoBehaviour
{
    public bool follow;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            follow = !follow;
            
        }
        if (follow)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Vector3.back * 10;
        }

       

    }
}
