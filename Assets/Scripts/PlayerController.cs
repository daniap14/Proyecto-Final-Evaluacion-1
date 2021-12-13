using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 15f;
    private float rotationSpeed = 30f;

    private float verticalInput;
    private float horizontalInput;


    void Start()
    {
        //Spawn inicial del helicóptero
        transform.position = new Vector3(0, 100, 0);

    }

   
    void Update()
    {
        //movimiento hacia adelante
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Controles
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);

    }
}
