using System;
using System.Linq;
namespace playgameNetcore
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ContainerContextOptions();
            options.JoinCount(3);
            options.JoinCount(5);
            options.JoinCount(7);
            var context = new ContainerContext(options);
            var player1 = new Player("玩家1");
            var player2 = new Player("玩家2");
            context.InitPlayers(player1, player2);
            Func<Player,string, int[]> inputToConvert = (player,str) =>
             {
                 var success = false;
                 var arrInt = new int[2];
                 while (!success || string.IsNullOrEmpty(str))
                 {
                     Console.Write(">>请输入行号和数量，用逗号分开，如 ");
                     ConsoleHelper.WriteText("2,3", ConsoleTextType.Debug);
                     Console.WriteLine("：代表从2行中拿走3个");
                     ConsoleHelper.WriteText($">>{player.Name}", ConsoleTextType.Debug);
                     Console.Write("请输入:");
                     str = Console.ReadLine();
                     arrInt = UtlHelper.EatConvertToIntArr(str);
                     success = arrInt != null && arrInt.Length > 1 ? true : false;
                 }
                 return arrInt;
             };
            context.Start(player =>
            {
                var arrInt = inputToConvert(player,string.Empty);
                return arrInt.ToArray();
            });
            //Console.WriteLine("Hello World!");
        }
    }
}
