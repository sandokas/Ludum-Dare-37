using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
    public float speed = 2;
    Vector3 forward;
    
	// Use this for initialization
	void Start () {
        //playerTransform = GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Camera camera = GetComponent<Camera>();
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
            Vector3 eulerAngles = transform.rotation.eulerAngles;
            if (eulerAngles.y < 90)
                mousePosition.x = 90;
            if (eulerAngles.y > 270)
                mousePosition.x = -90;
            forward = mousePosition - camera.transform.position;
        }

        }
        void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Quaternion cameraRotation = Quaternion.LookRotation(forward.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, Time.deltaTime * speed);
        }
    }
}
