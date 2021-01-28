using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int x;
    public int deckSize;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;

        for(int i=0; i<30; i++)
		{
            x = Random.Range(0, 5);
            deck[i] = CardDataBase.cardList[x];
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shuffle()
	{
        for(int i=0; i<deckSize; i++)
		{

		}
	}
}
