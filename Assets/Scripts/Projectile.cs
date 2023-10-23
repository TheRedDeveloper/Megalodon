using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 1;
    void Update()
    {
        transform.Translate(Vector3.right * projectileSpeed);
    }
}
