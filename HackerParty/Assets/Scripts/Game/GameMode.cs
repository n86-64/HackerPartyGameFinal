using UnityEngine;
using System.Collections;

// n86 (Nathan Butt) - Instantiates characters and assigns them a controller. 

public class GameMode : MonoBehaviour {

    // Character list and animators to be set for the player when it is instanciated. 
    public Sprite[] characterSprites;
    public RuntimeAnimatorController[] characterAnimators;

    public GameObject spawnPoint;
    int numberOfControllers;

	// Use this for initialization
	void Start ()
    {
        numberOfControllers = Input.GetJoystickNames().Length;
        //instanciateObjects(Input.GetJoystickNames().Length);
	}

    void instanciateObjects(int controllerNumbers)
    {
        Entity_Actor characterToSpawn;
        for(int i = 0; i < numberOfControllers; i++)
        {
            characterToSpawn = new Entity_Actor();
            characterToSpawn.setControllerID(i);
            characterToSpawn.setCharacterSkin(characterSprites[i], characterAnimators[i]);
            Instantiate(characterToSpawn);
        }
    }
}
