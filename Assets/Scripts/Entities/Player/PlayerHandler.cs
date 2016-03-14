using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {

	public Player player;
	public MapHandler mapHandler;

	void Start () {
		mapHandler = GameObject.Find ("MapHandler")
			.GetComponent<MapHandler>();
	}

	//Bounded Player Movement
	public bool MovePlayer(int x, int y){
		if ((player.x + x) < mapHandler.map.width &&
		   (player.y + y) < mapHandler.map.height &&
			(player.x + x) >= 0 && (player.y + y) >= 0) {
			if (mapHandler.map
				.getTile (player.x + x, player.y + y).type == 1) {
				player.x += x;
				player.y += y;

				return true;
			} else
				return false;
		}

		return false;
	}
}

[System.Serializable]
public class Player{
	public int x;
	public int y;
	public int hitPoints;
	public int orientation; //0 - Forward 1 - Right 2 - Backward 3 - Left

	public Player(int x, int y){
		this.x = x;
		this.y = y;
		orientation = 0;
	}

	public Player(){
		x = 0;
		y = 0;
		orientation = 0;
	}
}