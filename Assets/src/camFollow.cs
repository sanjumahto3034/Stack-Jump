using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform targate;
    public Vector3 offsetFromTargate;
    void Start(){
        Application.targetFrameRate = 60;
    }
    void Update(){
        transform.position = targate.position - offsetFromTargate;
    }
}
