using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWall : MonoBehaviour
{
    //public delegate void paddleTouchesWallEvent(bool isTouching, char whichPaddle);
    //public static event paddleTouchesWallEvent onWallTouched;
    int topBotMultiplier;

	void Start()
	{
        char s = this.name[this.name.Length - 1];

        if (s == 'T')
            topBotMultiplier = -1;
        else if (s == 'B')
            topBotMultiplier = 1;
        else
            Debug.LogError("ERROR. Couldn't establish whether wall is top or bottom.");


    }

    void OnTriggerEnter2D(Collider2D coll)
	{
        //Debug.Log("horiWall detects: " + coll);

        if (coll.CompareTag("Ball"))
		{
            MultiplyVerticalVelocity(coll, -1);
        }
  //      if (coll.CompareTag("Paddle"))
		//{
  //          //paddleID = coll.name[coll.name.Length - 1];
  //          //onWallTouched(true, paddleID);


  //          float wallHalfHeight = transform.GetComponent<BoxCollider2D>().size.y / 2;
  //          float paddleHalfHeight = coll.GetComponent<BoxCollider2D>().size.y / 2;
  //          Debug.Log("wallheight: " + wallHalfHeight);
  //          Debug.Log("paddleheight: " + paddleHalfHeight);

  //          Debug.Log(new Vector2(
  //              coll.transform.position.x,
  //              transform.position.y + wallHalfHeight + paddleHalfHeight));

  //          coll.transform.position = new Vector2(
  //              coll.transform.position.x,
  //              transform.position.y + wallHalfHeight + paddleHalfHeight);

           
  //      }
    }
	private void OnTriggerStay2D(Collider2D coll)
	{
        if (coll.CompareTag("Paddle"))
        {
            //paddleID = coll.name[coll.name.Length - 1];
            //onWallTouched(true, paddleID);


            float wallHalfHeight = transform.GetComponent<BoxCollider2D>().size.y / 2;
            float paddleHalfHeight = coll.GetComponent<BoxCollider2D>().size.y / 2;
            //Debug.Log("wallheight: " + wallHalfHeight);
            //Debug.Log("paddleheight: " + paddleHalfHeight);

            //Debug.Log(new Vector2(
            //    coll.transform.position.x,
            //    transform.position.y + wallHalfHeight + paddleHalfHeight));

            coll.transform.position = new Vector2(
                coll.transform.position.x,
                transform.position.y + topBotMultiplier * (wallHalfHeight + paddleHalfHeight)
                );


        }
    }
	//void OnTriggerExit2D(Collider2D coll)
	//{
	//       if (coll.CompareTag("Paddle"))
	//       {
	//           onWallTouched(false, paddleID);
	//       }
	//   }




	void MultiplyVerticalVelocity(Collider2D coll, int multiplicator)
	{
        Vector2 collVelocity = coll.GetComponent<Rigidbody2D>().velocity;

        collVelocity.y *= multiplicator;

        coll.GetComponent<Rigidbody2D>().velocity = collVelocity;
    }
}
