using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovementController : MonoBehaviour
{
   private bool isFloating = true;
   private float boxFloatingSpeed = 3f;


    void Start(){
        StartCoroutine(timeRemainToDestroy(10));
    }
    void Update(){
             if(isFloating)transform.position = Vector3.MoveTowards(transform.position,new Vector3(0,transform.position.y,0),Time.deltaTime * boxFloatingSpeed);
     }
      void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player"){
            isFloating = false;
        }
    }
    
    IEnumerator timeRemainToDestroy(int seconds){

        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
