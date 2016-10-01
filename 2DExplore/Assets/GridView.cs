using UnityEngine;
using System.Collections;

[System.Serializable]
public class GridView : MonoBehaviour {
    public GameObject selectedUnit;
    public TileType[] tileType;
    int [,] tiles;
    

    int mapSizeX = 10;
    int mapSizeY = 10;

	// Use this for initialization
	void Start ()
    {
        generateMapData();
        generateMapVisual();
    }
    void generateMapData()
    {
        //Allocate map tiles
        tiles = new int[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            //Initialize map tiles
            for (int y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }

        //Generate map data
        tiles[4, 4] = 2;
        tiles[5, 4] = 2;
        tiles[6, 4] = 2;
        tiles[7, 4] = 2;
        tiles[8, 4] = 2;

        tiles[4, 5] = 2;
        tiles[4, 6] = 2;
        tiles[8, 5] = 2;
        tiles[8, 6] = 2;


    }
    void generateMapVisual()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            //Initialize map tiles
            for (int y = 0; y < mapSizeY; y++)
            {
                TileType tt = tileType[tiles[x, y]];
                GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, y,0), Quaternion.identity);
                
                Clickable ct = go.GetComponent<Clickable>();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;
            }
        }
    }

    public Vector3 TileCoordtoWorldCoord(int x, int y)
    {
        return new Vector3(x, y, 0);
    }

    public void MoveSelectedUnitTo(int x, int y)
    {
        selectedUnit.GetComponent<Unit>().tileX = x;
        selectedUnit.GetComponent<Unit>().tileY = y;
        selectedUnit.transform.position = TileCoordtoWorldCoord(x, y);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
