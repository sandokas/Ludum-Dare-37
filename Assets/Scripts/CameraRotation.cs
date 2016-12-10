using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
    public float speed = 2;
    Vector3 forward;
    
    public Transform playerTransform;
	// Use this for initialization
	void Start () {
        //playerTransform = GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Camera camera = GetComponent<Camera>();
        if (Input.GetMouseButton(1))
        {
            //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Vector3 mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
            forward = mousePosition - camera.transform.position;
        }
        

    }
    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            //Vector3 playerForward = Vector3.Cross(forward, new Vector3(1, 0, 1));
            //Quaternion cameraRotation = Quaternion.LookRotation(forward.normalized, Vector3.up);
            Quaternion playerRotation = Quaternion.LookRotation(forward.normalized, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, Time.deltaTime * speed);
            playerTransform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime * speed);
        }
    }
}
