using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDetector : MonoBehaviour
{
    int sampleWindow = 34;
    AudioClip microphoneAudioClip;

    private void Start()
    {
        for(int i = 0; i < Microphone.devices.Length; i++)
        {
            Debug.Log(Microphone.devices[i]);
        }

        microphoneToAudioClip();
    }

    void microphoneToAudioClip()
    {
        string micName = Microphone.devices[0];
        microphoneAudioClip = Microphone.Start(micName, true, 10, AudioSettings.outputSampleRate);
    }

    public float getLoudnessFromMicrophone()
    {
        return getLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneAudioClip);
    }

    public float getLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startingPosition = clipPosition - sampleWindow;

        if(startingPosition < 0)
        {
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startingPosition);

        float clipTotalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            clipTotalLoudness += Mathf.Abs(waveData[i]);
        }

        return clipTotalLoudness / sampleWindow;
    }
}
