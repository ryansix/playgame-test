using System;
namespace playgameNetcore
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        public void Run(int rowIdx, int takeCount, Func<int, int, bool> takeFun,Action fail)
        {
            var takeResult = takeFun(rowIdx, takeCount);
            if (!takeResult)
                fail();
            ConsoleHelper.WriteText(">>"+this.Name, ConsoleTextType.Debug);
            Console.Write($" 从第{(rowIdx+1)}中取走{takeCount}个");
            if (takeResult)
            {
                ConsoleHelper.WriteSuccessTextLine("成功");
            }
            else
            {
                ConsoleHelper.WriteErrorTextLine("失败");
            }
        }
    } 
}
