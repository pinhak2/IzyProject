using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    public GameObject arrow, target;
    public Text scoreText;
    public Vector3 posIni;

    public static int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        posIni = arrow.transform.position;

    }
    
    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: "+ score;
        if (Input.GetKeyUp(KeyCode.R))
            {
            Instantiate(arrow, posIni, Quaternion.identity);
            }
          
    }
}
