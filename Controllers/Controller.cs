using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;
    public Animator anim;

    public virtual void Start()
    {
        pawn = GetComponentInChildren<Pawn>();
        anim = GetComponentInChildren<Animator>();
    }
    public virtual void ProcessInputs()
    {

    }
}
