using System;
using System.IO;

namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);
            questions = ShuffleQuestions(questions);

            int numberCorrect = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
            }
            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
        }
        public static Question[] ShuffleQuestions(Question[] questions)
        {
            Random random = new Random();
            for (int i = questions.Length - 1; i > 0; i--)
            {
                int index = random.Next(i + 1);
                Question temp = questions[index];
                questions[index] = questions[i];
                questions[i] = temp;

            }
            return questions;
        }
        public static string GetPercentCorrect(decimal numberCorrectAnswers, decimal numberOfQuestions)
        {
            return Math.Round(((numberCorrectAnswers / numberOfQuestions) * 100), 0) + "%";
        }

        public static bool AskQuestion(Question question)
        {
            DisplayQuestion(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];

                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                questions[i] = new Question();
                questions[i].Text = questionText;
                questions[i].Answers = new string[3];
                questions[i].Answers[0] = answer1;
                questions[i].Answers[1] = answer2;
                questions[i].Answers[2] = answer3;
                questions[i].CorrectAnswerIndex = correctAnswerIndex;
            }
            return questions;
        }
    }
}
