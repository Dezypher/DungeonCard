using UnityEngine;
using System.Collections;


[System.Serializable]
public class Card {
	public enum CardType{Item, Weapon, Skill};
	public static int CARDTYPE_ITEM = 0;
	public static int CARDTYPE_WEAPON = 1;
	public static int CARDTYPE_SKILL = 2;

	public string name;
	public string description;
	public CardType type;
	public Effect[] effects;

	public string GetName(){
		return name;
	}

	public int GetCardType(){
		return (int) type;
	}
}

[System.Serializable]
public class Effect {
	public enum EffectType{ChangeHP, ChangeStat};
	public static int EFFECT_CHANGEHP = 0;
	public static int EFFECT_CHANGESTAT = 1;

	public EffectType effectType;
	public int recepientID; //0 is none, 1 is Player
	public int[] values;
	public int animationID;
}

public class EffectHandler {		

	public void DoEffect(int effectType, int recepientID){

	}
}