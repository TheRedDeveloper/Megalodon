using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Movement : MonoBehaviour {
    public float RotationSpeed = 2;
    public float RotationHardness = 22.5f;
    public float TranslationSpeed = 2;
    public float slowdownFactor = .5f;
    public Sprite spriteL2;
    public SpriteRenderer spriteRenderer;
    public PolygonCollider2D colliderL1;
    public PolygonCollider2D colliderL2;
    public Transform PlayerSprite;
    public Rigidbody2D rb; 
    public bool isMoving = false;
    private bool soundIsPlaying = false;
    private FMOD.Studio.EventInstance instance;

    void Start(){
        refreshSprite();
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/UB_Loop");
        instance.start();
    }
    void OnDestroy()
    {
        instance.release();
    }

    void FixedUpdate(){
        isMoving = Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Horizontal") != 0f;
        if(!PlayerSprite) Debug.LogError("Movement kann PlayerSprite nicht finden.");
        float speedCoeff = 1;
        if(Input.GetAxisRaw("Vertical") != 0f) speedCoeff = slowdownFactor;
        PlayerSprite.localEulerAngles = new Vector3(0, 0, RotationHardness * -Input.GetAxisRaw("Horizontal") * speedCoeff);
        rb.AddTorque(Input.GetAxisRaw("Horizontal") * Time.deltaTime * -RotationSpeed * rb.inertia, ForceMode2D.Impulse);
        speedCoeff = 1;
        if(Input.GetAxisRaw("Horizontal") != 0f | Input.GetAxisRaw("Vertical") < 0f) speedCoeff = slowdownFactor;
        rb.velocity += (Vector2)(Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * Vector3.up * Time.fixedDeltaTime
        * TranslationSpeed * Input.GetAxisRaw("Vertical") * speedCoeff);
        if (isMoving && !soundIsPlaying)
            {
                instance.setParameterByName("Speed", 1);
                soundIsPlaying = true;
            }
        if (!isMoving && soundIsPlaying)
            {
                instance.setParameterByName("Speed", 0);
                soundIsPlaying = false;
            }  

    }

    public void refreshSprite() {
        if(Game.level >= 1) {
            spriteRenderer.sprite = spriteL2;
            colliderL1.enabled = false;
            colliderL2.enabled = true;
        }
    }
}
