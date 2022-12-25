using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isLeft;
    private bool isWalk;
    private void Start()
    {
        isLeft = true;
        isWalk = false;
    }

    public Animator animator;
    private Vector3 _move = new Vector3();
    public Vector3 Moving
    {
        get => _move;
    }

    // Update is called once per frame
    void Update()
    {
        _move = Vector3.zero;
        _move.x = Input.GetAxis("Horizontal");
        _move.y = Input.GetAxis("Vertical");
        var walk = MathF.Abs(_move.x) + MathF.Abs(_move.y);
        if (walk > 0 && !isWalk)
        {
            audioSource.Play();
            isWalk = true;
        }
        if (walk <= 0.01f && isWalk || PauseMenu.GameIsPaused)
        {
            audioSource.Stop();
            isWalk = false;
        }
        animator.SetFloat("Speed", walk);
        if (_move.x > 0.1f && isLeft)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            isLeft = false;
        }
        if (_move.x < -0.1f && !isLeft)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            isLeft = true;
        }
    }
}
