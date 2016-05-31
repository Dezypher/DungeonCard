using UnityEngine;
using System.Collections;

public class BattleHandler : MonoBehaviour {
	private ActorList actorList;
	private EnemyReference enemyReference;

	public Actor[] battleActors;
	public TurnMove[] turnMoves; //The moves of each battle actor
	public int turnNum;

	public void Start(){
		actorList = GameObject.Find ("ActorList")
			.GetComponent<ActorList> ();
		enemyReference = (Resources.Load ("ActorReference/EnemyReference")
			as GameObject).GetComponent<EnemyReference> ();
	}

	public void InitiateBattle(int[] enemies){
		battleActors = new Actor[enemies.Length + 1];
		battleActors [0] = actorList.actorList [0];

		for (int i = 0; i < enemies.Length; i++)
			battleActors [i + 1] = 
				enemyReference.enemyReference[enemies [i]];

		turnMoves = new TurnMove[battleActors.Length];

		turnNum = 1;

	}

	public void PlayerMove(int playerMove, int cardIndex){
		turnMoves [0] = new TurnMove (playerMove, cardIndex);

		PlayTurn ();
	}

	public void GenerateEnemyMoves(){
		for (int i = 1; i < battleActors.Length; i++) {
			Enemy enemy = battleActors [i] as Enemy;
			int weightTotal = enemy.moveWeightFlee
			                  + enemy.moveWeightUseMove
			                  + enemy.moveWeightWait;

			//Calculate probability of each type of move for the enemy
			int moveChance = enemy.moveWeightUseMove / weightTotal * 100;
			int waitChance = enemy.moveWeightWait / weightTotal * 100;	

			int moveRoll = Random.Range (0, 100);
			int moveType = 0;

			if (moveRoll < moveChance)
				moveType = 0;
			else if (moveRoll < (moveChance + waitChance))
				moveType = 1;
			else
				moveType = 2;

			int moveIndex = 0;
			if (moveType == 0) {
				int numMoves = enemy.moves.Length;

				moveIndex = (int) Random.Range (0, numMoves);
			}

			TurnMove turnMove = new TurnMove (moveType, moveIndex);
			turnMoves [i] = turnMove;
		}
	}

	public void PlayTurn(){
		//Start turn sequence by generating enemy moves
		GenerateEnemyMoves();

		//Check which battle actor moves first by checking speeds
	}
}

public class TurnMove {
	public static int MOVE_USE_MOVE = 0;
	public static int MOVE_WAIT = 1;
	public static int MOVE_FLEE = 2;
	//MoveType: 0 - Use Move, 1 - Wait, 2 - Attempt to Flee

	public int moveType; 
	public int moveIndex;

	public TurnMove(int moveType, int moveIndex){
		this.moveType = moveType;
	}
}