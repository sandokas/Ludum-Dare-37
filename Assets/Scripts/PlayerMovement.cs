using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5;

    public bool IsPlayerMoving
    {
        get { return isPlayerMoving; }
    }

    private Rigidbody rb;
    private bool isPlayerMoving = false;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        isPlayerMoving = false;
        Vector3 direction = Vector3.zero;
	    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            isPlayerMoving = true;
            direction = direction + transform.forward;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            //transform.Rotate
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            //rb.AddRelativeForce(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            isPlayerMoving = true;
            direction = direction -transform.forward;
        }
        rb.AddRelativeForce(direction.normalized * speed * Time.deltaTime,ForceMode.Impulse);
    }
}
