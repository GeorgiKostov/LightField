using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateColor : MonoBehaviour
{

    public GameObject[] ColorSpheres;
    public Material ColorChanger;
    public float Speed = 25f;
    public enum ColorType
    {
        Normal, Blue, Green
    }
    void Start()
    {
        for (int i = 0; i < ColorSpheres.Length; i++)
        {
            ColorSpheres[i].GetComponent<Renderer>().material = new Material(ColorChanger);
        }
        InvokeRepeating("Audio_Color_RandomBand", .1f, 1f);
        //InvokeRepeating("Audio_Color_Blue", .1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * Speed);
    }
    void Audio_Color_RandomBand()
    {
        for (int i = 0; i < ColorSpheres.Length; i++)
        {

            ColorSpheres[i].GetComponent<Renderer>().material.color = Utilities.GetRandomColor();
        }
    }
    void Audio_Color_Green()
    {
        for (int i = 0; i < ColorSpheres.Length; i++)
        {

            ColorSpheres[i].GetComponent<Renderer>().material.color = Utilities.GetRandomColor();
        }
    }

    public void InitBalls(ColorType type, float speed, float kill)
    {
        switch (type)
        {
            case ColorType.Normal:
                InvokeRepeating("Audio_Color_RandomBand", .1f, 1f);

                break;
            case ColorType.Blue:
                InvokeRepeating("Audio_Color_Green", .1f, 1f);

                break;
        }
        Speed = speed;
        Invoke("Kill", kill);

    }
    void Kill()
    {
        Destroy(gameObject);
    }
}
