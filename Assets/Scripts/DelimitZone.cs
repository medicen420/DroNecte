using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelimitZone : MonoBehaviour
{
    //[SerializeField] Color col;
    
   

    //Cuando el Drone está volando muy alto
    private void OnTriggerEnter(Collider other)
    {
        //Si el player está dentro del trigger
        //ejecuta el siguiente código
        if(other.gameObject.tag == "Player")
        {
            print("<color=#FDAA00> ¡Cuidado que te está torciendo la puerca! </color>");
            //Al pasar 3 segundo con el Player en el trigger 
            //Se manda llamar al método que carga nuestra escena GameOver
            Invoke("LimitZone", 5);

        }

    }

    //Cuando el drone ya no está volando muy alto
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Se manda cancelar el llamado del método
            //siempre y cuando el drone ya no se encuentre dentro del Trigger
            CancelInvoke("LimitZone");
            //Comentario en consola 
            print("<color=#00A0FB> ¡Eso estuvo cerca! </color>");
            //Debug.Log("Ya no te wachan los puercos");

        }
    }


    public void LimitZone()
    {
        
        print("<color=#C61301> ¡Ya te torcieron los puercos! </color>");
        SceneManager.LoadScene("GameOver");

    }



}
