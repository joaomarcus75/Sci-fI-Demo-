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
    
    [SerializeField]
    private GameObject _muzzeFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;


   

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
         


         if(Input.GetMouseButton(0))
        {
        //shoot effct
        _muzzeFlash.SetActive(true);

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f, 0));

        if(Physics.Raycast(rayOrigin,out RaycastHit hitInfo))
        {
            Debug.Log("Hit:" + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab,hitInfo.point,Quaternion.LookRotation(hitInfo.normal)) as GameObject; 
            //this is a way to save a Instantiate method(prefab) into a GameObject variable 
            Destroy(hitMarker,1f); //Destroy params --> (object,time to destroy)

        }
            

        }else{
            _muzzeFlash.SetActive(false);
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
