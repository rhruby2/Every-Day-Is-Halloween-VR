using UnityEngine.Audio;
using UnityEngine;
using System;



public class AudioManager : MonoBehaviour {
    [System.Serializable]   //shows in inspector
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0f,1f)]  //setups range for inspector
        public float volume;
        [Range(.1f,3f)]
        public float pitch;

        public bool loop = false;

        [HideInInspector]
        public AudioSource source;
    }

    public Sound[] sounds;
    public static AudioManager instance;

    //  called before Start
    void Awake () {
        //setting up AudioManager singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //adding Sounds to sounds array
		foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.name = s.name;
        }
	}

    void Start()
    {
        //Play("Theme");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("sound: " + s.name + " was not found"); return; }
        s.source.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
