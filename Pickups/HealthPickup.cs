using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private AudioPlayer audioPlayer;
    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }
    public HealthPower powerup;
    private void OnTriggerStay(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        Pawn pawn = other.GetComponent<Pawn>();
        if(powerupManager !=null)
        {
            if(pawn.controller.GetComponent<PlayerController>())
            {
                if(Input.GetKeyDown(pawn.controller.GetComponent<PlayerController>().AttackKey))
                {
                   audioPlayer.PlayHealthPickup();
                   powerupManager.Add(powerup);
                   Destroy(gameObject);
                }
            }
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {   
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        Pawn pawn = other.GetComponent<Pawn>();
        if(powerupManager !=null)
        {
            if(pawn.controller.GetComponent<SoldierFSM>())
            {
                audioPlayer.PlayHealthPickup();
                pawn.controller.GetComponent<SoldierFSM>().anim.SetBool("isWounded",false);
                pawn.controller.GetComponent<SoldierFSM>().isWound = false;
                powerupManager.Add(powerup);
                Destroy(gameObject);
            }
        }
    }
}
