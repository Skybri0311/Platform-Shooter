using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public fields
    public float _speed = 1;

    //private fields
    Rigidbody2D _rb;
    Animator _animator;
    float _horizontalValue;
    [SerializeField] float _runSpeedModifier;
    bool _isRunning = false;
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
       
    }
    
    //Call Move Method wiht the horizontal value
    void FixedUpdate()
    {
        Move(_horizontalValue); 
    }
    //Change Velocity of rigid body
    void Move(float dir)
    {
        //Set value of x using dir and speed
        float xVal = dir * _speed* 100 * Time.deltaTime;
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
    }
}
