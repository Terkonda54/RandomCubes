/***
 * Created by: Anupam Terkonda
 * Created: 1/24/22
 * 
 * Last Edited by: N/A
 * Last Edited: 1/26/22
 * 
 * Description: Spawns multiple cubes prefabs into scene.
 * ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    //creating Variables
    public GameObject cubePrefab; //new gameobject
    public List<GameObject> gameObjectList; //list for all cubes
    public float scalingFactor = 0.95f;
    //[HideInInspector]
    public int numberOfCubes = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiates the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to the number of cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab);

        gObj.name = "Cube" + numberOfCubes; //name property of the object

        gObj.transform.position = Random.insideUnitSphere; //random point inside a sphere radius of 1

        Color randomColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = randomColor; //assign random color to cubes

        gameObjectList.Add(gObj); //add cube to list

        List<GameObject> removeList = new List<GameObject>(); //list of game objects to remove

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingFactor; //set scale value
            goTemp.transform.localScale = Vector3.one * scale; //transforms the scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp); //add to remove list

            } //end if loop
        } //end foreach loop

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from gameobject list
            Destroy(goTemp); //destroy object from scene

        }//end foreach loop
    }
}
