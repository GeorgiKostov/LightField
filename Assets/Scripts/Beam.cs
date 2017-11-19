using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{

    public Animator Controller;
    public Material[] Colors;
    public enum BeamType
    {
        BeamX, BeamY
    }
    BeamType CurrentBeam;
    void Start()
    {
        Controller = GetComponent<Animator>();

    }
    public void InitBeam(BeamType type, float speed, float kill)
    {
        switch (type)
        {
            case BeamType.BeamX:
                transform.localScale = new Vector3(.1f, 4f, 1);

                Controller.Play("BeamX");

                break;
            case BeamType.BeamY:
                transform.localScale = new Vector3(4, .1f, 1);

                Controller.Play("BeamY");

                break;
        }
        GetComponent<Renderer>().material = Colors[Utilities.RandomInt(0, Colors.Length)];
        Controller.speed = speed;
        Invoke("Kill", kill);

    }

    void Update()
    {
    }
    void Kill()
    {
        Destroy(gameObject);
    }
}
