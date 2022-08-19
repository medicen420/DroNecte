using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delimit_Posicion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Regresa al nivel de juego");
            //Mandamos llamar al método después de 3 segundos, este se encargará
            //de Cargar la escena de "te saliste del nivel de juego"
            Invoke("FueradelNivel", 3);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("El jugador regresó a la zona de juego");
            CancelInvoke("FueradelNivel");
        }
    }


    public void FueradelNivel()
    {
        //Si el jugador permanece 3 segundos fuera del Nivel de juego pierde
        Debug.Log("Game Over");
        SceneManager.LoadScene("Over_ZoneGame");
    }

}
