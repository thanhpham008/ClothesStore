using System;
using System.Linq;

namespace ClothesStore
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");
			var store = new Store();

			var tShirt = new TShirt();
			tShirt.Init(Type.TShirt, Color.Red, Size.Small);
			store.Buy(tShirt, 1);

			var dressShirt = new DShirt();
			dressShirt.Init(Type.DressShirt, Color.Green, Size.Medium);
			store.Buy(dressShirt, 1);

			var jean = new Jean();
			jean.Init(Type.Jean, Color.Blue, Size.Large);
			store.Buy(jean, 1);

			tShirt = new TShirt();
			tShirt.Init(Type.TShirt, Color.Yellow, Size.Small);
			store.Buy(tShirt, 1);

			tShirt = new TShirt();
			tShirt.Init(Type.TShirt, Color.Yellow, Size.Small);
			store.Buy(tShirt, 1);

			//store.Sell(tShirt);


			//tShirt = new TShirt();
			//tShirt.Init(6, 12, Type.TShirt, Color.Red);

			//store.Clothes = store.Clothes.OrderBy(x => x.Type).ToList();
			Console.WriteLine("Welcome to ClothesStore.");
			PrintStoreStatus(store);

			while (true)
			{
				Console.Write("Do you want to buy or sell (1/2)?: ");
				var action = Console.ReadLine();
				if (action == "1")
				{
					Console.Write("Which type of clothes do you want to buy? (TShirt: 1, DressShirt: 2, Jean: 3): ");
					var type = Console.ReadLine();
					Console.Write("Please choose color (Red: 1, Green: 2, Yellow: 3, Blue: 4): ");
					var color = Console.ReadLine();
					Console.Write("Please choose size (Small: 1, Medium: 2, Large: 3): ");
					var size = Console.ReadLine();
					Console.Write("How many items do you want to buy?: ");
					var quantity = Console.ReadLine();

					var item = new TShirt();
					item.Init((Type)int.Parse(type), (Color)int.Parse(color), (Size)int.Parse(size));
					store.Buy(item, int.Parse(quantity));
				}
				else if (action == "2")
				{
					Console.Write("Choose the type of clothes you want to sell (TShirt: 1, DressShirt: 2, Jean: 3): ");
					var type = Console.ReadLine();
					Console.Write("Please choose color (Red: 1, Green: 2, Yellow: 3, Blue: 4): ");
					var color = Console.ReadLine();
					Console.Write("Please choose size (Small: 1, Medium: 2, Large: 3): ");
					var size = Console.ReadLine();
					Console.Write("How many items do you want to sell?: ");
					var quantity = Console.ReadLine();

					var item = new TShirt();
					item.Init((Type)int.Parse(type), (Color)int.Parse(color), (Size)int.Parse(size));
					var sell = store.Sell(item, int.Parse(quantity));
					if (sell == 0)
						Console.WriteLine("Sell succesfully!");
					else if (sell ==1)
						Console.WriteLine("Sorry, this item is out of stock!");
					else if (sell == 2)
						Console.WriteLine("Sorry, cannot find this item in stock!");
				}

				PrintStoreStatus(store);
			}

		}

		private static void PrintStoreStatus(Store store)
		{
			Console.WriteLine("Store status is:");
			Console.WriteLine("======================");

			foreach (var clothe in store.Clothes)
			{
				Console.WriteLine("Type: " + clothe.Type.ToString());
				Console.WriteLine("Color: " + clothe.Color.ToString());
				Console.WriteLine("Size: " + clothe.Size.ToString());
				Console.WriteLine("Buying price: " + clothe.BuyPrice.ToString());
				Console.WriteLine("Selling price: " + clothe.SellPrice.ToString());
				Console.WriteLine("Quantity: " + clothe.Quantity);
				Console.WriteLine("Total money left in store: " + store.Money);

				Console.WriteLine();
			}
			Console.WriteLine("======================");
		}
	}
}
