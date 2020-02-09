using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]


public class MixerController : MonoBehaviour
{
    private Slider slide; //Slider for music
    
    [SerializeField] private AudioMixer audioM; //the audio mixer
    [SerializeField] private string nameParam; //parameter to change

    public void SetVolume(float val)
    {

        slide.value = val;
        audioM.SetFloat(nameParam, val);
        PlayerPrefs.SetFloat(nameParam, val);
    }

   

    void Start()
    {
        slide = GetComponent<Slider>();

        {
            float v = PlayerPrefs.GetFloat(nameParam, 0);
            SetVolume(v);
        }


    }


    void Update()
    {

    }

   

}
