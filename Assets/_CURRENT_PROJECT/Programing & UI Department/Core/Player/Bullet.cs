using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Dependencies")]


    [Header("Options")]
    [SerializeField] private float lifespan = 2f; //length of time untill bullet despawns
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletLifespan());
    }


    IEnumerator BulletLifespan() // this function waits some amount of time and then deletes the bullet
    {
        yield return new WaitForSeconds(lifespan);
        destroyProjectile();
    }

    void destroyProjectile() // this function is here in case you want to add any stuff to the destroy behavior.
    {
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit object");
        if (other.tag == "Hitbox")
        {
            other.GetComponent<Health>().bulletHit(damage);
        }
        if (other.tag != "Player" && other.tag != "PunchHitbox")
        {
            Destroy(this.gameObject);
        }

    }


}
