using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    float aVelocity = 0.0f; // Not for physics, just for determining which animation is more prevalent 
    // Higher aVelocity means more running animation, less velocity means more idle animation.

    [SerializeField] private Rigidbody playerBody; //reference to player's rigidbody

    public float aAcceleration = 10.0f; // determines rate at which aVelocity increases
    public float aDecceleration = 10.0f; // c'mon, you took physics in high school, right?

    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        // set reference for animator
        animator = GetComponent<Animator>();

        // Should add a reference to which player is controlling this character

        // Assigns the animator's velocity var to VelocityHash
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {

        if(playerBody.velocity != Vector3.zero && aVelocity < 1.0f) // whenever the player's velocity is not equal to 0, the animator rapidly changes from idle to running
        {
            aVelocity += Time.deltaTime * aAcceleration;
        }

        if (playerBody.velocity == Vector3.zero && aVelocity > 0.0f) // whenever the player's velocity equal to 0, the animator rapidly changes from running to idle
        {
            aVelocity -= Time.deltaTime * aDecceleration;
        }

        if (playerBody.velocity == Vector3.zero && aVelocity < 0.0f) // contingency incase velocity ever drops below 0 (it shouldn't)
        {
            aVelocity = 0.0f;
        }

        // Updates the animators velocity var with the this script's local velocity var
        animator.SetFloat(VelocityHash, aVelocity);
    }
}
