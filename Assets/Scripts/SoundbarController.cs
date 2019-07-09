﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundbarController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void changeSound(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
