using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

     public  AudioSource backGroundSource;
    public AudioSource eventSource;

    public AudioClip background;
    public AudioClip button;
    public AudioClip win;
    public AudioClip popUp;
    public AudioClip gameBackground;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public  void WinSound() {
        backGroundSource.clip=win;
        backGroundSource.Play();
    }


    public void ButtonClick()
    {
        eventSource.PlayOneShot(button);
    }

    public void PopUpClick()
    {
        eventSource.PlayOneShot(popUp);
    }


    public void OnMute() {
        eventSource.mute = true;
        backGroundSource.mute = true;
    }

    public void OnPlay()
    {
        eventSource.mute = false;
        backGroundSource.mute = false;
    }


}
