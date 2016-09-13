using UnityEngine;
using System.Collections;

//public enum Orientations { UP, LEFT, DOWN, RIGHT};
public enum TileTypes { BORDER=0, STRAIGHT, CORNER};

public class SetTileTypes
{
    GameObject[] childObjs;
    Vector2 direction;
    Vector2 prevDirection;
    TileTypes tileType;

    /*
    public SetTileTypes ()
    {
        
        //Orientations orientation = Orientations.UP;
    }
    */

	public void SetTypes (GameObject[] gridObjs, GameObject[] srcObjs, int[] path)
    {
        direction = Vector2.zero;
        tileType = 0;
        //prevDirection = Vector2.zero;

        childObjs = new GameObject[gridObjs.Length];

        for (int i=0; i<gridObjs.Length; i++)
        {
            prevDirection = direction;

            if (i < gridObjs.Length - 1)
            {
                direction = gridObjs[path[i+1]].transform.position - gridObjs[path[i]].transform.position;
                direction.Normalize();
            }

            Debug.Log("Direction_" + gridObjs[path[i]].name + " = " + direction);

            if (i == 0 || i >= gridObjs.Length - 1) tileType = TileTypes.BORDER;
            else if (Vector2.Dot(prevDirection, direction) > 0) tileType = TileTypes.STRAIGHT;
            else tileType = TileTypes.CORNER;
            
            childObjs[path[i]] = GameObject.Instantiate(srcObjs[(int)tileType]);
            
            childObjs[path[i]].name = tileType.ToString();
            childObjs[path[i]].transform.parent = gridObjs[path[i]].transform;
            childObjs[path[i]].transform.localPosition = Vector3.zero;
            childObjs[path[i]].transform.localScale = Vector3.one;

            if (tileType == TileTypes.CORNER)
            {
                if (direction.x > 0 || direction.y > 0) childObjs[path[i]].transform.localScale = new Vector3(-1, -1, 1);
                else if (direction.y < 0 && prevDirection.x < 0) childObjs[path[i]].transform.localScale = new Vector3(-1, -1, 1);
                else if (direction.y < 0) childObjs[path[i]].transform.localScale = new Vector3(1, -1, 1);
                else if (direction.x < 0) childObjs[path[i]].transform.localScale = new Vector3(1, -1, 1);
            }
            else if (tileType == TileTypes.BORDER && i >= gridObjs.Length - 1) direction = new Vector2(direction.x * -1, direction.y * -1);

            childObjs[path[i]].transform.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(-direction.x, direction.y) * 180 / Mathf.PI);
        }



        /*
	    for (int i=0; i<gridObjs.Length; i++)
        {
            if (i!=gridObjs.Length-1) direction = gridObjs[objsOrder[i]].transform.position - gridObjs[objsOrder[i+1]].transform.position;
            else direction = gridObjs[objsOrder[i]].transform.position - gridObjs[objsOrder[i-1]].transform.position;
            direction.Normalize();

            if (i == 0 || i == gridObjs.Length -1)
            {
                childObjs[objsOrder[i]] = GameObject.Instantiate(srcObjs[0]);
                childObjs[objsOrder[i]].transform.parent = gridObjs[objsOrder[i]].transform;
                childObjs[objsOrder[i]].transform.localScale = Vector3.one;
            }
            else
            {
                if (Vector2.Dot(prevDirection, direction) > 0)
                {
                    childObjs[objsOrder[i]] = GameObject.Instantiate(srcObjs[1]);
                    childObjs[objsOrder[i]].transform.parent = gridObjs[objsOrder[i]].transform;
                    childObjs[objsOrder[i]].transform.localScale = Vector3.one;
                }
                else
                {
                    childObjs[objsOrder[i]] = GameObject.Instantiate(srcObjs[2]);
                    childObjs[objsOrder[i]].transform.parent = gridObjs[objsOrder[i]].transform;

                    if (prevDirection.x < 0)
                    {
                        childObjs[objsOrder[i]].transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else if (prevDirection.y != 0)
                        childObjs[objsOrder[i]].transform.localScale =
                        new Vector3(childObjs[objsOrder[i - 1]].transform.localScale.x * -1, childObjs[objsOrder[i - 1]].transform.localScale.y * -1, 1);
                    else childObjs[objsOrder[i]].transform.localScale = Vector3.one;
                }
            }

            prevDirection = direction;

            childObjs[objsOrder[i]].transform.localRotation = Quaternion.Euler(Vector3.zero);
            childObjs[objsOrder[i]].transform.localPosition = Vector3.zero;


            childObjs[objsOrder[i]].transform.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI);

            //childObjs[objsOrder[i]].transform.localRotation = Quaternion.Euler(0, 0, -90);

            if (direction == Vector2.up)
            {
                //childObjs[objsOrder[i]].transform.localRotation = Quaternion.Euler(direction.x, direction.y, 0);
            }
            else if (direction == Vector2.left)
            {

            }
            else if (direction == Vector2.down)
            {

            }
            else if (direction == Vector2.right)
            {

            }

            Debug.Log(direction);
        }*/
	}
}
