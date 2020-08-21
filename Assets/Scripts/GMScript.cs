using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    [Header("Main objects")]
    public GameObject arrow;
    public GameObject target;
    public GameObject bow;

    [Header("Canvas")]
    public Text scoreText;

    public RawImage image;
    public Text endText;

    [Header("Spawn details")]
    public Vector3 posIni;

    [Header("Arrows List")]
    public List<GameObject> arrowlist = new List<GameObject>();

    public static int score;

    public static bool finish;

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        finish = false;
        endText.GetComponent<Text>().enabled = false;
        image.GetComponent<RawImage>().enabled = false;
        scoreText.GetComponent<Text>().enabled = true;
        score = 0;
        posIni = arrow.transform.position;
        arrowlist.Add(arrow);
    }

    // Update is called once per frame
    private void Update()
    {
        if (finish)
        {
            endingMethod();
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
        scoreText.text = "Score: " + score;
        if (Input.GetKeyUp(KeyCode.R) && !finish)
        {
            GameObject arrow2 = Instantiate(arrow, posIni, Quaternion.identity);
            arrowlist.Add(arrow2);
        }
    }

    private void endingMethod()
    {
        target.gameObject.GetComponent<MeshRenderer>().enabled = false;
        bow.gameObject.GetComponent<MeshRenderer>().enabled = false;
        scoreText.GetComponent<Text>().enabled = false;
        foreach (GameObject a in arrowlist)
        {
            a.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        image.GetComponent<RawImage>().enabled = true;
        endText.GetComponent<Text>().enabled = true;
        endText.text = "Score: " + score + "\nAperte 'Espaço' para\n jogar novamente!";
    }
}