using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private PolygonCollider2D pc;
    private AudioSource aS;


    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        pc = GetComponent<PolygonCollider2D>();
        aS = GetComponent<AudioSource>();
    }

    public void PublicBreak()
    {
        StartCoroutine(Break());
    }

    private IEnumerator Break()
    {
        particle.Play();
        aS.Play();

        sr.enabled = false;
        pc.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
