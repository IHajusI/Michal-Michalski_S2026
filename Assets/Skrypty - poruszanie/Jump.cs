using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [Header("Zmienne")]
    // rigidbody już wpisanie w skrypcie "Move L2R" ale tutaj też chce z jakiegoś powodu
    public Rigidbody2D body2d;
    [Header("Suwaki")]
    [SerializeField, Range(0f, 20f)][Tooltip("Siła skoku trzymanego")] public float maxJump = 10f;
    [SerializeField, Range(0f, 1f)][Tooltip("Siła skoku wciśniętego")] public float maxTapJump = 0.5f;

    [Header("Zmienne do sprawdzania kolizji z ziemią")]
    public Transform groundCheckPozycja;
    public Vector2 groundCheckRozmiar = new Vector2(0.7f, 0.05f);
    public LayerMask groundLayer;
    int maxJumpCount = 1;
    int jumpsRemaining;


     //SKAKANIE
     void Update()
    {
        GroundCheck();
    }

 
    public void Jumping(InputAction.CallbackContext context)
    { 
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                body2d.velocity = new Vector2(body2d.velocity.x, maxJump);
                jumpsRemaining--;
                Debug.Log(context.performed + " trzymany");
            }
            else if (context.canceled)
            {
                body2d.velocity = new Vector2(body2d.velocity.x, body2d.velocity.y * maxTapJump);
                jumpsRemaining--;
                Debug.Log(context.canceled + " wciśnięty");
            }
        }
      
           
    }
    // SPRAWDZANIE KOLIZJI Z ZIEMIĄ
    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPozycja.position, groundCheckRozmiar, 0, groundLayer))
        {
            jumpsRemaining = maxJumpCount;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPozycja.position, groundCheckRozmiar);
    }
}
