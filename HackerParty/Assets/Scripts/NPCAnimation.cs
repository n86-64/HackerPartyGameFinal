using UnityEngine;
using System.Collections;

public class NPCAnimation : MonoBehaviour {

    private Animator anim;
    private HashIDs hash;

    private Vector3 relative;

    public GameObject containerObject;
    private Vector3 lastPos;
    private Vector3 currentPos;


    void Start()
    {
        lastPos = containerObject.transform.position;
    }

    void Awake()
    {

        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
    }

    void FixedUpdate()
    {
        //set horizontal and vertical to 0 here, so new assesments of the direction can be made
        float horizontal = 0;
        float vertical = 0;

        //relative = transform.InverseTransformDirection(Vector3.right);

        currentPos = containerObject.transform.position;

        float xDiff = currentPos.x - lastPos.x;
        float zDiff = currentPos.z - lastPos.z;

        if (xDiff > 0 && xDiff * xDiff > zDiff * zDiff)
        {
            horizontal = 1;
            GetComponent<playerDetect>().facingDirection = 'r';
        }
        else  if(xDiff < 0 && xDiff * xDiff > zDiff * zDiff)
        {
            horizontal = -1;
            GetComponent<playerDetect>().facingDirection = 'l';
        }
        else if(zDiff < 0 && xDiff * xDiff < zDiff * zDiff)
        {
            vertical = -1;
            GetComponent<playerDetect>().facingDirection = 'd';
        }
        else if (zDiff > 0 && xDiff * xDiff < zDiff * zDiff)
        {
            vertical = 1;
            GetComponent<playerDetect>().facingDirection = 'u';
        }

        lastPos = containerObject.transform.position;
        MovementManager(vertical, horizontal);

    }

    void MovementManager(float vertical, float horizontal)
    {
        anim.SetFloat(hash.yFloat, vertical);
        anim.SetFloat(hash.xFloat, horizontal);
/*
        if (vertical == 1)
        {
            anim.SetFloat(hash.yFloat, 1f);
        }
        if (vertical < 0)
        {
            anim.SetFloat(hash.yFloat, -1f);
        }
        if (horizontal > 0)
        {
            anim.SetFloat(hash.xFloat, 1f);
        }
        if (horizontal < 0)
        {
            anim.SetFloat(hash.xFloat, -1f);
        }
    */}
}