using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float RotationSpeed = 2;
    public float RotationHardness = 22.5f;
    public float TranslationSpeed = 2;
    public float slowdownFactor = .5f;
    public Transform PlayerSprite;
    public Rigidbody2D rb; 

    void Start() {
        if(Game.mapPosition != null) transform.position = (Vector3)Game.mapPosition;
    }

    void Update()
    {
        if(!PlayerSprite) Debug.LogError("Movement kann PlayerSprite nicht finden.");
        float speedCoeff = 1;
        if(Input.GetAxisRaw("Vertical") != 0f) speedCoeff = slowdownFactor;
        PlayerSprite.localEulerAngles = new Vector3(0, 0, RotationHardness * -Input.GetAxisRaw("Horizontal") * speedCoeff);
        rb.AddTorque(Input.GetAxisRaw("Horizontal") * Time.deltaTime * -RotationSpeed * rb.inertia, ForceMode2D.Impulse);
        speedCoeff = 1;
        if(Input.GetAxisRaw("Horizontal") != 0f | Input.GetAxisRaw("Vertical") < 0f) speedCoeff = slowdownFactor;
        rb.velocity += (Vector2)(Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * Vector3.up * Time.fixedDeltaTime
        * TranslationSpeed * Input.GetAxisRaw("Vertical") * speedCoeff);
    }
}
