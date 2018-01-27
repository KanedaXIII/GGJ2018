using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float Velocidad = 2.0F;
    Rigidbody2D rb;
    bool caida = false;

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
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag.Equals("Boquete"))
        {
            caida = true;
            Debug.Log("caida");
        }

    }
    

        void Movimiento() {
            float EjeX =  Input.GetAxis("Horizontal");
            float EjeY =  Input.GetAxis("Vertical");
        Vector2 mov = new Vector2(EjeX*Velocidad ,EjeY*Velocidad) ;
        rb.velocity = mov;
    }
    void Caida() {
        Debug.Log("cayendo");
        transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 0f, Time.fixedDeltaTime),
        Mathf.Lerp(transform.localScale.y, 0f, Time.fixedDeltaTime), 1.0f);

        //transform.localScale = new Vector3(1.0f, 1.0f, 20.0f);

        if (transform.localScale.x <= 6f)
        {
            caida = false;
            transform.position = new Vector3(0, 0, -10);
            transform.localScale = new Vector2(10, 10);
        }
    }

    


}