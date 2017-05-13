using UnityEngine;
using System.Collections.Generic;

// TODO - consider having two seperate classes for NPCs and players. Hence Entity_Actor is a player. 

public class Entity_Actor : MonoBehaviour {

    private SpriteRenderer actorSprite;
    public Controller_Actor actorController;
    private Rigidbody actorRigidbody;
    private BoxCollider actorCollider;
    private RuntimeAnimatorController actorAnimator; 

    private int controllerID;

    public List<Sprite> starterSprites;
    public int spriteToLoad;
    private bool isHacking;

    // gameplay properties.
    public float actorVelocity;

    void Start()
    {
    }


    public void setIsHacking(bool b)
    {
        isHacking = b;
    }
    void Awake()
    {
        actorRigidbody = this.gameObject.GetComponent<Rigidbody>();
        actorCollider = this.gameObject.GetComponent<BoxCollider>();
        actorSprite = this.gameObject.GetComponent<SpriteRenderer>();
        actorAnimator = this.GetComponent<RuntimeAnimatorController>();
        setupCharacter();
        isHacking = false;
    }
	

    void FixedUpdate()
    {
        if (!isHacking)
        {
            actorRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * actorVelocity;
        }
    }


    // setup the character based on controllerID.
    void setupCharacter()
    {

        #region character sprite selection
        // TODO - add routiene to get correct player sprites. (Will be set by the spawnManager)
        if (!(spriteToLoad > starterSprites.Count))
        {
            actorSprite.sprite = starterSprites[spriteToLoad];
        }

        #endregion

        // dynamicly adjust the collider accroding to the sprite size
        actorCollider.size = new Vector3(0.15f, 0.2f, 0.0f);
    }

    // external setup routienes
    public void setControllerID(int newID)
    {
        controllerID = newID;
    }

    public void setCharacterSkin(Sprite newCharacterSprite, RuntimeAnimatorController newCharacterAnimation)
    {
        actorSprite.sprite = newCharacterSprite;
        actorAnimator = newCharacterAnimation;
    }
}
