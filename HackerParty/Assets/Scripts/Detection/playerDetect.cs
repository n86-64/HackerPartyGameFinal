using UnityEngine;
using System.Collections;

public class playerDetect : MonoBehaviour {

    private GameObject[] players;
    private Vector3 enemyDirection;

    public float healthLost = 0.1f;
    public float range = 0f;
    private float distance = 0f;
    public int fov = 0;

    public bool isSeen = false;
    private bool inRange = false;

    // Use this for initialization
    void Start () {

        players = GameObject.FindGameObjectsWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < players.Length; i++)
        {
            incognitoBar incog = players[i].GetComponent<incognitoBar>();
            distance = Vector3.Distance(players[i].transform.position, transform.position);
            enemyDirection = transform.forward;

            Vector3 ray = transform.TransformDirection(Vector3.forward) * range;
            Debug.DrawRay(transform.position, ray, Color.red);

            if (distance <= range)
            {
                inRange = true;

                if (Vector3.Angle(transform.forward, players[i].transform.position - transform.position) < fov)
                {
                    isSeen = true;
                    incog.detected = true;
                    incog.loseHealth(healthLost * Time.fixedDeltaTime);

                }
                else
                {
                    isSeen = false;

                }


            }
            else
            {
                inRange = false;
                incog.detected = false;
            }
        }
	}

}
