using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchBehaviour : MonoBehaviour
{
    [SerializeField] float toTargetDistance;
    [SerializeField] Image debugImage;
    [SerializeField] Image distanceDebugImage;

    [SerializeField] Transform target;

    Camera currentCamera;

    Vector3 onGridTouchPosition;

	void Start ()
    {
        currentCamera = Camera.main;
        debugImage.color = Color.black;
        distanceDebugImage.transform.localScale = toTargetDistance * Vector3.one;
        onGridTouchPosition = Vector3.zero;
	}
	

	void Update ()
    {
	    if (Input.touchCount > 0)
        {
            distanceDebugImage.transform.position = Input.touches[0].position;

            onGridTouchPosition = currentCamera.ScreenToWorldPoint(Input.touches[0].position);
            onGridTouchPosition.z = target.position.z;

            if (Vector3.Distance(onGridTouchPosition, target.position) < toTargetDistance)
            {
                debugImage.color = Color.green;
            }
            else debugImage.color = Color.red;
        }
        else debugImage.color = Color.black;
	}
}
