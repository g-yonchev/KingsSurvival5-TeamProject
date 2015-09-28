namespace King.Commons
{
    using System;

    public static class MessageConstants
    {
        internal const string FinishGameMessage = "Game is finished!";
        internal const string InvalidCommandMessage = "Invalid command name!";
        internal const string ErrorMessage = "Sorry, there are some errors, but I can't tell you anything! You broked my program!";
        internal const string KingTurnMessage = "Please enter king's turn: ";
        internal const string EmptyStringMessage = "Empty command!";
        internal const string PawnTurnMessage = "Please enter pawn's turn: ";
        internal const string KingVictoryMessage = "King wins in {0} moves!";
        internal const string WrongDirectionMessage = "You can't go in this direction! ";
        internal const string KingLostMessage = "King loses in {0} moves!";
        internal const string GoodbyeMessage = "\nThank you for playing!\n\n";
    }
}
