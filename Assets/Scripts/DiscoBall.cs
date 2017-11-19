using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBall : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Audio_Color_RandomBand", .1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Audio_Color_RandomBand()
    {

        this.GetComponent<Renderer>().material.color = new Color(Utilities.RandomFloat(0, 1),
            Utilities.RandomFloat(0, 1), Utilities.RandomFloat(0, 1));

    }
}
