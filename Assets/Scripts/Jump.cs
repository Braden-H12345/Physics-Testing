using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    
    [SerializeField] private float _jumpForce = 300f;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _gravFactor = 1f; //if the fall needs to be faster
    private Rigidbody _rigidbody;


    //Ground check variables
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.4f;

    private bool isGrounded;

    private bool isJumpPressed = false;

    public bool isGroundedCheck()
    {
        return isGrounded;
    }
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if(isGrounded && _rigidbody.velocity.y < 0)
        {
            //zeroes out the y velocity so that jump can be performed again later (not fighting a negative velocity to achieve lift)
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        }

        if(isJumpPressed == false && isGrounded)
        {
            isJumpPressed = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void FixedUpdate()
    {
        if( isJumpPressed && isGrounded)
        {
            _rigidbody.AddForce(1, _jumpForce, 1);
            //_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, Mathf.Sqrt(_jumpForce * 2f * _gravity), _rigidbody.velocity.z); 
            //technically the formula for height, but its smoother ^^^
            isGrounded = false;
            isJumpPressed=false;
        }
        else
        {
            _rigidbody.AddForce(0, _gravity * -1* _gravFactor, 0);
        }
    }
}
