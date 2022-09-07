using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour
{
    //Esta es la variable que contiene el tiempo de retraso
    //para volver a cargar el nivel de juego
    [SerializeField] float levelLoadDelay = 3f;



    //Clip de audios para cuando llegamos a la meta final
    [SerializeField] AudioClip succes;
    //Clip de audio para cuando choque nuestro Drone
    [SerializeField] AudioClip crash;


    //Part�culas
    [SerializeField] ParticleSystem succesParticles;
    //Clip de audio para cuando choque nuestro Drone
    [SerializeField] ParticleSystem crashParticles;



    AudioSource audioSource;



    //Si actualmente estamos en transici�n, entonces no hagas nada
    [SerializeField] bool isTransitioning = false;

    bool collisionDisabled = false;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {

    }

   

    void OnCollisionEnter(Collision other)
    {

        //Si estamos en transici�n
        //no ejecutes nada de este m�todo
        if (isTransitioning || collisionDisabled)
            return;

        //Me acabo de dar cuenta de que esta es la forma en la que 
        //podemos tener multiples collisiones en el mismo script
        switch (other.gameObject.tag)
        {
            //Case #1
            //Base inicial 
            case "Friendly":
                Debug.Log("This thing is Friendly");
                break;

            //Case #2
            //Base final
            case "Finish":

                Debug.Log("You finish");
                StarSuccesSequence();

                break;


            //Si no es ninguno de los casos anteriores entonces
            //ejecuta por default lo siguiente
            default:

                //Ahora vamos a agregar un ligero retraso de tiempo 
                //antes de que se cargue el m�todo

                //Para ello usamos Invoke
                StartCrashSequence();

                break;
        }



    }


    //M�todo para cuando nuestro Drone haya llegado a la meta final
    void StarSuccesSequence()
    {
        //Las part�culas se activan cuando llegamos a la plataforma
        succesParticles.Play();
        //Nuestra booleana se convierte en true
        //esto es para que ya no se gener� ning�n sonido 
        //cuando hayamos concluido nuestro nivel de juego
        isTransitioning = true;
        //
        audioSource.Stop();
        audioSource.PlayOneShot(succes);
        //Haremos el retraso en el tiempo para agregar un fx sonido al chocar
        //Y agregar efecto de particulas al chocar
        GetComponent<Movement>().enabled = false;




        //Ajustaremos el c�digo para que se desbloque el siguiente nivel de juego
        //una vez que hayamos entregado todas las bolsas de weed y hayamos llegado a la 
        //landingpad (plataforma de aterrizaje)


        //Para ello crear� diferentes escenas

        //Escena de niveles
        //en esta escena incluiremos todos los niveles de juego que existen dentro del juego



        //Mandamos llamar al siguiente nivel de juego
        Invoke("LoadNextLevel", levelLoadDelay);
    }



    //*********************************************
    //M�todo para cuando nuestro Drone haya chocado
    void StartCrashSequence()
    {
        //TimeL.SetActive(true);
        crashParticles.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        //Buscamos nuestro componente Movement para desactivarlo cuando 
        //choquemos nuestro drone, de este modo el jugador ya no podr� controllar el drone.
        GetComponent<Movement>().enabled = false;


        //Mandamos llamar de nuevo al mismo nivel de juego
        Invoke("ReloadLevel", levelLoadDelay);

    }



    //M�todo que se encarga de cargar el siguiente nivel
    //B�sicamente son las mismas l�neas de c�digo que el m�todo "ReloadLevel"
    //solamente agregamos un "+1" para que de este modo pueda decir que vamos a cargar la escena actual
    //m�s 1 que ser�a la que le sigue
    public void LoadNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Ahora estas l�neas de c�digo me permiten volver a reiniciar desde nivel 0 
        //en caso de que hayamos recorrido todos los niveles que existen en el juego


        //Nuestro indice de estado actual
        //b�sicamente el n�mero de la escena que est� activada en este momento + 1
        int nextSceneIndex = currentSceneIndex + 1;


        //Si el indice de la siguiente escena es igual al n�mero de escenas que hay en buildsettings
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            //Entonces nextSceneIndex equivale a 0 que ser�a mi primer nivel de juego
            nextSceneIndex = 0;

        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    //M�todo para cargar una escena
    //en este caso cargaremos de nuevo el nivel si hay una colisi�n diferente a las 
    //que existen en el switch
    void ReloadLevel()
    {
        //L�nea de c�digo que me permite abrir una de las escenas
        //mediante el tipeo de n�mero de escena o el nombre en s�

        //SceneManager.LoadScene(1);

        //Estas l�neas de c�digo b�sicamente vuelven a cargar la escena que esta
        //activa en ese momento 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    





}
