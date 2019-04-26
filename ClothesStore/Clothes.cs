using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore
{
	public class Store
	{
		public List<Clothes> Clothes { get; set; }

		public int Money { get; set; }

		public Store()
		{
			Clothes = new List<Clothes>();
			Money = 1000;
		}

		public void Buy(Clothes clothes, int quantity)
		{
			var clothe = Clothes.FirstOrDefault(x => x.Type == clothes.Type && x.Size == clothes.Size && x.Color == clothes.Color);
			if (clothe != null)
			{
				clothe.Quantity += quantity;
				Money -= clothes.BuyPrice * quantity;
			}
			else
			{
				clothes.Quantity = quantity;
				Clothes.Add(clothes);
				Money -= clothes.BuyPrice * quantity;
			}
		}

		public int Sell(Clothes clothes, int quantity)
		{
			var clothe = Clothes.FirstOrDefault(x => x.Type == clothes.Type && x.Size == clothes.Size && x.Color == clothes.Color);
			if (clothe != null)
			{
				if (clothe.Quantity >= quantity)
				{
					clothe.Quantity -= quantity;
					Money += clothes.SellPrice * quantity;
					return 0;
				}
				else
				{
					return 1;
				}
			}
			return 2;
		}
	}

	public class Clothes
	{
		public int BuyPrice { get; set; }
		public int SellPrice { get; set; }
		public Type Type { get; set; }
		public Color Color { get; set; }
		public Size Size { get; set; }
		public int Quantity { get; set; }

		public Supplier Supplier { get; set; }

		public virtual void Init(Type type, Color color, Size size, Supplier supplier)
		{
			Type = type;
			Color = color;
			Size = size;
			Supplier = supplier;
		}
	}

	public class TShirt : Clothes
	{
		public override void Init(Type type, Color color, Size size, Supplier supplier = Supplier.SuperSills)
		{
			BuyPrice = 6;
			SellPrice = 12;
			base.Init(type, color, size, supplier);
		}

	}

	public class DShirt : Clothes
	{
		public override void Init(Type type, Color color, Size size, Supplier supplier = Supplier.SuperSills)
		{
			BuyPrice = 8;
			SellPrice = 20;
			base.Init(type, color, size, supplier);
		}
	}

	public class Jean : Clothes
	{
		public override void Init(Type type, Color color, Size size, Supplier supplier = Supplier.GreatTextile)
		{
			BuyPrice = 10;
			SellPrice = 30;
			base.Init(type, color, size, supplier);
		}
	}

	public enum Type
	{
		TShirt = 1,
		DressShirt = 2,
		Jean = 3
	}

	public enum Size
	{
		Small = 1,
		Medium = 2,
		Large = 3
	}

	public enum Color
	{
		Red = 1,
		Green = 2,
		Yellow = 3,
		Blue = 4
	}

	public enum Supplier
	{
		SuperSills = 1,
		GreatTextile = 2
	}
}
