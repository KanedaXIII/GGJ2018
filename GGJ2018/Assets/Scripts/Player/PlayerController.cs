using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float Velocidad = 2.0F;
    Rigidbody2D rb;
    bool caida = false;
    bool baldosaCheck = false;
    public AudioClip Baldoseando;
    public AudioClip Andando;
   
  

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }
	
	void FixedUpdate () {
        if (!caida)
        {
            Movimiento();
        }
        else {
            Caida();
        }
    }

    void Update()
    {
        if (baldosaCheck)
        {
            SonidoAndar(Baldoseando);
        }
        else
        {
            SonidoAndar(Andando);
        }
    }

    void Movimiento() {
            
            float EjeX =  Input.GetAxis("Horizontal");
            float EjeY =  Input.GetAxis("Vertical");
        Vector2 mov = new Vector2(EjeX*Velocidad ,EjeY*Velocidad) ;
        rb.velocity = mov;
       
    }

    void SonidoAndar(AudioClip sonido) {
        GetComponent<AudioSource>().clip = sonido;
        if (rb.velocity != Vector2.zero) {
             AudioManager.Instance.PlaySound(GetComponent<AudioSource>(), true);
            
        }
        else
            AudioManager.Instance.PlaySound(GetComponent<AudioSource>(), false);
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Boquete"))
        {
            caida = true;
        }
        if (coll.gameObject.tag.Equals("Final"))
        {
            GameManager.Instance.LoadeScene("reset");
        }

        if (coll.gameObject.tag.Equals("Baldosa")) {
            Debug.Log("Ha entrado en la baldosa");
            baldosaCheck = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Baldosa"))
        {
            baldosaCheck = false;
        Debug.Log("Salio de la baldosa");
        }
}

    void Caida() {
        transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 0f, Time.fixedDeltaTime),
        Mathf.Lerp(transform.localScale.y, 0f, Time.fixedDeltaTime), 1.0f);
        if (transform.localScale.x <= 6f)
        {
            caida = false;
            transform.position = new Vector3(0, 0, -10);
            transform.localScale = new Vector2(10, 10);
        }
    }
}