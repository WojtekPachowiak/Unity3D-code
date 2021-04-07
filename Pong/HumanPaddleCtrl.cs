using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPaddleCtrl : PaddleController
{

    void FixedUpdate()
    {
        yMove = Input.GetAxisRaw("Vertical");

        //this.MovePaddle(yMove);

        if (yMove != 0) //&& !isTouchingWall)
        {
            rb2d.velocity = new Vector2(0, velocity * yMove);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

	//public override void MovePaddle(float yMove)
	//{
 //       if (yMove != 0) //&& !isTouchingWall)
 //       {
 //           rb2d.velocity = new Vector2(0, velocity * yMove);
 //       }
 //       else
 //       {
 //           rb2d.velocity = Vector2.zero;
 //       }
 //   }
}
