using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {

    // Character list and animators to be set for the player when it is instanciated. 
    public Sprite[] characterSprites;
    public Animator[] characterAnimators;

    public GameObject spawnPoint;

    int numberOfControllers;

	// Use this for initialization
	void Start ()
    {
        numberOfControllers = Input.GetJoystickNames().Length;
        instanciateObjects(Input.GetJoystickNames().Length);
	}
	
    void Awake()
    {
    }

	// Update is called once per frame
	void Update ()
    {
	
	}

    void instanciateObjects(int controllerNumbers)
    {

    }
}
