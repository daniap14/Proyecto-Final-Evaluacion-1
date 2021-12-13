using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 15f;
    private float rotationSpeed = 30f;

    private float verticalInput;
    private float horizontalInput;

    public GameObject proyectil;


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

        
        //Limite del mapa
        if (transform.position.y >= 200)
        { transform.position = new Vector3(transform.position.x, 200, transform.position.z); }
        if (transform.position.y <= 0)
        { transform.position = new Vector3(transform.position.x, 0, transform.position.z); }

        if (transform.position.x >= 200)
        { transform.position = new Vector3(200, transform.position.y, transform.position.z); }
        if (transform.position.x <= -200)
        { transform.position = new Vector3(-200, transform.position.y, transform.position.z); }

        if (transform.position.z >= 350)
        { transform.position = new Vector3(transform.position.x, transform.position.y, 350); }
        if (transform.position.z <= -100)
        { transform.position = new Vector3(transform.position.x, transform.position.y, -100); }

        //Lanzamiento de proyectil
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(proyectil, transform.position, gameObject.transform.rotation);
        }
    }
}
