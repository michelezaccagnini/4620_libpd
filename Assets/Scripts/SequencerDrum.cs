using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerDrum : MonoBehaviour
{
    public LibPdInstance patch;
    float ramp;
    float t;
    int[] mode;
    int count = 0;
    
    [SerializeField]
    List<bool> kick;
    [SerializeField]
    List<bool> snare;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        bool trig = ramp > (ramp + Time.deltaTime) % 1;
        ramp = (ramp + Time.deltaTime) % 1;

        if (trig)
        {
            if (kick[count])
            {
                patch.SendBang("kick_bang");

                count = (count + 1) % kick.Count;
            }

        }
    }
}
