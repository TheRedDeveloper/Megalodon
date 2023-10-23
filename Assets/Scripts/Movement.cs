using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float RotationSpeed = 2;

    void Start()
    {
        
    }

    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * -RotationSpeed;
        transform.Rotate(0, 0, speed);
    }
}
