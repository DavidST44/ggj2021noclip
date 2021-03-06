using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = System.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class GameMusic
    {
        public AudioClip menu;
        public AudioClip puzzle;
        public AudioClip ambientPuzzle;
    }

    public GameMusic yungsMusic;
    public GameMusic abbysMusic;
    public GameMusic activeMusic;
    public AudioClip death;
    public AudioClip gameOver;
    public AudioClip damage;
    public AudioClip pickUp;
    public AudioClip noClip;
    public AudioClip voidAmbient;
    public AudioClip flight;

    public AudioController flightSound;
    public AudioController voidAmbientSound;
    
    // Music
    public AudioController menuPopupMusic;
    public AudioController menuMusic;
    public AudioController puzzleMusic;
    public AudioController voidMusic;

    public GameObject audioControllerPrefab;

    public AudioController AddController(AudioClip clip, bool loop, float volume)
    {
        var go = Instantiate(audioControllerPrefab, transform.position, transform.rotation, transform);
        go.name = clip.name;
        var audioController = go.GetComponent<AudioController>();
        audioController.audioSource = go.GetComponent<AudioSource>();
        audioController.audioSource.clip = clip;
        audioController.audioSource.loop = loop;
        audioController.audioSource.volume = volume;
        return audioController;
    }

    private void Awake()
    {
        if (Instance)
            Destroy(Instance.gameObject);
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        flightSound = AddController(flight, true, 1);
        voidAmbientSound = AddController(voidAmbient, true, 1);
        activeMusic = yungsMusic;
        menuMusic = AddController(activeMusic.menu, true, 1);
        puzzleMusic = AddController(activeMusic.puzzle, true, 1);
        voidMusic = AddController(activeMusic.ambientPuzzle, true, 1);
        menuPopupMusic = AddController(abbysMusic.menu, true, 1);
    }
}