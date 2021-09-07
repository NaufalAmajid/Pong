using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //RigidBody 2D Bola
    private Rigidbody2D rigidbody2D;

    //Besar Gaya awal untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    //MODIFIKASI SCRIPT
    private Vector2 trajectoryOrigin;
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin;  }
    }

    //SCRIPT
    void ResetBall()
    {

        transform.position = Vector2.zero;

        rigidbody2D.velocity = Vector2.zero;

    }

    void PushBall()
    {

        //float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        float RandomDirection = Random.Range(0, 2);

        if(RandomDirection < 1.0f)
        {
            rigidbody2D.AddForce(new Vector2(-xInitialForce, yInitialForce));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(xInitialForce, yInitialForce));
        }

    }

    void RestartGame()
    {
        ResetBall();

        Invoke("PushBall", 2);
    }

    // Start is called before the first frame update
    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();

        RestartGame();

        //MODIFIKASI SCRIPT
        trajectoryOrigin = transform.position;
    }

}
