using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private StatsController stats;
    private float maxspeedmagnitude = 10f;
    private PlayerTorsoAndLegsAnimator ptla;
    public Vector3 movement;
    // used to set the movement to be consumed on the next fixedupdate
    public void setMovement(Vector3 tmp)
    {
        movement = tmp;
    }
    public void Start()
    {
        stats = GetComponent<StatsController>();
        rb = GetComponent<Rigidbody>();
        ptla = GetComponent<PlayerTorsoAndLegsAnimator>();
    }
    // consumes movement setting it to 0
    private void consumeMovement()
    {
        if (movement != Vector3.zero)
        {
            ptla.IsWalking = true;
        }
        else
        {
            ptla.IsWalking = false;
        }
        Vector3 potentialVelocity = movement * maxspeedmagnitude;
        rb.velocity = new Vector3(potentialVelocity.x, rb.velocity.y, potentialVelocity.z);
        movement = Vector3.zero;
    }
    public void Update()
    {
    }
    public void FixedUpdate()
    {
        consumeMovement();

        rb.AddForce(new Vector3(0,0.1f,0), ForceMode.VelocityChange);
    }
}
