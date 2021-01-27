using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int Id;
    public string CardName;
    public int Cost;
    public int Power;
    public string CardDescription;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
