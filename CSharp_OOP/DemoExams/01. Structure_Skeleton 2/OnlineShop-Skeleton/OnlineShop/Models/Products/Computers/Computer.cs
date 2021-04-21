using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;


        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();

        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override double OverallPerformance
        => CalculateOverallPerformance();

        public override decimal Price
            => CalculateTotalPrice();


        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(x => x.GetType() == component.GetType()))
            {
                var excMessage = String.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name,
                    this.GetType().Name,
                    this.Id);

                throw new ArgumentException(excMessage);
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (component == null)
            {
                var excMessage = String.Format(ExceptionMessages.NotExistingComponent,
                    componentType,
                    this.GetType().Name,
                    this.Id);

                throw new ArgumentException(excMessage);
            }

            this.components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                var excMessage = String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name,
                    this.GetType().Name,
                    this.Id);

                throw new ArgumentException(excMessage);
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                var excMessage = String.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id);

                throw new ArgumentException(excMessage);
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var componentsMessage = String.Format(SuccessMessages.ComputerComponentsToString, this.components.Count);

            string peripheralAverageResult = this.Peripherals.Count == 0 ? "0.00" : this.peripherals.Average(x => x.OverallPerformance).ToString("F2");

            var peripheralsMessage = String.Format(SuccessMessages.ComputerPeripheralsToString, this.peripherals.Count, peripheralAverageResult);

            sb.AppendLine(base.ToString());

            sb.AppendLine($" {componentsMessage}");

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" {peripheralsMessage}");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }


        private double CalculateOverallPerformance()
        {
            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }

            var result = base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);

            return result;
        }

        private decimal CalculateTotalPrice()
        {
            var price = base.Price + this.Components.Sum(x => x.Price) + this.Peripherals.Sum(x => x.Price);

            return price;
        }
    }
}
