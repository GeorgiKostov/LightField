using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.forward, Time.deltaTime*500f);
        }

    }


}
