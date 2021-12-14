using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;

    private float speed = 15f;
    private float rotationSpeed = 30f;

    private float verticalInput;
    private float horizontalInput;

    public GameObject proyectil;

    public int coins = 0;
    public AudioClip monedaClip;

    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI gameOverText;

    public AudioSource audioMusic;
    public AudioSource audioCoin;


    void Start()
    {
        //Spawn inicial del helicóptero
        transform.position = new Vector3(0, 100, 0);

        coins = 0;

        gameOverText.gameObject.SetActive(false);

    }

   
    void Update()
    {
        if (!gameOver)
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

        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(proyectil, gameObject.transform.position, gameObject.transform.rotation);
        }

            CoinsText.text = $"Coins: {coins} / 10";

        }

    }

    public void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            //Al coger una moneda
            if (otherCollider.gameObject.CompareTag("Moneda"))
            {
                //Destruye la moneda
                Destroy(otherCollider.gameObject);

                //Añade una moneda al contador
                coins = coins + 1;

                //Sonido de moneda
                audioCoin.PlayOneShot(monedaClip, 1);
            }

            //Al colisionar con un obstaculo
            else if (otherCollider.gameObject.CompareTag("Obstaculo"))
            {
                //Destruye el objecto y el player
                Destroy(otherCollider.gameObject);
                Destroy(gameObject);

                //Texto en pantalla "GAME OVER"
                gameOverText.text = $"GAME OVER";
                gameOverText.gameObject.SetActive(true);

                //Para la musica
                audioMusic.Stop();

                //Fin del juego
                gameOver = true;
            }
        }
    }
}
