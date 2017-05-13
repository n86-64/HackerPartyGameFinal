using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private Animator anim;
    private HashIDs hash;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
    }

    void FixedUpdate()
    {

        //change where the v and h values are found based on the input
        float vertical = Input.GetAxis("Player" + this.gameObject.GetComponent<Entity_Actor>().getControllerID() + "Vertical");
        float horizontal = Input.GetAxis("Player" + this.gameObject.GetComponent<Entity_Actor>().getControllerID() + "Horizontal");
        MovementManager(vertical, horizontal);
    }

    void MovementManager (float vertical, float horizontal)
    {
        if(vertical > 0)
        {
            anim.SetFloat(hash.yFloat, 1f);
          //  this.transform.Translate(0f, 0.04f, 0f);
        }
        else if(vertical < 0)
        {
            anim.SetFloat(hash.yFloat, -1f);
         //   this.transform.Translate(0f, -0.04f, 0f);
        }
        else
        {
            anim.SetFloat(hash.yFloat, 0f);
        }

        if(horizontal > 0)
        {
           // this.transform.Translate(0.04f, 0f, 0f);
            anim.SetFloat(hash.xFloat, 1f);
        }
        else if(horizontal < 0)
        {
          //  this.transform.Translate(-0.04f, 0f, 0f);
            anim.SetFloat(hash.xFloat, -1f);
        }
        else
        {
            anim.SetFloat(hash.xFloat, 0f);
        }
    }
}