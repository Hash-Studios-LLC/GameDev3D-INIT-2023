using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private bool collided;
    
    public RobotData robotData;



    void OnCollisionEnter(Collision co){
        if(co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided ){
           collided = true;
           Destroy(gameObject);
        }
    }

    //when rocket collides with player they take damage
    void TakeDamage() {
        if(collided) {
            robotData.playerHealth -= robotData.rocketDamage;
        }
    }
}
