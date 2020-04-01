using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{
    public AudioClip clickSound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }


    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = clickSound;

        //button sfx volume 
        source.volume = 0.1f;

        source.playOnAwake = false;

        //when pressed it will activate that sound
        button.onClick.AddListener(()=> playSoundOnClick());
    }

    public void playSoundOnClick()
    {
        source.PlayOneShot(clickSound);
    }
}
