using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pos_weed : MonoBehaviour
{
    public GameObject dronec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = dronec.transform.position;
    }
}
