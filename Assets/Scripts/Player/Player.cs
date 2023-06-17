using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using System.Diagnostics.SymbolStore;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public HealthBase _healthBase;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    private float _currentSpeed;

    public Animator animator;

    public float timeToDestroy = 1f;

    private void Awake()
    {
        if (_healthBase != null)
        {
            _healthBase.OnKill += onPlayerKill;
        }
        
    }
    private void onPlayerKill()
    {
        _healthBase.OnKill -= onPlayerKill;
        PlayKillAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleJumping();
        HandleMoviment();

 
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl)) {
            _currentSpeed = soPlayerSetup.SpeedRun;
            animator.speed = 1.5f;
            //animator.SetBool(boolRunning, true);
        }

        else {
            _currentSpeed = soPlayerSetup.speed;
            animator.speed = 1f;
            // animator.SetBool(boolRunning, false);
        }
            



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(-_currentSpeed, myRigibody.velocity.y);
           if (myRigibody.transform.localScale.x != -1) {
                myRigibody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(soPlayerSetup.boolRun, true);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigibody.MovePosition(myRigibody.position + velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(_currentSpeed, myRigibody.velocity.y);
            if (myRigibody.transform.localScale.x != 1)
            {
                myRigibody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(soPlayerSetup.boolRun, false);
        }

        if(myRigibody.velocity.x >0) {

            myRigibody.velocity -= soPlayerSetup.friction;

        }else if (myRigibody.velocity.x < 0)
        {
            myRigibody.velocity += soPlayerSetup.friction;
        }
    }
    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            
            myRigibody.velocity = Vector2.up * soPlayerSetup.forceJump;
            myRigibody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigibody.transform);
            HandleScaleJump();
        }
      
    
            
    }

    private void HandleScaleJump()
    {
        myRigibody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigibody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    private void PlayKillAnimation()
    {
        animator.SetTrigger(soPlayerSetup.triggerDeath);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

}
