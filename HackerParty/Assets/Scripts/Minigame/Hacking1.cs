<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Hacking1 : MonoBehaviour {

    public int state;
    private int hacking;
    private int progress;
    private bool hacked;
    private bool beingHacked;

    public GameObject[] buttons;
    public string[] buttonInputs;

    private float delayTime;
    private GameObject hackingPlayer;
    private GameObject displayedSprite;
    public GameObject ex;
    public Image image;
    public bool miniGame;

    public void setHackingPlayer(GameObject player)
    {
        hackingPlayer = player;
    }
    public bool getHacked()
    {
        return hacked;
    }

    public bool getBeingHacked()
    {
        return beingHacked;
    }
    public void setBeingHacked(bool b)
    {
        beingHacked = b;
    }
    public void interact()
    {
        miniGame = true;
    }
    // Use this for initialization

    void Awake()
    {
       
    }
    void Start ()
    {
        hacked = false;
        miniGame = false;
        state = 0;
        hacking = (Random.Range(0, 3) + 5);
	}

    // Update is called once per frame
    void Update()
    {

        if (miniGame)
        {
            if (state == 0)
            {
                delayTime += Time.deltaTime;
                if (delayTime > 0.5f)
                {
                    delayTime = 0f;
                    state = Random.Range(1, 4);

                    displayedSprite = Instantiate(buttons[state - 1], transform.position + new Vector3(0,0,2),transform.rotation) as GameObject;
                }
            }
            else
            {
                if (Input.anyKeyDown) //detect if any key was pressed
                {
                    
                    if (Input.GetButtonDown (hackingPlayer.tag + buttonInputs[state - 1])) //if the key pressed wa the correct one
                    {
                        progress++;
                        state = 0;
                        Destroy(displayedSprite.gameObject);
                    }
                    else if (Input.GetButtonDown(hackingPlayer.tag + "RightButton")) //or if the user chooses to stop hacking
                    {
                        miniGame = false;
                        state = 0;
                        progress = 0;
                        hackingPlayer.GetComponent<Entity_Actor>().setIsHacking(false);
                        Destroy(displayedSprite.gameObject);
                    }
                    else //if it is not the correct one 
                    {
                        Instantiate(ex);
                    }
                }
            }
            
          
           

            if (progress == hacking)
            {
                Debug.Log("hacked m8");
                miniGame = false;
                hacked = true;
                hackingPlayer.GetComponent<Entity_Actor>().setIsHacking(false);
            }

          //  float fill = (float)hacked / (float)hacking;

           // image.fillAmount = fill;
        }
    }
}
=======
﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Hacking1 : MonoBehaviour {

    public int state;
    private int hacking;
    private int progress;
    private bool hacked;
    private bool beingHacked;

    public GameObject[] buttons;
    public string[] buttonInputs;

    private float delayTime;
    private GameObject hackingPlayer;
    private GameObject displayedSprite;
    public GameObject ex;
    public Image image;
    public bool miniGame;

    public void setHackingPlayer(GameObject player)
    {
        hackingPlayer = player;
    }
    public bool getHacked()
    {
        return hacked;
    }

    public bool getBeingHacked()
    {
        return beingHacked;
    }
    public void setBeingHacked(bool b)
    {
        beingHacked = b;
    }
    public void interact()
    {
        miniGame = true;
    }
    // Use this for initialization

    void Awake()
    {
       
    }
    void Start ()
    {
        hacked = false;
        miniGame = false;
        state = 0;
        hacking = (Random.Range(0, 3) + 5);
	}

    // Update is called once per frame
    void Update()
    {

        if (miniGame)
        {
            if (state == 0)
            {
                delayTime += Time.deltaTime;
                if (delayTime > 0.5f)
                {
                    delayTime = 0f;
                    state = Random.Range(1, 4);

                    displayedSprite = Instantiate(buttons[state - 1], transform.position + new Vector3(0,0,2),transform.rotation) as GameObject;
                }
            }
            else
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetButtonDown(buttonInputs[state - 1]))
                    {
                        progress++;
                        state = 0;
                        Destroy(displayedSprite.gameObject);
                    }
                    else
                    {
                        Instantiate(ex);
                    }
                }
            }
            
            
           

            if (progress == hacking)
            {
                Debug.Log("hacked m8");
                miniGame = false;
                hacked = true;
                hackingPlayer.GetComponent<Entity_Actor>().setIsHacking(false);
            }

          //  float fill = (float)hacked / (float)hacking;

           // image.fillAmount = fill;
        }
    }
}
>>>>>>> b08b8fd7f8e43b94be767e317a609b8314e1b867
