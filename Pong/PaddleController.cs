using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PaddleController : MonoBehaviour
{
    public float velocity = 5;
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public float paddleHeight;
    [HideInInspector] public float yMove;
    //public bool isTouchingWall = false;
    [HideInInspector] public int leftOrRightPaddle;

    public delegate void BallOnPaddleEvent(Collider2D coll, int maxReflectionAngle, float paddleHeight, float paddlePosY);
    public static event BallOnPaddleEvent onBallOnPaddle;


    //void OnEnable()
    //{
    //    HorizontalWall.onWallTouched += TouchedAWall;
    //}

    //void OnDisable()
    //{
    //    HorizontalWall.onWallTouched -= TouchedAWall;
    //}

    //void TouchedAWall(bool isTouching, char whoTouched)
    //{
    //    isTouchingWall = isTouching;
    //}



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        paddleHeight = GetComponent<BoxCollider2D>().size.y;



        char s = this.name[this.name.Length - 1];

        if (s == '1')
            leftOrRightPaddle = 0;
        else if (s == '2')
            leftOrRightPaddle = 1;
        else
            Debug.LogError("ERROR. Couldn't establish whether paddle is left or right.");
    }


    //public abstract void MovePaddle(float yMove);


	private void OnTriggerEnter2D(Collider2D coll)
	{
        //Debug.Log("paddle detects: " + coll);

        if (coll.CompareTag("Ball"))
		{
            onBallOnPaddle(coll, leftOrRightPaddle, paddleHeight, this.transform.position.y);
            //ReflectABall(coll);
        }
    }


}
