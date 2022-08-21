using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolCounter : AmmoCounter
{
    public void Start()
    {
        if(GetComponentInParent<PlayerController>())
        {
        PlayerUI = GetComponentInParent<PlayerController>().gameObject.GetComponentInChildren<playerUI>();
        }
       clipCount = clipCapacity;
       if(PlayerUI !=null)
       {
        PlayerUI.SetAmmoUI(ammoCount);
        PlayerUI.SetClipUI(clipCount, clipCapacity);
       }
    }
    public override void SubtractFromAmmo(int amount)
    {
       ammoCount -= amount;
       ammoCount = Mathf.Clamp(ammoCount, 0 , 9999);
       if(PlayerUI !=null)
       {
        PlayerUI.SetAmmoUI(ammoCount);
       }
    }
    public override void AddToAmmo(int amount)
    {
        ammoCount += amount;
        ammoCount = Mathf.Clamp(ammoCount, 0 , 9999);
        if(PlayerUI !=null)
       {
        PlayerUI.SetAmmoUI(ammoCount);
       }
    }
    public override void SubtractFromClipCount(int amount)
    {
       clipCount -= amount; 
       clipCount = Mathf.Clamp(clipCount, 0 , clipCapacity);
       if(PlayerUI !=null)
       {
        PlayerUI.SetClipUI(clipCount, clipCapacity);
       }
    }
    public override void AddToClipCount(int amount)
    {
        clipCount += amount;
        clipCount = Mathf.Clamp(clipCount, 0 , clipCapacity);
        if(PlayerUI !=null)
       {
        PlayerUI.SetClipUI(clipCount, clipCapacity);
       }
    }
    public override void Reload()
    {   if(clipCount == clipCapacity)return;

        int ammoToFill = clipCapacity - clipCount;
        clipCount += ammoCount;
        clipCount = Mathf.Clamp(clipCount, 0 , clipCapacity);
        ammoCount -= ammoToFill;
        ammoCount = Mathf.Clamp(ammoCount, 0 , 9999);
        if(PlayerUI !=null)
       {
        PlayerUI.SetAmmoUI(ammoCount);
        PlayerUI.SetClipUI(clipCount, clipCapacity);
       }
    }
}
