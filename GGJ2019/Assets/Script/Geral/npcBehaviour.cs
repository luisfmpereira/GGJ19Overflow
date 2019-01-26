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
        NPC.transform.position = Vector2.MoveTowards(new Vector2(this.transform.position.x,this.transform.position.z),
        new Vector2(player.transform.position.x,player.transform.position.z), approachSpeed * Time.deltaTime);
    }
}
