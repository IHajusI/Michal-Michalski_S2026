using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// ewidentnie rozbić na pojedyńcze skrypty kiedy już będzie gra robiona

public class ProstePoruszanie : MonoBehaviour
{
    //dwa "suwaczki" sprawiające że można zmienić wartość siły skoku i szybkość w inspektorze bez wchodzenia w skrypt
    // dodanie zmiennej tutaj również powoduje jej stworzenie, nie potrzeba tego robić oddzielnie
    public Rigidbody2D body;
    [Header("Poruszanie w osi X")]
    [SerializeField, Range(0f, 40f)][Tooltip("szybkość")] public float moveSpeed = 10f;


    [Header("Poruszanie w osi Y")]
    [SerializeField, Range(0f, 100f)][Tooltip("moc skoku")] public float maxJump = 10f;
    [SerializeField, Range(0f, 1f)][Tooltip("jak duży jest skok przy szybkim wciśnięciu klawisza")] public float maxTapJump = 1f;

    [Header("Sprawdzanie kolizji z ziemią")]
    public Transform groundCheckPozycja;
    public Vector2 groundCheckRozmiar = new Vector2(0.4f, 0.05f);
    public LayerMask groundLayer;
    // transform reprezentuje dane na temat pozycji, rotacji i rozmiaru obiektu do którego jest "przylepiony
    // vector tu robi jako "linijka", rozmiar pudełka który będzie sprawdzał kolizje. czyli jego jeden i drugi bok
    // VECTOR TO NIE KIERUNEK SAM W SOBIE, tylko trzyma dane w OSIACH KIERUNKU, więc 0.5f to pół "jednostki" w prawo 
    // a 0.05f to tyle w górę, wartości ujemne byłyby w drugą stronę
    // a LayerMask dopisać jeszcze co to


    //zmienna horizontalMovement to ruch w osi X, jego wartość zależy od sekcji linijek po 42
    //Vector2 to dana która przechowuje dwie liczby, X i Y
    float horizontalMovement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
       
    
    }

    void Update ()
    { //przy każdej klatce gry prędkość w osi X jest ustawiana jako horizontal movement razy zmienna moveSpeed (oś y jest w trybie "odczytaj i zostaw jak jest")
        body.velocity = new Vector2(horizontalMovement * moveSpeed, body.velocity.y);
       

    }
    // LEWO PRAWO
    public void Move(InputAction.CallbackContext context)
    {//horizontalMovement = *zczytaj* wartość x z Vectora2
        horizontalMovement = context.ReadValue<Vector2>().x;
        
    }
    // SKOK
    public void Jump(InputAction.CallbackContext context)
    {// .performed znaczy jeśli dany context został wypełniony (przycisk został wciśnięty)
        //rigidbody sprawia że gracz opada (grawitacja) input skoku tylko dodaje mu tymczasową siłę pchającą do góry
        // lewa i prawa część nawiasu to prędkości w osiach x i y, wpisanie po prostu "body.velocity" znaczy "odczytaj jaka jest teraz i neich tak zostanie
        // a wpisanie zmiennej takiej jak maxJump po prawej sprawia że czyta to właśnie z tej zmiennej
        if (isGrounded())
        {
            if (context.performed)
            {
                body.velocity = new Vector2(body.velocity.x, maxJump);
                Debug.Log(context.performed + " trzymany");
            
            }
            else if (context.canceled)
            {
                body.velocity = new Vector2(body.velocity.x, body.velocity.y * maxTapJump);
                Debug.Log(context.canceled + "wciśnięty");
            }

            //UNITY NIE WIDZI WCIŚNIĘCIA SAMEGO, DO NAPRAWY
        

        }
        
    }
    // ta zmienna zmienia wartość kiedy gracz dotyka ziemii
    private bool isGrounded()
    {
        if(Physics2D.OverlapBox(groundCheckPozycja.position, groundCheckRozmiar, 0, groundLayer))
        {
            return true;
        }
        else return false;
    }

    // sekcja sprawdzania czy jesteśmy na ziemii
    // gizmos to mały box, aktualnie podłączony do "create empty" pod nazwą GroundCheck
    //pierwsza linia ustawia kolor, druga jego pozycję i rozmiar 
    //JESZCZE nic nie robi poza istnieniem
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPozycja.position, groundCheckRozmiar);
    }


   


}
