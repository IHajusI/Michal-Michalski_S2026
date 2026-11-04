using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveL2R : MonoBehaviour
{
    [Header("Zmienne")]
    public Rigidbody2D body2d;
    float horizontalMovement;
    private float direction;
    bool isFacingRight = true;


    [Header("Suwaki")]
    [SerializeField, Range(0f, 10f)][Tooltip("Szybkość ruchu")] public float maxSpeed = 5f;




    // na starcie zgarnij komponent rigidbody
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    // obliczanie prędkości w każdej klatce gry i sprawdzaj czy postać patrzy w prawo czy w lewo funkcją Turn
    void Update()
    {
        body2d.velocity = new Vector2(horizontalMovement * maxSpeed, body2d.velocity.y);
        // jeśli poruszasz się w prawo (zmieniasz pozycję na osi x dodatnio ORAZ zmienna "CzyPatrzęWPrawo" opkazuje false (że patrzę w lewo)
        //użyj funkcji Turn
        if (horizontalMovement > 0f && !isFacingRight)
        {
            Turn();
        }
        else if (horizontalMovement < 0f && isFacingRight)
        {
            Turn();
        }

    }
    // logika przerkęcająca gameObject Gracza na drugą stronę
    void Turn()
        //vector3 to dane na temat gracza currentTurn to nadana nazwa tej danej, gameobject.trans.local to jak wchodzenie w foldery w folderach, szukając konkretnego pliku
        //currentTurn.x zmienia wartość obrotu w osi mnożąc ją przez -1, obracając go
    {
        Vector3 currentTurn = gameObject.transform.localScale;
        currentTurn.x *= -1;
        gameObject.transform.localScale = currentTurn;

        isFacingRight = !isFacingRight;
    }
      //zczytanie wciśnięcia przycisku z InputSsytem
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }



}  