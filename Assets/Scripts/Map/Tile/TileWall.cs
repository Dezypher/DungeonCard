using UnityEngine;
using System.Collections;

public class TileWall : MonoBehaviour {

	public GameObject[] walls;

	public void RemoveWall(int i){
		Destroy (walls [i]);
	}
}
