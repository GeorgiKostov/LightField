using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private MeshRenderer meshRenderer;
    public bool AnimateTiling;

    void Start()
    {
        if (GetComponent<SpriteRenderer>() != null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        if (GetComponent<MeshRenderer>() != null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
    }

    public void Init(float time, float kill)
    {
        InvokeRepeating("RandomizeColor", 0f, time);
        Invoke("Kill", kill);
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    void Update()
    {

    }

    void RandomizeColor()
    {
        if (spriteRenderer != null)
            spriteRenderer.material.color = Utilities.GetRandomColor();
        if (meshRenderer != null)
            meshRenderer.material.color = Utilities.GetRandomColor();
    }

     
}
