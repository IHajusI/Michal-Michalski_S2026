using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> dane = new List<int> { 1, 3, 3, 1, 2, 2, 3, 1, 3, 2 };
        List<int> jedynki = new List<int>();
        List<int> dwojki = new List<int>();
        List<int> trojki = new List<int>();

        foreach (int i in dane)
        {
            if (i == 1)
            {
                jedynki.Add(i);
               


            }
            else if (i == 2)
            {
                dwojki.Add(i);
             


            }
            else if (i == 3)
                trojki.Add(i);
        
    
        }

        dane.Clear();
        Debug.Log("Jedynki: " + jedynki.Count);
        Debug.Log("Dwojki: " + dwojki.Count);
        Debug.Log("Trojki: " + trojki.Count);
        Debug.Log("Dane: " + dane.Count);


    }

   
}
