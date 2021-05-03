using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Utilities.Messages;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Enums;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> foods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;

        private decimal TotalIncome = 0.0m;

        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);

            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);

            }

            this.foods.Add(food);

            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);

            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables
                .Where(x => !x.IsReserved)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return String.Format(OutputMessages.TotalIncome, TotalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            StringBuilder sb = new StringBuilder();

            if (table != null)
            {
                decimal bill = table.GetBill();
                table.Clear();

                TotalIncome += bill;

                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {bill:f2}");

            }

            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var food = this.foods.FirstOrDefault(x => x.Name == foodName);

            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }


            table.OrderFood(food);

            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = this.tables
                .Where(x => !(x.IsReserved))
                .FirstOrDefault(c => c.Capacity >= numberOfPeople);

            string result = string.Empty;

            if (freeTable == null)
            {
                result = String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                freeTable.Reserve(numberOfPeople);

                result = String.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
            }

            return result;
        }


    }
}
