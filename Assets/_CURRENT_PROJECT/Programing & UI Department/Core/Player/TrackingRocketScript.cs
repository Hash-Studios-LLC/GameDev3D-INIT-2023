using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: PROJECTILE SCRIPT
//BUG: THERE IS A BUG WHERE PUTTING A RIGIDBODY PROPERTY SPAWNS A TON OF CYLINDERS IDK HOW TO FIX IT.
public class TrackingRocketScript : MonoBehaviour
{
    //reference to player
    //TODO: edit with GameManager later maybe?
    public GameObject playerReference;
    public GameObject projectileReference;
    public float projectileSpeed = 30f;
    public float fireRate = 4f;
    private Vector3 playerPosition;
    private Vector3 destination;
    private float timeToFire;

    // Start is called before the first frame update
    void Start()
    {
     //TODO: Lock projectile on the y axis because they start floating due to gravity
    }

    // Update is called once per frame
    void Update()
    {
       playerPosition = playerReference.transform.localPosition;

        if(Input.GetButtonDown("Rocket") && Time.time >= timeToFire){
            timeToFire = Time.time * 1/fireRate;
            ShootProjectile();
        }
    }
    /*BUG: MASSIVE BUG WITH THE SHOOTPROJECTILE OR THE INSTANTIATE PROJECTILE FUNCTIONS
     *IT SPAWNS A LOT OF PROJECTILES FOR SOME REASON ALSO IT'S 5 AM IT'S REALLY LATE I WANT TO SLEEP
     **/
    // Woodhouse3d: use GetButtonDown as it only triggers the frame the button is pushed.
    void ShootProjectile(){
       Ray ray = new Ray(playerPosition, transform.forward);
       RaycastHit hit;

       if(Physics.Raycast(ray, out hit)){
          destination = hit.point;
       }
       InstantiateProjectile(playerPosition);
    }
    void InstantiateProjectile(Vector3 characterPosition){

       var projectileObj = Instantiate(projectileReference, characterPosition, Quaternion.identity) as GameObject;
       projectileObj.GetComponent<Rigidbody>().velocity = (destination - characterPosition).normalized * projectileSpeed;
    }
}
