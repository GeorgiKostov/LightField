using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : AManager<AudioManager>
{

    //Audio Anim
    public AudioSource audio;
    public static float[] Samples = new float[512];
    public static float[] FreqBand = new float[8];
    public bool MicOn;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (MicOn)
            StreamMic();
    }

    void Update()
    {
        audio.GetSpectrumData(Samples, 0, FFTWindow.Blackman);
        MakeFrequencyBands();
    }

    void StreamMic()
    {
        audio.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        audio.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audio.Play();
    }

    void MakeFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += Samples[count] * (count + 1);
                count++;
            }
            average /= count;
            FreqBand[i] = average * 10;
        }
    }
}

