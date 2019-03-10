using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEngine : Speedy
{

    public float transformForwardSpeed;
    public float transformLeftSpeed;
    public float fineTransformForwardSpeed;
    public float normalTransformForwardSpeed;
    public float fineTransformLeftSpeed;
    public float normalTransformLeftSpeed;

    public override void MoveForward(float input)
    {

        if (playerPos == PlayerPos.TooHigh)
        {
            input = -1;
        }
        if (playerPos == PlayerPos.TooLow)
        {
            input = 1;
        }
        moveForward.y = input * transformForwardSpeed;
        transform.parent.position += moveForward;
        //transform.parent.Translate(moveLeft, Space.Self);
    }

    public override void MoveLeft(float input)
    {
        if (playerPos == PlayerPos.TooRight)
        {
            input = -1;
        }
        if (playerPos == PlayerPos.TooLeft)
        {
            input = 1;
        }
        moveLeft.x = input *transformLeftSpeed;
        transform.parent.position += moveLeft;
        //transform.parent.Translate(moveForward, Space.Self);
    }

    public void Update()
    {
        MoveLeft(input.GetLeft);
        MoveForward(input.GetForward);
        if (input.GetFineMov)
        {
            transformForwardSpeed = fineTransformForwardSpeed;
            transformLeftSpeed = fineTransformLeftSpeed;
        }
        else
        {

            transformForwardSpeed = normalTransformForwardSpeed;
            transformLeftSpeed = normalTransformLeftSpeed;
        }
        


        if ((screen.upExtend.y - transform.position.y) < 0)
        {
            playerPos = PlayerPos.TooHigh;
        }
        else if ((screen.downExtend.y - transform.position.y) > 0)
        {
            playerPos = playerPos = PlayerPos.TooLow;
        }
        else if ((transform.position.x - screen.rightExtend.x) > 0)
        {
            playerPos = PlayerPos.TooRight;
        }
        else if ((screen.leftExtend.x - transform.position.x) > 0)
        {
            playerPos = PlayerPos.TooLeft;
        }
        else
        {
            playerPos = PlayerPos.Fine;
        }

    }
}
