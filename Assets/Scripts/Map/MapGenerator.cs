using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	//GENERATION PARAMETERS

	public float tileScale;
	public float originX;
	public float originY;
	public GameObject tileReference;
	public GameObject playerObject;
	public Player player;

	public MapHandler mapHandler;

	void Awake () {
		mapHandler = GameObject.Find ("MapHandler")
			.GetComponent<MapHandler>();
		tileReference = Resources.Load ("Prefabs/Map/Tile") as GameObject;
		playerObject = GameObject.Find ("PlayerObject");
		player = GameObject.Find ("PlayerHandler")
			.GetComponent<PlayerHandler>().player;
		player.name = "Player";
	}

	public void Generate(Map map){
		for (int x = 0; x < map.width; x++)
			for (int y = 0; y < map.height; y++) {
				if (map.getTile (x, y).type == 1) {
					GameObject tile = 
						Instantiate (tileReference, new Vector3 (x * tileScale, 0, y * tileScale), Quaternion.identity) 
							as GameObject;

					TileWall tileWall = tile.GetComponent<TileWall> ();

					if ((y + 1) < map.height && map.getTile (x, y + 1).type != 0) {
						tileWall.RemoveWall (0);
					}
					if ((y - 1) >= 0 && map.getTile (x, y - 1).type != 0) {
						tileWall.RemoveWall (2);
					}
					if ((x + 1) < map.width && map.getTile (x + 1, y).type != 0) {
						tileWall.RemoveWall (1);
					}
					if ((x - 1) >= 0 && map.getTile (x - 1, y).type != 0) {
						tileWall.RemoveWall (3);
					}
				}
			}

		//Set Player position to Spawn Point
		playerObject.transform.position = new Vector3(map.spawnPointX * tileScale, 
						playerObject.transform.position.y, 
						map.spawnPointY * tileScale);
		player.x = map.spawnPointX;
		player.y = map.spawnPointY;
	}
}