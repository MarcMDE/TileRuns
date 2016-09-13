using UnityEngine;
using System.Collections;

public class MoveThroughBehaviour : MonoBehaviour
{
    [SerializeField] ScreenGridCellsLogic gridCells;

    [SerializeField] float sourceSpeed, topSpeed;
    [SerializeField] TextAsset textFilePattern;

    Vector3[] targets;
    int targetIndex;

    Vector3 sourcePosition;
    float speed;


    void Start ()
    {
        //readText = new ReadTextFile(textFilePattern);
        //targets = readText.GetValues();

        speed = sourceSpeed;
        targetIndex = 0;
        sourcePosition = targets[targetIndex];
        transform.position = sourcePosition;
	}
	
	void Update ()
    {
	
	}

    void SetNextTarget ()
    {
        sourcePosition = targets[targetIndex];
        transform.position = sourcePosition;


    }
}
