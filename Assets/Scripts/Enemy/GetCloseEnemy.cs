using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCloseEnemy : MonoBehaviour
{
    private Transform player;
    private CircleCollider2D radar;
    private GameObject closeEnemy;
    public LayerMask enemyLayerMask;
    private Collider2D[] enemyColliders;
    void Start()
    {
        radar = FindObjectOfType<CircleCollider2D>();
    }
    
}
