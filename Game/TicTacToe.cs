using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Game
{

    class TicTacToe
    {
        public List<dynamic> Board = new List<dynamic> { };
        List<Player> Players = new List<Player> { };
        private bool _GameOver;
        private int _CurrentlyActivePlayer;

        public TicTacToe()
        {
            this.GeneratePlayers();

            this.intBoard();

            this._CurrentlyActivePlayer = 0;
       
            this._GameOver = false;

           
            

            this._Run();
        }

        private void _Run()
        {
            while (this._GameOver == false)
            {
                this.PlayOneRound();
            }
        }

        private void GeneratePlayers()
        {
            string playerName = "";
            

            Console.Write("Enter a name for player 1: ");
            playerName = Console.ReadLine();

            this.Players.Add(new Player("x", playerName));
            
            Console.Write("Enter a name for player 2: ");
            playerName = Console.ReadLine();
            this.Players.Add(new Player("o", playerName));
        }


        public bool PlayOneRound()
        {

            displayBoard();
            

            Console.WriteLine(this.Players[this._CurrentlyActivePlayer].Name);
            Console.Write("Please enter a Number on the board: ");
            int.TryParse(Console.ReadLine(), out int row);
            Console.Clear();


            while (!judge(row))
            {
                Console.WriteLine("Try again you entered not a valid cordinate");
                Console.Write(this.Players[this._CurrentlyActivePlayer].Name + " Please enter a new Row value: ");
                int.TryParse(Console.ReadLine(), out row);
                
            }

            Board[row] = this.Players[this._CurrentlyActivePlayer].Sign;




            if (win())
                   {
                Console.WriteLine("congratulations " + this.Players[this._CurrentlyActivePlayer].Name + ". you win");
                Console.WriteLine("do you want to play another round? [y]es [N]o");
                var hej = Console.ReadKey().KeyChar;
                switch (hej)
                {
                    case 'y':
                        {
                            this._GameOver = false;
                            intBoard();
                            break;
                            

                        }
                    case 'n':
                        {
                            this._GameOver = true;
                            intBoard();
                            break;
                        }
                }
            }
              if (draw())
              {
                Console.WriteLine("it's a draw!");
                Console.WriteLine("do you want to play another round? [y]es [N]o");
                var hej = Console.ReadKey().KeyChar;
                switch (hej)
                {
                    case 'y':
                        {
                            this._GameOver = false;
                            break;
                        }
                    case 'n':
                        {
                            this._GameOver = true;
                            break;
                        }
                }
                
              }
            Console.Clear();
            this._ChangeActivePlayer();

            return false;
        }
        private bool judge(int row) // kordinaterne værdierne 1 2 3
        {
            
            if (row > 8 || row < 0)
            {
                return false;
            }
            
            return true;

        }

        private void _ChangeActivePlayer()
        {
            if(this._CurrentlyActivePlayer == 0)
            {
                this._CurrentlyActivePlayer = 1;
            } else
            {
                this._CurrentlyActivePlayer = 0;
            }
        }



        public void intBoard() //sætter værdierne i mit array til at være 0
        
        {   

            for(int i = 0; i < 9; i++)
            {
                this.Board.Add(i.ToString());
            }
           
        }

        private void displayBoard() // min metode der slaæ vise spillepladen
        {


            for (int row = 1; row < 10; row++)
            {

                

                Console.Write(" " + this.Board[row -1] +" |");

                if(row % 3 == 0 && row > 2)
                {
                    Console.WriteLine();
                }
            }
        }

        private bool draw() //kriterier for at være uafgjort
        {

            var b = this.Board.Find(x => x != "o" || x != "x");

            if(b != null)
            {
                return false;
            }

            return true;
            
        }

        private bool win() //kriterier for at vinde
        {
            if (this.Board[0] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[1] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[2] == this.Players[this._CurrentlyActivePlayer].Sign)
            {
                return true;
            }
            else if (this.Board[3] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[4] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[5] == this.Players[this._CurrentlyActivePlayer].Sign)

            {
                return true;
            }
            else if (this.Board[6] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[7] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[8] == this.Players[this._CurrentlyActivePlayer].Sign)

            {
                return true;
            }
            else if (this.Board[0] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[3] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[6] == this.Players[this._CurrentlyActivePlayer].Sign)

            {
                return true;
            }
            else if (this.Board[1] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[4] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[7] == this.Players[this._CurrentlyActivePlayer].Sign)

            {
                return true;
            }
            else if (this.Board[2] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[5] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[8] == this.Players[this._CurrentlyActivePlayer].Sign)

            {
                return true;
            }
            else if (this.Board[0] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[4] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[8] == this.Players[this._CurrentlyActivePlayer].Sign)

            {
                return true;
            }
            else if (this.Board[2] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[4] == this.Players[this._CurrentlyActivePlayer].Sign && this.Board[6] == this.Players[this._CurrentlyActivePlayer].Sign)

            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}