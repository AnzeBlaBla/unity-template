using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = MakeAudioSource(s).GetComponent<AudioSource>();
        }
    }
    GameObject MakeAudioSource(Sound sound, Vector3 position = default(Vector3))
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.SetParent(transform);
        go.transform.position = position;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = sound.clip;
        source.volume = sound.volume;
        source.pitch = sound.pitch;
        source.loop = sound.loop;
        source.mute = sound.mute;

        source.spatialBlend = sound.spatialize;
        source.minDistance = sound.distanceMin;
        source.maxDistance = sound.distanceMax;

        source.outputAudioMixerGroup = sound.group.group;
        return go;
    }

    IEnumerator DestroyAfterPlay(GameObject go)
    {
        yield return new WaitForSeconds(go.GetComponent<AudioSource>().clip.length);
        Destroy(go);
    }
    public void Play(string name, GameObject playOn)
    {
        Sound sound = FindSoundByName(name);

        GameObject newGo = MakeAudioSource(sound, playOn.transform.position);
        newGo.GetComponent<AudioSource>().Play();
        if(!sound.loop)
            StartCoroutine(DestroyAfterPlay(newGo));
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
