using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using System.Diagnostics.SymbolStore;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public Ease ease = Ease.OutBack;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float SpeedRun;
    public float forceJump = 5;
    
    
    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;

    private float _currentSpeed;
    private bool _isRunning = false;


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
        if (Input.GetKeyDown(KeyCode.Space)){
            
            myRigibody.velocity = Vector2.up * forceJump;
            myRigibody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigibody.transform);
            HandleScaleJump();
        }
        else if(myRigibody.velocity.y == 0)
        {
            
            
            
        }
        
            
    }

    private void HandleScaleJump()
    {
        myRigibody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myRigibody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
    private void HandleDownJump()
    {
        myRigibody.transform.DOScaleY(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigibody.transform.DOScaleX(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
