using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public class Manager : IManager
    {
        //    private readonly Dictionary<string, Task> tasks = new Dictionary<string, Task>();
        //    private readonly Dictionary<string, List<string>> dependencies = new Dictionary<string, List<string>>();


        //    public void AddDependency(string taskId, string dependentTaskId)
        //    {
        //        if (!tasks.ContainsKey(taskId) || !tasks.ContainsKey(dependentTaskId))
        //        {
        //            throw new ArgumentException();
        //        }

        //        if (HasCircularDependency(taskId, dependentTaskId))
        //        {
        //            throw new ArgumentException();
        //        }

        //        dependencies[taskId].Add(dependentTaskId);

        //        foreach (var task in dependencies)
        //        {
        //            if (task.Key.Contains(taskId))
        //            {
        //                dependencies[task.Key].Add(dependentTaskId);

        //            }
        //        }
        //    }

        //    private bool HasCircularDependency(string taskId, string dependentTaskId, HashSet<string> visited = null)
        //    {
        //        visited = visited ?? new HashSet<string>();

        //        if (visited.Contains(taskId))
        //        {
        //            return true; // Circular dependency detected
        //        }

        //        visited.Add(taskId);

        //        foreach (var dependency in dependencies[taskId])
        //        {
        //            if (HasCircularDependency(dependency, dependentTaskId, visited))
        //            {
        //                return true;
        //            }
        //        }

        //        visited.Remove(taskId);

        //        return false;
        //    }

        //    public void AddTask(Task task)
        //    {
        //        if (tasks.ContainsKey(task.Id))
        //        {
        //            throw new ArgumentException();
        //        }

        //        tasks.Add(task.Id, task);
        //        dependencies.Add(task.Id, new List<string>());
        //    }

        //    public bool Contains(string taskId)
        //    {
        //        //return allTasks.ContainsKey(taskId);
        //        return tasks.ContainsKey(taskId);
        //    }

        //    public Task Get(string taskId)
        //    {
        //        //if (!allTasks.ContainsKey(taskId))
        //        //{
        //        //    throw new ArgumentException();
        //        //}

        //        //return allTasks[taskId];

        //        if (!tasks.ContainsKey(taskId))
        //        {
        //            throw new ArgumentException();
        //        }

        //        return tasks[taskId];
        //    }

        //    public IEnumerable<Task> GetDependencies(string taskId)
        //    {
        //        if (!tasks.ContainsKey(taskId))
        //        {
        //            return new List<Task>();
        //        }

        //        var taskDependencies = dependencies[taskId]
        //            .Select(dep => tasks[dep]);

        //        return taskDependencies;

        //        //var taskDependencies = new HashSet<Task>();
        //        //GetAllDependents(taskId, taskDependencies);
        //        //return taskDependencies;
        //    }

        //    public IEnumerable<Task> GetDependents(string taskId)
        //    {
        //        if (!tasks.ContainsKey(taskId))
        //        {
        //            return new List<Task>();
        //        }

        //        //var dependents = new HashSet<Task>();
        //        //GetAllDependents(taskId, dependents);
        //        //return dependents;

        //        return dependencies
        //            .Where(kvp => kvp.Value.Contains(taskId))
        //            .Select(kvp => tasks[kvp.Key]);
        //    }

        //    private void GetAllDependents(string taskId, HashSet<Task> dependents)
        //    {
        //        foreach (var dependant in tasks[taskId].Dependencies)
        //        {
        //            dependents.Add(dependant);
        //            GetAllDependents(dependant.Id, dependents);
        //        }
        //    }

        //    public void RemoveDependency(string taskId, string dependentTaskId)
        //    {
        //        if (!tasks.ContainsKey(taskId) || !tasks.ContainsKey(dependentTaskId))
        //        {
        //            throw new ArgumentException();
        //        }

        //        dependencies[taskId].Remove(dependentTaskId);

        //    }

        //    public void RemoveTask(string taskId)
        //    {
        //        if (!tasks.ContainsKey(taskId))
        //        {
        //            throw new ArgumentException();
        //        }

        //        var task = tasks[taskId];
        //        tasks.Remove(taskId);

        //        RemoveDependencyRecursively(task);

        //        if (task.Dependant != null)
        //        {
        //            task.Dependant.Dependencies.Remove(task);
        //        }
        //        //Remove

        //        //tasks.Remove(taskId);
        //        //dependencies.Remove(taskId);

        //        //// Remove the task from dependencies of other tasks
        //        //foreach (var dependencyList in dependencies.Values)
        //        //{
        //        //    dependencyList.Remove(taskId);
        //        //}
        //    }

        //    private void RemoveDependencyRecursively(Task task)
        //    {
        //        foreach (var dependency in task.Dependencies)
        //        {
        //            RemoveDependencyRecursively(dependency);
        //            tasks.Remove(dependency.Id);
        //        }
        //    }

        //    public int Size()
        //    {
        //        //return allTasks.Count;
        //        return tasks.Count;
        //    }
        //}

        private readonly Dictionary<string, Task> tasks;
        private readonly Dictionary<string, HashSet<string>> dependencies;

        public Manager()
        {
            tasks = new Dictionary<string, Task>();
            dependencies = new Dictionary<string, HashSet<string>>();
        }

        public void AddTask(Task task)
        {
            if (tasks.ContainsKey(task.Id))
            {
                throw new ArgumentException("Task with the same ID already exists.");
            }

            tasks.Add(task.Id, task);
            dependencies.Add(task.Id, new HashSet<string>());
        }

        public void RemoveTask(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                throw new ArgumentException("Task with the specified ID does not exist.");
            }

            tasks.Remove(taskId);
            dependencies.Remove(taskId);

            // Remove the task from dependencies of other tasks
            foreach (var dependencyList in dependencies.Values)
            {
                dependencyList.Remove(taskId);
            }
        }

        public bool Contains(string taskId)
        {
            return tasks.ContainsKey(taskId);
        }

        public Task Get(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                throw new ArgumentException("Task with the specified ID does not exist.");
            }

            return tasks[taskId];
        }

        public int Size()
        {
            return tasks.Count;
        }

        public void AddDependency(string taskId, string dependentTaskId)
        {
            if (!tasks.ContainsKey(taskId) || !tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException("Either the task or its dependent task does not exist.");
            }

            if (HasCircularDependency(taskId, dependentTaskId))
            {
                throw new ArgumentException("Circular dependency detected.");
            }

            dependencies[taskId].Add(dependentTaskId);
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!tasks.ContainsKey(taskId) || !tasks.ContainsKey(dependentTaskId))
            {
                throw new ArgumentException("Either the task or its dependent task does not exist.");
            }

            dependencies[taskId].Remove(dependentTaskId);
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                return Enumerable.Empty<Task>();
            }

            return dependencies[taskId].Select(dep => tasks[dep]);
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            if (!tasks.ContainsKey(taskId))
            {
                return Enumerable.Empty<Task>();
            }

            return dependencies.Where(kvp => kvp.Value.Contains(taskId)).Select(kvp => tasks[kvp.Key]);
        }

        private bool HasCircularDependency(string taskId, string dependentTaskId, HashSet<string> visited = null)
        {
            visited = visited ?? new HashSet<string>();

            if (visited.Contains(taskId))
            {
                return true; // Circular dependency detected
            }

            visited.Add(taskId);

            foreach (var dependency in dependencies[taskId])
            {
                if (HasCircularDependency(dependency, dependentTaskId, visited))
                {
                    return true;
                }
            }

            visited.Remove(taskId);

            return false;
        }

    }
}