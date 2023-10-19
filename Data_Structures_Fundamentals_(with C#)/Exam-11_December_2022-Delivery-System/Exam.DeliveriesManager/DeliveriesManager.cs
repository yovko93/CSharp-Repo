using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string, Deliverer> deliverers = new Dictionary<string, Deliverer>();
        private Dictionary<string, Package> packages = new Dictionary<string, Package>();
        private Dictionary<string, string> packagesByDeliverer = new Dictionary<string, string>();

        public void AddDeliverer(Deliverer deliverer)
        {
            deliverers.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            packages.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!deliverers.ContainsKey(deliverer.Id) || !packages.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }

            packagesByDeliverer.Add(package.Id, deliverer.Id);
        }

        public bool Contains(Deliverer deliverer)
        {
            return deliverers.ContainsKey(deliverer.Id);
        }

        public bool Contains(Package package)
        {
            return packages.ContainsKey(package.Id);
        }

        public IEnumerable<Deliverer> GetDeliverers()
        {
            return deliverers.Values;
        }

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            var deliverersByPackageId = new Dictionary<string, List<string>>();

            foreach (var package in packagesByDeliverer)
            {
                if (!deliverersByPackageId.ContainsKey(package.Value))
                {
                    deliverersByPackageId.Add(package.Value, new List<string>());
                }

                deliverersByPackageId[package.Value].Add(package.Key);
            }

            return deliverersByPackageId
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => deliverers[kvp.Key].Name)
                .Select(kvp => deliverers[kvp.Key]);

            //return deliverers
            //    .Where(d => packagesByDeliverer.ContainsValue(d.Key))
            //    .Select(p => p.Value)
            //    .OrderByDescending(d => packagesByDeliverer.Count)
            //    .ThenBy(d => d.Name);
        }

        public IEnumerable<Package> GetPackages()
        {
            return packages.Values;
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        {
            return packages.Values
                .OrderByDescending(package => package.Weight)
                .ThenBy(package => package.Receiver);
        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return packages
                .Where(package => !packagesByDeliverer.ContainsKey(package.Key))
                .Select(package => package.Value);
        }
    }
}
