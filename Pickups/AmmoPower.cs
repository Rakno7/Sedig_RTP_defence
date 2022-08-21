using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AmmoPower : Powerup
{
    public int AmmoToAdd;
    public override void Apply(PowerupManager target)
    {
        AmmoCounter ammoCount = target.GetComponentInChildren<AmmoCounter>();
        
        ammoCount.AddToAmmo(AmmoToAdd);
    }
    public override void Remove(PowerupManager target)
    {
        return;
    }
}
