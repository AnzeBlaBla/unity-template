using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;
    public ExposedAudioGroup[] exposedGroups;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = MakeAudioSource(s);
        }
    }
    AudioSource MakeAudioSource(Sound sound, GameObject on = null)
    {
        AudioSource source;
        if (on == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            source = on.AddComponent<AudioSource>();
        }
        source.clip = sound.clip;
        source.volume = sound.volume;
        source.pitch = sound.pitch;
        source.loop = sound.loop;
        source.mute = sound.mute;
        source.spatialBlend = sound.spatialize;
        source.minDistance = sound.distanceMin;
        source.maxDistance = sound.distanceMax;
        return source;
    }

    public void Play(string name, GameObject playOn)
    {
        // Copy the sound and make a new one
        Sound sound = FindSoundByName(name);

        AudioSource newSource = MakeAudioSource(sound, playOn);
        newSource.Play();
    }

    public void Play(string name)
    {
        Sound s = FindSoundByName(name);
        s.source.Play();
        // if it's already playing, reset it (if reset is true)
        /* if (reset)
        {
            s.source.Stop();
            s.source.Play();
        }
        else if (!s.source.isPlaying)
        {
            s.source.Play();
        } */
    }
    private Sound FindSoundByName(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return null;
        }
        return s;
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    public void Resume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.UnPause();
    }
}
