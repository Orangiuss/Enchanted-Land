using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
    public int Id;
    public string CardName;
    public int Cost;
    public int Power;
    public string CardDescription;

    public Card()
	{

	}

    public Card(int id, string cardName, int cost, int power, string cardDescription)
	{
        Id = id;
        CardName = cardName;
        Cost = cost;
        Power = power;
        CardDescription = cardDescription;
	}
}
