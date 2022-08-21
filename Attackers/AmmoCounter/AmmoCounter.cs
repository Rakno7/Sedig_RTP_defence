using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AmmoCounter: MonoBehaviour
{
    public playerUI PlayerUI;
    public int ammoCount;
    public int clipCount;
    public int clipCapacity;

    public abstract void SubtractFromAmmo(int amount);
    
    public abstract void AddToAmmo(int amount);
    
    public abstract void SubtractFromClipCount(int amount);
    
    public abstract void AddToClipCount(int amount);
    public abstract void Reload();
  
}
