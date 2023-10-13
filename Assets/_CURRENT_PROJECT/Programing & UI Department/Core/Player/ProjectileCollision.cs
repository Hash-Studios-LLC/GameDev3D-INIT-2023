using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private bool collided;
    void OnCollisionEnter(Collision co){
        if(co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided ){
           collided = true;
           Destroy(gameObject);
        }
    }
}
