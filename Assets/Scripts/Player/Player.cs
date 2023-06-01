using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed;
    public float SpeedRun;

    public float forceJump = 5;

    private float _currentSpeed;

    private void Update()
    {
        HandleJumping();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = SpeedRun; 
        else
            _currentSpeed = speed;



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(-_currentSpeed, myRigibody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigibody.MovePosition(myRigibody.position + velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(_currentSpeed, myRigibody.velocity.y);
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
