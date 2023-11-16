using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Dependencies")]
    Rigidbody rb;

    [Header("Options")]
    [SerializeField] private float lifespan = 2f; //length of time untill bullet despawns
    public int damage;

    // Start is called before the first frame update
    public GameObject rocketTrail;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(BulletLifespan());
        transform.forward = rb.velocity;
    }


    IEnumerator BulletLifespan() // this function waits some amount of time and then deletes the bullet
    {
        yield return new WaitForSeconds(lifespan);
        FindAnyObjectByType<VFXList>().MisileExplosion(gameObject);
        if (FindAnyObjectByType<AudioManager>()!=null)
        FindAnyObjectByType<AudioManager>().Play("rocket Explosion");
        destroyProjectile();
    }

    void destroyProjectile() // this function is here in case you want to add any stuff to the destroy behavior.
    {
        TrailParent();
        Destroy(this.gameObject);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(FindAnyObjectByType<AudioManager>())
        FindAnyObjectByType<AudioManager>().Play("rocket Explosion");
        Debug.Log("hit object");
        if (other.tag == "Hitbox")
        {
            other.GetComponent<Health>().bulletHit(damage);
            Destroy(this.gameObject);
        }
            else
        {
          
            Destroy(this.gameObject);
        }
        FindAnyObjectByType<VFXList>().MisileExplosion(gameObject);
        TrailParent();
    }

   public void TrailParent()
    {
        rocketTrail.transform.parent = null;
        
       Destroy(rocketTrail, 3f);
    }
}
