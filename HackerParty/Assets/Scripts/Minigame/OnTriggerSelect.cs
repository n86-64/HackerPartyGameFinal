using UnityEngine;
using System.Collections;

public class OnTriggerSelect : MonoBehaviour {

    private GameObject target;
    public GameObject prefabA;
    public GameObject displayedA;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (target != null)
        {
            if (Input.GetButtonDown("HackA"))
            {
                //start hacking
                target.GetComponent<Hacking1>().interact();
                //get rid of label
                Destroy(displayedA.gameObject);
                //stop the player from moving while hacking
                this.GetComponent<Entity_Actor>().setIsHacking(true);
                //pass the player to the computer so the compuer object can set the player moving after it is hacked
                target.GetComponent<Hacking1>().setHackingPlayer(this.gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Computer" 
            && !other.gameObject.GetComponent<Hacking1>().getHacked() 
            && !other.gameObject.GetComponent<Hacking1>().getBeingHacked())
        {
            target = other.gameObject;
            displayedA = Instantiate(prefabA, target.transform.position + new Vector3(0, 0, 2), target.transform.rotation) as GameObject;
            
        }

    }

    void OnTriggerExit(Collider other)
    {
        target = null;
        Destroy(displayedA.gameObject);
    }
}
