using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
   
        #region Singleton for SFX
        public static SFX instance = null;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        #endregion

        public AudioClip sfx;

        private AudioSource source { get { return GetComponent<AudioSource>(); } }


        void Start()
        {
     
            gameObject.AddComponent<AudioSource>();
            source.clip = sfx;

            //SFX volume level
            source.volume = 0.3f;
            source.playOnAwake = false;

        }

        public void playSound()
        {
            source.PlayOneShot(sfx);
        }
    
}
