using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour
{
    //Esta es la variable que contiene el tiempo de retraso
    //para volver a cargar el nivel de juego
    [SerializeField] float levelLoadDelay = 2f;



    
    
    //Clip de audios para cuando llegamos a la meta final
    [SerializeField] AudioClip succes;
    //Clip de audio para cuando choque nuestro Drone
    [SerializeField] AudioClip crash;

    AudioSource audioSource;


    //Si actualmente estamos en transici�n, entonces nmo hagas nada
    [SerializeField] bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other)
    {
        //Si no estamos en transici�n
        //manda a ejecutar el c�digo

        //1er forma de hacerlo
        /* if(isTransitioning == false)
         {

         }*/

        //2da forma de hacerlo

        //Si estamos en transici�n
        //no ejecutes nada de este m�todo
        if (isTransitioning)
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

    void StarSuccesSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(succes);
        //Haremos el retraso en el tiempo para agregar un fx sonido al chocar
        //Y agregar efecto de particulas al chocar
        GetComponent<Movement>().enabled = false;   
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        //Buscamos nuestro componente Movement para desactivarlo cuando 
        //choquemos nuestro drone, de este modo el jugador ya no podr� controllar el drone.
        GetComponent<Movement>().enabled = false;

        Invoke("ReloadLevel", levelLoadDelay);
        
    }

    

    //M�todo que se encarga de cargar el siguiente nivel
    //B�sicamente son las mismas l�neas de c�digo que el m�todo "ReloadLevel"
    //solamente agregamos un "+1" para que de este modo pueda decir que vamos a cargar la escena actual
    //m�s 1 que ser�a la que le sigue
    void LoadNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Ahora estas l�neas de c�digo me permiten volver a reiniciar desde nivel 0 
        //en caso de que hayamos recorrido todos los niveles que existen en el juego


        //Nuestro indice de estado actual
        //b�sicamente el n�mero de la escena que est� activada en este momento + 1
        int nextSceneIndex = currentSceneIndex + 1;


        //Si el indice de la siguiente escena es igual al n�mero de escenas que hay en buildsettings
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
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
