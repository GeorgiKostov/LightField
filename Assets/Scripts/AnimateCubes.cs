﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCubes : MonoBehaviour {

    public enum AnimationState {
        DownUp, UpDown, LeftRight, RightLeft, CenterOut, OutCenter,
        CircleClockwise, CircleCounterClock, RotateAround, Clock, Star
    }
    public enum StartState {
        Up, Down, Left, Right, Center
    }
    public GameObject[] Cubes;
    public AnimationState CurrentState;
    public float DeathTimer;
    public float LerpVal;
    public float Multiplier;
    public float AnimSpeed;
    //member vars
    Vector2 _centre;
    public float _angle;
    public float[] _angles;

    void Start() {
        _centre = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
    }




    void FixedUpdate() {
        switch (CurrentState) {
            case AnimationState.LeftRight:
                for (int i = 0; i < Cubes.Length; i++) {
                    Audio_Pos_LeftRight(Cubes, i);
                }
                break;
            case AnimationState.CircleClockwise:
                for (int i = 0; i < Cubes.Length; i++) {
                    Anim_Circle_Clockwise(Cubes, i);
                }
                break;
            case AnimationState.Clock:
                for (int i = 0; i < Cubes.Length; i++) {
                    Anim_Clock(Cubes, i);
                }
                break;
            case AnimationState.CircleCounterClock:
                for (int i = 0; i < Cubes.Length; i++) {
                    Anim_Circle_Counterclock(Cubes, i);
                }
                break;
            case AnimationState.Star:
                for (int i = 0; i < Cubes.Length; i++) {
                    Anim_Star(Cubes, i);
                }
                break;
        }
    }

    public void InitAudioAnimation(AnimationState state, float destroyTime,
    float multiplier, float lerp, float speed) {
        CurrentState = state;
        DeathTimer = destroyTime;
        Multiplier = multiplier;
        LerpVal = lerp;
        AnimSpeed = speed;
        //Invoke("Kill", DeathTimer);
    }

    void Setup_Adjust_StartingPos(Vector3 start, float offsetX, float offsetY) {
        Cubes[0].transform.localPosition = start;
        for (int i = 1; i < Cubes.Length; i++) {
            Cubes[i].transform.localPosition = new Vector3(Cubes[i - 1].transform.localPosition.x + offsetX,
                Cubes[i - 1].transform.localPosition.y + offsetY, Cubes[i].transform.localPosition.z);
        }
    }

    public void SetupCircle() {
        float angle = -180;
        for (int i = 0; i < Cubes.Length; i++) {
            Cubes[i].transform.position = Utilities.RandomCircle(_centre, Utilities.RandomFloat(-1, 1));
            //Vector2 aPosOnCircle = new Vector2(
            //    _centre.x + .5f * Mathf.Sin(angle * Mathf.Deg2Rad),
            //    _centre.y + .5f * Mathf.Cos(angle * Mathf.Deg2Rad)
            //    );
            //Cubes[i].transform.position = aPosOnCircle;
            //angle += 40;
        }
    }

    public void SetupCircle2() {
        float offset = .1f;
        float angle = -90;
        _angles = new float[Cubes.Length];
        for (int i = 0; i < Cubes.Length; i++) {
            //Cubes[i].transform.position = Utilities.RandomCircle(_centre, Utilities.RandomFloat(-1, 1));
            Vector2 aPosOnCircle = new Vector2(
                _centre.x + .5f * Mathf.Sin(angle * Mathf.Deg2Rad),
                _centre.y + .5f * Mathf.Cos(angle * Mathf.Deg2Rad)
                );
            Cubes[i].transform.position = aPosOnCircle;
            angle += 20;
        }
    }
    void Kill() {
        Destroy(gameObject);
    }
    void Audio_Scale_BottomUp(GameObject[] array, int i) {
        array[i].transform.localScale = Vector3.Lerp(array[i].transform.localScale,
    new Vector3(array[i].transform.localScale.x, AudioManager.FreqBand[i] * Multiplier,
        array[i].transform.localScale.z), Time.deltaTime * LerpVal);

        array[i].transform.localPosition = Vector3.Lerp(array[i].transform.localPosition,
    new Vector3(array[i].transform.localPosition.x, (AudioManager.FreqBand[i] * Multiplier) / 2,
    array[i].transform.localPosition.z), Time.deltaTime * LerpVal);
    }

    void Audio_Pos_BottomUp(GameObject[] array, int i) {
        array[i].transform.localPosition = Vector3.Lerp(array[i].transform.localPosition,
    new Vector3(array[i].transform.localPosition.x, (AudioManager.FreqBand[i] * Multiplier),
        array[i].transform.localPosition.z), Time.deltaTime * LerpVal);
    }

    void Audio_Pos_LeftRight(GameObject[] array, int i) {
        array[i].transform.localPosition = Vector3.Lerp(array[i].transform.localPosition,
    new Vector3(AudioManager.FreqBand[i] * Multiplier, array[i].transform.localPosition.y,
        array[i].transform.localPosition.z), Time.deltaTime * LerpVal);
    }

    void Audio_Circle_Pos(GameObject[] array, int i) {

        array[i].transform.localPosition = Vector3.Lerp(array[i].transform.localPosition,
                Utilities.RandomCircle(new Vector3(1.5f, 1, 0), 3), Time.deltaTime * LerpVal);

    }
    void Anim_Clock(GameObject[] array, int i) {
        _angle += AnimSpeed * Time.deltaTime;
        //var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle))*10f;
        Vector2 aPosOnCircle = new Vector2(
    _centre.x + .2f * i * Mathf.Sin(_angle * Mathf.Deg2Rad),
    _centre.y + .2f * i * Mathf.Cos(_angle * Mathf.Deg2Rad)
    );
        Cubes[i].transform.position = aPosOnCircle;
    }
    void Anim_Circle_Clockwise(GameObject[] array, int i) {
        _angles[i] += Time.deltaTime * AnimSpeed * Utilities.RandomFloat(0, 120);
        if (_angles[i] >= 360)
            _angles[i] = 0;
        Vector2 aPosOnCircle = new Vector2(
    _centre.x + AudioManager.FreqBand[i] * Multiplier * Mathf.Sin(_angles[i] * Mathf.Deg2Rad),
    _centre.y + AudioManager.FreqBand[i] * Multiplier * Mathf.Cos(_angles[i] * Mathf.Deg2Rad)
    );
        Cubes[i].transform.position = Vector3.Lerp(Cubes[i].transform.position, aPosOnCircle, Time.deltaTime * LerpVal);
    }

    void Anim_Circle_Counterclock(GameObject[] array, int i) {
        _angles[i] -= Time.deltaTime * AnimSpeed * Utilities.RandomFloat(0, 120);
        if (_angles[i] <= -360)
            _angles[i] = 0;
        Vector2 aPosOnCircle = new Vector2(
    _centre.x + AudioManager.FreqBand[i] * Multiplier * Mathf.Sin(_angles[i] * Mathf.Deg2Rad),
    _centre.y + AudioManager.FreqBand[i] * Multiplier * Mathf.Cos(_angles[i] * Mathf.Deg2Rad)
    );
        Cubes[i].transform.position = Vector3.Lerp(Cubes[i].transform.position, aPosOnCircle, Time.deltaTime * LerpVal);
    }

    void Anim_Star(GameObject[] array, int i) {
        _angles[i] = Utilities.RandomFloat(0, 120);
        Vector2 aPosOnCircle = new Vector2(
    _centre.x + AudioManager.FreqBand[i] * Multiplier * Mathf.Sin(_angles[i] * Mathf.Deg2Rad),
    _centre.y + AudioManager.FreqBand[i] * Multiplier * Mathf.Cos(_angles[i] * Mathf.Deg2Rad)
    );
        Cubes[i].transform.position = Vector3.Lerp(Cubes[i].transform.position, aPosOnCircle, Time.deltaTime * LerpVal);

    }

    void Anim_FireFlies(GameObject[] array, int i) {
        _angles[i] = Time.deltaTime * AnimSpeed * Utilities.RandomFloat(-180, 180);
        //var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle))*10f;
        Vector2 aPosOnCircle = new Vector2(
    _centre.x + Mathf.Sin(_angles[i] * Mathf.Deg2Rad),
    _centre.y + Mathf.Cos(_angles[i] * Mathf.Deg2Rad)
    );
        Cubes[i].transform.position = Vector3.Lerp(Cubes[i].transform.position, aPosOnCircle, Time.deltaTime * LerpVal);
    }
}
