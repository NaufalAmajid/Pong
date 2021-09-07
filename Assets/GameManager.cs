using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //PLAYER 1
    public PlayerControl player1;
    private Rigidbody2D player1Rigidbody;

    //PLAYER 2
    public PlayerControl player2;
    private Rigidbody2D player2Rigidbody;

    //BALL
    public BallControl ball;
    private Rigidbody2D ballRigidbody;
    private CircleCollider2D ballCollider;

    //MAX SCORE
    public int maxScore;

    //Menampilkan Debug Informasi
    private bool isDebugWindowShown = false;

    //MODIFIKASI
    public Trajectory trajectory;

    private void Start()
    {

        player1Rigidbody = player1.GetComponent<Rigidbody2D>();
        player2Rigidbody = player2.GetComponent<Rigidbody2D>();
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();

    }

    void OnGUI()
    {

        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + player1.Score);
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + player2.Score);

        if(GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {

            player1.ResetScore();
            player2.ResetScore();

            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            
        }

        if(player1.Score == maxScore)
        {

            GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER 1 WIN'S");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);

        }else if (player2.Score == maxScore)
        {

            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER 2 WIN'S");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);

        }

        //Menampilkan Debug Informasi
        if (isDebugWindowShown)
        {
            Color oldColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.red;

            float ballMass = ballRigidbody.mass;
            Vector2 ballVelocity = ballRigidbody.velocity;
            float ballSpeed = ballRigidbody.velocity.magnitude;
            Vector2 ballMomentum = ballMass * ballVelocity;
            float ballFriction = ballCollider.friction;

            float impulsePlayer1X = player1.LastContactPoint.normalImpulse;
            float impulsePlayer1Y = player1.LastContactPoint.tangentImpulse;
            float impulsePlayer2X = player2.LastContactPoint.normalImpulse;
            float impulsePlayer2Y = player2.LastContactPoint.tangentImpulse;

            string debugText =
                "Ball mass = " + ballMass + "\n" +
                "Ball velocity = " + ballVelocity + "\n" +
                "Ball speed = " + ballSpeed + "\n" +
                "Ball momuntem = " + ballMomentum + "\n" +
                "Ball friction = " + ballFriction + "\n" +
                "Last Impulse from player 1 = (" + impulsePlayer1X + ", " + impulsePlayer1Y + ")\n" +
                "Last Impulse from player 2 = (" + impulsePlayer2X + ", " + impulsePlayer2Y + ")\n";

            GUIStyle guiStyle = new GUIStyle(GUI.skin.textArea);
            guiStyle.alignment = TextAnchor.UpperCenter;
            GUI.TextArea(new Rect(Screen.width / 2 - 200, Screen.height - 200, 400, 110), debugText, guiStyle);

            GUI.backgroundColor = oldColor;
            
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height - 73, 120, 53), "TOGGLE\nDEBUG INFO"))
        {
            isDebugWindowShown = !isDebugWindowShown;
            trajectory.enabled = !trajectory.enabled;

        }



    }

}
