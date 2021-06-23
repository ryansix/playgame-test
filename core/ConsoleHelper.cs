using System;
namespace playgameNetcore
{
    public static class ConsoleHelper
    {
        public static void WriteText(string context, ConsoleTextType type)
        {
            var originColor = Console.ForegroundColor;

            switch (type)
            {
                case ConsoleTextType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case ConsoleTextType.Info:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case ConsoleTextType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ConsoleTextType.Debug:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    break;
            }
            Console.Write(context);
            Console.ForegroundColor = originColor;
        }

        public static void WriteErrorText(string text)
        {
            WriteText(text, ConsoleTextType.Error);
        }
        public static void WriteErrorTextLine(string text)
        {
            WriteText(text, ConsoleTextType.Error);
            Console.WriteLine();
        }

        public static void WriteSuccessText(string text)
        {
            WriteText(text, ConsoleTextType.Success);
        }
        public static void WriteSuccessTextLine(string text)
        {
            WriteText(text, ConsoleTextType.Success);
            Console.WriteLine();
        }

    }

    public enum ConsoleTextType
    {
        Error,
        Info,
        Debug,
        Success
    }
}
