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
    [Space(10)]
    [Header("3D Audio")]
    [Range(0f, 1f)]
    public float spatialize = 0f;
    public float distanceMin = 0f;
    public float distanceMax = 500f;
    
    [HideInInspector]
    public AudioSource source;
}