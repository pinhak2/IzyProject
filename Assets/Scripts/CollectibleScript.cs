using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectibleScript : MonoBehaviour
{
    public GameObject target;

    public bool down;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.transform.SetParent(target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Move");
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Arrow")
        {
            GMScript.score = GMScript.score * 2;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(this);
        }
    }

    IEnumerator Move()
    {
       
        
            this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(0.02f, 0 , 0), 2);
            yield return new WaitForSecondsRealtime(1);
        

        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(-0.02f, 0, 0), 2);
        yield return new WaitForSecondsRealtime(1);
    }
}
