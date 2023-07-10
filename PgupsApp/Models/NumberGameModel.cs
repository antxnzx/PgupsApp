using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Models
{
    class NumberGameModel
    {

        public int numberOfCells { get; set; }
        public int[] numbers { get; set; }
        Random random = new Random();
        public int CorrectAnswer { get; set; }

        public NumberGameModel(int numOfCells)
        {
            numberOfCells = numOfCells;
            CorrectAnswer = 1;
            numbers = new int[numOfCells];
            for (int i = 0; i < numOfCells; i++)
            {
                numbers[i] = i + 1;
            }
        }

        public int[] RefreshNumbers()
        {
            int[] tempNumbers = new int[numberOfCells];
            for (int i = 0; i < numberOfCells; i++)
            {
                int rand = random.Next(0, 16);
                int tempNumber = numbers[rand];
                if (tempNumber == 0)
                {
                    i--;
                    continue;
                }
                tempNumbers[i] = tempNumber;
                numbers[rand] = 0;
            }
            numbers = tempNumbers;
            return numbers;
        }

        public void CheckAnswer(string number)
        {
            if (number == CorrectAnswer.ToString())
            {
                RefreshNumbers();
                CorrectAnswer++;
            }
            if (number == numberOfCells.ToString())
            {
                for (int i = 0; i < numberOfCells; i++)
                {
                    numbers[i] = 0;
                }
            }

        }
    }

    
}
