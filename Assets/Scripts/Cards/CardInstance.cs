using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// instanitiate the Card Prefab, contains all info about a card
/// /// </summary>
public class CardInstance : MonoBehaviour
{

    public Image image;//获取图片组件，设置图片
    public Sprite[] img;//获取Prefab上绑定过的指定的图片
    public Sprite[] smallImg;
    public int ImageIndex;//图片索引
    public int Demage;//伤害
    public string cardType;//卡牌类型
    public Card card;//确认这张牌

    public Text Title;
    public Text CardInfomation;
    public Image SmallImage;
    
    public int CardID;


    public void Start()
    {
        //设置卡牌文字信息
        Invoke("DelaySetInfor", 0.5f);
    }

    private void DelaySetInfor()
    {
       
        Title.text = card.cardName;
        CardInfomation.text = card.CardIntro;
    }

    /// <summary>
    /// 设置卡牌图片 
    /// </summary>
    /// <param name="index"></param>
    public void SetImage(int index)
    {

        ImageIndex = index;
        image.sprite = img[index];
        //Debug.Log(card.CardID);

        switch (card.cardID)
        {
            case 0:
                SmallImage.sprite = smallImg[0];
                break;
            case 1:
                SmallImage.sprite = smallImg[1];
                break;
            case 2:
                SmallImage.sprite = smallImg[2];
                break;
            case 3:
                SmallImage.sprite = smallImg[3];
                break;
            case 4:
                SmallImage.sprite = smallImg[4];
                break;
            case 5:
                SmallImage.sprite = smallImg[5];
                break;
            case 6:
                SmallImage.sprite = smallImg[6];
                break;
            case 7:
                SmallImage.sprite = smallImg[7];
                break;
            case 9:
                SmallImage.sprite = smallImg[8];
                break;
            case 14:
                SmallImage.sprite = smallImg[9];
                break;
            case 15:
                SmallImage.sprite = smallImg[10];
                break;
            case 16:
                SmallImage.sprite = smallImg[11];
                break;
            case 17:
                SmallImage.sprite = smallImg[12];
                break;
        }
    }

    public void SetCurChooseCardToEvent()
    {
        GameObject.FindGameObjectWithTag("Event").GetComponent<MainSceneEvent>().NowChooseCard = card;
    }
    public void SetCard(Card card)
    {
        this.card = card;
    }
 

    public void SetIntro(string Intro)
    { 
        // CardIntro.text=Intro;
    }
}