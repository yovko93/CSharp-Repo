using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quiz.Data;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureService(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var json = File.ReadAllText("EF-Core-Quiz.json");
            var questions = JsonConvert.DeserializeObject<IEnumerable<JsonQuestion>>(json);

            var quizService = serviceProvider.GetService<IQuizService>();
            var questionService = serviceProvider.GetService<IQuestionService>();
            var answerService = serviceProvider.GetService<IAnswerService>();

            var quizId = quizService.Add("EF Core Test");
            foreach (var question in questions)
            {
                var questionId = questionService.Add(question.Question, quizId);
                foreach (var answer in question.Answers)
                {
                    answerService.Add(answer.Answer, answer.Correct ? 1 : 0, answer.Correct, questionId);
                }
            }

            //var questionService = serviceProvider.GetService<IQuestionService>();
            //questionService.Add("1+1", 1);

            //var answerService = serviceProvider.GetService<IAnswerService>();
            //answerService.Add("2", 5, true, 2);

            //var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            //userAnswerService.AddUserAnswer("da3f1a5b-af38-4b5c-9ba6-8f268869cf60", 1, 2, 1);

            //var quizService = serviceProvider.GetService<IUserAnswerService>();
            //var quiz = quizService.GetUserResult("da3f1a5b-af38-4b5c-9ba6-8f268869cf60", 1);

            //Console.WriteLine(quiz);
        }

        private static void ConfigureService(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options
                => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
        }
    }
}
