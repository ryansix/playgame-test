using System;
using System.Collections.Generic;
using System.Linq;
namespace playgameNetcore
{
    public class ContainerContextOptions
    {
        public ContainerContextOptions()
        { 
        }
        public int Count => rows.Sum(u => u);

        public int Size => rows.Count;
        private List<int> rows { get; set; }=new List<int>();
        /// <summary>
        /// 初始数量
        /// </summary>
        public int initLength { get; private set; }
        public void JoinCount(int count)
        {
            this.rows.Add(count);
            this.initLength += count;
        }
        public void TakeCount(int idx , int count)
        {
            this.rows[idx] -= count;
        }
        public int GetCount(int rowIndex)
        {
            return this.rows[rowIndex];
        }
        public void Draw()
        {
            var idx = 1;
            this.rows.ForEach(u => {
                if (u == 0) { idx++; return; }
                Console.WriteLine(idx + ". " + "".PadLeft(u, '*'));
                idx++;
            });
        }
    }

    public class ContainerContext
    {
        private Player[] players = new Player[2];
        private readonly Judge _judge = new Judge();
        public ContainerContextOptions Options { get; private set; }
        public ContainerContext(ContainerContextOptions options)
        {
            Options = options;
            _judge.gameIsOver += new EventHandler(this.Over);
        }

        public void InitPlayers(Player player1,Player player2)
        {
            players[0] = player1;
            players[1] = player2;
        }
        private bool isOverGame = false;
        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="action"></param>

        public void Start(Func<Player,int[]> waitInputFunc)
        { 
            this.ReDraw();
            var stepIndex = 0;
            while (!isOverGame)
            {
                var player = players[stepIndex % 2];
                var inputArr = waitInputFunc(player); 
                player.Run(inputArr[0], inputArr[1],(idx,count)=> {
                    if (idx >= this.Options.Size) {
                        ConsoleHelper.WriteErrorTextLine($"当前不存在行:{idx}!");
                        this.ReDraw();
                        return false;
                    }
                    if (count == 0 || count > this.Options.GetCount(idx))
                    {
                        ConsoleHelper.WriteErrorTextLine($"第{idx}行拿走数量不允许为0或大于剩余数量");
                        this.ReDraw();
                        return false;
                    }
                    this.Options.TakeCount(idx, count);
                    this.ReDraw();
                    this._judge.Trial(this,player);
                    return true;
                },()=> {
                    stepIndex--;
                });
                stepIndex++;
            }
        }
        
        public void Over(object sender,EventArgs args)
        {
            this.isOverGame = true;
        }
        public void ReDraw()
        { 
            this.Options.Draw();
        }
    }
}
