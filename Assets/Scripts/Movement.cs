using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private double _maxSpeed = 10f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude >= _maxSpeed && GetComponent<Jump>().isGroundedCheck()) 
            return;

        if (Input.GetKey(KeyCode.W))
            _rigidbody.AddForce(_movementSpeed * transform.forward);

        if (Input.GetKey(KeyCode.S))
            _rigidbody.AddForce(_movementSpeed * -transform.forward);

        if (Input.GetKey(KeyCode.D))
            _rigidbody.AddForce(_movementSpeed * transform.right);

        if (Input.GetKey(KeyCode.A))
            _rigidbody.AddForce(_movementSpeed * -transform.right);
    }

}
