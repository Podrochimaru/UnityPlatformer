using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    [SerializeField] private Rigidbody _rigidbody;
    bool _onGround = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _onGround = false;
        }
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = Vector3.forward * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = Vector3.back * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = Vector3.left * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = Vector3.right * movementSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _onGround == true)
        {
            _rigidbody.AddForce(Vector3.up * movementSpeed, ForceMode.Impulse);
        }

    }
}
