using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RunTileTypes { BORDER, STRAIGHT, CORNER};

public class ScreenGridGeneration : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    /*
    [Header("Grid Values")]
    [Tooltip("Width & Height values > 0")]
    [SerializeField] int gridWidth;
    [SerializeField] int gridHeight;
    [Space(10)]
    */
    [SerializeField] GameObject[] sourceObjs = new GameObject[(System.Enum.GetValues(typeof(RunTileTypes)).Length)];

    GameObject gridParent;
    //GameObject [] objs;
    List<GameObject> objs;
    ScreenGridCellsLogic cells;
    SetGridFromTextFile grid;
    SetTileTypes tileTypes;

	public void GenerateGrid ()
    {
        grid = new SetGridFromTextFile(textFile);
        tileTypes = new SetTileTypes();

        /*
        // Set min width & height
        if (gridWidth < 0) gridWidth = 1;
        if (gridHeight < 0) gridHeight = 1;
        */

        // Destroy previous grid (if exist)
        DestroyGrid();

        // Set gridParent
        gridParent = new GameObject("GridParent");
        gridParent.transform.position = Vector3.zero;

        // Set Grid Cells
        cells = new ScreenGridCellsLogic();
        cells.SetCells(grid.Rows, grid.Lines);

        // Init objs List
        objs = new List<GameObject>();
        
        for (int i=0; i < grid.Lenght; i++)
        {
            /*
            if (sourceObj != null) objs[i] = Instantiate(sourceObj);
            else objs[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            */
            /*
            if (i == 0) objs[i] = Instantiate(sourceObjs[0]);
            else if (i == grid.Rows * grid.Lines - 1) objs[i] = Instantiate(sourceObjs[0]);
            else objs[i] = Instantiate(sourceObjs[1]);
            */

            objs.Add(new GameObject("Cell_0"+i));
            //objs.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

            objs[i].transform.position = cells.GetCellPosition(i);
            objs[i].transform.localScale = new Vector3(cells.GetCellSize().x, cells.GetCellSize().y, objs[i].transform.localScale.z);
            objs[i].transform.SetParent(gridParent.transform);
        }

        /*
        for (int i=0; i<grid.Lenght; i++)
        {
            objs.Insert(grid.Lenght + i, objs[grid.GetPathValue(i)]);
            objs[grid.Lenght + i].name = "Cell_0" + i;
        }

        for (int i=0; i<grid.Lenght; i++)
        {
            objs.RemoveAt(0);
        }
        */


        tileTypes.SetTypes(objs.ToArray(), sourceObjs, grid.GetPathValues());
	}

    public void DestroyGrid ()
    {
        // Destroy GridParent (if exist)
        if(gridParent!= null) DestroyImmediate(gridParent);
    }
}
