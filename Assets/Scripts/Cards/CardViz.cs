using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//Loading card object and everything in it.




namespace SA
{
    public class CardViz : MonoBehaviour
    {
        public Text title;
        public Text details;
        public Text flavor;
        public Image art;
        public Text source;

        //Creating Card Object
        public Card card;

        void Start()
        {
            LoadCard(card);
            //Need to have card prefabs in the prefabs folder

        
             
        }



        public void LoadCard(Card c)
        {
            if (c == null)
            {
                return;
            }

            c.cardViz = this;

            card = c;
            title.text = c.cardName;
            details.text = c.cardDetails;

            if (string.IsNullOrEmpty(c.cardFlavour))
            {
                flavor.gameObject.SetActive(false);
            }
            else
            {
                flavor.gameObject.SetActive(true);
                flavor.text = c.cardFlavour;
            }


            card = c;
            title.text = c.cardName;
            details.text = c.cardDetails;
            flavor.text = c.cardFlavour;
            source.text = c.source;
            art.sprite = c.art;
        }

    }
}
