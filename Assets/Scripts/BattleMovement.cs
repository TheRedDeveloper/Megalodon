using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMovement : MonoBehaviour
{
    public float VerticalSpeed = 2;
    public float HorizontalSpeed = 2;
    public float RotationHardness = 22.5f;
    public float slowdownFactor = .5f;
    public Transform PlayerSprite;

    public GameObject projectile;
    public float shootCool = .5f;
    public float recoilStrength = .1f;
    public Rigidbody2D rb; 

    float sinceShot;
    void Start() {
        sinceShot = 100;
    }
    void Update()
    {
        if(!PlayerSprite) Debug.LogError("Movement kann PlayerSprite nicht finden.");
        float speedCoeff = 1; if(Input.GetAxisRaw("Vertical") != 0f | Input.GetAxisRaw("Horizontal") < 0f) speedCoeff = slowdownFactor;
        rb.velocity += Vector2.right * Time.deltaTime * HorizontalSpeed *  Input.GetAxisRaw("Horizontal") * speedCoeff;
        speedCoeff = 1; if(Input.GetAxisRaw("Horizontal") != 0f) speedCoeff = slowdownFactor;
        PlayerSprite.localEulerAngles = new Vector3(0, 0, RotationHardness * Input.GetAxisRaw("Vertical") * speedCoeff);
        rb.velocity += Vector2.up * Time.deltaTime * VerticalSpeed *  Input.GetAxisRaw("Vertical") * speedCoeff;
        sinceShot += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && sinceShot > shootCool) {
            Instantiate(projectile, transform.position+new Vector3(1,0,0), Quaternion.FromToRotation(Vector3.up, Vector3.right));
            rb.velocity += Vector2.left * recoilStrength;
            sinceShot = 0;
        }
    }
}
