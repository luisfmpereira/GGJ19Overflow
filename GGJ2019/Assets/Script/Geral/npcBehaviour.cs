using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcBehaviour : MonoBehaviour
{
    private GameObject player;
    private Transform NPC;

    [SerializeField]
    private float approachSpeed;
    void Start()
    {
        NPC = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        NPC.transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z),
                                                     new Vector3(player.transform.position.x,this.transform.position.y,player.transform.position.z), approachSpeed * Time.deltaTime);
    }
}
