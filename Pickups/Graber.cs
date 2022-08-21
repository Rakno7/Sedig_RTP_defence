using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Graber : MonoBehaviour
{
    public GameObject GrabableObject;
    public bool isHolding;
    void Start()
    {}
    
    
    public abstract void Grab();
    public abstract void Drop();

    public abstract void DoGrab();
    public abstract void DoDrop();

}
