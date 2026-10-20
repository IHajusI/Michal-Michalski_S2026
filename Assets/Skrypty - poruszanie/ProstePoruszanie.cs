using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProstePoruszanie : MonoBehaviour
{

    public Rigidbody2D body;
    public float moveSpeed = 10f;

    float horizontalMovement;

    void Start()
    {

    }

    void Update()
    {
        body.velocity = new Vector2(horizontalMovement * moveSpeed, body.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        
    }




}
