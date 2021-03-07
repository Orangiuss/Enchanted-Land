using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Collection
{
    public List<int> collection = new List<int>();
    public List<DeckCollection> decks = new List<DeckCollection>();

    public Collection()
    {
        // Collection de base à ajouter
        decks.Add(new DeckCollection());
        collection.Add(1);
        decks[0].deck.Add(3);
    }
}