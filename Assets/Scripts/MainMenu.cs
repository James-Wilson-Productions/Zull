using UnityEngine;
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
        music = GameObject.Find("Music").GetComponent<Slider>();
        gamma = GameObject.Find("Gamma").GetComponent<Slider>();
        RenderSettings.ambientLight = new Color(0.2f, 0.2f, 0.2f, 1);
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
        GameObject.FindObjectOfType<MusicManager>().GetComponent<MusicManager>().SetVolume(music.value);
    }

    public void gammaSlider() {
        RenderSettings.ambientLight = new Color(gamma.value, gamma.value, gamma.value, 1);
    }
}
