using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private float speed = 30f;
    private float timerDestroy = 10f;

    void Start()
    {

        //Tiempo limite del proyectil
        Destroy(gameObject, timerDestroy);


    }

    
    void Update()
    {
        //Avance constante del proyectil
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);

        }
    }
}
