using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speedMovement;
    public Joystick joystick;
    public Button interaction;
    public bool isholding;
    private GameObject CloseObject;
    Vector3 forward, right;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 rightMovent = joystick.Horizontal * speedMovement * Time.deltaTime * right;
        Vector3 upMovement = joystick.Vertical * speedMovement * Time.deltaTime * forward;
        transform.position += rightMovent;
        transform.position += upMovement;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hold")) 
        {
            interaction.GetComponentInChildren<Text>().text = "Hold";
            interaction.GetComponent<InteractionScript>().actualMode = 1;        
            CloseObject = other.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hold") && !isholding)
        {
            interaction.GetComponentInChildren<Text>().text = "Action";
            interaction.GetComponent<InteractionScript>().actualMode = 0;
        }
    }

    public void GrabItem()
    {
        CloseObject.transform.SetParent(this.transform);
        interaction.GetComponentInChildren<Text>().text = "Drop";
        isholding = true;
    }
    public void DropItem()
    {
        interaction.GetComponentInChildren<Text>().text = "Action";
        CloseObject.transform.SetParent(null);
        isholding = false;
    }
}
