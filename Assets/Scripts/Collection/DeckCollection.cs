using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DeckCollection
{
    public List<int> deck = new List<int>();

    public DeckCollection()
    {
        // Collection de base à ajouter
        deck.Add(1);
        deck.Add(1);
        deck.Add(2);
        deck.Add(2);
    }
}
