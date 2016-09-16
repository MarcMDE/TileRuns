using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour
{
    //[SerializeField] ScreenGridGeneration grid;
    SetGridFromTextFile grid;
    [SerializeField] float speed;
    [SerializeField] float axisZ;

    [SerializeField][HideInInspector] Vector3[] waypoints;
    int waypointIndex;
    Vector3 direction;

    bool onMovement;
    bool pathEnded;


	void Start ()
    {

        Debug.Log("WP_Lenght" + waypoints.Length);     
        onMovement = false;
        pathEnded = false;
        waypointIndex = 0;

        SetNextWaypoint();
	}

	void Update ()
    {
        if (!pathEnded)
        {
            if (onMovement)
            {
                transform.Translate(direction * speed * Time.deltaTime);
                if (direction.x > 0 && transform.position.x > waypoints[waypointIndex].x) SetNextWaypoint();
                else if (direction.x < 0 && transform.position.x < waypoints[waypointIndex].x) SetNextWaypoint();
                else if (direction.y > 0 && transform.position.y > waypoints[waypointIndex].y) SetNextWaypoint();
                else if (direction.y < 0 && transform.position.y < waypoints[waypointIndex].y) SetNextWaypoint();
            }
            else if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0) 
            {
                onMovement = true;
                Debug.Log("Movement Enabled");
            }
        }
	}

    void SetNextWaypoint ()
    {
        transform.position = waypoints[waypointIndex];
        waypointIndex++;

        if (waypointIndex >= waypoints.Length) pathEnded = true;
        else
        {
            direction = waypoints[waypointIndex] - transform.position;
            direction.Normalize();
        }

        Debug.Log("New Waypoint Set");
    }

    public void SetWaypoints (GameObject[] cells, int[] path)
    {
        waypoints = new Vector3[cells.Length];

        for (int i = 0; i < cells.Length; i++)
        {
            waypoints[i] = cells[path[i]].transform.position;
            waypoints[i].z = axisZ;
        }
    }

    /*
    public void SetWaypoints (GameObject[] objs)
    {
        waypoints = new Vector3[objs.Length];

        for (int i=0; i<objs.Length; i++)
        {
            waypoints[i] = objs[i].transform.position;
        }
    }
    */
}
