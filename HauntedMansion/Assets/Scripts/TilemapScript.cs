using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapScript : MonoBehaviour
{

    GameObject[] tilesList = new GameObject[51];

    [SerializeField] float timeTileChange;
    int timeMultiplier = 1;
    int movementSelector = 1;

    float deltaTime;
    bool startDeltaTime = true;
    float storeEndPosition;

    float positionModifierX = 1.5f;
    float positionModifierY = -0.5f;


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
    SpriteRenderer[] asd;
    enum Tile
    {
        NORMAL,
        GET_TILES,
        START_MOVING_TILES,
        STOP_MOVING_TILES,

        MOVEMENT1,
        MOVEMENT2,
        MOVEMENT3,
        MOVEMENT4,
    }

    Tile tilesStates = Tile.NORMAL;


    // Use this for initialization
    void Start()
    {
        TileC2Position += positionModifierX;
        TileC4Position += positionModifierX;
        TileC6Position += positionModifierX;
        TileC8Position += positionModifierX;
        TileL2Position += positionModifierY;
        TileL4Position += positionModifierY;
        asd = GetComponentsInChildren<SpriteRenderer>();
        GetTiles();
    }

    // Update is called once per frame
    void Update()
    {

        switch (tilesStates)
        {
            case Tile.NORMAL:
                CheckIfMovement();
                break;
            case Tile.GET_TILES:
                break;
            case Tile.START_MOVING_TILES:
                break;
            case Tile.STOP_MOVING_TILES:
                break;
            case Tile.MOVEMENT1:
                Movement1();
                tilesStates = Tile.NORMAL;
                break;
            case Tile.MOVEMENT2:
                Movement2();
                tilesStates = Tile.NORMAL;
                break;
            case Tile.MOVEMENT3:
                Movement3();
                tilesStates = Tile.NORMAL;
                break;
            case Tile.MOVEMENT4:
                Movement4();
                tilesStates = Tile.NORMAL;
                break;
        }

    }

    void GetTiles()
    {

        for (int i = 0; i < tilesList.Length; i++)
        {
            tilesList[i] = asd[i].gameObject.GetComponentInParent<TileIdentifier>().gameObject;
        }
    }

    GameObject[] GetColumn(float distance)
    {
        int columnSize = 6;
        int gameObjectListPosition = 0;
        GameObject[] gameObjectList = new GameObject[columnSize];
        for (int i = 0; i < tilesList.Length; i++)
        {
            if (tilesList[i].transform.position.x < distance + 0.5f && tilesList[i].transform.position.x > distance - 0.5f)
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

    void GetAllColumns()
    {
        TileC2 = GetColumn(TileC2Position);
        TileC4 = GetColumn(TileC4Position);
        TileC6 = GetColumn(TileC6Position);
        TileC8 = GetColumn(TileC8Position);
    }

    void GetAllLines()
    {
        TileL2 = GetLine(TileL2Position);
        TileL4 = GetLine(TileL4Position);
    }

    void Movement1()
    {

        GetAllColumns();
        MoveColumnDown(TileC2);
        MoveColumnDown(TileC6);
        MoveColumnUp(TileC4);
        MoveColumnUp(TileC8);
    }

    void Movement2()
    {
        GetAllLines();
        MoveLineRight(TileL2);
        MoveLineLeft(TileL4);
    }

    void Movement3()
    {
        GetAllColumns();
        MoveColumnUp(TileC2);
        MoveColumnUp(TileC6);
        MoveColumnDown(TileC4);
        MoveColumnDown(TileC8);
    }

    void Movement4()
    {
        GetAllLines();
        MoveLineLeft(TileL2);
        MoveLineRight(TileL4);
    }

    void MoveColumnDown(GameObject[] column)
    {
        Debug.Log(TileC2[0].transform.position.y - storeEndPosition);

        for (int i = 0; i < column.Length; i++)
        {
            column[i].transform.position = new Vector3(column[i].transform.position.x, column[i].transform.position.y - 1, column[i].transform.position.z);
        }


    }

    void MoveColumnUp(GameObject[] column)
    {
        for (int i = 0; i < column.Length; i++)
        {
            column[i].transform.position = new Vector3(column[i].transform.position.x, column[i].transform.position.y + 1, column[i].transform.position.z);
        }
    }

    void MoveLineLeft(GameObject[] line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            line[i].transform.position = new Vector3(line[i].transform.position.x - 1, line[i].transform.position.y, line[i].transform.position.z);
        }
    }

    void MoveLineRight(GameObject[] line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            line[i].transform.position = new Vector3(line[i].transform.position.x + 1, line[i].transform.position.y, line[i].transform.position.z);
        }
    }

    void CheckIfMovement()
    {
        if (Time.timeSinceLevelLoad > timeTileChange * timeMultiplier)
        {
            timeMultiplier++;
            switch (movementSelector)
            {
                case 1:
                    tilesStates = Tile.MOVEMENT1;
                    movementSelector = 2;
                    break;
                case 2:
                    tilesStates = Tile.MOVEMENT2;
                    movementSelector = 3;
                    break;
                case 3:
                    tilesStates = Tile.MOVEMENT3;
                    movementSelector = 4;
                    break;
                case 4:
                    tilesStates = Tile.MOVEMENT4;
                    movementSelector = 1;
                    break;
            }
        }
    }

}