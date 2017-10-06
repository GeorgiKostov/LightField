using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateColor : MonoBehaviour {

    public GameObject[] ColorSpheres;
    public Material ColorChanger;
    void Start () {
        for (int i = 0; i < ColorSpheres.Length; i++) {
            ColorSpheres[i].GetComponent<Renderer>().material = new Material(ColorChanger);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Audio_Color_RandomBand() {
        for (int i = 0; i < ColorSpheres.Length; i++) {

            ColorSpheres[i].GetComponent<Renderer>().material.color = new Color(AudioManager.FreqBand[Utilities.RandomInt(0, 8)], AudioManager.FreqBand[Utilities.RandomInt(0, 8)], AudioManager.FreqBand[Utilities.RandomInt(0, 8)]);
        }
    }
}
 