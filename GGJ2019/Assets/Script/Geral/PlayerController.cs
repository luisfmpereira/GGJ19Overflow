using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int count;
    public float force;
    public float speedMovement;
    private Joystick joystick;
    private Button interaction;
    public bool isholding;
    private GameObject CloseObject;
    Vector3 forward, right;
    [Header("SafeZone")]
    public bool willUseSafeZone;
    public GameObject safeZone;
    private float distanceFog;
    public Vector2 minAndMaxDistance;
    public Image fog;
    private float xRange;
    private float zRange; 
    private Color color;
    private AudioManager audioManager;
    public bool isWalking;
    private GameObject last;

    private void Awake()
    {
        joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
        interaction = GameObject.Find("InteractionButton").GetComponent<Button>();
        
    }



    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        xRange = 1280 * 3.5f;
        zRange = 720 * 3.5f;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        if(willUseSafeZone)
        StartCoroutine(UpdateFog());
        audioManager.PlaySound("GGJ8");
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

        if ((rightMovent != Vector3.zero || upMovement != Vector3.zero) && !isWalking)
        {
            StartCoroutine("MoveUpAndDown");
            isWalking = true;
            audioManager.PlaySound("Jump");
        }
        if ((rightMovent == Vector3.zero && upMovement == Vector3.zero) && isWalking)
        {
            StopCoroutine("MoveUpAndDown");      
            isWalking = false;
            audioManager.StopSound("Jump");
        }
        transform.position += rightMovent;
        transform.position += upMovement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hold") && !isholding) 
        {
            if (last == null)
                last = other.gameObject.transform.parent.gameObject;
            interaction.GetComponentInChildren<Text>().text = "Hold";
            interaction.GetComponent<InteractionScript>().actualMode = 1;
            CloseObject = other.gameObject.transform.parent.gameObject;
        }
        if (other.CompareTag("ChangeScene"))
        {
            SceneManager.LoadScene(other.GetComponent<ChangeScene>().nextScene);
            audioManager.StopSound("Jump");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hold") && !isholding)
        {
            interaction.GetComponentInChildren<Text>().text = "Hold";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hold") && !isholding)
        {
            interaction.GetComponentInChildren<Text>().text = "Action";
            interaction.GetComponent<InteractionScript>().actualMode = 0;
            last = null;
        }
    }

    public void GrabItem()
    {
        Debug.Log(CloseObject);
        last.transform.SetParent(this.transform);
        interaction.GetComponentInChildren<Text>().text = "Drop";
        isholding = true;
        audioManager.PlaySound("Grab");
    }
    public void DropItem()
    {
        interaction.GetComponentInChildren<Text>().text = "Action";
        last.transform.SetParent(null);
        isholding = false;
        audioManager.PlaySound("Drop");
    }

    IEnumerator UpdateFog()
    {
        while (true)
        {
            
            distanceFog = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(safeZone.transform.position.x, safeZone.transform.position.z));
            float porc = distanceFog / (minAndMaxDistance.y ) ;
            fog.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Max(1280, (xRange * (1 - porc))), Mathf.Max(720, (zRange * (1 - porc))));
            color.a = porc * 2;
                fog.color = color;
            yield return new WaitForSeconds(0.02f);
        
        }
    }

    IEnumerator MoveUpAndDown()
    {
        while (true)
        {
            this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * force, ForceMode.Impulse);
            yield return new WaitForSeconds(0.55f);
        }
    }
}
