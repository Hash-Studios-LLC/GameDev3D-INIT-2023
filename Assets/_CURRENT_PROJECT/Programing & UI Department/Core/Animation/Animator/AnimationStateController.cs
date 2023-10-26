using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    float aVelocity = 0.0f; // Not for physics, just for determining which animation is more prevalent 
    // Higher aVelocity means more running animation, less velocity means more idle animation.
    RobotData robotData;
    [SerializeField] private Rigidbody playerBody; //reference to player's rigidbody

    public float aAcceleration = 10.0f; // determines rate at which aVelocity increases
    public float aDecceleration = 10.0f; // c'mon, you took physics in high school, right?

    int VelocityHash;
    // determines if the player can attack
    [SerializeField] private bool canPunch;
    [SerializeField] private bool canShot;
    // temporary values 
    private float punchCD ;
    private float rocketCD ;
    public TrackingRocketScript track;
    //finds the object
    public GameObject punchCollider;
    [SerializeField] private float shootDelay;//  how much the delay to spawn the bullet
    [SerializeField] private float PunchDelay;// how much time it takes the punch collider to appear
   [SerializeField] private float rocketCD_AnimTime;// currently i don't have a way to check animation time so we have to add manually
    [SerializeField] private float PunchCD_AnimTime;// currently i don't have a way to check animation time so we have to add manually

    // Start is called before the first frame update
    void Start()
    {
        // set reference for animator
        animator = GetComponent<Animator>();
        robotData = GetComponentInParent< Robot_Initalization>().rob;
        Debug.Log(robotData);
        // Should add a reference to which player is controlling this character
        punchCollider.SetActive(false);
        // Assigns the animator's velocity var to VelocityHash
        VelocityHash = Animator.StringToHash("Velocity");
        punchCD = robotData.punchCooldown;
        rocketCD = robotData.rocketCooldown;
        canPunch = true;
        canShot = true;
        Debug.Log("punch cd: "+punchCD);// check if it matches
        Debug.Log("rocket cd: "+rocketCD);// check if it matches
    }

    // Update is called once per frame
    void Update()
    {

        if (playerBody.velocity != Vector3.zero && aVelocity < 1.0f) // whenever the player's velocity is not equal to 0, the animator rapidly changes from idle to running
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
    public void Punch()
    {
        // temporary keybind   waits for the animation to end to perform another action
        if (canPunch == true  && animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1.0f)
        {

            animator.SetTrigger("Punch");

            SendCustomEvenDelayedSeconds(ActivatePunchCollider, PunchDelay);
            // the cd starts once the animation begins needs to be adjsuted
            StartCoroutine(PunchCd());
            
        }
    }
    public  void Shoot() {
       
        // temporary keybind   waits for the animation to end to perform another action
        if (canShot == true && animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1.0f)
        {
            animator.SetTrigger("Shot");
        
            SendCustomEvenDelayedSeconds(track.ShootProjectile,shootDelay);// delays the bullet spawn
            StartCoroutine(ShotCd());
           
           

        }
    }

    void ActivatePunchCollider()
    {

     
        // Instantiate the punch collider object
        GameObject punch = Instantiate(punchCollider, transform.position + transform.forward, transform.rotation);

        //since punchCollider is false
        punch.SetActive(true);
        //creates an instance of punch where punchCollider is
        punch.transform.position = new Vector3(punchCollider.transform.position.x, punchCollider.transform.position.y, punchCollider.transform.position.z);
        Destroy(punch, 0.5f); //Destruction of object, Adjust this time as needed
    }
   
    private IEnumerator RunFunctionAfterDelay(float delayInSeconds, System.Action functionToRun)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Call the function after the delay
        functionToRun.Invoke();
    }

    public void SendCustomEvenDelayedSeconds(System.Action functionToRun, float delayInSeconds)
    {
        StartCoroutine(RunFunctionAfterDelay(delayInSeconds, functionToRun));
    }
    //makes punch true after x amount of time 
    IEnumerator PunchCd()
    {

        canPunch = false;
        yield return new WaitForSeconds(punchCD+PunchCD_AnimTime);
        canPunch = true;
       // Debug.Log("animation lasted: " + animator.GetCurrentAnimatorStateInfo(1).length);
    }
    //makes shot true after x amount of time 
    IEnumerator ShotCd()
    {
        
 
        canShot = false;
        yield return new WaitForSeconds(rocketCD+rocketCD_AnimTime);
        canShot = true;
       
      
    }
   


}
