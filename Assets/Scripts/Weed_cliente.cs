using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed_cliente : MonoBehaviour
{

    public Score point;
    // Start is called before the first frame update
    void Start()
    {
        //point = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cliente")
        {
            Debug.Log("Gracias por la weed");
            point.Point_Win();
        }
    }



}
