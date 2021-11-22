using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public fields
    

    //private fields
    [SerializeField] float _runSpeedModifier;
    [SerializeField] Transform _groundCheckCollider;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] float _speed = 1;
    [SerializeField] float _jumpPower = 300;

    Rigidbody2D _rb;
    Animator _animator;

    const float _groundCheckRadius = 0.2f;
    float _horizontalValue;
    bool _jump;
    bool _isGrounded;
    bool _isRunning;
    bool _facingRight = true;

    //Set rigidbody when game starts
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    //Check each frame for input (horizontal)
    void Update()
    {
        //Store the horizontal value
       _horizontalValue = Input.GetAxisRaw("Horizontal");
        //If Lshift is pressed, enable _isRunning
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _isRunning = true;
        //If Lshift is not pressed, disable _isRunning
        if (Input.GetKeyUp(KeyCode.LeftShift))
            _isRunning = false;
        //If player presses jump button, enable jump
        if (Input.GetButtonDown("Jump"))
            _jump = true;
        //If player is not pressing jump button, disable jump
        else if (Input.GetButtonUp("Jump"))
            _jump = false;
    }
    
    //Call Move Method wiht the horizontal value
    void FixedUpdate()
    {
        GroundCheck();
        Move(_horizontalValue, _jump); 
    }

    void GroundCheck()
    {
        _isGrounded = false;
        //Check if the GroundCheckObject is colliding with the other 2D colliders thert are in the ground layer
        //if yes (isGrounded true) else (isGrounded false)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheckCollider.position, _groundCheckRadius, _groundLayer);
        if (colliders.Length > 0)
            _isGrounded = true;

      
    }

    
    void Move(float dir,bool _jumpFlag)
    {
        if(_isGrounded && _jumpFlag)
        {
            _isGrounded = false;
            _jumpFlag = false;
            _rb.AddForce(new Vector2(0f, _jumpPower));
        }

        #region Move & Run
        //Set value of x using dir and speed
        float xVal = dir * _speed* 100 * Time.fixedDeltaTime;
        //If player is running, multiply by Modifier value
        if (_isRunning)
            xVal *= _runSpeedModifier;
        //Create Vector2 for the velocity
        Vector2 targetVelocity = new Vector2(xVal, _rb.velocity.y);
        //Set the players velocity
        _rb.velocity = targetVelocity;

        //If looking right and clicked left (flip to the left)
        if(_facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
            _facingRight = false;
        }
        //If looking left and clicked right (flip to the right)
        else if(!_facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _facingRight = true;
        }
        //Debug.Log(_rb.velocity.x);
        //(0 Idle , 6 walking , 12 running)
        //Set the float xVelocity according to the x value of the RigidBody2D velocity
        _animator.SetFloat("xVelocity", Mathf.Abs(_rb.velocity.x));
        #endregion
    }
}