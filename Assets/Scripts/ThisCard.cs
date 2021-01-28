using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public Card thisCard = new Card();
    [Range(0, 4)]
    public int thisId;
    public int Id;
    public string CardName;
    public int Cost;
    public int Power;
    public int PV;
    public string CardDescription;
    [Range(1, 4)]
    public int Rarete;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text PVText;
    public Text descriptionText;

    public Sprite sprite;
    public Image image;
    public Image imageRareteColor;

    // Start is called before the first frame update
    void Start()
    {
        thisCard = CardDataBase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        thisCard = CardDataBase.cardList[thisId];
        Id = thisCard.Id;
        CardName = thisCard.CardName;
        Cost = thisCard.Cost;
        Power = thisCard.Power;
        PV = thisCard.PV;
        CardDescription = thisCard.CardDescription;
        Rarete = thisCard.Rarete;

        sprite = thisCard.Image;

        nameText.text = "" + CardName;
        costText.text = "" + Cost;
        powerText.text = "" + Power;
        PVText.text = "" + PV;
        descriptionText.text = " " + CardDescription;

        image.sprite = sprite;

        if(Rarete == 1) { imageRareteColor.color = Color.gray; }
        if(Rarete == 2) { imageRareteColor.color = Color.blue; }
        if (Rarete == 3) { imageRareteColor.color = Color.magenta; }
        if (Rarete == 4) { imageRareteColor.color = Color.yellow; }
    }
}
