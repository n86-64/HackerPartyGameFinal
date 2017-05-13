using UnityEngine;
using System.Collections;

public class pathfinding_script : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent navComponent;

    // locations the NPC can move to

    public GameObject[] locations;

    private int location;

    void Start ()
    {
        navComponent = this.transform.GetComponent<NavMeshAgent>();

        location = (Random.Range(0, locations.Length));

        target = locations[location].GetComponent<Transform>();
    }
	
	void Update ()
    {

        if (target)
        {            
            navComponent.SetDestination(target.position);
        }
        if (Vector3.Distance(transform.position,target.position) < 1)
        {

            location = (Random.Range(0, locations.Length));
            target = locations[location].GetComponent<Transform>();
        }

        this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
}
