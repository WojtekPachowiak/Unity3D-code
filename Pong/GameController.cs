using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public GameObject[] paddles;

    public GameObject ball;
    public float ballVelocity = 5;
    float tempBallVelocity;
    public float ballAcceleartion = 0.25f;

    public TextMeshProUGUI scoreDisplay1;
    public TextMeshProUGUI scoreDisplay2;
    public TextMeshProUGUI gameOverText;

    int player1Score = 0;
    int player2Score = 0;
    public int maxScore;


	void OnEnable()
	{
        VerticalWall.onPointScored += UpdateScore;
        PaddleController.onBallOnPaddle += ReflectABall;
    }

	void OnDisable()
	{
        VerticalWall.onPointScored -= UpdateScore;
        PaddleController.onBallOnPaddle -= ReflectABall;

    }



    void Start()
    {
        tempBallVelocity = ballVelocity;
        LaunchABall();
    }



    bool CheckIfGameOver()
	{
        if (player1Score == maxScore || player2Score == maxScore)
		{
            if (player1Score == maxScore)
            {
                gameOverText.text = "Player1 wins";
            }
            else if (player2Score == maxScore)
            {
                gameOverText.text = "Player2 wins";
            }


            StartCoroutine(GameOverPause(3));

            return true;
            //Start CoroutineWaitForSeconds(1f);

        }
        return false;
    }


    public void UpdateScore(char sideScored)
	{
        if (sideScored == 'R')
		{
            player1Score++;
            scoreDisplay1.text = player1Score.ToString();
        }
        
        else if (sideScored == 'L')
		{
            player2Score++;
            scoreDisplay2.text = player2Score.ToString();
        }

        if (CheckIfGameOver() == false)
        {
            ResetAGame();
        }
    }


    void LaunchABall()
	{
        StartCoroutine(Pause(1));

        float angle = Random.Range(Mathf.Deg2Rad * 45f, Mathf.Deg2Rad * -45f);
        float sign = Random.value <= 0.5 ? 1 : -1;

        ball.GetComponent<Rigidbody2D>().velocity = ballVelocity * new Vector2(sign * Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }


    public void ResetAGame()
	{
        //Debug.Log("Reset a Game");

        ball.transform.position = new Vector2(0f, 0f);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (GameObject paddle in paddles)
		{
            paddle.transform.position = new Vector2(paddle.transform.position.x, 0f);
        }

        tempBallVelocity = ballVelocity;

        LaunchABall();
    }

    private IEnumerator Pause(int seconds)
    {
        //Debug.Log("pause for: " + seconds);
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + seconds;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        
    }

    private IEnumerator GameOverPause(int seconds)
    {
        //Debug.Log("pause for: " + seconds);

        gameOverText.gameObject.SetActive(true);

        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + seconds;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;

        player1Score = 0;
        player2Score = 0;
        scoreDisplay1.text = player1Score.ToString();
        scoreDisplay2.text = player2Score.ToString();

        gameOverText.gameObject.SetActive(false);
        ResetAGame();
    }



    float reflectionAngle;
    void ReflectABall(Collider2D coll, int leftOrRightPaddle, float paddleHeight, float paddlePosY)
    {
        //Debug.Log("REFLECTIN A BALL");
        //Debug.Log("maxReflectionAngle: " + leftOrRightPaddle);


        float maxAngle = Mathf.Deg2Rad * 45;
        float whereBallHit = coll.transform.position.y - (paddlePosY - paddleHeight / 2);


        //Debug.Log(Map(whereBallHit, 0, paddleHeight, -maxAngle, maxAngle));
        if (leftOrRightPaddle == 0)
        {
            reflectionAngle = Map(whereBallHit, 0, paddleHeight, -maxAngle, maxAngle);
        }
        else if (leftOrRightPaddle == 1)
        {
            reflectionAngle = Mathf.PI - Map(whereBallHit, 0, paddleHeight, -maxAngle, maxAngle);
        }

        //Debug.Log("whereBallHit: " + whereBallHit);
        //Debug.Log(reflectionAngle * Mathf.Rad2Deg);

        //Vector2 collVelocity = coll.GetComponent<Rigidbody2D>().velocity;
        //collVelocity += new Vector2(ballAcceleartion, ballAcceleartion);

        tempBallVelocity += ballAcceleartion;

        coll.GetComponent<Rigidbody2D>().velocity = tempBallVelocity * new Vector2(Mathf.Cos(reflectionAngle), Mathf.Sin(reflectionAngle)).normalized;

        //collVelocity.x *= -1;
        //coll.GetComponent<Rigidbody2D>().velocity = collVelocity;

        float Map(float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }
    }


    
}
