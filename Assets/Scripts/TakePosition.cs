using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePosition : MonoBehaviour
{
    void Start() {
        if(Game.mapPosition != null) transform.position = (Vector3)Game.mapPosition;
    }
}
