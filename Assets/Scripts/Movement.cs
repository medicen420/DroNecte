using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    //No necesitamos que nos devuelvan nada, por lo que tendremos
    //que poner solo void
    void ProcessThrust()
    {
        //Mientras se mantenga presionada la tecla
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed SPACE - TRUE");
        }

        
    }

    void ProcessRotation()
    {

        //GIRAR IZQUIERDA
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("ROTATE LEFT");
        }

        //GIRAR DERECHA
        //Else if se puede considerar como: "De otra manera"
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("ROTATE RIGHT");
        }
    }
}
