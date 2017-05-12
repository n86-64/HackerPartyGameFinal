using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        StartCoroutine(die());
	}
	

    IEnumerator die()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
