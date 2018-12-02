using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapScript : MonoBehaviour {

    GameObject[] tilesList = new GameObject[51];

    bool movement1 = true;
    bool movement2 = false;
    bool movement3 = false;
    bool movement4 = false;

    GameObject[] TileC2 = new GameObject[6];
    GameObject[] TileC4 = new GameObject[6];
    GameObject[] TileC6 = new GameObject[6];
    GameObject[] TileC8 = new GameObject[6];
    GameObject[] TileL2 = new GameObject[10];
    GameObject[] TileL4 = new GameObject[10];

    float TileC2Position = -4f;
    float TileC4Position = -2f;
    float TileC6Position = 0f;
    float TileC8Position = 2f;
    float TileL2Position = 2f;
    float TileL4Position = 0f;

    enum tile
    {

    }


    // Use this for initialization
    void Start () {
        GetTiles();
	}
	
	// Update is called once per frame
	void Update () {
        if (movement1)
        {
            TileC2 = GetColumn(TileC2Position);
            TileC4 = GetColumn(TileC4Position);
            TileC6 = GetColumn(TileC6Position);
            TileC8 = GetColumn(TileC8Position);
        }
		
	}

    void GetTiles()
    {
        SpriteRenderer[] asd = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < tilesList.Length; i++)
            {
                tilesList[i] = asd[i].gameObject;
            }
    }

    GameObject[] GetColumn(float distance)
    {
        int columnSize = 6;
        int gameObjectListPosition = 0;
        GameObject[] gameObjectList = new GameObject[columnSize]; 
        for (int i = 0; i < tilesList.Length; i++)
        {
            
            
            if(tilesList[i].transform.position.x < distance + 0.5f && tilesList[i].transform.position.x > distance - 0.5f)
            {
                gameObjectList[gameObjectListPosition] = tilesList[i];
                gameObjectListPosition++;
            }
        }
        return gameObjectList;
    }

    GameObject[] GetLine(float distance)
    {
        int columnSize = 10;
        int gameObjectListPosition = 0;
        GameObject[] gameObjectList = new GameObject[columnSize];
        for (int i = 0; i < tilesList.Length; i++)
        {


            if (tilesList[i].transform.position.y < distance + 0.5f && tilesList[i].transform.position.y > distance - 0.5f)
            {
                gameObjectList[gameObjectListPosition] = tilesList[i];
                gameObjectListPosition++;
            }
        }
        return gameObjectList;
    }
}
