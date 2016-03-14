using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float scale;
	public float currRotation;
	public float moveSpeed;
	public float rotationSpeed;
	public float timeInterval;

	public GameObject cameraPivot;
	public int direction = 0;

	private PlayerHandler playerHandler;
	private float tick = 0;
	private bool canPress = true;
	private Vector3 destination;

	void Start () {
		playerHandler = GameObject.Find ("PlayerHandler")
			.GetComponent<PlayerHandler>();
		destination = new Vector3 (playerHandler.player.x * scale,
									transform.position.y,
									playerHandler.player.y * scale);
	}

	void Update () {
		destination = new Vector3 (playerHandler.player.x * scale,
			transform.position.y,
			playerHandler.player.y * scale);


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
			bool moved = false;

			switch (playerHandler.player.orientation) {
			case 0:
				moved = playerHandler.MovePlayer (0, 1);
				break;
			case 1:
				moved = playerHandler.MovePlayer (1, 0);
				break;
			case 2:
				moved = playerHandler.MovePlayer (0, -1);
				break;
			case 3:
				moved = playerHandler.MovePlayer (-1, 0);
				break;
			}

			if(moved)
				canPress = false;

		} else if (Input.GetAxis ("Vertical") < 0 && canPress) {
			bool moved = false;

			switch (playerHandler.player.orientation) {
			case 0:
				moved = playerHandler.MovePlayer (0, -1);
				break;
			case 1:
				moved = playerHandler.MovePlayer (-1, 0);
				break;
			case 2:
				moved = playerHandler.MovePlayer (0, 1);
				break;
			case 3:
				moved = playerHandler.MovePlayer (1, 0);
				break;
			}

			if(moved)
				canPress = false;
		}

		if (Input.GetAxis ("Horizontal") > 0 && canPress) {
			canPress = false;

			direction = 1;

			if (playerHandler.player.orientation < 3) {
				currRotation += 90;
				playerHandler.player.orientation++;
			} else {
				currRotation = 0;
				playerHandler.player.orientation = 0;
			}
		} else if (Input.GetAxis ("Horizontal") < 0 && canPress) {
			canPress = false;

			direction = -1;

			if (playerHandler.player.orientation > 0) {
				currRotation -= 90;
				playerHandler.player.orientation--;
			} else {
				currRotation = 270;
				playerHandler.player.orientation = 3;
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