using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {

	public Player player;
	public MapHandler mapHandler;

	void Start () {
		mapHandler = GameObject.Find ("MapHandler")
			.GetComponent<MapHandler>();
		GameObject.Find ("ActorList")
			.GetComponent<ActorList> ().actorList[0] = player;
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