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
    [SerializeField]
    private AudioSource _weapomAudio; //private AudioSource _shootAudio;
    [SerializeField]
    private int _currentAmmo;
    private int _maxAmmo = 50;
    private bool _isReloading = false;
    private UIManager _uiManager;


   

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>(); 
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _currentAmmo = _maxAmmo;
        
    }

    // Update is called once per frame
    void Update()
    {
         


         if(Input.GetMouseButton(0) & _currentAmmo > 0 )
        {
           shoot();
        
           }else{
            _muzzeFlash.SetActive(false);
            _weapomAudio.Stop();
        }
         if(Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        CalculatedMovement();

        if(Input.GetKey(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(Reload());
        }
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
    void shoot()
    {
        _muzzeFlash.SetActive(true);
        _currentAmmo --; 
        
           if(_uiManager != null)
        {
            _uiManager.UpdateAmmo(_currentAmmo);
        }
    
        
        if(_weapomAudio.isPlaying == false)
        {

        _weapomAudio.Play();
        }
        

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f, 0));

        if(Physics.Raycast(rayOrigin,out RaycastHit hitInfo))
        {
            Debug.Log("Hit:" + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab,hitInfo.point,Quaternion.LookRotation(hitInfo.normal)) as GameObject; 
            //this is a way to save a Instantiate method(prefab) into a GameObject variable 
            Destroy(hitMarker,1f); //Destroy params --> (object,time to destroy)

        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.8f);
        _currentAmmo = _maxAmmo;
        if(_uiManager != null)
        {
            _uiManager.UpdateAmmo(_currentAmmo);
        }
        _isReloading = false;
    }

   
}
