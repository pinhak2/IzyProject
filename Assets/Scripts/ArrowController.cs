using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    
    public float speed;
    public bool activated, onTarget;
    public Vector3 posIni;
    private Rigidbody rb;
    private Vector3 euLer;
    private Quaternion currentRotation;
    public AudioClip shoot, hit, miss;
    public AudioSource audio;
   


    // Start is called before the first frame update
    void Start()
    {
         audio = this.gameObject.GetComponent<AudioSource>();
        onTarget = false;
        this.transform.localScale = new Vector3(0.5f, 0.75f, 1);
        euLer = new Vector3(90, 0, 0);
        currentRotation.eulerAngles = euLer;
        transform.rotation = currentRotation;
        activated = false;
        posIni = this.transform.position;
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !activated && !onTarget)
        {
            Debug.Log("Apertou R");

            activated = true;
            audio.PlayOneShot(shoot);
            rb.isKinematic = false;
         
          
            // rb.AddForce(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            this.GetComponent<Rigidbody>().velocity = new Vector3(-30,0,0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("Hit Target");
            this.gameObject.GetComponent<BoxCollider>().size = new Vector3(1.5f, 0.1f, 0.05f);
            onTarget = true;
            activated = false;
            audio.PlayOneShot(hit);
            rb.isKinematic = true;
            GMScript.score += 1;
            this.transform.SetParent(collision.transform);
        }

        if (collision.gameObject.tag == "Arrow" && collision.gameObject.GetComponent<ArrowController>().onTarget && activated )
        {

            Debug.Log("Hit Arrow");
            audio.PlayOneShot(miss);
            //  collision.gameObject.transform.localScale = new Vector3(5, 5, 5);
            Time.timeScale = 0;
        }

    }
}
