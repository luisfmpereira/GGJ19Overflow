using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, 0.01f, this.transform.position.z), 3);
    }
    private void OnTriggerExit(Collider other)
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, 0.05f, this.transform.position.z), 3);
    }

}
