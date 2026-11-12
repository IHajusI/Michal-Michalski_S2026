using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszanieLekcja : MonoBehaviour
{
    public float moveSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x + Time.deltaTime * moveSpeed * horizontal, transform.position.y + Time.deltaTime * moveSpeed * vertical, transform.position.z);

    
    }
}
