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
    public HealthBase _healthBase;

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

    [Header("Animation player")]
    public Animator animator;
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public string boolRunning = "Running";
    public float playerSwipeDuration = .1f;

    
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
            _currentSpeed = SpeedRun;
            animator.speed = 1.5f;
            //animator.SetBool(boolRunning, true);
        }

        else {
            _currentSpeed = speed;
            animator.speed = 1f;
            // animator.SetBool(boolRunning, false);
        }
            



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigibody.MovePosition(myRigibody.position - velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(-_currentSpeed, myRigibody.velocity.y);
           if (myRigibody.transform.localScale.x != -1) {
                myRigibody.transform.DOScaleX(-1, playerSwipeDuration);
            }
                animator.SetBool(boolRun, true);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigibody.MovePosition(myRigibody.position + velocity * Time.deltaTime);
            myRigibody.velocity = new Vector2(_currentSpeed, myRigibody.velocity.y);
            if (myRigibody.transform.localScale.x != 1)
            {
                myRigibody.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
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
      
    
            
    }

    private void HandleScaleJump()
    {
        myRigibody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myRigibody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

}
