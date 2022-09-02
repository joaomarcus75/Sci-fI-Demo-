using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
  //check for collision
  private AudioClip _BuySound;
  private void OnTriggerStay(Collider other) {
  
    if(other.transform.tag == "Player")
    {
          if(Input.GetKeyDown(KeyCode.E))
          {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                if(player.hasCoin == true)
                {
                    player.hasCoin = false;
                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if(uiManager != null)
                    {
                    uiManager.RemoveCoin();
                    }
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.Play();
                    player.EnableWeapons();
                }
                else
                {
                     Debug.Log("Get Out of Here!");
                }
            }

          }

    }
  }
      //play the win sound
  //else Debug  Get out of here! 



}
