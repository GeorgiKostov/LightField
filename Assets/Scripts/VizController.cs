using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizController : MonoBehaviour
{

    public GameObject[] YCubes;
    public GameObject[] XCubes;

    public GameObject[] ColorSpheres;
    [Header("Scale")]
    public float ScaleMult;
    public float Xdistance;
    [Header("Position")]
    public float Ydistance;
    public float PosMult;
    [Header("Lerps")]
    public float LerpVal_scale = 2f;
    public float LerpVal_pos = 5;

    public Material ColorChanger;
    void Start()
    {
        for (int i = 0; i < ColorSpheres.Length; i++)
        {
            ColorSpheres[i].GetComponent<Renderer>().material = new Material(ColorChanger);
        }
        InvokeRepeating("Audio_Color_RandomBand", 1f, .1f);
        //InvokeRepeating("AnimateScale", 1f, .05f);

        //position cubes correctly
        //push next cubes further from first one
        //Setup_Adjust_StartingPos();
        InvokeRepeating("Audio_Circle_Pos", 1f, .1f);

    }


    void FixedUpdate()
    {

        for (int i = 0; i < YCubes.Length; i++)
        {
            //Audio_Scale_BottomUp(XCubes,i);
            //Audio_Pos_BottomUp(YCubes, i);
            //Audio_Pos_LeftRight(XCubes, i);
            //Audio_Circle_Pos(XCubes, i);
        }

    }

    void Audio_Color_RandomBand()
    {
        for (int i = 0; i < ColorSpheres.Length; i++)
        {

            ColorSpheres[i].GetComponent<Renderer>().material.color = new Color(AudioManager.FreqBand[Utilities.RandomInt(0, 8)], AudioManager.FreqBand[Utilities.RandomInt(0, 8)], AudioManager.FreqBand[Utilities.RandomInt(0, 8)]);
        }
    }

    void Audio_Circle_Pos()
    {
        for (int i = 0; i < YCubes.Length; i++)
        {
            XCubes[i].transform.localPosition = Vector3.Lerp(XCubes[i].transform.localPosition,
                Utilities.RandomCircle(new Vector3(1.5f, 1, 0), 3), Time.deltaTime*LerpVal_pos);
        }
    }

    void Setup_Adjust_StartingPos()
    {
        for (int i = 1; i < YCubes.Length; i++)
        {
            YCubes[i].transform.localPosition = new Vector3(YCubes[i - 1].transform.localPosition.x + Xdistance,
                YCubes[i].transform.localPosition.y, YCubes[i].transform.localPosition.z);
        }
        for (int i = 1; i < XCubes.Length; i++)
        {
            XCubes[i].transform.localPosition = new Vector3(XCubes[i].transform.localPosition.x,
                XCubes[i - 1].transform.localPosition.y + Ydistance, XCubes[i].transform.localPosition.z);
        }
    }

    void Audio_Scale_BottomUp(GameObject[] array, int i)
    {
        array[i].transform.localScale = Vector3.Lerp(array[i].transform.localScale,
    new Vector3(array[i].transform.localScale.x, AudioManager.FreqBand[i] * ScaleMult,
        array[i].transform.localScale.z), Time.deltaTime * LerpVal_scale);

        array[i].transform.localPosition = Vector3.Lerp(array[i].transform.localPosition,
new Vector3(array[i].transform.localPosition.x, (AudioManager.FreqBand[i] * ScaleMult) / 2,
array[i].transform.localPosition.z), Time.deltaTime * LerpVal_scale);
    }

    void Audio_Pos_BottomUp(GameObject[] array, int i)
    {
        array[i].transform.localPosition = Vector3.Lerp(array[i].transform.localPosition,
    new Vector3(array[i].transform.localPosition.x, (AudioManager.FreqBand[i] * PosMult),
        array[i].transform.localPosition.z), Time.deltaTime * LerpVal_scale);
    }

    void Audio_Pos_LeftRight(GameObject[] array, int i)
    {
        array[i].transform.localPosition = Vector3.Lerp(array[i].transform.localPosition,
    new Vector3(AudioManager.FreqBand[i] * PosMult, array[i].transform.localPosition.y,
        array[i].transform.localPosition.z), Time.deltaTime * LerpVal_pos);
    }
}

