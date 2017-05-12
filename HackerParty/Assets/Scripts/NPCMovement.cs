using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {

    public GameObject[] destinationStates = new GameObject[5];
    private GameObject activeDestination;

	// Use this for initialization
	void Start () {
        activeDestination = destinationStates[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x - activeDestination.transform.position.x > 0.1f)
        {
            transform.Translate(-0.1f, 0, 0);
        }
        else if (this.transform.position.x - activeDestination.transform.position.x < -0.1f)
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (this.transform.position.z - activeDestination.transform.position.z > 0.1f)
        {
            transform.Translate(0, -0.1f, 0);
        }
        else if (this.transform.position.z - activeDestination.transform.position.z < -0.1f)
        {
            transform.Translate(0, 0.1f, 0);
        }

        if (Random.Range(0,100) == 0)
        {
            activeDestination = destinationStates[Random.Range(0, 4)];
        }
    }
}
