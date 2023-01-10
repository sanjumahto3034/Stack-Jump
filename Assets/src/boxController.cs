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
        highScore = PlayerPrefs.GetInt("score");
        GameObject obj = Instantiate(box, new Vector3(0, 1.4f, 0), Quaternion.identity);
        lastElement = obj;
    }

    void FixedUpdate()
    {
        
    }
    public void addObject()
    {
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
        IsGameRunning = false;

    }
    public int getCount(){ 
        if(highScore<countId)PlayerPrefs.SetInt("score",countId);
        return countId;
    }
}

