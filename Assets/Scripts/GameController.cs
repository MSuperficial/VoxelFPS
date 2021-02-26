using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
    public GameObject panel_Stop;
    public GameObject panel_Options;
    public GameObject panel_Gameover;
    public GameObject player;
    public GameObject weapon;
    //private float timer;
    public Text text_HpLeft;
    public Text text_BulletsLeft;
    public Text text_Time;
    public Text text_Gameover;
    public Slider slider_Hp;
    public Slider slider_Bullet;
    public Slider slider_Volume;
    public Slider slider_MouseSpeed;
    public Toggle toggle_Mute;
    private bool isStop;
    private int seconds;
    private int minutes;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        isStop = false;
        panel_Stop.SetActive(false);
        panel_Options.SetActive(false);
        panel_Gameover.SetActive(false);
        Time.timeScale = 1;
        //timer = 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        Pause();
        HpChange();
        BulletChange();
        TimeChange();
        if(player.GetComponent<Player>().Hp <= 0)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            panel_Gameover.SetActive(true);
            isStop = true;
            Cursor.lockState = CursorLockMode.None;
            text_Gameover.text = "你存活了\n" + text_Time.text;
        }
        if(player.transform.position.y <= -75f)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            panel_Gameover.SetActive(true);
            isStop = true;
            Cursor.lockState = CursorLockMode.None;
            text_Gameover.text = "你掉出了这个世界";
        }
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isStop)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                isStop = true;
                panel_Stop.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                if(panel_Options.activeSelf)
                {
                    panel_Options.SetActive(false);
                    panel_Stop.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    Cursor.visible = false;
                    isStop = false;
                    panel_Stop.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HpChange()
    {
        slider_Hp.value = player.GetComponent<Player>().Hp;
        text_HpLeft.text = player.GetComponent<Player>().Hp.ToString();
    }

    public void BulletChange()
    {
        slider_Bullet.value = weapon.GetComponent<DesertEagle>().bullet;
        text_BulletsLeft.text = weapon.GetComponent<DesertEagle>().bullet.ToString();
    }

    public void TimeChange()
    {
        seconds = (int)Time.timeSinceLevelLoad;
        minutes = seconds / 60;
        seconds -= minutes * 60;
        if(seconds < 10 && minutes < 10)
        {
            text_Time.text = "0" + minutes + ":" + "0" + seconds;
        }
        if(seconds < 10 && minutes >= 10)
        {
            text_Time.text = minutes + ":" + "0" + seconds;
        }
        if(seconds >= 10 && minutes < 10)
        {
            text_Time.text = "0" + minutes + ":" + seconds;
        }
    }

    public void Options()
    {
        panel_Stop.SetActive(false);
        panel_Options.SetActive(true);
    }

    public void VolumeChange()
    {
        if(!toggle_Mute.isOn)
        {
            AudioListener.volume = slider_Volume.value;
        }
    }

    public void Mute()
    {
        AudioListener.volume = toggle_Mute.isOn ? (0.0f) : (slider_Volume.value);
    }

    public void MouseSpeed()
    {
        player.GetComponent<Move>().rotSpeed = slider_MouseSpeed.value;
        player.GetComponent<CameraChange>().rotSpeed = slider_MouseSpeed.value;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
}
