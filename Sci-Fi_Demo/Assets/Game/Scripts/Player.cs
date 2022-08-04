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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown(0))
        {
            
        Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f,Screen.height /2f, 0));

        if(Physics.Raycast(rayOrigin,Mathf.Infinity))
        {
            Debug.Log("Raycast Hit Someting");
        }

        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
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
