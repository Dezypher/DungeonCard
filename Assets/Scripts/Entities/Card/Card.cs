using UnityEngine;
using System.Collections;


[System.Serializable]
public class Card {
	public enum CardType{Item, Weapon, Skill};
	public static int CARDTYPE_ITEM = 0;
	public static int CARDTYPE_WEAPON = 1;
	public static int CARDTYPE_SKILL = 2;

	public string name;
	public CardType type;
	public CardEffect[] effects;

	public string GetName(){
		return name;
	}

	public int GetCardType(){
		return (int) type;
	}
}

[System.Serializable]
public class CardEffect {
	public enum CardEffectType{};
	public static int CARDEFFECT_CHANGEHP = 0;
	public static int CARDEFFECT_CHANGESTAT = 1;

	public CardEffectType effectType;
	public int recepientID; //0 is none, 1 is Player
	public int[] values;
	public int animationID;
}

public class CardHandler {

}