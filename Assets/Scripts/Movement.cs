using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rgb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;

    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();

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
        //Input.GetKey - Mientras se mantenga presionada la tecla
        if (Input.GetKey(KeyCode.Space))
        {
            rgb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            //Si no estás reproduciendo el audio...
            //entonces reprodúcelo
            if (!aud.isPlaying)
            {
                aud.Play();
            }
            
        }
        else
        {
            aud.Stop();
        }
       
        
        
        

        
    }

    void ProcessRotation()
    {

        //GIRAR IZQUIERDA
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }

        //GIRAR DERECHA
        //Else if se puede considerar como: "De otra manera"
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        //Estamos diciendo que estamos congelando la rotación para 
        //poder rotar manualmente
        rgb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rgb.freezeRotation = false; //Estamos descongelnado la rotación para que el sistema
        //de física pueda hacerse cargo
    }
}
