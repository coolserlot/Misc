using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

class Program {
  public static void Main (string[] args) {
    Console.CursorVisible = false;
    Console.WriteLine("_____________________________________________");
    for (int i = 0; i < 15; i++) {
    Console.WriteLine ("|                                           |");
      }
    Console.WriteLine("---------------------------------------------");
    int[,] spaces = new int[43,15];
    Random rnd = new Random();
    int snakeHeadX = 22;
    int snakeHeadY = 8;
    bool gameOver = false;
    string facing = "right";
    bool moveCooldown = false;
    bool apple = false;
    int score = 0;
    int appleX = rnd.Next(1,45);
    int appleY = rnd.Next(1,16);
    var snaketailX = new ArrayList();
    var snaketailY = new ArrayList();
    bool canTurn = true;
    snaketailX.Add(0);
    snaketailY.Add(0);

    Console.SetCursorPosition(snakeHeadX,snakeHeadY);
    Console.Write("\b*");
    Console.ReadKey();
    Task.Run(() =>
      {
        while (!gameOver) {
          ConsoleKeyInfo turn = Console.ReadKey();
          if (turn.Key == ConsoleKey.UpArrow && facing != "down" && canTurn) {
            facing = "up";
            canTurn = false;
          }
          else if (turn.Key == ConsoleKey.DownArrow && facing != "up" && canTurn) {
            facing = "down";
            canTurn = false;
          }
          else if (turn.Key == ConsoleKey.LeftArrow && facing != "right" && canTurn) {
            facing = "left";
            canTurn = false;
          }
          else if (turn.Key == ConsoleKey.RightArrow && facing != "left" && canTurn) {
            facing = "right";
            canTurn = false;
          }
        }
      });

    Task.Run (() =>
      {
        while(!gameOver) {
          if (snakeHeadX == 1 || snakeHeadX == 45 || snakeHeadY == 0 || snakeHeadY == 16) {
            gameOver= true;
          }
        }
      });
    Task.Run (() =>
      {
      while(!gameOver) {
        if (moveCooldown) {
          if(facing == "up" || facing == "down") {
            System.Threading.Thread.Sleep(150);
          }
          else {
        System.Threading.Thread.Sleep(100);
            }
          moveCooldown = false;
        }
      }
      });
    
    while (!gameOver) {
      if (!moveCooldown) {
        for (int i = 0; i < score; i++) {
          Console.SetCursorPosition((int)snaketailX[i],(int)snaketailY[i]);
          Console.Write("\b ");
        }
        Console.SetCursorPosition(snakeHeadX, snakeHeadY);
        if(score == 2) {
          snaketailX[1] = snaketailX[0];
          snaketailY[1] = snaketailY[0];
        }
        
        for(int i = score-1; i > 0; i--) {
          
            snaketailX[i] = snaketailX[i-1];
            snaketailY[i] = snaketailY[i-1];
          
          
        }
        snaketailX[0] = snakeHeadX;
        snaketailY[0] = snakeHeadY;
     if (facing == "right") {
       Console.Write("\b ");
       snakeHeadX++;
     }
      else if (facing == "left") {
        Console.Write("\b ");
        snakeHeadX--;
      }
      else if (facing == "up") {
        Console.Write("\b ");
        snakeHeadY--;
      }
      else if (facing == "down") {
        Console.Write("\b ");
        snakeHeadY++;
      }
       canTurn = true;
        Console.SetCursorPosition(snakeHeadX,snakeHeadY);
        Console.Write("\b*");
        for (int i = 0; i < score; i++) {
          Console.SetCursorPosition((int)snaketailX[i], (int)snaketailY[i]);
          Console.Write("\b*");
        }
        moveCooldown = true;
        for(int i = 0; i < score; i++) {
          if((int)snakeHeadX == (int)snaketailX[i] && snakeHeadY == (int)snaketailY[i]) {
            gameOver = true;
          }
        }
        }
      
        
        
     if (!apple) {
       appleX = rnd.Next(3,44);
       appleY = rnd.Next(3,15);
       for (int i = 0; i < score; i++) {
         if ((int)snaketailX[i] == appleX && (int)snaketailY[i] == appleY) {
           appleX = rnd.Next(3,44);
          appleY = rnd.Next(3,15);
           i = 0;
         }
       }
       Console.SetCursorPosition(appleX,appleY);
       Console.Write("\bo");
       apple = true;
     }
      if (snakeHeadX == appleX && snakeHeadY == appleY) {
        Console.SetCursorPosition(appleX, appleY); 
        Console.Write("\b ");
        apple = false;
        score++;
        snaketailX.Add(1);
        snaketailY.Add(1);
        snaketailX[score-1] = snakeHeadX;
        snaketailY[score-1] = snakeHeadY;
      Console.SetCursorPosition(22,18);
      Console.Write(score);
      }
  }
    Console.SetCursorPosition(18,17);
    Console.Write("Game Over");
  }
}