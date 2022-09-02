using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{ 
    [SerializeField]
    private AudioClip _coinPickUp;  
    
    private void OnTriggerStay(Collider other) 
    {
      if(other.transform.tag == "Player")
      {
        if(Input.GetKeyDown(KeyCode.E))
        {
          Player player = other.GetComponent<Player>();
          
          if(player != null)
          {
            player.hasCoin = true;
            AudioSource.PlayClipAtPoint(_coinPickUp,transform.position,1f);
            UIManager uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
            if(uIManager != null)
            {
                uIManager.CollectedCoin();
            }
            Destroy(this.gameObject);
              

          }
        }
      }  
    }

}
