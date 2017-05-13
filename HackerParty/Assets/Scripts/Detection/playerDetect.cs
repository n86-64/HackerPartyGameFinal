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

    public char facingDirection;

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

            //add variable for npc facing and change. up accordingly

            Vector3 ray = new Vector3(0, 0, 0); ;
            switch(facingDirection)
            {
                case 'u':
                    enemyDirection = transform.up;
                    ray = transform.TransformDirection(Vector3.up) * range;
                    break;
                case 'd':
                    enemyDirection = transform.up * -1;
                    ray = transform.TransformDirection(Vector3.down) * range;
                    break;
                case 'l':
                    enemyDirection = transform.right * -1;
                    ray = transform.TransformDirection(Vector3.left) * range;
                    break;
                case 'r':
                    enemyDirection = transform.right;
                    ray = transform.TransformDirection(Vector3.right) * range;
                    break;
                default:
                    break;
            }
            
            Debug.DrawRay(transform.position, ray, Color.red);

            if (distance <= range)
            {
                inRange = true;

                if (Vector3.Angle(enemyDirection, players[i].transform.position - transform.position) < fov)
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
