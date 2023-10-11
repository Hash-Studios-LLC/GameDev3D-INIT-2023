using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    float velocity = 0.0f; // Not for physics, just for determining which animation is more prevalent 
    // Higher velocity means more running animation, less velocity means more idle animation.

    public float acceleration = 0.1f; // determines rate at which velocity increases
    public float decceleration = 0.5f; // c'mon, you took physics in high school, right?

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
        // should be replaced with input for corresponding player
        bool forwardPressed = Input.GetKey("w");

        if(forwardPressed && velocity < 1.0f) // as w is held down, the animator steadily transitions from idle to running
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocity > 0.0f) // as w is let go, the animator rapidly changes from running to idle
        {
            velocity -= Time.deltaTime * decceleration;
        }

        if (!forwardPressed && velocity < 0.0f) // contingency incase velocity ever drops below 0 (it shouldn't)
        {
            velocity = 0.0f;
        }

        // Updates the animators velocity var with the this script's local velocity var
        animator.SetFloat(VelocityHash, velocity);
    }
}
