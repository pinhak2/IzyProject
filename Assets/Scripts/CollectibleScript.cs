using System.Collections;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public GameObject target;

    [Header("Audio")]
    public new AudioSource audio;

    public AudioClip star;

    public bool down;

    // Start is called before the first frame update
    private void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.transform.SetParent(target.transform);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine("Move");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            audio.PlayOneShot(star);
            GMScript.score = GMScript.score * 2;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this);
        }
    }

    private IEnumerator Move()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(0.025f, 0, 0), 1);
        down = true;
        yield return new WaitForSeconds(2.2f);

        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(-0.025f, 0, 0), 1);
    }
}