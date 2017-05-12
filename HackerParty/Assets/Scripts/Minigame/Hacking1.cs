using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Hacking : MonoBehaviour {

    public int state;
    private int hacking;
    private int hacked;


    public GameObject[] buttons;
    public string[] buttonInputs;

    private float delayTime;
    private GameObject displayedSprite;
    public GameObject ex;
    public Image image;
    public bool miniGame;

    // Use this for initialization

    void Awake()
    {
       
    }
    void Start ()
    {
        miniGame = true;
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

                    displayedSprite = Instantiate(buttons[state - 1]) as GameObject;
                }
            }
            else
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetButtonDown(buttonInputs[state - 1]))
                    {
                        hacked++;
                        state = 0;
                        Destroy(displayedSprite.gameObject);
                    }
                    else
                    {
                        Instantiate(ex);
                    }
                }
            }
            
            
           

            if (hacked == hacking)
            {
                Debug.Log("hacked m8");
                miniGame = false;
            }

            float fill = (float)hacked / (float)hacking;

            image.fillAmount = fill;
        }
    }
}
