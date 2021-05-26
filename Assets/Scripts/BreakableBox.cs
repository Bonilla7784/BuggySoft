using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BreakableBox : MonoBehaviour
{
    [SerializeField]
    GameObject heartPrefab;

    public float heartDropChance;

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

        AstarPath.active.Scan();
        DropHeart();

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }

    void DropHeart()
    {
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(chance);
        if (chance <= heartDropChance)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.Euler(0f,0f,0f));
        }
    }
}
