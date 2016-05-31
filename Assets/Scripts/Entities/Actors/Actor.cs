using UnityEngine;
using System.Collections;

public class Actor {
	public string name;
	public int hitPoints;

	//STATS
	public int maxHitPoints;
	public int physicalAttack;
	public int magicalAttack;
	public int defense;
	public int speed;
}

[System.Serializable]
public class Physical : Actor {
	public int x;
	public int y;
	public int orientation; //0 - Forward 1 - Right 2 - Backward 3 - Left
}

[System.Serializable]
public class Enemy : Actor {
	public string description;
	public int[] moves;

	public int moveWeightUseMove;
	public int moveWeightWait;
	public int moveWeightFlee;
}

[System.Serializable]
public class Move {
	public string moveName;
	public string moveDescription;
	public Effect[] effects;
	public int animationID;
}

[System.Serializable]
public class Player : Physical {
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