using System;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Sound", menuName = "NimamoŠe/Sound", order = 1)]
public class Sound : ScriptableObject
{
    public AudioClip clip;
    public ExposedAudioGroup group;
    public float volume = 1f;
    public float pitch = 1f;
    public bool loop = false;
    public bool mute = false;
    
    [HideInInspector]
    public AudioSource source;
}