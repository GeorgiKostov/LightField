using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{

    public float ScrollSpeed = 0.9f;
    public float ScrollSpeed2 = 0.9f;
    private SpriteRenderer spriteRenderer;
    private MeshRenderer meshRenderer;

    void Start()
    {
        if (GetComponent<SpriteRenderer>() != null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        if (GetComponent<MeshRenderer>() != null)
            meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        var offset = Time.time * ScrollSpeed;
        var offset2 = Time.time * ScrollSpeed2;
        if (spriteRenderer != null)
            spriteRenderer.material.mainTextureOffset = new Vector2(offset2, -offset);
        if (meshRenderer != null)
            meshRenderer.material.mainTextureOffset = new Vector2(offset2, -offset);
    }

    public void Init(float time)
    {
        InvokeRepeating("RandomizeMovement", 0f, time);
    }

    void RandomizeMovement()
    {
        ScrollSpeed = Utilities.RandomFloat(-.2f, .2f);
        ScrollSpeed2 = Utilities.RandomFloat(-.2f, .2f);
    }
}