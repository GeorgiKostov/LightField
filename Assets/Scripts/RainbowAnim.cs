using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowAnim : MonoBehaviour
{
    private float Speed;
    void Start()
    {
        Speed = Utilities.RandomFloat(-1.5f, 1.5f);
        transform.rotation = Quaternion.Euler(0,90,0);
        transform.position = new Vector3(0,-1,0);
    }

    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time*Speed);
    }
    public void InitShape(float speed, float kill)
    {
        Speed = speed;
        Invoke("Kill", kill);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
