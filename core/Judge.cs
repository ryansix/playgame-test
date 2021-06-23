using System;
namespace playgameNetcore
{
    /// <summary>
    /// 游戏评判者
    /// </summary>
    public class Judge
    {
        public Judge()
        {

        }
        public EventHandler gameIsOver;

        //审判输赢 
        //1. 如果没输，则继续游戏，轮到下一个玩家
        //2. 如果输了，则游戏结束
        public void Trial(ContainerContext context, Player player)
        {
            if (context.Options.Count == 0)
            {
                ConsoleHelper.WriteText($">>{player.Name}", ConsoleTextType.Debug);
                Console.WriteLine($"输了,游戏结束");
                gameIsOver(this, null);
            } 
            else
            {
                Console.WriteLine($"");
            }
        }
    }
}
