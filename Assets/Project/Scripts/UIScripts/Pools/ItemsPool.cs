using UnityEngine;
using UnityEngine.UI;

namespace GFrame
{
	public class ItemsPool : SpawnPool<ItemsPool>
	{
		public ItemsPool()
		{
			m_Pools.Add("Bomb", new BombPool());
			m_Pools.Add("Card", new CardPool());
			m_Pools.Add("LogItem", new LogItemPool());
		}
	}
	public class BombPool : PrefabPool<Bomb>
	{
		public override string PrefabPath()
		{
			return "Prefabs/Items/Bomb";
		}
	}
	public class Bomb : UIComponents
	{
		public override void InitUIComponents()
		{
			BombStar_Text = transform.Find("BombStar").GetComponent<Text>();
			BombNumber_Text = transform.Find("BombNumber").GetComponent<Text>();
		}
		public override void Clear()
		{
			BombStar_Text = null;
			BombNumber_Text = null;
		}
		public Text BombStar_Text;
		public Text BombNumber_Text;
	}
	public class CardPool : PrefabPool<Card>
	{
		public override string PrefabPath()
		{
			return "Prefabs/Items/Card";
		}
	}
	public class Card : UIComponents
	{
		public override void InitUIComponents()
		{
			Number_Image = transform.Find("Number").GetComponent<Image>();
			SmallHuase_Image = transform.Find("SmallHuase").GetComponent<Image>();
			Huase_Image = transform.Find("Huase").GetComponent<Image>();
		}
		public override void Clear()
		{
			Number_Image = null;
			SmallHuase_Image = null;
			Huase_Image = null;
		}
		public Image Number_Image;
		public Image SmallHuase_Image;
		public Image Huase_Image;
	}
	public class LogItemPool : PrefabPool<LogItem>
	{
		public override string PrefabPath()
		{
			return "Prefabs/Items/LogItem";
		}
	}
	public class LogItem : UIComponents
	{
		public override void InitUIComponents()
		{
			RoomId_Text = transform.Find("RoomId").GetComponent<Text>();
			Time_Text = transform.Find("Time").GetComponent<Text>();
			P1Name_Text = transform.Find("P1/P1Name").GetComponent<Text>();
			P1Score_Text = transform.Find("P1/P1Score").GetComponent<Text>();
			P2Name_Text = transform.Find("P2/P2Name").GetComponent<Text>();
			P2Score_Text = transform.Find("P2/P2Score").GetComponent<Text>();
			P3Name_Text = transform.Find("P3/P3Name").GetComponent<Text>();
			P3Score_Text = transform.Find("P3/P3Score").GetComponent<Text>();
			P4Name_Text = transform.Find("P4/P4Name").GetComponent<Text>();
			P4Score_Text = transform.Find("P4/P4Score").GetComponent<Text>();
		}
		public override void Clear()
		{
			RoomId_Text = null;
			Time_Text = null;
			P1Name_Text = null;
			P1Score_Text = null;
			P2Name_Text = null;
			P2Score_Text = null;
			P3Name_Text = null;
			P3Score_Text = null;
			P4Name_Text = null;
			P4Score_Text = null;
		}
		public Text RoomId_Text;
		public Text Time_Text;
		public Text P1Name_Text;
		public Text P1Score_Text;
		public Text P2Name_Text;
		public Text P2Score_Text;
		public Text P3Name_Text;
		public Text P3Score_Text;
		public Text P4Name_Text;
		public Text P4Score_Text;
	}
}
