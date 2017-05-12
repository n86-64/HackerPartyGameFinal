using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
    private int playersJoined = 0;
    private int playersReady = 0;
    private bool gameStart = true;
    private bool[] playerReadyArray = new bool[7];
    private bool[] playerJoinedArray = new bool[7];
    private Object[] spriteArray = new Object[7];

    public List<Image> boxList;
    public List<GameObject> characterList;

    private List<int> inputQueueButtonA = new List<int>();
    private List<int> inputQueueButtonB = new List<int>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            playerReadyArray[i] = false;
            playerJoinedArray[i] = false;
        }
	}

    // Update is called once per frame
    void Update()
    {
        int playerSelected = 0;
        bool triggered = false;

        if (Input.GetButtonDown("Quit"))
        {
            QuitGame();
        }

        if (playersJoined == playersReady && (playersJoined > 1))
        {
            LoadGame();
        }

        if (Input.GetButtonDown("OptionsMenu"))
        {
            LoadSettingsMenu();
        }

        if(Input.GetButtonDown("PlayerAnyJoinReady") || Input.GetButtonDown("AnyPlayerBButton"))
        {
            triggered = true;
        }


        for (int i = 0; i < 8; i++)
        {
            string inputName = "PlayerxJoinReady";
            char[] inputCharray = new char[16];
            for (int j = 0; j < 16; j++)
            {
                inputCharray[j] = inputName[j];
            }

            inputCharray[6] = (char)(i + 48);
            playerSelected = i;

            inputName = new string(inputCharray);

            
            if (Input.GetButtonDown(inputName))
            {
                //Debug.Log(playerSelected);
                inputQueueButtonA.Add(playerSelected);
            }
        }
        for (int i = 0; i < 8; i++)
        {
            string inputName = "PlayerxBButton";
            char[] inputCharray = new char[14];
            for (int j = 0; j < 14; j++)
            {
                inputCharray[j] = inputName[j];
            }

            inputCharray[6] = (char)(i + 48);
            playerSelected = i;

            inputName = new string(inputCharray);


            if (Input.GetButtonDown(inputName))
            {
                //Debug.Log(playerSelected);
                inputQueueButtonB.Add(playerSelected);
            }
        }

        //Debug.Log(triggered);
        if (triggered == true)
        {
            toggleReady(triggered);
        }
        
        if (triggered == true)
        {
            joinGame(triggered);
        }

        if (triggered == true)
        {
            leaveGame();
        }

        inputQueueButtonA.Clear();
        inputQueueButtonB.Clear();
    }

    void LoadSettingsMenu()
    {
        Application.LoadLevel("Settings");
    }
    void LoadGame()
    {
        Debug.Log("trying to load main");
        Application.LoadLevel("BaseScene");
    }
    
    void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    void joinGame(bool triggered)
    {
        triggered = false;


        //Debug.Log("hello");
        for (int i = 0; i < inputQueueButtonA.Count; i++)
        {
            //Debug.Log(inputQueueButtonA[i]);
            //Debug.Log(playerJoinedArray[inputQueueButtonA[i]]);
            if (playerJoinedArray[inputQueueButtonA[i]] == false)
            {
                Debug.Log("please show more that once");
                playerJoinedArray[inputQueueButtonA[i]] = true;
                playersJoined++;

                spawnSprite(inputQueueButtonA[i]);
            }
        }
    }

    void leaveGame()
    {
        for (int i = 0; i < inputQueueButtonB.Count; i++)
        {
            if (playerJoinedArray[inputQueueButtonB[i]] == true)
            {
                Debug.Log("leave game registered");
                Debug.Log(i);
                playerReadyArray[inputQueueButtonB[i]] = false;
                playerJoinedArray[inputQueueButtonB[i]] = false;

                Sprite.Destroy(spriteArray[inputQueueButtonB[i]], 0);

                boxList[inputQueueButtonB[i]].GetComponent<Image>().color = new Color(1f, 1f, 1f);

                playersJoined--;             
            }
        }
    }

    void toggleReady(bool triggered)
    {
       // triggered = false;
        for (int i = 0; i < inputQueueButtonA.Count; i++)
        {
            //Debug.Log(inputQueueButtonA[i]);
            if (playerReadyArray[inputQueueButtonA[i]] == false && playerJoinedArray[inputQueueButtonA[i]] == true)
            {
                playerReadyArray[inputQueueButtonA[i]] = true;
                boxList[inputQueueButtonA[i]].GetComponent<Image>().color = new Color(0.0f, 1f, 0.0f);
                playersReady++;
            }
            else if (playerReadyArray[inputQueueButtonA[i]] == true && playerJoinedArray[inputQueueButtonA[i]] == true)
            {
                playerReadyArray[inputQueueButtonA[i]] = false;
                boxList[inputQueueButtonA[i]].GetComponent<Image>().color = new Color(1f, 1f, 1f);
                playersReady--;
            }
        }
    }

    void spawnSprite(int playerNo)
    {
        Vector3 location = new Vector3((playerNo * 2.7f) - 9.3f, -3.7f, 1);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);

        spriteArray[playerNo] = Sprite.Instantiate(characterList[playerNo], location, rotation);
    }
}
