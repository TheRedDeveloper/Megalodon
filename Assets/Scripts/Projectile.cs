using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 1;
    public float damage = 0.3f;
    public Rigidbody2D rb;
    public float lifeSpan = 10;
    float lifeTime = 0;
    void Start(){
        rb.velocity = 1000*(Vector2)(Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * Vector3.up * Time.fixedDeltaTime * projectileSpeed);
    }
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime>lifeSpan) Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(lifeTime > 0.01) {
            Debug.Log(col.gameObject.name);
            if(col.gameObject.tag == "Player") Game.HP -= damage;
            if(col.gameObject.tag == "Boss") Game.boss.GetComponentInChildren<Boss>().HP -= damage;
            Destroy(gameObject);
        }
    }

}
