using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;

namespace WebApplication.App_Code
{
    public class Chat : Hub
    {
        private static readonly ConcurrentDictionary<string, char[,]> gameFields = new ConcurrentDictionary<string, char[,]>();
        private static readonly char[] symbols = {'~', '!', '@', '#', '$', '%', '^', '&', '*', '+', '>', ';'};
        public void Send(int row, int col)
        {
            char[,] field;
           gameFields.TryGetValue(Context.ConnectionId, out field);

            if (field[row, col] == ' ')
            {
                Clients.Caller.gameOver();
            }
          
            else
            {
                Clients.Caller.openBlock(row, col, field[row, col]);
            }
        }

        public void GenerateField(int rows, int cols)
        {
            var elemntsInTheField = (rows * cols);
            if (elemntsInTheField % 2 == 0)
            {
                throw new ArgumentException();
            }
            var elementsToTake = elemntsInTheField / 2;
            var fieldElements = symbols.Take(elementsToTake).ToList();
            //double the elemnts
            fieldElements.AddRange(symbols.Take(elementsToTake));
            //add bomb
            fieldElements.Add(' ');
            var fieldShuffled = fieldElements.OrderBy(elem => Guid.NewGuid());
            var field = new char[rows, cols];
            int currentRow = 0;
            int currentCol = 0;
            int bombRow = 0;
            int bombCol = 0;
            foreach (var item in fieldShuffled)
	        {
                if (item == ' ')
                {
                    bombRow = currentRow;
                    bombCol = currentCol;
                }
		        field[currentRow, currentCol] = item;
                currentCol++;
                if (currentCol == cols )
	            {
		            currentCol =0;
                    currentRow ++;
	            }
	        }
            gameFields.TryAdd(Context.ConnectionId, field);

            Clients.Caller.showBomb(bombRow, bombCol);
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            char[,] field;
            gameFields.TryRemove(Context.ConnectionId, out field);
            return base.OnDisconnected();
        }
    }
}