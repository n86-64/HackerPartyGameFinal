using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class incognitoBar : MonoBehaviour {

    public Transform player;
    public float startingHealth = 0;
    public float currentHealth = 0;
    public Slider incogSlider;
    public bool detected = false;
    public bool isDead = false;
    public float regenAmount = 0.5f;

    // Use this for initialization
    void Start () {

        currentHealth = startingHealth;
	
	}
	
	// Update is called once per frame
	void Update () {

      //  Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
      //  transform.position = newPos;

        if ((detected == false) && (currentHealth < startingHealth))
        {
            currentHealth += regenAmount;
        }

        incogSlider.value = currentHealth;

        if (currentHealth < 1)
        {
            isDead = true;
        //    Destroy(player.gameObject);
        }

    }

    public void loseHealth (float amount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= amount;
            incogSlider.value = currentHealth;
        }
    }
}
