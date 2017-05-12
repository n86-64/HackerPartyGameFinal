using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

    public int xFloat = 0;
    public int yFloat = 0;

    void Awake()
    {
        xFloat = Animator.StringToHash("xVelocity");
        yFloat = Animator.StringToHash("yVelocity");
    }
}
