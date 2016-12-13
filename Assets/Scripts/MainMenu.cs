using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static Color ambientLighting;
	public Text HighScoreText;

    bool settingsOpen;

    Animator anim;
    Slider sfx;
    Slider music;
    Slider gamma;

    void Awake() {
        anim = GetComponent<Animator>();
		HighScoreText.text = "High Score: " + FragmentManager.HighScore;
        sfx = GameObject.Find("SFX").GetComponent<Slider>();
        music = GameObject.Find("Music").GetComponent<Slider>();
        gamma = GameObject.Find("Gamma").GetComponent<Slider>();
        RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f, 1);
        ambientLighting = RenderSettings.ambientLight;
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

	public void tutorial(){
		SceneManager.LoadScene ("Tutorial");
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
        ambientLighting = RenderSettings.ambientLight;
    }
}
