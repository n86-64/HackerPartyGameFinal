using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingMenuController : MonoBehaviour
{
    private int soundEffectPercentage = 50;
    private int musicPercentage = 50;

    public Text soundEffectPercentageUI;
    public Text musicPercentageUI;

    private bool soundEffectVolumeSelected = true;
    private bool musicVolumeSelected = false;

    private float timer = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer);
        if (timer > 0.0f)
        {
            timer -= 0.1f;
        }

        soundEffectPercentageUI.text = soundEffectPercentage.ToString() + "%";
        musicPercentageUI.text = musicPercentage.ToString() + "%";

        float vertical = Input.GetAxis("Vertical");

        //Debug.Log(vertical);

        if (Input.GetAxis("Vertical") < 0.0f)
        {
            soundEffectVolumeSelected = true;
            musicVolumeSelected = false;
            soundEffectPercentageUI.color = new Color(1f, 0f, 0f);
            musicPercentageUI.color = new Color(0.2f, 0.2f, 0.2f);
        }
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            soundEffectVolumeSelected = false;
            musicVolumeSelected = true;
            musicPercentageUI.color = new Color(1f, 0f, 0f);
            soundEffectPercentageUI.color = new Color(0.2f, 0.2f, 0.2f);
        }

        if (Input.GetAxis("Horizontal") < 0.0f && timer <= 0)
        {
            timer = 1f;

            if (soundEffectVolumeSelected == true && soundEffectPercentage > 0)
            {
                soundEffectPercentage -= 5;
            }
            if (musicVolumeSelected == true && musicPercentage > 0)
            {
                musicPercentage -= 5;
            }
        }

        if (Input.GetAxis("Horizontal") > 0.0f && timer <= 0)
        {
            timer = 1f;

            if (soundEffectVolumeSelected == true && soundEffectPercentage < 100)
            {
                soundEffectPercentage +=5;
            }
            if (musicVolumeSelected == true && musicPercentage < 100)
            {
                musicPercentage +=5;
            }
        }

        if (Input.GetButtonDown("AnyPlayerBButton"))
        {
            Application.LoadLevel("Menu");
        }
    }
}