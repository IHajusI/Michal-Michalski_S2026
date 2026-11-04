using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    [Header("Zmienne do sprawdzania kolizji z ziemią")]
    public Transform groundCheckPozycja;
    public Vector2 groundCheckRozmiar = new Vector2 (0.7f, 0.05f);
    public LayerMask groundLayer;   
    

    private bool isOnGround()
    {
        if(Physics2D.OverlapBox(groundCheckPozycja.position, groundCheckRozmiar, 0, groundLayer))
        {
            return true;

        }
        else return false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPozycja.position, groundCheckRozmiar);
    }
}
