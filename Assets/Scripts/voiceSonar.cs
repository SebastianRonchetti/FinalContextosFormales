using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class voiceSonar : MonoBehaviour
{
    AudioDetector detector;
    public AudioSource aSource;
    [SerializeField] Camera cam;
    int clipLimitFar = 25, clipLimitNear = 5, sensitivity = 15;
    float clipIncrease, clipDecrease, currentLoudest;
    bool voiceExtendedSight = false;

    // Start is called before the first frame update
    void Start()
    {
        aSource.loop = false;
        cam.farClipPlane = clipLimitNear;
        cam.nearClipPlane = 0.3f;
        clipDecrease = 0.2f;
        detector = GetComponent<AudioDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        float fixerNumber = 0;
        clipIncrease = detector.getLoudnessFromMicrophone();

        //usar multiplicacion para incrementar el numero obtenido de clip increase da un valor menor al inicial, ironicamente,
        // dividir el valor aumenta el total
        
        if (!voiceExtendedSight || cam.farClipPlane <= clipLimitNear + 2)
        {
            voiceExtendedSight = true;
            StartCoroutine(screamCooldown());
            fixerNumber = sensitivity / clipIncrease;
            stablishFarsight(fixerNumber);
        }

        if (cam.farClipPlane > clipLimitNear)
        {
            fixerNumber = Mathf.Lerp(cam.farClipPlane, clipLimitNear, clipDecrease * Time.deltaTime);
            stablishFarsight(fixerNumber);
        }

        stablishFarsight(fixerNumber);
    }

    void stablishFarsight(float distance)
    {
        if (distance > clipLimitFar)
        {
            distance = clipLimitFar;
        }

        if (distance < clipLimitNear + 0.5)
        {
            distance = clipLimitNear;
            voiceExtendedSight = false;
        }

        cam.farClipPlane = distance;
    }

    IEnumerator screamCooldown()
    {
        yield return new WaitForSeconds(10f);
        voiceExtendedSight = false;
    }

    void cheatSound()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
            clipIncrease = detector.getLoudnessFromAudioClip(aSource.timeSamples, aSource.clip);
        }
        else
        {
            if (aSource.isPlaying)
            {
                aSource.Stop();
            }
        }
    }
}
