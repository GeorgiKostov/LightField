using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBall : MonoBehaviour
{

    void Start()
    {
        InvokeRepeating("Audio_Color_RandomBand", .1f, Utilities.RandomFloat(5, 12));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Space))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

    }
    void Audio_Color_RandomBand()
    {

        this.GetComponent<Renderer>().material.color = Utilities.GetRandomColor();

    }
}
