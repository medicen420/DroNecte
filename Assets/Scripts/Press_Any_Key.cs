using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Press_Any_Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PressAnyKey();
    }

    public void PressAnyKey()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Over");
        }
    }
}
