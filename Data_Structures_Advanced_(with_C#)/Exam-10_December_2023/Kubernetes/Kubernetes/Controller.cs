using System;
using System.Collections.Generic;
using System.Linq;

namespace Kubernetes
{
    public class Controller : IController
    {
        private Dictionary<string, Pod> allPods = new Dictionary<string, Pod>();
        private LinkedList<Pod> podQueue = new LinkedList<Pod>();

        public bool Contains(string podId)
        {
            return allPods.ContainsKey(podId);
        }

        public void Deploy(Pod pod)
        {
            podQueue.AddLast(pod);
            allPods.Add(pod.Id, pod);
        }

        public Pod GetPod(string podId)
        {
            if (!allPods.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            return allPods[podId];
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
        {
            return podQueue
                .Where(pod => pod.Port >= lowerBound && pod.Port <= upperBound);
        }

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
        {
            return podQueue
                 .Where(pod => pod.Namespace == @namespace);
        }

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
        {
            return podQueue
                .OrderByDescending(pod => pod.Port)
                .ThenBy(pod => pod.Namespace);
        }

        public int Size()
        {
            return allPods.Count;
        }

        public void Uninstall(string podId)
        {
            if (!allPods.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            var pod = allPods[podId];
            allPods.Remove(podId);

            podQueue.Remove(pod);
        }

        public void Upgrade(Pod pod)
        {
            if (allPods.ContainsKey(pod.Id))
            {
                var currentPod = GetPod(pod.Id);
                currentPod.ServiceName = pod.ServiceName;
                currentPod.Namespace = pod.Namespace;
                currentPod.Port = pod.Port;

                allPods[pod.Id] = currentPod;
            }
            else
            {
                Deploy(pod);
            }
        }
    }
}