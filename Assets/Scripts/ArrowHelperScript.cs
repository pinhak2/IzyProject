using UnityEngine;

public class ArrowHelperScript : MonoBehaviour
{
    private AudioClip miss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow" && !GetComponentInParent<ArrowController>().activated && other.gameObject.GetComponent<ArrowController>().activated)
        {
            Debug.Log("Hit Arrow");
            miss = other.gameObject.GetComponent<ArrowController>().miss;
            other.gameObject.GetComponent<ArrowController>().audio.PlayOneShot(miss);
            Time.timeScale = 0;
            GMScript.finish = true;
        }
    }
}