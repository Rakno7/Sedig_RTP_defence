using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMover : Mover
{
   public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Move(Vector3 direction, float speed)
    {
        Vector3 movementVector = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movementVector);
    }
    public override void Rotate(float speed)
    {
        Vector3 RotateVector = new Vector3(0, speed * Time.deltaTime,0);
        transform.Rotate(RotateVector);
    }
}
