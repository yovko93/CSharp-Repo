using System;
using System.Linq;
using System.Collections.Generic;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(computer);

            var result = String.Format(SuccessMessages.AddedComputer, computer.Id);

            return result;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            this.DoesComputerExist(computerId);

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            this.peripherals.Add(peripheral);

            this.computers.FirstOrDefault(x => x.Id == computerId)
                .AddPeripheral(peripheral);

            var succMessage = String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

            return succMessage;

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            this.DoesComputerExist(computerId);

            var peripheral = this.computers
                .FirstOrDefault(x => x.Id == computerId)
                .RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            var succMessage = String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);

            return succMessage;
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            this.DoesComputerExist(computerId);

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            this.components.Add(component);

            this.computers.FirstOrDefault(x => x.Id == computerId)
                .AddComponent(component);

            var succMessage = String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

            return succMessage;
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            this.DoesComputerExist(computerId);

            var component = this.computers
                 .FirstOrDefault(x => x.Id == computerId)
                 .RemoveComponent(componentType);

            //TODO:
            //this.components.Remove(component);

            var succMessage = String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);

            return succMessage;
        }

        public string BuyComputer(int id)
        {
            this.DoesComputerExist(id);

            var computer = this.computers.First(x => x.Id == id);

            var result = computer.ToString();

            this.computers.Remove(computer);

            return result;
        }

        public string BuyBest(decimal budget)
        {
            var computer = this.computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();

            if (computer == null)
            {
                var msg = String.Format(ExceptionMessages.CanNotBuyComputer, budget);

                throw new ArgumentException(msg);
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            this.DoesComputerExist(id);

            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            return computer.ToString();
        }


        private void DoesComputerExist(int computerId)
        {
            if (!this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
