using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddleCtrl : PaddleController
{
    public Transform ballTransform;

    public float slowRadius = 1f;
    public float stopRadius = 0.2f;

	public Vector2 arenaSize = new Vector2(4.5f, 4.9f);
	public bool ballTowardsPlayer1 = false;
	Rigidbody2D ballRb2d;
	Vector2 ballVelocity;
	bool isCalculated = false;


	private void Start()
	{
		ballRb2d = ballTransform.GetComponent<Rigidbody2D>();

	}

	//private void Update()
	//{
	//	if (ballVelocity.x < 0f)
	//	{
	//		ballTowardsPlayer1 = true;
	//	}
	//	else if (ballVelocity.x > 0f)
	//	{
	//		ballTowardsPlayer1 = false;
	//	}
	//}

	void FixedUpdate()
    {
		//if (Mathf.Abs(diff) < 0.5f)
		//    yMove = 0;
		//else if(diff > 0)
		//    yMove = 1;
		//else if (diff < 0)
		//    yMove = -1;

		//PaddleAtBallHeight();

		//rb2d.velocity = new Vector2(0, velocity * diff);
		if (ballVelocity.x > 0f && ballTowardsPlayer1 == false)
		{
			ballTowardsPlayer1 = true;
			isCalculated = false;
		}

		if (ballVelocity.x < 0f && ballTowardsPlayer1 == true)
		{
			ballTowardsPlayer1 = false;
		}


		if (ballTowardsPlayer1 && !isCalculated)
		{
			ballVelocity = ballRb2d.velocity;
			this.transform.position = new Vector2(0f, BallPredictor(ballVelocity));
			isCalculated = true;
		}


		// float tempVel = rb2d.velocity.y;
		//rb2d.velocity = new Vector2(0f, Mathf.SmoothDamp(this.transform.position.y, ballTransform.position.y, ref veloczity,0.1f));


		//if (ballTransform.position.y > this.transform.position.y)
		//	yMove = 1;
		//else if (ballTransform.position.y < this.transform.position.y)
		//	yMove = -1;
		//else if (Mathf.Approximately(ballTransform.position.y, this.transform.position.y))
		//	yMove = 0;

		//this.MovePaddle(yMove);
	}
	void PaddleAtBallHeight()
	{
		float diff = ballTransform.position.y - this.transform.position.y;

		if (Mathf.Abs(diff) < stopRadius)
			rb2d.velocity = Vector2.zero;
		else if (Mathf.Abs(diff) < slowRadius)
			rb2d.velocity = new Vector2(0f, velocity * diff / slowRadius);
		else
			rb2d.velocity = new Vector2(0, velocity * Mathf.Sign(diff));
	}


	float BallPredictor(Vector2 velocity)
	{
		Vector2 ballDirection = velocity.normalized;

		float multiplier = arenaSize.y / ballDirection.y;

		Vector2 result = ballDirection * multiplier;
		if (result.x > arenaSize.x)
		{
			float multiplier2 = arenaSize.x / ballDirection.x;
			Vector2 result2 = ballDirection * multiplier2;
			return result2.y;
		}
		else
		{
			//Vector2 newVelocity;
			//if (ballVelocity.y > 0)
			//	newVelocity = Vector2.Reflect(ballVelocity, Vector2.down);
			//else if (ballVelocity.y < 0)
			//	newVelocity =  Vector2.Reflect(ballVelocity, Vector2.up);

			Vector2 newVelocity = ballVelocity.y > 0 ? Vector2.Reflect(ballVelocity, Vector2.down) : Vector2.Reflect(ballVelocity, Vector2.up);

			return BallPredictor(newVelocity);
		}
	}
	//public override void MovePaddle(float yMove)
	//{
	//    if (yMove != 0) //&& !isTouchingWall)
	//    {
	//        //float diff = Mathf.Mathf.Abs(transform.position.y - ballTransform.position.y);
	//        //Mathf.Lerp(transform.position.y, ballTransform.position.y, Mathf.);
	//        //rb2d.MovePosition(ballTransform.pos)
	//        rb2d.velocity = new Vector2(0, velocity * yMove);
	//    }
	//    else
	//    {
	//        rb2d.velocity = Vector2.zero;
	//    }
	//}
}
