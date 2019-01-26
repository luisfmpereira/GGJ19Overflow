using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    public GameObject player;
    public float force;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickJump()
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0));
    }
}
