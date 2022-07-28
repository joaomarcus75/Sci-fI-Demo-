using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 1.5f;
    private float _gravity = 9.81f;
    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculatedMovement();
    }

    void CalculatedMovement()
    {
            float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput,0,verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
}
