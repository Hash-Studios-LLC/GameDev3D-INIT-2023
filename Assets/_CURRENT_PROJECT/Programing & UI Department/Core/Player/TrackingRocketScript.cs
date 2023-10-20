using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingRocketScript : MonoBehaviour
{
    //reference to player
    //TODO: edit with GameManager later maybe?
    public PlayerInput playerInput;
    public RobotData robotData;
    public GameObject projectileReference;
    public GameObject bulletSpawnPoint;
    public float baseRocketSpeed = 10f;
    public float fireRate = 4f;
    private Vector3 playerPosition;
    private Vector3 destination;
    public float shootcooldown = 0.5f;

    private bool canshoot = true;


    private void Start()
    {
        shootcooldown = robotData.rocketCooldown;
    }

    public void shootInput()
    {
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
       InstantiateProjectile();
    }
    void InstantiateProjectile(){

       var projectileObj = Instantiate(projectileReference, bulletSpawnPoint.transform.position, Quaternion.identity) as GameObject;


        // set bullet properties
        projectileObj.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.transform.forward * robotData.rocketSpeed * baseRocketSpeed;
        projectileObj.GetComponent<Bullet>().damage = robotData.rocketDamage;
    }
}
