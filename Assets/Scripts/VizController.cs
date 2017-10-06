using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizController : MonoBehaviour {


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

    public GameObject XCubes;
    public GameObject YCubes;
    public GameObject Beam;

    void Start() {

        GameObject newAnim = Instantiate(XCubes, transform.position, Quaternion.identity);
        newAnim.GetComponent<AnimateCubes>().InitAudioAnimation(AnimateCubes.AnimationState.Star,
            10f, 1f, 1f, 2f);
        newAnim.GetComponent<AnimateCubes>().SetupCircle2();
        /*
        GameObject newBeam = Instantiate(Beam, transform.position, Quaternion.identity);
        newBeam.GetComponent<Beam>().InitBeam(global::Beam.BeamType.BeamX, .2f);

        GameObject beam2 = Instantiate(Beam, transform.position, Quaternion.identity);
        beam2.GetComponent<Beam>().InitBeam(global::Beam.BeamType.BeamY, .5f);
   */
    }


    void FixedUpdate() {
        //Audio_Scale_BottomUp(XCubes,i);
        //Audio_Pos_BottomUp(YCubes, i);
        //Audio_Pos_LeftRight(XCubes, i);
        //Audio_Circle_Pos(XCubes, i);

    }
}

