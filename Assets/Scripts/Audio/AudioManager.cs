using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake(){ //ustvarimo instance
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds){ //napolnino Sound
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    void Start(){ //zacne igrati bg music
       Play("Theme");
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }

    public void StopMusic(string name){
        Sound s1 = Array.Find(sounds, sound => sound.name == name);
        if (s1 == null) return;
        s1.source.Stop();
        Debug.Log("pause music stopped");
    }
}
