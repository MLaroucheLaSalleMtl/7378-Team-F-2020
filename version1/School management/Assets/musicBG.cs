using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class musicBG : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic; 

    private AudioSource bgMusic; 

    [SerializeField] private GameObject musicPanel;

    bool panelActivation = false;


    public void openPanel()
    {
        musicPanel.SetActive(true);
        panelActivation = true;
    }

    public void closePanel()
    {
        musicPanel.SetActive(false);
        panelActivation = false;
    }

    public void doPanel()
    {
        if (panelActivation)
        {
            closePanel();
            Debug.Log("close ");
        }
        else
        {
            openPanel();
            Debug.Log("open ");
        }
    }

    public void PlayPauseMusic()
    {
        // Check if the music is currently playing.
        if (bgMusic.isPlaying)
            bgMusic.Pause(); // Pause if it is
        else
            bgMusic.Play(); // Play if it isn't
    }

    public void PlayStop()
    {
        if (bgMusic.isPlaying)
            bgMusic.Stop();
        else
            bgMusic.Play();
    }

    public void PlayMusic()
    {
        bgMusic.Play();
    }

    public void StopMusic()
    {
        bgMusic.Stop();
    }

    public void PauseMusic()
    {
        bgMusic.Pause();
    }

    void Start()
    {

        bgMusic = GetComponent<AudioSource>();


        bgMusic.clip = backgroundMusic;

        bgMusic.volume = 0.010f;
        PlayMusic();

    }

    void Update()
    {
        
    }
}
