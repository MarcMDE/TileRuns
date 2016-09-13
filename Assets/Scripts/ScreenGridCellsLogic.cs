using UnityEngine;
using System.Collections;

public class ScreenGridCellsLogic
{
    Camera pov;

    Vector3 [] cellsPosition;
    Vector2 cellsSize;
    Vector3 sourcePosition;

    float cellsZ;

	public void SetCells (int gridWidth, int gridHeight)
    {
        pov = Camera.main;

        cellsPosition = new Vector3[gridWidth * gridHeight];

        // Set cellsSize -> Camera Size / Camera Width & Height
        cellsSize = GetCameraSize(pov);
        cellsSize.x /= gridWidth;
        cellsSize.y /= gridHeight;

        sourcePosition = pov.ScreenToWorldPoint(new Vector3(0, pov.pixelHeight, 0));

        cellsZ = 0;

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                cellsPosition[y * gridWidth + x] = new Vector3((sourcePosition.x + cellsSize.x / 2) + cellsSize.x * x, (sourcePosition.y - cellsSize.y / 2) - cellsSize.y * y, cellsZ);
            }
        }
    }
	
    /*
	public void Update (int gridWidth, int gridHeight)
    {
        for (int i=1; i<gridHeight; i++)
        {
            Debug.DrawLine(new Vector3(sourcePosition.x, 0, sourcePosition.z - i * cellsSize.y), new Vector3(sourcePosition.x + cellsSize.x * gridWidth, 0, sourcePosition.z - i * cellsSize.y), Color.black);
        }

        for (int i=1; i < gridWidth; i++)
        {
            Debug.DrawLine(new Vector3(sourcePosition.x + cellsSize.x * i, 0, sourcePosition.z), new Vector3(sourcePosition.x + cellsSize.x * i, 0, sourcePosition.z - gridHeight * cellsSize.y), Color.black);
        }
    }
    */

    Vector2 GetCameraSize (Camera a)
    {
        Vector3 cameraVector;

        // Camera Max - Camera Min
        cameraVector = a.ScreenToWorldPoint(new Vector3(a.pixelWidth, a.pixelHeight, 0));
        cameraVector -= a.ScreenToWorldPoint(Vector3.zero);

        return new Vector2(cameraVector.x, cameraVector.y);
    }

    public Vector3 GetCellPosition(int index)
    {
        return cellsPosition[index];
    }

    public Vector2 GetCellSize()
    {
        return cellsSize;
    }
}
