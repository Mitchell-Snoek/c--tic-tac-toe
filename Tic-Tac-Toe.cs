using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static char player1 = ' ';
        static char player2 = ' ';
        static int score1 = 0;
        static int score2 = 0;
        public static void Choose()
        {
            Console.WriteLine("Player 1 choose X or O:  ");
            var choice = Console.ReadLine();
            if (choice == "X" || choice == "x")
            {
                player1 = 'X';
                player2 = 'O';
            }
            else if (choice == "o" || choice == "O")
            {
                player1 = 'O';
                player2 = 'X';
            }
            var Start = new Start();
            Start.Secondary();
        }

        static void Won(int check)
        {
            bool finish = false;
            if (check == -1)
            {
                Console.WriteLine("no winner");
                finish = true;
            }
            else if (check == 0)
            {
                var Start = new Start();
                Start.Secondary();
            }
            else if (check == 1)
            {
                if (player % 2 == 0)
                {
                    Board();
                    score1++;
                    Console.WriteLine("player 1 aka {0} won", player1);
                    Console.WriteLine("score:");
                    Console.WriteLine("player1: {0}", score1);
                    Console.WriteLine("player2: {0}", score2);
                    finish = true;
                }
                else if (player % 2 == 1)
                {
                    Board();
                    score2++;
                    Console.WriteLine("player 2 aka {0} won", player2);
                    Console.WriteLine("score:");
                    Console.WriteLine("player1: {0}", score1);
                    Console.WriteLine("player2: {0}", score2);
                    finish = true;
                }
            }
            if (finish == true)
            {
                Console.WriteLine("Do you want to play again?");
                Console.WriteLine("press y for yes or n for no");
                var again = Console.ReadLine();
                if (again == "y" || again == "Y")
                {
                    arr[1] = '1'; arr[2] = '2'; arr[3] = '3'; arr[4] = '4'; arr[5] = '5'; arr[6] = '6'; arr[7] = '7'; arr[8] = '8'; arr[9] = '9';
                    player = 1;
                    var Start = new Start();
                    Start.Replay();
                }
                else if (again == "n" || again == "N")
                {
                    return;
                }
            }
        }

        public static void Play()
        {
            Console.WriteLine("Type any number:  "); 
            int x = Int32.Parse(Console.ReadLine());
            if (x < 1 || x > 9)
            {
                Console.WriteLine("number not availible");
                Play();
            }
            else if (arr[x] == 'X' || arr[x] == 'O')
            {
                Console.WriteLine("box already checked");
                Play();
            }
            else if (player % 2 == 1)
            {
                arr[x] = player1;
                player++;
            }
            else if (player % 2 == 0)
            {
                arr[x] = player2;
                player++;   
            }
            CheckWin();            
        }

        public static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        public static void CheckWin()
        {
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                Won(1);
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                Won(1);
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                Won(1);
            }
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                Won(1);
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                Won(1);
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                Won(1);
            }
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                Won(1);
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                Won(1);
            }
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                Won(-1);
            }
            else
            {
                Won(0);
            }
        }
    }

    class Start
    {
        static void Main()
        {
            var Program = new Program();
            Program.Choose();
        }
        public void Replay()
        {
            var Program = new Program();
            Program.Choose();
        }
        public void Secondary()
        {
            var Program = new Program();
            Program.Board();
            Program.Play();
        }
    }
}