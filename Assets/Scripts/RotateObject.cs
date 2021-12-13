using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    private float rotateSpeed = 500f;
    private float objectSpeed = 50f;
    public PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

   
    void Update()
    {
        if (gameObject.CompareTag("Aspa"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
            

        transform.Rotate(Vector3.up * Time.deltaTime * objectSpeed);
    }
}
