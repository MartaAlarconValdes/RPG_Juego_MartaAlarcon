using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el puntero en el centro de la pantalla
        Cursor.visible = false; // Hace invisible el puntero
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
