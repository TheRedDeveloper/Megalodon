using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float RotationSpeed = 2;
    public float RotationHardness = 22.5f;
    public float TranslationSpeed = 2;
    public Transform PlayerSprite;

    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * -RotationSpeed;
        if(!PlayerSprite) Debug.LogError("Movement kann PlayerSprite nicht finden.");
        PlayerSprite.localEulerAngles = new Vector3(0, 0, 30 * -Input.GetAxisRaw("Horizontal"));
        transform.Rotate(0, 0, speed);
        transform.Translate(Vector3.up * Time.deltaTime * TranslationSpeed * Input.GetAxisRaw("Vertical"), Camera.main.transform);
    }
}
