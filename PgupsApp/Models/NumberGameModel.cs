using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Models
{
    class NumberGameModel
    {

        private int numberOfCells;
        private int[] numbers;
        private readonly Random random = new();
        private int[] correctAnswers;
        private int correctAnswerId;

        public NumberGameModel(int numOfCells, int diff)
        {
            numberOfCells = numOfCells;
            numbers = new int[numOfCells];
            for (int i = 0; i < numOfCells; i++)
            {
                numbers[i] = i + 1;
            }

            correctAnswers = new int[numOfCells];
            switch (diff)
            {
                case 1:
                    for (int i = 0; i < numOfCells; i++)
                    {
                        correctAnswers[i] = i + 1;
                    }
                    break;
                case 2:
                    for (int i = 0; i < numOfCells; i++)
                    {
                        correctAnswers[i] = numOfCells - i;
                    }
                    break;
                case 3:
                    for (int i = 0; i < numOfCells; i++)
                    {
                        
                        if (i==0 || i%2 == 0)
                        {
                            correctAnswers[i] = i/2 + 1;
                        } 
                        else if (i % 2 == 1)
                        {
                            correctAnswers[i] = numOfCells - (i-1)/2;
                        }
                    }
                    break;
                default:
                    break;
            }
            
        }

        public int[] GetNumbers()
        {
            return numbers;
        }
        public void RefreshNumbers()
        {
            int[] tempNumbers = new int[numberOfCells];
            for (int i = 0; i < numberOfCells; i++)
            {
                int rand = random.Next(0, numberOfCells);
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
        }

        public bool CheckAnswer(string number)
        {

            if (number == correctAnswers[correctAnswerId].ToString())
            {
                if (number == correctAnswers[numberOfCells - 1].ToString())
                {
                    return true;
                }
                RefreshNumbers();
                correctAnswerId++;
            }
            return false;
            

        }
    }

    
}
