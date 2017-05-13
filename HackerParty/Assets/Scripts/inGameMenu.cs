using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class inGameMenu : MonoBehaviour {

    public Text leaveConfirm;
    public Text no;
    public Text yes;
    public Image popupBackground;
    public Image AButton;
    public Image BButton;

    private int playerPausing = 0;
    private bool popUpMenu = false;

    private string optionAInput = "Player0JoinReady";
    private string optionBInput = "Player0BButton";


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int playerSelected = 0;

        for (int i = 0; i < 8; i++)
        {
            string inputName = "PlayerxMenu";
            char[] inputCharray = new char[11];
            for (int j = 0; j < 11; j++)
            {
                inputCharray[j] = inputName[j];
            }

            inputCharray[6] = (char)(i + 48);
            playerSelected = i;

            inputName = new string(inputCharray);

            if (Input.GetButtonDown(inputName))
            {      
                playerPausing = playerSelected;

                Debug.Log("Menu Selected");
                popUpMenu = true;
                leaveConfirm.text = "Player " + playerPausing.ToString() + ", Confirm Drop Out?";
                PopUpSwitchTransparent(false);

                //optionA
                string menuOptionA = "PlayerxJoinReady";
                char[] inputOptionACharray = new char[16];
                for (int j = 0; j < 16; j++)
                {
                    inputOptionACharray[j] = menuOptionA[j];
                }
                inputOptionACharray[6] = (char)(playerPausing + 48);
                optionAInput = new string(inputOptionACharray);

                //optionB
                string menuOptionB = "PlayerxBButton";
                char[] inputOptionBCharray = new char[14];
                for (int j = 0; j < 14; j++)
                {
                    inputOptionBCharray[j] = menuOptionB[j];
                }

                inputOptionBCharray[6] = (char)(playerPausing + 48);
                optionBInput = new string(inputOptionBCharray);
            }
        }

        if (popUpMenu == true && Input.GetButtonDown(optionAInput))
        {
            Debug.Log("A!");
            popUpMenu = false;
            PopUpSwitchTransparent(true);
        }

        if (popUpMenu == true && Input.GetButtonDown(optionBInput))
        {
            Debug.Log("B!");
            popUpMenu = false;
            PopUpSwitchTransparent(true);
        }
    }
    





    void PopUpSwitchTransparent(bool transparent)
    {
        if (transparent == true)
        {
            leaveConfirm.color = Color.clear;
            no.color = Color.clear;
            yes.color = Color.clear;
            popupBackground.color = Color.clear;
            AButton.color = Color.clear;
            BButton.color = Color.clear;
        }
        if (transparent == false)
        {
            leaveConfirm.color = Color.red;
            no.color = Color.red;
            yes.color = Color.red;
            popupBackground.color = Color.white;
            AButton.color = Color.white;
            BButton.color = Color.white;
        }
    }

}