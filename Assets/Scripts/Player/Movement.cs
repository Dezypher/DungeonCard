using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float scale;
	public float currRotation;
	public float moveSpeed;
	public float rotationSpeed;
	public int orientation; //0 - Forward 1 - Right 2 - Backward 3 - Left
	public float timeInterval;

	public float tick = 0;

	public GameObject cameraPivot;

	public int direction = 0;
	public bool canPress = true;
	public Vector3 destination;

	void Start () {
		destination = transform.position;
	}

	void Update () {
		if (destination.x > transform.position.x) {
			transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
			if (destination.x < transform.position.x)
				transform.position = new Vector3 (destination.x, transform.position.y, transform.position.z);
		} else if (destination.x < transform.position.x) {
			transform.Translate (-Vector3.right * Time.deltaTime * moveSpeed);
			if (destination.x > transform.position.x)
				transform.position = new Vector3 (destination.x, transform.position.y, transform.position.z);
		} else if (destination.z > transform.position.z) {
			transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
			if (destination.z < transform.position.z)
				transform.position = new Vector3 (transform.position.x, transform.position.y, destination.z);
		} else if (destination.z < transform.position.z) {
			transform.Translate (-Vector3.forward * Time.deltaTime * moveSpeed);
			if (destination.z > transform.position.z)
				transform.position = new Vector3 (transform.position.x, transform.position.y, destination.z);
		}

		if (Input.GetAxis ("Vertical") > 0 && canPress) {
			canPress = false;

			float x = transform.position.x;
			float y = transform.position.y;
			float z = transform.position.z;

			switch (orientation) {
			case 0:
				destination = new Vector3(x, y, z + scale);
				break;
			case 1:
				destination = new Vector3(x + scale, y, z);
				break;
			case 2:
				destination = new Vector3(x, y, z - scale);
				break;
			case 3:
				destination = new Vector3(x - scale, y, z);
				break;
			}
		} else if (Input.GetAxis ("Vertical") < 0 && canPress) {
			canPress = false;

			float x = transform.position.x;
			float y = transform.position.y;
			float z = transform.position.z;

			switch (orientation) {
			case 0:
				destination = new Vector3(x, y, z - scale);
				break;
			case 1:
				destination = new Vector3(x - scale, y, z);
				break;
			case 2:
				destination = new Vector3(x, y, z + scale);
				break;
			case 3:
				destination = new Vector3(x + scale, y, z);
				break;
			}
		}

		if (Input.GetAxis ("Horizontal") > 0 && canPress) {
			canPress = false;

			direction = 1;

			if (orientation < 3) {
				currRotation += 90;
				orientation++;
			} else {
				currRotation = 0;
				orientation = 0;
			}
		} else if (Input.GetAxis ("Horizontal") < 0 && canPress) {
			canPress = false;

			direction = -1;

			if (orientation > 0) {
				currRotation -= 90;
				orientation--;
			} else {
				currRotation = 270;
				orientation = 3;
			}
		}

		if (currRotation != cameraPivot.transform.localRotation.y) {
			cameraPivot.transform.Rotate ((Vector3.up * direction) * Time.deltaTime * rotationSpeed);
			float rotY = cameraPivot.transform.eulerAngles.y;

			if(direction == 1){
				if (currRotation == 0){
					 if (rotY > 0 && rotY < 90) {
						cameraPivot.transform.eulerAngles = new Vector3 (0, currRotation, 0);
						direction = 0;
					}
				} else if (rotY > currRotation) {
					cameraPivot.transform.eulerAngles = new Vector3 (0, currRotation, 0);
					direction = 0;
				}
			} else if (direction == -1) {
				if (currRotation == 0){
					if (rotY > 270 && rotY < 360) {
						cameraPivot.transform.eulerAngles = new Vector3 (0, currRotation, 0);
						direction = 0;
					}
				} else if (rotY < currRotation) {
					cameraPivot.transform.eulerAngles = new Vector3 (0, currRotation, 0);
					direction = 0;
				}
			}
		}

		if (!canPress) {
			tick += 1 * Time.deltaTime;

			if (tick > timeInterval) {
				canPress = true;
				tick = 0;
			}
		}
	}
}