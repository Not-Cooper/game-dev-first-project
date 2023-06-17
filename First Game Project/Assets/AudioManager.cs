using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager manager;

    void Awake()
    {
        //persist between scenes of game
        //checks if there is already an instance of manager between scenes so we dont have 2 at once
        DontDestroyOnLoad(gameObject);

        if (manager == null)
            manager = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        //Array is part of System import (dont need System.Array but lets me know)
        //this is just a wierd way to write a foreach loop
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        //Array is part of System import (dont need System.Array but lets me know)
        //this is just a wierd way to write a foreach loop
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found");
            return;
        }

        s.source.Stop();
    }
}
