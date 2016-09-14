using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RunTileTypes { BORDER, STRAIGHT, CORNER};

public class ScreenGridGeneration : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    [SerializeField] PathFollower pathFollower;

    /*
    [Header("Grid Values")]
    [Tooltip("Width & Height values > 0")]
    [SerializeField] int gridWidth;
    [SerializeField] int gridHeight;
    [Space(10)]
    */
    [SerializeField] GameObject[] sourceObjs = new GameObject[(System.Enum.GetValues(typeof(RunTileTypes)).Length)];

    GameObject gridParent;
    GameObject[] objs;
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
        objs = new GameObject[grid.Lenght];
        
        for (int i=0; i < grid.Lenght; i++)
        {
            objs[i] = new GameObject("Cell_0"+i);
            objs[i].tag = "GameGridCell";
            //objs.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));

            objs[i].transform.position = cells.GetCellPosition(i);
            objs[i].transform.localScale = new Vector3(cells.GetCellSize().x, cells.GetCellSize().y, objs[i].transform.localScale.z);
            objs[i].transform.SetParent(gridParent.transform);
        }

        tileTypes.SetTypes(objs, sourceObjs, grid.GetPathValues());

        pathFollower.SetWaypoints(objs, grid.GetPathValues());
	}

    public void DestroyGrid ()
    {
        // Destroy GridParent (if exist)
        if(gridParent!= null) DestroyImmediate(gridParent);
    }
}
