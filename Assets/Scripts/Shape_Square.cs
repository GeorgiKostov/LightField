using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Square : MonoBehaviour
{
    public Animator Controller;

    public enum SquareAnim
    {
        Anim1, Anim2
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitShape(SquareAnim type, float speed, float kill)
    {
        Controller.speed = speed;
        switch (type)
        {
            case SquareAnim.Anim1:
                Controller.Play("Square_Anim1");
                break;
            case SquareAnim.Anim2:
                Controller.Play("Square_Anim2");
                break;
        }
        Invoke("Kill", kill);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
