using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour
{

    public int tileX, tileY;
    public GridView map;


    void OnMouseUp()
    {
        Debug.Log("Click!");

        map.MoveSelectedUnitTo(tileX,tileY);
    }
}
