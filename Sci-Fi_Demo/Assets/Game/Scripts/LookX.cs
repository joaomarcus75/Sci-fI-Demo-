using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        
        Vector3 newRotationX = transform.localEulerAngles;
        newRotationX.y += _mouseX * _sensitivity;
        transform.localEulerAngles = newRotationX;

  
       

       
    
    
    
    }
}
