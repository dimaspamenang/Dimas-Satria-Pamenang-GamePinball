using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BumperController : MonoBehaviour
{

    public Collider bola;
    public float multiplier;
    public Color color;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;
    public float score;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //Animasi
            animator.SetTrigger("hit");

            // SFX
            audioManager.PlaySFX(collision.transform.position);

            // VFX
            vfxManager.PlayVFX(collision.transform.position);

            // score add
            scoreManager.AddScore(score);
        }
    }
}
