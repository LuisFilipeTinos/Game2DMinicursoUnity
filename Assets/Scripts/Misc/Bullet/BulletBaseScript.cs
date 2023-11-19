using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBaseScript : MonoBehaviour
{
    protected float horizontalMovement;
    protected float verticalMovement;

    [SerializeField] protected float moveSpeed = 1600f;
    [SerializeField] protected float magnitude = 5;

    protected Vector2 velocityVector;

    public abstract void Movement();
}
