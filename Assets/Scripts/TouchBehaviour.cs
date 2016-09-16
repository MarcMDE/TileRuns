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

	void Start ()
    {
        currentCamera = Camera.main;
        debugImage.color = Color.black;
        distanceDebugImage.transform.localScale = toTargetDistance * Vector3.one;
	}
	

	void Update ()
    {
	    if (Input.touchCount > 0)
        {
            if (Vector3.Distance(currentCamera.ScreenToWorldPoint(Input.touches[0].position), target.position) < toTargetDistance)
            {
                debugImage.color = Color.green;
                distanceDebugImage.transform.position = currentCamera.WorldToScreenPoint(target.transform.position);
            }
        }
        debugImage.color = Color.red;
	}
}
