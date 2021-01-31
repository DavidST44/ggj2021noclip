using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public AudioController menuSound;
    public AudioController puzzleSound;
    public AudioController ambientPuzzleSound;
    
    public GameObject audioControllerPrefab;
    
    public AudioController AddController(AudioClip clip, bool loop, float volume)
    {
        var go = Instantiate(audioControllerPrefab,transform.position, transform.rotation, transform);
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
        if(Instance)
            Destroy(Instance.gameObject);
        Instance = this;
        flightSound = AddController(flight, true, 1);
        voidAmbientSound = AddController(voidAmbient, true, 1);
        activeMusic = yungsMusic;
        menuSound = AddController(activeMusic.menu, true, 1);
        puzzleSound = AddController(activeMusic.puzzle, true, 1);
        ambientPuzzleSound = AddController(activeMusic.ambientPuzzle, true, 1);
        transform.SetParent(GameObject.Find("Player").transform);
        transform.localPosition = Vector3.zero;
    }
}
