using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Quit_Game_Dronecte();

    }

    private static void Quit_Game_Dronecte()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("You press Escape");
            Application.Quit();
        }
    }
}
