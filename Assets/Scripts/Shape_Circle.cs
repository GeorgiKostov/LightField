using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Circle : MonoBehaviour
{

    public Animator Controller;

	void Start () {
		
	}
	
	void Update () {
		
	}
    public void InitShape(float speed, float kill)
    {

        Controller.speed = speed;
        Invoke("Kill", kill);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
