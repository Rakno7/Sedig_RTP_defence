using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public audiomanager musicAudioManager;
    public audiomanager uiAudioManager;
    public audiomanager sfxAudioManager;
    public audiomanager ambianceAudioManager;
    void Start()
    {      
       musicAudioManager = GameManager.instance.musicAudioManager;
       ambianceAudioManager = GameManager.instance.ambianceAudioManager;
       uiAudioManager = GameManager.instance.uiAudioManager;
       sfxAudioManager = GameManager.instance.sfxAudioManager;
    }
    public void PlayerButtonClick()
    {
       uiAudioManager.Play("ButtonClick");
    }
    public void PlayerButtonHover()
    {
       uiAudioManager.Play("ButtonHover");
    }
    public void PlayerToogleClick()
    {
       uiAudioManager.Play("Click");
    } 
    public void PlayMainMusic()
    {
         musicAudioManager.PlayMusic("MainMusic");
    }
    public void PlayGameMusic()
    {
          musicAudioManager.PlayMusic("GameplayMusic");
    }
    public void PlayGameAmbiance()
    {
          ambianceAudioManager.PlayAmbiance("Ambiance1");
    }
     public void StopMenuMusic()
    {
            musicAudioManager.Stop("MainMusic");
    }
    public void StopGameMusic()
    {
            musicAudioManager.Stop("GameplayMusic");
    }
    public void PlayGunDraw()
    {
      sfxAudioManager.PlayAtPoint("DrawGun",transform.position);
    }
    public void HolsterGun()
    {
      sfxAudioManager.PlayAtPoint("HolsterGun",transform.position);
    }
    
    public void PlayShot()
    {
        int rand;
        rand = Random.Range(1,9);
        
            sfxAudioManager.PlayAtPoint("Shot" + rand, transform.position);
    }
    public void PlayBulletImpactFlesh()
    {
        int rand;
        rand = Random.Range(1,6);
        sfxAudioManager.PlayAtPoint("ImpactFlesh" + rand, transform.position);
    }

    public void PlayTurretShot()
    {
        int rand;
        rand = Random.Range(1,4);
         sfxAudioManager.PlayAtPoint("TurretShot" + rand, transform.position);
    }

    public void PlayMetalImpact()
    {
        int rand;
        rand = Random.Range(1,6);
         sfxAudioManager.PlayAtPoint("ImpactMetal" + rand, transform.position);
    }
    public void ChanceToPlayZombieSound()
    {
        int chance = Random.Range(1,10);
        if(chance == 1)
        {
        int rand;
        rand = Random.Range(1,11);
         sfxAudioManager.PlayAtPoint("Zombie" + rand, transform.position);
        }
    }
    public void PlayZombieHurtSound()
    {
        int chance = Random.Range(1,3);
        if(chance == 1)
        {
        int rand;
        rand = Random.Range(1,11);
         sfxAudioManager.PlayAtPoint("ZombieHurt" + rand, transform.position);
        }
    }
    public void PlayReload()
    {
        int rand;
        rand = Random.Range(1,4);
        sfxAudioManager.PlayAtPoint("Reload" + rand, transform.position);
    }

    public void PlayFootStep()
    {
        int rand;
        rand = Random.Range(1,5);
         sfxAudioManager.PlayAtPoint("Footstep" + rand, transform.position);
    }

     public void PlayHealthPickup()
    {
       sfxAudioManager.PlayAtPoint("Bandage",transform.position);
    }
     public void PlaySpeedPickup()
    {
       sfxAudioManager.PlayAtPoint("PickupSpeed",transform.position);
    }
     public void PlayShieldPickup()
    {
       sfxAudioManager.PlayAtPoint("PickupShield",transform.position);
    }
}
