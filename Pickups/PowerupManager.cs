using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> removePowersFromListQueue;
    void Start()
    {
        powerups = new List<Powerup>();
        removePowersFromListQueue = new List<Powerup>();
    }
    void Update()
    {
        PowerUpTimer();
    }
    void LateUpdate()
    {
        RemovePowersFromListCheck();
    }
    public void Add(Powerup powertoAdd)
    {
      powertoAdd.Apply(this);
      powerups.Add(powertoAdd);
    }
    public void Remove(Powerup powertoRemove)
    {
        removePowersFromListQueue.Add(powertoRemove);
    }

    public void RemovePowersFromListCheck()
    {
        foreach(Powerup power in removePowersFromListQueue)
        {
            powerups.Remove(power);
        }
        removePowersFromListQueue.Clear();
    }
    public void PowerUpTimer()
    {
        foreach(Powerup power in powerups)
        {
          power.duration -=Time.deltaTime;
          if(power.duration <= 0)
          {
            Remove(power);
          }
        }
    }
}
