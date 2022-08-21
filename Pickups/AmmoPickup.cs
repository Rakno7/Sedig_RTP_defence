using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioPlayer audioPlayer;
    public AmmoPower powerup;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }

     private void OnTriggerEnter(Collider other)
    {  
        if(other.GetComponent<Pawn>())
        {
            if(other.GetComponent<Pawn>().GetComponentInParent<PlayerController>())
            {
              PowerupManager powerupManager = other.GetComponent<PowerupManager>();
              Pawn pawn = other.GetComponent<Pawn>();
                if(powerupManager !=null)
                {
                    audioPlayer.PlayHealthPickup();
                    powerupManager.Add(powerup);
                    Destroy(gameObject);
                }
            }
        } 
        
    }
}
