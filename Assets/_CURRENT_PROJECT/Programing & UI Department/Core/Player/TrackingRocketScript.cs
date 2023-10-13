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
    public float shootcooldown = 0.5f;

    private bool canshoot = true;

    // Start is called before the first frame update
    void Start()
    {
     //TODO: Lock projectile on the y axis because they start floating due to gravity
    }

    // Update is called once per frame
    void Update()
    {
       playerPosition = playerReference.transform.localPosition + Vector3.left * 3; 
        /* Woodhouse3d: added offset, you were spawing rigidbodies inside other rigidbodies.
         * use an empty object instead for more control over the spawnpoint.
         */

        if(Input.GetButton("Rocket") && canshoot){
            Debug.Log("pew");
            StartCoroutine(Shoot());
            canshoot = false;
        }
    }
    /*BUG: MASSIVE BUG WITH THE SHOOTPROJECTILE OR THE INSTANTIATE PROJECTILE FUNCTIONS
     *IT SPAWNS A LOT OF PROJECTILES FOR SOME REASON ALSO IT'S 5 AM IT'S REALLY LATE I WANT TO SLEEP
     **/
    // woodhouse3d: the problem was that you had the bullet spawner object set as the projectileReference. that means
    // that the script was spawning itself, which spawned itself and spawned itself again.
    IEnumerator Shoot()
    {
        ShootProjectile();
        yield return new WaitForSeconds(shootcooldown);
        canshoot = true;
    }



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
