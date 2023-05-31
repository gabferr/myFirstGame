using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;

    public float speed;

    public Vector2 friction = new Vector2(.1f, 0);

    public float forceJump = 5;
    private void Update()
    {
        HandleJumping();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(-speed, myRigibody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigibody.MovePosition(myRigibody.position + velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(speed, myRigibody.velocity.y);
        }

        if(myRigibody.velocity.x >0) {

            myRigibody.velocity -= friction;

        }else if (myRigibody.velocity.x < 0)
        {
            myRigibody.velocity += friction;
        }
    }
    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            myRigibody.velocity = Vector2.up *forceJump;
    }
}
