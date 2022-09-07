using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //Esta es una bolsita de weed
    //public GameObject Bolsita_1;

    public GameObject[] bolsitas;
    string bolsas_weed = "bolsitas";
    public int touch_drone;


    // Start is called before the first frame update
    void Start()
    {

        bolsitas = GameObject.FindGameObjectsWithTag(bolsas_weed);
        
    }


    // Update is called once per frame
    void Update()
    {
        ControlDelivery();

    }

    public void ControlDelivery()
    {
        //Si presionamos la flecha abajo 
        //ejecutamos el método Deliverweed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            touch_drone++;
            if(touch_drone == 1)
            {
                Deliverweed();
            }
            else if(touch_drone == 2)
            {
                Deliverweed_2();
            }
            else
            {
                Debug.Log("Ya no hay merca");
            }
        }
    }





    public void Deliverweed()
    {
        bolsitas[0].GetComponent<Pos_weed>().enabled = false;
        bolsitas[0].AddComponent<Rigidbody>();
        bolsitas[0].GetComponent<Rigidbody>().useGravity = true;
        //bolsitas[0].AddComponent<Rigidbody>();

        if (touch_drone == 2)
        {
            Deliverweed_2();
        }
        //-----------------------
    }

    public void Deliverweed_2()
    {
        bolsitas[1].GetComponent<Pos_weed>().enabled = false;
        bolsitas[1].AddComponent<Rigidbody>();
        bolsitas[1].GetComponent<Rigidbody>().useGravity = true;
    }




    //MÉTODO #1
    /* public void Deliverweed()
     {
         //Comentario en consola
         print("<color=#468C27> Ahí va la mosh madre </color>");

         //Desactivamos el código que nos permite
         //mantener la bolsa de weed abajo del Dron
         Bolsita_1.GetComponent<Pruebaa>().enabled = false;

         //Ya que agregaremos el siguiente código
         //Primero le agregamos a nuestra bolsita de weed un componente del tipo Rigidbody
         Bolsita_1.AddComponent<Rigidbody>();
         //Activamos la gravedad para que la bolsa caiga por si sola
         Bolsita_1.GetComponent<Rigidbody>().useGravity = true;

     }*/


}
