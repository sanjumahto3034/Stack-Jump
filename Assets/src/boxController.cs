using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour
{
    public float offsetXAmt = 10;
    public GameObject box;
    private GameObject lastElement;
    public float yOffsetOfBox;
    private int countId = -1;
    bool isLeft = false;
    [HideInInspector]public bool IsGameRunning = true;
    private int highScore;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("score"); // Get highest score from locl storage
        GameObject obj = Instantiate(box, new Vector3(0, 1.4f, 0), Quaternion.identity); // First time institate game object
        lastElement = obj;
    }

    void FixedUpdate()
    {
        
    }
    public void addObject()
    {
        /*
        * This function is used to create the floating object in game 
        * The object is created in two ways - 1. By landing on base object, 2. When the value of transform.position.x = 0;
        */
        int spawnRange = Random.Range(0, 20);
        float offsetX = spawnRange % 2 == 0 ? offsetXAmt: offsetXAmt * -1;
        isLeft = (offsetX < 0) ? true : false;
        var transfrm = new Vector3(offsetX,lastElement.transform.position.y + yOffsetOfBox,0);


        GameObject boxObject = Instantiate(box, transfrm, Quaternion.identity);
        lastElement = boxObject;
        lastElement.GetComponent<boxMovementController>().setId(countId);
        countId++;
    }
    public void youLost(){
        /* After game lost code */
        IsGameRunning = false;

    }
    public int getCount(){ 
         /* Check if high score is achived or not */
        if(highScore<countId)PlayerPrefs.SetInt("score",countId);
        return countId;
    }
}

