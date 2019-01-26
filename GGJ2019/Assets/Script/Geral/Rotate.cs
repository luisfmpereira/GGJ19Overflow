using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform rotateTransf;
    [SerializeField]
    private float rotateSpeed;

    void Start()
    {
        rotateTransf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateTransf.Rotate(0,rotateSpeed * Time.deltaTime,0);
    }
}
