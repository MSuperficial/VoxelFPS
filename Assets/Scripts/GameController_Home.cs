using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController_Home : MonoBehaviour {
    public GameObject panel_Option;
    public GameObject panel_Choose;
    public GameObject weapon;
    public Slider slider_Volume;
    public Toggle toggle_Mute;
    public GameObject button_play1;
    public GameObject button_option;
    public GameObject button_quit;
    public GameObject button_play2;
    public GameObject text;
    public float rotateSpeed;
	// Use this for initialization
	void Start () {
        panel_Option.SetActive(false);
        panel_Choose.SetActive(false);
        weapon.SetActive(false);
        button_play2.SetActive(false);
        text.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
	
	// Update is called once per frame
	void Update () {
        Esc();
        SelfRotate();
	}

    public void Quit()
    {
        Application.Quit();
    }

    public void Option()
    {
        panel_Option.SetActive(true);
    }

    public void Esc()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(panel_Option.activeSelf)
            {
                panel_Option.SetActive(false);
            }
        }
    }

    public void Play_1()
    {
        panel_Choose.SetActive(true);
        weapon.SetActive(true);
        button_play2.SetActive(true);
        button_play1.SetActive(false);
        button_option.SetActive(false);
        button_quit.SetActive(false);
        text.SetActive(true);
    }

    public void Play_2()
    {
        SceneManager.LoadScene("Playing");
    }

    public void SelfRotate()
    {
        weapon.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    public void VolumeChange()
    {
        if (!toggle_Mute.isOn)
        {
            AudioListener.volume = slider_Volume.value;
        }
    }

    public void Mute()
    {
        AudioListener.volume = toggle_Mute.isOn ? (0.0f) : (slider_Volume.value);
    }

}
