using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> scheduleOfLessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] command = input.Split(':');
                string lessonTitle = command[1];
                string exercise = string.Empty;

                if (command[0] == "Add")
                {
                    if (scheduleOfLessons.Contains(lessonTitle))
                    {
                        continue;
                    }
                    scheduleOfLessons.Add(lessonTitle);
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    if (scheduleOfLessons.Contains(lessonTitle))
                    {
                        continue;
                    }
                    scheduleOfLessons.Insert(index, lessonTitle);
                }
                else if (command[0] == "Remove")
                {
                    if (scheduleOfLessons.Contains(lessonTitle))
                    {
                        scheduleOfLessons.Remove(lessonTitle);
                        exercise = lessonTitle + "-Exercise";
                        if (scheduleOfLessons.Contains(exercise))
                        {
                            scheduleOfLessons.Remove(exercise);
                        }
                    }
                }
                else if (command[0] == "Swap")
                {
                    if (scheduleOfLessons.Contains(lessonTitle))
                    {
                        string secondLessonTitle = command[2];

                        if (scheduleOfLessons.Contains(secondLessonTitle))
                        {
                            int firstLessonIndex = scheduleOfLessons.IndexOf(lessonTitle);
                            string firstExercise = lessonTitle + "-Exercise";
                            int secondLessonIndex = scheduleOfLessons.IndexOf(secondLessonTitle);
                            string secondExercise = secondLessonTitle + "-Exercise";
                            string temp = scheduleOfLessons[firstLessonIndex];
                            //  Arrays, Arrays-Exercise, Lists, Methods
                            //  Swap:Arrays:Methods
                            //  course start
                              scheduleOfLessons[firstLessonIndex] = scheduleOfLessons[secondLessonIndex];
                            scheduleOfLessons[secondLessonIndex] = temp;

                            if (scheduleOfLessons.Contains(firstExercise))
                            {
                                scheduleOfLessons.Remove(firstExercise);
                                scheduleOfLessons.Insert(secondLessonIndex, firstExercise);
                            }
                            if (scheduleOfLessons.Contains(secondExercise))
                            {
                                scheduleOfLessons.Remove(secondExercise);
                                scheduleOfLessons.Insert(firstLessonIndex + 1, secondExercise);
                            }

                        }
                    }
                }
                else if (command[0] == "Exercise")
                {
                    int indexOfLesson = scheduleOfLessons.IndexOf(lessonTitle);
                    exercise = lessonTitle + "-Exercise";

                    if (scheduleOfLessons.Contains(exercise))
                    {
                        continue;
                    }
                    if (indexOfLesson < 0)
                    {
                        scheduleOfLessons.Add(lessonTitle);
                        scheduleOfLessons.Add(exercise);
                    }
                    else
                    {
                        scheduleOfLessons.Insert(indexOfLesson + 1, exercise);
                    }
                }

            }

            for (int i = 0; i < scheduleOfLessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{scheduleOfLessons[i]}");
            }
        }
    }
}
