using UnityEngine;
using System.Collections;

// controller type.
enum ControllerType
{
    CONTROLLER_PLAYER = 0,
    CONTROLLER_NPC
};

public class Controller_Actor : MonoBehaviour {

    private ControllerType controllerType; 

    void Awake()
    {
        controllerType = ControllerType.CONTROLLER_PLAYER;
    }

	// Update is called once per frame
	void Update ()
    {
	
	}

    // public functions.
    public int getControllerType()
    {
        return (int)controllerType;
    }

    public Vector3 getControllerDirection()
    {
        // TODO - impliment input update. 
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
