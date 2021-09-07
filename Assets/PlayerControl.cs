using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Tombol untuk gerak keatas
    public KeyCode upButton = KeyCode.W;

    //Tombol untuk gerak kebawah
    public KeyCode downButton = KeyCode.S;

    //Kecepatan gerak
    public float speed = 10.0f;

    //batas atas dan bawah game scene (batas bawah dengan ( - ))
    public float yBoundary = 9.0f;

    //rigidbody 2D this raket
    private Rigidbody2D rigidbody2D;

    //skor
    public int score;

    //MODIFIKASI SCRIPT
    private ContactPoint2D lastContactPoint;
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint;  }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }    
    }

    // Start is called before the first frame update
    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       
        //UNTUK MENGGERAKKAN RAKET
        Vector2 velocity = rigidbody2D.velocity;
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }else
        {
            velocity.y = 0.0f;
        }
        rigidbody2D.velocity = velocity;

        //BATASAN GERAK RAKET
        Vector2 position = transform.position;
        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        }else if (position.y < - yBoundary)
        {
            position.y = -yBoundary;
        }
        transform.position = position;

        //MEMANIPULASI SCORE
        
    }

    //MEMANIPULASI SCORE
    public void IncrementScore()
    {
        score++;
    }
    public void ResetScore()
    {
        score = 0;
    }
    public int Score
    {
        get { return score; }
    }
}
