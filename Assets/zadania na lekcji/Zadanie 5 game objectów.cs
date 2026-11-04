using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5gameobjectów : MonoBehaviour
{
    public List<GameObject> obiekty = new List<GameObject>();
    [Header("Zmienne")]
    public int devide;
    public Gradient gr;
    public float angle = 15;

     void Start()
    {
        SortowanieObiektow();
      
    }

    void SortowanieObiektow()
    {
        foreach (GameObject obiekt in obiekty)

            if (obiekt.GetComponent<SpriteRenderer>() != null)
            {
                Debug.Log(obiekt.name + " 2D");
                Sprite(obiekt.GetComponent<SpriteRenderer>());
            }
            else if (obiekt.GetComponent<MeshRenderer>() != null)
            {
                Debug.Log(obiekt.name + " 3D");
                Cube(obiekt.transform);
                
            }

    }
    //1. nazwa funkcji 2. komponent 3. nazwa zmiennej tworzonej przez nią
     void Sprite(SpriteRenderer sprite)
     {
        sprite.color = gr.Evaluate(sprite.gameObject.transform.position.y / devide);
     }


    void Cube(Transform tran)
    {
        tran.Rotate(angle, 0, 0);
        tran.position = new Vector3(tran.position.x, tran.position.y + 1 *Time.deltaTime, tran.position.z); 
    }

    void Update () 
    {
       SortowanieObiektow();
    }
     
   

    
       
   
  
  
   
}