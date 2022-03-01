using System;
using UnityEngine;
using UnityEngine.Audio;


[CreateAssetMenu(fileName = "ExposedAudioGroup", menuName = "NimamoŠe/ExposedAudioGroup", order = 1)]
public class ExposedAudioGroup : ScriptableObject
{
    public AudioMixerGroup group;
    public string exposedName;

    public void SetValue(float value)
    {
        group.audioMixer.SetFloat(exposedName, value);
    }
}