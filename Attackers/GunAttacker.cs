using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttacker : Attacker
{
   public enum WeaponType
   {
       Pistol, Turret
   };
   public Color raycolor;
   private RaycastHit Hit;
   public AudioPlayer audioPlayer;
   public WeaponType currentWeapon;
   public AmmoCounter ammoCount;

   public void ReloadGun()
   {
      if(ammoCount.ammoCount != 0 && ammoCount.clipCount != ammoCount.clipCapacity)
      {
      ammoCount.Reload();
      audioPlayer.PlayReload();
      }
   }
   public override void Attack()
   {
     
    if(!isHasAttacked)
    {
      //subtrack ammo from clip
     if(ammoCount !=null)
     {
         if(ammoCount.clipCount !=0)
         {
          ammoCount.SubtractFromClipCount(1);
         }
         else if(ammoCount.clipCount == 0 && ammoCount.ammoCount > 0)
         {
           ReloadGun();
         } 
         else if(ammoCount.clipCount == 0 && ammoCount.ammoCount == 0)
         {
            return;
         }
     }
    if(currentWeapon == WeaponType.Pistol){audioPlayer.PlayShot();}
    if(currentWeapon == WeaponType.Turret){audioPlayer.PlayTurretShot();}
    

    Instantiate(AttackParticlePrefab, firePoint.transform.position,firePoint.transform.rotation);
    
      if(Physics.SphereCast(firePoint.transform.position, attackRadius ,pawn.transform.forward, out Hit, attackRange))
      {
         
         if(Hit.transform.gameObject.GetComponent<Health>())
         {
            if(!Hit.transform.gameObject.GetComponentInParent<AllyReference>())
            {
            audioPlayer.PlayBulletImpactFlesh();
            raycolor = Color.red;
            Debug.DrawRay(firePoint.transform.position, pawn.transform.forward, raycolor, 0.5f);
            Vector3 hitpoint = Hit.point;
            GameObject Particles = Instantiate(EnemyImpactParticlePrefab);
            Particles.transform.position = hitpoint; 
            Hit.transform.gameObject.GetComponent<Health>().ReduceHealth(attackDamage,pawn); 
            } 
         }
        
        else
        {
         audioPlayer.PlayMetalImpact();
          raycolor = Color.white;
           Vector3 hitpoint = Hit.point;
            GameObject Particles = Instantiate(WallImpactParticlePrefab);
            Particles.transform.position = hitpoint; 
          Debug.DrawRay(firePoint.transform.position, pawn.transform.forward, raycolor, 0.5f);
          //Debug.Log("hit Something else");
        } 
      }
    Invoke("Cooldown", cooldownLength);
    isHasAttacked = true;
    }
    
   }
   public override void Cooldown()
   {
      isHasAttacked = false;
   }

   
  // private void OnDrawGizmos()
  // {
  //   if(Application.isPlaying)
  //   {
  //      if(Hit.collider!=null)
  //      {
  //         Gizmos.DrawSphere(Hit.point, attackRadius);
  //      }
  //   }
  // }
}
