using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float HP;
    public float mHP;
    public float speed;
    public float minDistance;
    public int givesMetal;
    public int givesOil;
    public int givesGunpowder;
    public float shootCool = .5f;
    public float recoilStrength = .1f;
    public Vector3 offsetToPlayer;
    public GameObject projectile;
    public Vector3 projectileOffset;
    public Rigidbody2D rb;

    float sinceShot;

    void Start() {
        sinceShot = 100;
    }
    void Update()
    {
        sinceShot += Time.deltaTime;
        if(sinceShot > shootCool && shootCool != 0){
            Instantiate(projectile, transform.position+projectileOffset, Quaternion.FromToRotation(Vector3.up, Vector3.left) * Quaternion.Euler(0, 0, Random.Range(-10, 10)));
            rb.velocity += Vector2.right * recoilStrength;
            sinceShot = 0;
        }
    }

    void FixedUpdate()
    {
        Vector3 target = BattleManager.player.transform.position + offsetToPlayer;
        if (Vector3.Distance(target, transform.position) > minDistance) {
            rb.velocity += (Vector2)(target - transform.position).normalized * speed * Time.fixedDeltaTime;
        }
    }
}
