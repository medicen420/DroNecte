using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] int points = 0;
    public Text txt_points;
    string txt_point;
    public string txt_score;
    

    // Start is called before the first frame update
    void Start()
    {
        txt_points.text = txt_score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Point_Win()
    {
        points++;
        txt_point = points.ToString();
        txt_points.text = txt_score + " " + txt_point;
        print("<color=#E761A5>" + " " + txt_point + " " + "bolsita ha sido entregada </color>");

        //Si todas las bolsas han sido entregadas entonces...
        if(points == 2)
        {
            print("<color=#72DD18> Toda la mercancía ha sido entregada </color>");
        }
         
    }



}
