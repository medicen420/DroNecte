using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Handler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //Me acabo de dar cuenta de que esta es la forma en la que 
        //podemos tener multiples collisiones en el mismo script
        switch (other.gameObject.tag)
        {
                //Case #1
            case "Friendly":
                Debug.Log("This thing is Friendly");
                break;

                //Case #2
            case "Finish":
                Debug.Log("You finish");
                break;

                //Case #3
            case "Point":
                Debug.Log("You have a point");
                break;

                //Si no es ninguno de los casos anteriores entonces
                //ejecuta por default lo siguiente
            default:
                ReloadLevel();
                break;


        }
       
    }


    void ReloadLevel()
    {
        //L�nea de c�digo que me permite abrir una de las escenas
        //mediante el tipeo de n�mero de escena o el nombre en s�

        //SceneManager.LoadScene(0);

        //Estas l�neas de c�digo b�sicamente vuelven a cargar la escena que esta
        //activa en ese momento 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
