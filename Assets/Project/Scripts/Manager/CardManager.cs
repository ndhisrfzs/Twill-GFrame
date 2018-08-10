using Logic;
using UnityEngine;

namespace GFrame
{
    public class CardManager : Singleton<CardManager>
    {
        private CardManager() { }

        public GameObject CreateCard(byte card_value)
        {
            var number = TwillLogic.CardNumber(card_value);
            var huase = TwillLogic.CardHuase(card_value);

            var go = PoolManager.Instance.Pool<ItemsPool>().Spawn<Card>();
            go.name = card_value.ToString();

            var select_card = go.GetComponent<SelectCard>();
            select_card.enabled = true;
            select_card.isSelected = false;

            var card = go.GetComponent<Card>();
            if (number == CardEnum.ElderJoker || number == CardEnum.LittleJoker)
            {
                card.Number_Image.enabled = false;
                card.SmallHuase_Image.enabled = false ;
                card.Huase_Image.enabled = true;
                card.Huase_Image.sprite = loadSprite(number.ToString());
            }
            else
            {
                card.Number_Image.enabled = true;
                card.SmallHuase_Image.enabled = true;
                card.Huase_Image.enabled = false;
                if (huase == CardEnum.Diamond || huase == CardEnum.Hert)
                {
                    card.Number_Image.sprite = loadSprite(number + "r");
                }
                else
                {
                    card.Number_Image.sprite = loadSprite(number + "b");
                }

                //if (number <= CardEnum.Ten || number == CardEnum.Ace || number == CardEnum.Two)
                //{
                //    card.Huase_Image.sprite = loadSprite(huase.ToString());
                //}
                //else
                //{
                //    if (huase == CardEnum.Diamond || huase == CardEnum.Hert)
                //    {
                //        card.Huase_Image.sprite = loadSprite(number + "r1");
                //    }
                //    else
                //    {
                //        card.Huase_Image.sprite = loadSprite(number + "b1");
                //    }
                //}
                card.SmallHuase_Image.sprite = loadSprite(huase.ToString());
            }

            card.Number_Image.SetNativeSize();
            card.Huase_Image.SetNativeSize();
            card.SmallHuase_Image.SetNativeSize();

            return go;
        }

        public void Despawn(GameObject go)
        {
            PoolManager.Instance.Pool<ItemsPool>().Despawn<Card>(go);
        }

        private Sprite loadSprite(string spriteName)
        {
            return Resources.Load<GameObject>("Sprite/" + spriteName).GetComponent<SpriteRenderer>().sprite;
        }
    }
}
