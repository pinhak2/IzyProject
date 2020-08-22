using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public bool activated;

    public AudioSource audio;

    [Header("Game Objects")]
    public GameObject gm;

    public AudioClip hit;

    public AudioClip miss;

    public bool onTarget;

    [Header("Vectors")]
    public Vector3 posIni;

    [Header("Audio")]
    public AudioClip shoot;

    [Header("Variable")]
    public float speed;

    private Quaternion currentRotation;
    private Vector3 euLer;
    private Rigidbody rb;

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
            collision.gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, collision.gameObject.transform.position + new Vector3(-0.4f, 0, 0), 6 * Time.deltaTime);
            this.transform.SetParent(collision.transform);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.transform.SetParent(gm.transform);
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !activated && !onTarget)
        {
            Debug.Log("Apertou R");

            activated = true;
            audio.PlayOneShot(shoot);
            rb.isKinematic = false;

            this.GetComponent<Rigidbody>().velocity = new Vector3(-30, 0, 0);
        }
    }
}