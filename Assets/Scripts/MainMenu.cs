﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    bool settingsOpen;

    Animator anim;
    Slider sfx;
    Slider music;
    Slider gamma;

    void Awake() {
        anim = GetComponent<Animator>();
        sfx = GameObject.Find("SFX").GetComponent<Slider>();
    }

    public void startGame() {
        Application.LoadLevel(1);
    }

	public void openSettings() {
        settingsOpen = true;
        anim.SetBool("OpenSettings", true);
    }

    public void closeSettings() {
        settingsOpen = false;
        anim.SetBool("OpenSettings", false);
    }

    public void quit() {
        Application.Quit();
    }

    public void sfxSlider() {
        SoundManager.instance.Volume = sfx.value;
    }

    public void musicSlider() {
        //TODO: Insert MusicManager.instance.Volume = to music.value here
    }

    public void gammaSlider() {
        //TODO: Insert light brightness = to gamma.value here
    }
}
