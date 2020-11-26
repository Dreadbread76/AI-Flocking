﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    private Collider2D agentCollider;
    private Animator anim;
    public Collider2D AgentCollider { get { return agentCollider; } }
    public Animator Animator { get { return anim; } }
    private void Start()
    {
        agentCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        if (agentCollider == null)
        {
            Debug.LogError("FlockAgent can't find Collider2D");
            return;
        }
    }
    public void Initialize (Flock flock)
    {
        agentFlock = flock;
    }
    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}