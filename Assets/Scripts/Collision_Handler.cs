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


    //Partículas
    [SerializeField] ParticleSystem succesParticles;
    //Clip de audio para cuando choque nuestro Drone
    [SerializeField] ParticleSystem crashParticles;



    AudioSource audioSource;



    //Si actualmente estamos en transición, entonces no hagas nada
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

        //Si estamos en transición
        //no ejecutes nada de este método
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
                //antes de que se cargue el método

                //Para ello usamos Invoke
                StartCrashSequence();

                break;
        }



    }


    //Método para cuando nuestro Drone haya llegado a la meta final
    void StarSuccesSequence()
    {
        //Las partículas se activan cuando llegamos a la plataforma
        succesParticles.Play();
        //Nuestra booleana se convierte en true
        //esto es para que ya no se generé ningún sonido 
        //cuando hayamos concluido nuestro nivel de juego
        isTransitioning = true;
        //
        audioSource.Stop();
        audioSource.PlayOneShot(succes);
        //Haremos el retraso en el tiempo para agregar un fx sonido al chocar
        //Y agregar efecto de particulas al chocar
        GetComponent<Movement>().enabled = false;




        //Ajustaremos el código para que se desbloque el siguiente nivel de juego
        //una vez que hayamos entregado todas las bolsas de weed y hayamos llegado a la 
        //landingpad (plataforma de aterrizaje)


        //Para ello crearé diferentes escenas

        //Escena de niveles
        //en esta escena incluiremos todos los niveles de juego que existen dentro del juego



        //Mandamos llamar al siguiente nivel de juego
        Invoke("LoadNextLevel", levelLoadDelay);
    }



    //*********************************************
    //Método para cuando nuestro Drone haya chocado
    void StartCrashSequence()
    {
        //TimeL.SetActive(true);
        crashParticles.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        //Buscamos nuestro componente Movement para desactivarlo cuando 
        //choquemos nuestro drone, de este modo el jugador ya no podrá controllar el drone.
        GetComponent<Movement>().enabled = false;


        //Mandamos llamar de nuevo al mismo nivel de juego
        Invoke("ReloadLevel", levelLoadDelay);

    }



    //Método que se encarga de cargar el siguiente nivel
    //Básicamente son las mismas líneas de código que el método "ReloadLevel"
    //solamente agregamos un "+1" para que de este modo pueda decir que vamos a cargar la escena actual
    //más 1 que sería la que le sigue
    public void LoadNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Ahora estas líneas de código me permiten volver a reiniciar desde nivel 0 
        //en caso de que hayamos recorrido todos los niveles que existen en el juego


        //Nuestro indice de estado actual
        //básicamente el número de la escena que está activada en este momento + 1
        int nextSceneIndex = currentSceneIndex + 1;


        //Si el indice de la siguiente escena es igual al número de escenas que hay en buildsettings
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            //Entonces nextSceneIndex equivale a 0 que sería mi primer nivel de juego
            nextSceneIndex = 0;

        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    //Método para cargar una escena
    //en este caso cargaremos de nuevo el nivel si hay una colisión diferente a las 
    //que existen en el switch
    void ReloadLevel()
    {
        //Línea de código que me permite abrir una de las escenas
        //mediante el tipeo de número de escena o el nombre en sí

        //SceneManager.LoadScene(1);

        //Estas líneas de código básicamente vuelven a cargar la escena que esta
        //activa en ese momento 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    





}
