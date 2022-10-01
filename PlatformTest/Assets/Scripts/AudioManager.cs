using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public bool musicOn = true;

    void Awake(){

        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start(){
        Play("MainTheme");
    }

    void Update(){
        if(musicOn == false && GetSource("MainTheme").isPlaying){
            Pause("MainTheme");
        }else if(musicOn == true && !GetSource("MainTheme").isPlaying){
            Play("MainTheme");
        }
    }

    public void Play(string name){
        Sound s =Array.Find(sounds, sound=> sound.name == name);
        if(s == null)
            return;
        s.source.Play();
    }

    public void Pause(string name){
        Sound s = Array.Find(sounds, sound=> sound.name == name);
        if(s == null)
            return;
        s.source.Pause();
    }

    public AudioSource GetSource(string name){
        Sound s = Array.Find(sounds, sound=> sound.name == name);
        return s.source;

    }

    public void ToggleMusic(){
        musicOn = !musicOn;
    }


}
