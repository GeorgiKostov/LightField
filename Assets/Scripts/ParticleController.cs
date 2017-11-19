using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem system;
    void Start()
    {
        system = GetComponent<ParticleSystem>();
    }

    void Update()
    {

    }

    public void InitShape(float speed, float kill)
    {
        
        Invoke("Kill", kill);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
