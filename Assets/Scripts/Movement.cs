using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    //Clip de audio para el motor del Drone
    [SerializeField] AudioClip mainEngine;
    //Sistema de part�culas de mi drone cuando est� volando
    [SerializeField] ParticleSystem mainEngineParticle;



    Rigidbody rgb;
    AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        

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
            StartThrusting();

        }
        else
        {
            StopThrusting();

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

    
    




    void StartThrusting()
    {
        rgb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        //Si no est�s reproduciendo el audio...
        //entonces reprod�celo
        if (!audioSource.isPlaying)
        {
            //Esta l�nea de c�digo sirve �nicamente si tenemos 
            //1 solo clip de audio 
            //aud.Play();

            //Pero queremos tener m�ltiples clips de audio
            audioSource.PlayOneShot(mainEngine);

        }
        //Se activa mi sistema de part�culas

        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }

    }

    


    private void StopThrusting()
    {
        audioSource.Stop();
        //Se desactiva mi sistema de part�culas
        mainEngineParticle.Stop();
    }

    

    void ApplyRotation(float rotationThisFrame)
    {
        //Estamos diciendo que estamos congelando la rotaci�n para 
        //poder rotar manualmente
        rgb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rgb.freezeRotation = false; //Estamos descongelnado la rotaci�n para que el sistema
        //de f�sica pueda hacerse cargo
    }
}
