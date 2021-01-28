using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
	public static List<Card> cardList = new List<Card>();

	private void Awake()
	{
		cardList.Add(new Card(0, "Demon", 4, 5, 3, "Venez avec moi hihi...", Resources.Load <Sprite>("1"), 1));
		cardList.Add(new Card(1, "Nain", 4, 5, 3, "Attention à ma grosse hache", Resources.Load<Sprite>("1"), 2));
		cardList.Add(new Card(2, "Elfe", 4, 5, 3, "Je tire à l'arc !", Resources.Load<Sprite>("2"), 3));
		cardList.Add(new Card(3, "Orc", 4, 5, 3, "Rrrrrr !", Resources.Load<Sprite>("1"), 3));
		cardList.Add(new Card(4, "Mage", 4, 5, 3, "Attention à sa magie", Resources.Load<Sprite>("1"), 4));
	}
}
