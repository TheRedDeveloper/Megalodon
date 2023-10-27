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
    public GameObject projectile2;
    public float[] shootCool = new float[]{.5f,.4f,.3f};
    public float shootCool2 = .5f;
    public float recoilStrength = .1f;
    public float recoilStrength2 = .2f;
    public static bool paused = false;
    public Vector3 projectileOffset;
    public Rigidbody2D rb;

    public Sprite spriteL2;
    public SpriteRenderer spriteRenderer;
    public PolygonCollider2D colliderL1;
    public PolygonCollider2D colliderL2;

    float sinceShot;
    float sinceShot2;

    public bool isMoving = false;
    void Start() {
        if(Game.level >= 1) {
            spriteRenderer.sprite = spriteL2;
            colliderL1.enabled = false;
            colliderL2.enabled = true;
            Camera.main.orthographicSize = 10;
            Camera.main.transform.position = new Vector3(15,0,-10);
        }
        sinceShot = 100;
        sinceShot2 = 100;
    }
    void Update()
    {
        if(!paused) {
            isMoving = Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Horizontal") != 0f;
            if(!PlayerSprite) Debug.LogError("Movement kann PlayerSprite nicht finden.");
            float speedCoeff = 1; if(Input.GetAxisRaw("Vertical") != 0f | Input.GetAxisRaw("Horizontal") < 0f) speedCoeff = slowdownFactor;
            rb.velocity += Vector2.right * Time.deltaTime * (HorizontalSpeed+Game.level) *  Input.GetAxisRaw("Horizontal") * speedCoeff;
            speedCoeff = 1; if(Input.GetAxisRaw("Horizontal") != 0f) speedCoeff = slowdownFactor;
            PlayerSprite.localEulerAngles = new Vector3(0, 0, RotationHardness * Input.GetAxisRaw("Vertical") * speedCoeff);
            rb.velocity += Vector2.up * Time.deltaTime * (VerticalSpeed+Game.level) *  Input.GetAxisRaw("Vertical") * speedCoeff;
            sinceShot += Time.deltaTime;
            sinceShot2 += Time.deltaTime;
            if (Input.GetButtonDown("Fire1") && sinceShot > shootCool[Game.level]) {
                Instantiate(projectile, transform.position+projectileOffset, Quaternion.FromToRotation(Vector3.up, Vector3.right));
                rb.velocity += Vector2.left * recoilStrength;
                sinceShot = 0;
                FMODUnity.RuntimeManager.PlayOneShot("event:/UB_WooshWeapon_Sound");
            }
            if (Game.level >= 2 && Input.GetButton("Fire2") && sinceShot2 > shootCool2) {
                Instantiate(projectile2, transform.position+projectileOffset, Quaternion.FromToRotation(Vector3.up, Vector3.right));
                rb.velocity += Vector2.left * recoilStrength2;
                sinceShot2 = 0;
                FMODUnity.RuntimeManager.PlayOneShot("event:/UB_WooshWeapon_Sound");
            }
        }
    }
}
