﻿namespace KingSurvival.GameLogic.Commons
{
    using System;
    using System.Text.RegularExpressions;

    public class Validator
    {
        public static bool IsValidPawnMove(string input)
        {
            string validInput = input.ToUpper();
            var regex = new Regex(GameConstants.RegexPawnPattern);

            if (regex.IsMatch(validInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidKingMove(string input)
        {
            string validInput = input.ToUpper();
            var regex = new Regex(GameConstants.RegexKingPattern);

            if (regex.IsMatch(validInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CheckIfObjectIsNull(object obj, string errorMessage = MessageConstants.EmptyString)
        {
            if (obj == null)
            {
                throw new NullReferenceException(MessageConstants.NullFigureErrorMessage);
            }
        }

        public static bool IsValidCommand(string command)
        {
            return true;
        }

        internal static bool CanMove()
        {
            return true;
        }
    }
}