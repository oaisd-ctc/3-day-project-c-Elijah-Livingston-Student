using System;
public class Program
{
    public static string difficulty;
    
    public static Random rand = new Random();

    public static int mowerType;
    public static int mowerX = 10;
    public static int mowerY;
    public static int groundY;
    public static int jumpHeight;
    public static bool isJumping = false;
    public static int jumpCounter;

    public static int lives;
    public static int money;
    public static int moneyCount;
    public static bool iFrames = false;
    public static int iFrameCount = 0;

    public static int obstacleX;
    public static int obstacle;
    public static int powerUpX;
    public static int powerUp;
    public static int randomY = 0;
    public static bool end = false;
    public static void Main(string[] args)
    {
        while (!end)
        {
            Introduction();
        }
    }
    public static void Introduction()
    {
    if (end)
        {
            return;
        }

    StartOfGame:
        Console.Clear();
        Console.WriteLine("Welcome to Lawn Mowing Simulator 1: The Game!");
        Console.WriteLine("This game you will upgrade your mower, collect powerups, and run over obstacles!");
        Console.WriteLine("Would you like to begin, see credits or leave.");
        Console.WriteLine("(b/c/l)");
        string startChoice = Console.ReadLine();
        if (startChoice == "b")
        {
        difficulty:
        Console.WriteLine("There are 3 difficulties! Easy, Hard, Impossible.");
        Console.WriteLine("(e/h/i)");
        difficulty = Console.ReadLine();
        if (difficulty != "e" && difficulty != "h" && difficulty != "i")//if input is invalid
        {
            Console.SetCursorPosition(0,3);
            for (int i = difficulty.Length; i > 0; i--)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0,2);
            goto difficulty;
        }
        Menu();

        }
        else if (startChoice == "c")
        {
            Console.WriteLine("David:");
            Thread.Sleep(100);
            Console.WriteLine("Shop");
            Thread.Sleep(100);
            Console.WriteLine("Heath:");
            Thread.Sleep(100);
            Console.WriteLine("Art, Movement");
            Thread.Sleep(100);
            Console.WriteLine("Al:");
            Thread.Sleep(100);
            Console.WriteLine("Powerup functions");
            Thread.Sleep(100);
            Console.WriteLine("Elijah:");
            Thread.Sleep(100);
            Console.WriteLine("Intro");
            Console.Write("Press any key to continue");
            Console.ReadKey();
            goto StartOfGame;

        }
        else if (startChoice == "l")
        {
            Console.WriteLine("Bye!");
            end = true;
        }
        else
        {
            goto StartOfGame;
        }
    }

    public static void Menu()
    {
    menu:
    if (end)
        {
            Introduction();
        }
        Console.CursorVisible = true;
        Console.WriteLine("Hello!");
        Console.WriteLine("Would you like to go to the shop, credits, mowing, or exit");
        Console.WriteLine("(s/c/m/e)");
        string menuOption = Console.ReadLine();
        if (menuOption == "e")
        {
            Console.WriteLine("Thanks for playing!");
            end = true;
            Introduction();
        }
        if (menuOption == "s")
        {
            ShopRunner();
        }
        else if (menuOption == "c")
        {
            Console.WriteLine("David:");
            Thread.Sleep(100);
            Console.WriteLine("Shop Keeper, Project Manager");
            Thread.Sleep(100);
            Console.WriteLine("Heath:");
            Thread.Sleep(100);
            Console.WriteLine("Art, Gameplay");
            Thread.Sleep(100);
            Console.WriteLine("Al:");
            Thread.Sleep(100);
            Console.WriteLine("Powerup functions");
            Thread.Sleep(100);
            Console.WriteLine("Elijah:");
            Thread.Sleep(100);
            Console.WriteLine("Intro, other Menus");
            Thread.Sleep(2000);
            goto menu;
        }
        else if (menuOption == "m")
        {
            if (mowerType != 1 && mowerType != 2 && mowerType != 3)
            {
                Console.WriteLine("You have to buy a mower first!!!");
                Thread.Sleep(1000);
                goto menu;
            }
            Game();
        }
        else if (menuOption != "m" && menuOption != "c" && menuOption != "s" && menuOption != "e")
        {
            Menu();
        }


    }
    public static void End()
    {
        Console.WriteLine("You won! You have $" + money + "Yay!");
        Console.WriteLine("Come back and mow another time!");
        end = true;
    }
    // Global game state variables

    public static void Game()
    {
        if (difficulty == "e")
        {
            lives = 10;
        }
        if (difficulty == "h")
        {
            lives = 5;
        }
        if (difficulty == "i")
        {
            lives = 2;
        }
        int doubleScoreFrames = 0;
        bool invincible = false;
        bool extraLife = false;
        bool doubleScore = false;
        bool iFrames = false; // invincibility frames after getting damaged
        int iFrameCount = 0; // amount of time player should be invincible after damaged
        int moneyCount = 0;
        Console.Clear();

        groundY = Console.WindowHeight - 3;
        mowerY = groundY;
        if (difficulty == "e")
        {
            lives = 10;
        }
        if (difficulty == "h")
        {
            lives = 5;
        }
        if (difficulty == "i")
        {
            lives = 2;
        }
        if (mowerType == 2)
        {
            lives+=3;
        }
        if (mowerType == 3)
        {
            lives+=6;
        }

        if (mowerType == 1)
        {
            mowerX = Math.Max(mowerX, 6);
        }
        if (mowerType == 2)
        {
            mowerX = Math.Max(mowerX, 15);
        }
        if (mowerType == 3)
        {
            mowerX = Math.Max(mowerX, 14);
        } 

        if (mowerType == 1)//all 3 of these determine jump height based on vehicle
        {
            jumpHeight = 5;
        }
        if (mowerType == 2)
        {
            jumpHeight = 6;
        }
        if (mowerType == 3)
        {
            jumpHeight = 7;
        }
        Console.CursorVisible = false;
        int obstacleX = Console.WindowWidth - 100;
        int powerUpX = Console.WindowWidth - 100;

        while (true)
        {
            if (money >= 6967)
            {
                End();
                return;
            }
            // invincibility frames
            if (iFrameCount == 0)
            {
                iFrames = false;
            }
            if (iFrameCount > 0)
            {
                iFrameCount--;
            }

            // Input
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Spacebar && !isJumping && mowerY == groundY)
                {
                    isJumping = true;
                    jumpCounter = jumpHeight;
                }
            }

            // Jump
            if (isJumping)
            {
                mowerY--;
                jumpCounter--;
                if (jumpCounter <= 0)
                {
                    isJumping = false;
                }
            }
            else if (mowerY < groundY)
            {
                mowerY++; // Gravity
            }

            // Move obstacle
            if (mowerType == 1)
            {
                obstacleX--;
                powerUpX--;
            }
            if (mowerType == 2)
            {
                obstacleX -= 2;
                powerUpX -= 2;
            }
            if (mowerType == 3)
            {
                obstacleX -= 3;
                powerUpX -= 3;
            }

            if (obstacleX <= 0)
            {
                obstacleX = Console.WindowWidth - 100;
                obstacle = rand.Next(1, 4);
                if (obstacle == 2)
                {
                    obstacle = rand.Next(1,3); //reduce bush frequency
                }
                if (obstacle == 3)
                {
                    obstacle = rand.Next(1, 4); // reduce cow frequency
                }
            }
            if (powerUpX <= 0)
            {
                powerUpX = Console.WindowWidth - 100;
                powerUp = rand.Next(1,30);
            }
            int obstacleWidth = 1;
            if (obstacle == 1) 
            {
                obstacleWidth = 2;
            }
            if (obstacle == 2) 
            {
                obstacleWidth = 5;
            }
            if (obstacle == 3)
            {
                obstacleWidth = 13;
            }
            int powerUpWidth = 1;
            if (powerUp == 3 || powerUp == 12 || powerUp == 19)
            {
                powerUpWidth = 2;
            }
            if (powerUp != 3 && powerUp != 12 && powerUp != 19)
            {
                powerUpWidth = 0;
            }

            int mowerLeftOffset = 0;
            int mowerWidth = 1;
            if (mowerType == 1)
             {
                 mowerLeftOffset = 3; 
                 mowerWidth = 4; 
                 }
            if (mowerType == 2) 
            {
                 mowerLeftOffset = 11;
                  mowerWidth = 12;
                   }
            if (mowerType == 3) 
            {
                 mowerLeftOffset = 10;
                  mowerWidth = 16;
                   }

            int mowerLeft = mowerX - mowerLeftOffset;
            int mowerRight = mowerLeft + mowerWidth - 1;
            int obstacleLeft = obstacleX;
            int obstacleRight = obstacleLeft + obstacleWidth - 1;
            int powerUpLeft = powerUpX;
            int powerUpRight = powerUpLeft + powerUpWidth - 1;

            if (mowerLeft < 0) 
            {
                mowerLeft = 0;
            }
            if (mowerRight >= Console.WindowWidth) 
            {
                mowerRight = Console.WindowWidth - 1;
            }

            if (obstacleLeft < 0) 
            {
                obstacleLeft = 0;
            }
            if (obstacleRight >= Console.WindowWidth) 
            {
                obstacleRight = Console.WindowWidth - 1;
            }

            if (powerUpLeft < 0)
            {
                powerUpLeft = 0;
            }
            if (powerUpRight >= Console.WindowWidth)
            {
                powerUpRight = Console.WindowWidth - 1;
            }
            
            bool rangesOverlap = (mowerLeft <= obstacleRight) && (obstacleLeft <= mowerRight) && (iFrameCount == 0); //determines if damage should be taken, also takes into account iFrames, if there is none, damage is take. if not, damage isn't taken as they would take more than 1 damage.
            bool powerUpOverlap = (mowerLeft <= powerUpRight) && (powerUpLeft <= mowerRight) && (iFrameCount == 0);
            if (iFrameCount == 0)
            {
                invincible = false;
            }
            if (doubleScoreFrames == 0)
            {
                doubleScore = false;
            }
        if ((mowerY == groundY-randomY) && powerUpOverlap)
            {
                if (powerUp == 1)
                {
                    invincible = true;
                    iFrameCount = 200;
                }
                if (powerUp == 2)
                {
                    doubleScore = true;
                    doubleScoreFrames = 200;
                }
                if (powerUp == 3)
                {
                    lives++;
                }
            }
        lose:
            if (((mowerY == groundY) && !iFrames && rangesOverlap && !invincible) || lives == 0 )
            {
                lives--;
                if (mowerType == 1)
                {
                    iFrames = true;
                    iFrameCount += 2;
                }
                if (mowerType == 2)
                {
                    iFrames = true;
                    iFrameCount += 5;
                }
                if (mowerType == 3)
                {
                    iFrames = true;
                    iFrameCount += 16;
                }
                if (lives <= 1)
                {
                    Console.CursorVisible = true;
                    Console.Clear();
                error:
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game Over!");
                    Console.WriteLine($"${money}");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Menu();
                }
            }

            // Draw frame
            Console.Clear();
        if (doubleScore)
            {
                Console.SetCursorPosition(70,0);
                Color("red");
                Console.Write($"Double Score: {doubleScoreFrames/20} seconds");
                doubleScoreFrames--;
            }
        if (invincible)
            {
                Console.SetCursorPosition(30,0);
                Color("blue");
                Console.Write($"Invincibility: {iFrameCount/20} seconds");
                Color(" ");
            }
// Money goes up only when on ground
if (mowerY == groundY)
{
    if (mowerType == 1)
    {
        // 2 dollars per second
        moneyCount++;
        if (doubleScore)
        {
            moneyCount++;
        }
        if (moneyCount >= 10) // 20 frames/sec ÷ 10 = 2 per sec
        {
            money++;
            moneyCount = 0;
        }
    }
    if (mowerType == 2)
    {
        // 10 dollars per second
        moneyCount++;
        if (doubleScore)
        {
            moneyCount++;
        }
        if (moneyCount >= 2) // 20 frames/sec ÷ 2 = 10 per sec
        {
            money++;
            moneyCount = 0;
        }
    }
    if (mowerType == 3)
    {
        // 35 dollars per second
        moneyCount++;
        if (doubleScore)
        {
            moneyCount++;
        }
        if (moneyCount >= 1) // increment every frame
        {
            money += 2; // 20 frames/sec × 2 = 40/sec ≈ 35/sec target
            moneyCount = 0;
        }
    }
}

            DrawMower();
            if (obstacle == 1)
            {
                DrawRock(obstacleX);
            }
            if (obstacle == 2)
            {
                DrawBush(obstacleX);
            }
            if (obstacle == 3)
            {
                DrawCow(obstacleX);
            }
            if (powerUp == 1)
            {
                Invincibility(powerUpX);
            }
            if (powerUp == 2)
            {
                DoubleScore(powerUpX);
            }
            if (powerUp == 3)
            {
                ExtraLife(powerUpX);
            }
            DrawGround();

            Console.SetCursorPosition(0, 0);
            Console.Write($"${money}");
            Console.SetCursorPosition(8, 0);
            Console.Write($"Lives: {lives}");

            // Speed control
            if (invincible)
            {
                if (difficulty == "e" || difficulty == "h")
                {
                    Thread.Sleep(15);

                }
                else
                {
                    Thread.Sleep(8);
                }
            }
            else
            {
                if (difficulty == "e")
                {
                    Thread.Sleep(50);
                }
                if (difficulty == "h")
                {
                    Thread.Sleep(25); // Control game speed
                }
                if (difficulty == "i")
                {
                    Thread.Sleep(15);
                }
            }
        }
    }
    public static void Invincibility(int x)
    {
        Color("yellow");
        if (x == Console.WindowWidth-100)
        {
            randomY = 4;
        }
        Console.SetCursorPosition(x, groundY-randomY);
        int arrayY = 0;
        int arrayX = 4;
        char[,] invincibility = {
            {'█','█','█','█','█','█'},
            };
        while (arrayY >= 0)
        {
            Console.Write(invincibility[arrayY, arrayX]);
            arrayX++;
            if (arrayX > 4)
            {
                arrayX = 0;
                arrayY--;
            }
        }
    }
    public static void DoubleScore(int x)
    {
        Color("blue");
        if (x == Console.WindowWidth-100)
        {
            randomY = 4;
        }
        Console.SetCursorPosition(x, groundY-randomY);
        int arrayY = 0;
        int arrayX = 4;
        char[,] doubleScore = {
            {'█','█','█','█','█'}
            };
        while (arrayY >= 0)
        {
            Console.Write(doubleScore[arrayY, arrayX]);
            arrayX++;
            if (arrayX > 4)
            {
                arrayX = 0;
                arrayY--;
            }
        }
    }
    public static void ExtraLife(int x)
    {
        Color("red");
        if (x == Console.WindowWidth-100)
        {
            randomY = 4;
        }
        Console.SetCursorPosition(x, groundY-randomY);
        int arrayY = 0;
        int arrayX = 4;
        char[,] extraLife = {
            {'█','█','█','█','█'}
            };
        while (arrayY >= 0)
        {
            Console.Write(extraLife[arrayY, arrayX]);
            arrayX++;
            if (arrayX > 4)
            {
                arrayX = 0;
                arrayY--;
            }
        }
    }


    public static void DrawMower()// these are all the mower sprites. color is added when going through array.
    {
        if (mowerType == 1)
        {
            Console.SetCursorPosition(mowerX - 3, mowerY);
            int savePosX = mowerX;
            int savePosY = mowerY;
            int arrayY = 4;
            int arrayX = 0;
            char[,] lawnMower = {
                {'█','█','█',' '},
                {' ',' ','█',' '},
                {' ',' ','█',' '},
                {' ',' ','▛','▜'},
                {' ',' ','▙','▟'}
                };
            Color("gray");
            while (arrayY >= 0)
            {
                Console.Write(lawnMower[arrayY, arrayX]);
                arrayX++;
                if (arrayX > 3)
                {
                    arrayX = 0;
                    arrayY--;
                    mowerY--;
                    Console.SetCursorPosition(mowerX - 3, mowerY);
                }
            }
            mowerX = savePosX;
            mowerY = savePosY;
            Color("");
        }
        if (mowerType == 2)
        {
            Console.SetCursorPosition(mowerX - 11, mowerY);
            int savePosX = mowerX;
            int savePosY = mowerY;
            int arrayY = 4;
            int arrayX = 0;
            char[,] lawnMower = {
                {'█','█','█','█',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ','█','█','█',' ',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ','█','█','█',' ',' ',' ',' ',' '},
                {' ',' ',' ',' ',' ',' ','█','█','█','█','█','█',},
                {' ',' ',' ',' ',' ',' ','█','█','█','█','█','█',}
                };
            Color("red");
            while (arrayY >= 0)
            {
                Console.Write(lawnMower[arrayY, arrayX]);
                arrayX++;
                if (arrayX > 11)
                {
                    arrayX = 0;
                    arrayY--;
                    mowerY--;
                    Console.SetCursorPosition(mowerX - 11, mowerY);
                }
                if (arrayY <= 2)
                {
                    Color("gray");
                }
            }
            mowerX = savePosX;
            mowerY = savePosY;
            Console.ResetColor();
        }
        if (mowerType == 3)
        {
            Console.SetCursorPosition(mowerX - 10, mowerY);
            int savePosX = mowerX;
            int savePosY = mowerY;
            int arrayY = 4;
            int arrayX = 0;
            char[,] lawnMower = {
                {' ',' ','█','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ','█','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {' ',' ','█','█','█','█','█',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                {'█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█'},
                {'█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█'}
                };
            Color("darkred");
            while (arrayY >= 0)
            {
                Console.Write(lawnMower[arrayY, arrayX]);
                arrayX++;
                if (arrayX == 1 && arrayY == 4)
                {
                    Color("black");
                }
                if (arrayX >= 2 && arrayX <= 5)
                {
                    Color("darkred");
                }
                if (arrayX >= 6 && arrayX <= 9 && arrayY == 4)
                {
                    Color("gray");
                }
                if (arrayX >= 10 && arrayX <= 12)
                {
                    Color("darkred");
                }
                if (arrayX == 13 && arrayY == 4)
                {
                    Color("black");
                }
                if (arrayX >= 14)
                {
                    Color("darkred");
                }
                if (arrayY <= 2)
                {
                    Color("darkgray");
                }
                if (arrayX > 15)
                {
                    arrayX = 0;
                    arrayY--;
                    mowerY--;
                    Console.SetCursorPosition(mowerX - 10, mowerY);
                }
            }
            mowerX = savePosX;
            mowerY = savePosY;
            Color("");
        }
    }

    public static void DrawRock(int x)//rock sprite
    {
        Color("darkgray");
        Console.SetCursorPosition(x, groundY);
        int arrayY = 1;
        int arrayX = 0;
        char[,] rock = {
            {'█','█',},
            {'█','█',}
            };
        while (arrayY >= 0)
        {
            Console.Write(rock[arrayY, arrayX]);
            arrayX++;
            if (arrayX > 1)
            {
                arrayX = 0;
                arrayY--;
            }
        }
    }
    public static void DrawBush(int x)//bush sprite
    {

        int arrayY = 3;
        int arrayX = 0;

        char[,] bush = {
        {' ','▄','█','▄',' '},
        {'█','█','█','█','█'},
        {'█','█','█','█','█'},
        {' ','█','█','█',' '}
    };

        Color("darkgreen");
        int drawY = groundY;
        while (arrayY >= 0)
        {
            Console.SetCursorPosition(x, drawY);
            for (arrayX = 0; arrayX < bush.GetLength(1); arrayX++)
            {
                Console.Write(bush[arrayY, arrayX]);
            }
            drawY--;
            arrayY--;
        }
        Color("");
    }

    public static void DrawCow(int x)//cow sprite
    {
        char[][] cow = new char[][]
        {
        new char[] { ' ', '`','\\','-','-','-','-','-','-','(','o','o',')' },
        new char[] { ' ',' ',' ','|','|',' ',' ',' ',' ','(','_','_',')' },
        new char[] { ' ',' ',' ','|','|','w','-','-','|','|' }
        };
        int drawY = groundY;
        for (int arrayY = cow.Length - 1; arrayY >= 0; arrayY--)
        {
            Console.SetCursorPosition(x, drawY);

            for (int arrayX = 0; arrayX < cow[arrayY].Length; arrayX++)
            {
                char c = cow[arrayY][arrayX];

                if (arrayY == 0 && (arrayX == 10 || arrayX == 11))
                {
                    Color("black");
                }
                else if (arrayY == 2 && arrayX == 4) 
                {
                    Color("magenta");
                }
                else
                {
                    Color("white");
                }

                Console.Write(c);//draws the cow
            }

            drawY--;
        }

        Color(""); // reset
    }

    public static void DrawGround()//makes sure ground is at the same height and also is not taking up the full console
    {
        Color("green");
        for (int x = 0; x < Console.WindowWidth - 100; x++)
        {
            Console.SetCursorPosition(x, groundY + 1);
            Console.Write("█");
        }
        Color("");
    }
        public static void Shop()
        {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to menu with one option!");
            Console.WriteLine("shop = s");
            Console.WriteLine("exit = e");

            string input = Console.ReadLine() ?? ""; //I tell it to ignore null with '??'
            input = input.ToLower(); // any cap letter is auto lower case so both cases are accpeted

            switch (input) //This is the switch box method i was talking about.
            {
                case "s":
                    ShopRunner();
                    break;

                case "e":
                    return;
            }
        }
        }

        static void ShopRunner() //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!START OF SHOP RUNNER
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------- Welcome to Tractor Supplier shop! -------------------- ");
                Thread.Sleep(0500);
                Console.WriteLine("");
                Console.WriteLine("\nWe currently have three available options for you to choose from!");
                Thread.Sleep(0500);
                Console.WriteLine("\nMower worst = >1< ----- $0 (Free)");
                Thread.Sleep(0500);
                Console.WriteLine("Mower mid = >2< --------- $500 (For the Middle Class)");
                Thread.Sleep(0500);
                Console.WriteLine("Mower best = >3< -------- $1500 (If you are rich and have pocket money)");
                Thread.Sleep(0500);
                Console.WriteLine("Type 'e' to exit menu.");
                Console.WriteLine();
                Thread.Sleep(0500);
                Console.WriteLine($"You currently have ${money}");

                string choice = Console.ReadLine() ?? "";
                choice = choice.ToLower();

                switch (choice)
                {
                    case "1":
                        MowerWorst();
                        break;

                    case "2":
                        MowerMid();
                        break;

                    case "3":
                        MowerBest();
                        break;

                    case "e":
                        Menu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\nInvalid Operation.");
                        Thread.Sleep(0500);
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        break;
                }

                static void MowerWorst()
                {
                Recycle1: //goto's restart
                int Cost = 0;
                    Console.Clear();
                    string Confirm;
                    Console.WriteLine("\nAre you sure you want to use Mower Worst for $0?");
                    Console.WriteLine("\nYes = yes \nNo = no.");

                    Confirm = Console.ReadLine() ?? "";
                    Confirm = Confirm.ToLower();

                    if (Confirm != "yes" && Confirm != "no")
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nNot a valid yes or no.");
                        Console.WriteLine("Type any key to continue.");
                        Console.ReadKey();
                        goto Recycle1;
                    }
                    else if (Confirm == "yes")
                    {
                        Console.Clear();
                        Console.WriteLine("Thank you for your perchase of Mower 1!");
                        Thread.Sleep(0500);
                        Console.WriteLine("An invoice will be sent to jeb_@mowerCompany.com");
                        Thread.Sleep(0500);
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();

                        money -= Cost;
                        mowerType = 1;
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry that you were not satisfied.");
                        Thread.Sleep(0500);
                        Console.WriteLine("Hope to see you oh so very soon!");
                        Thread.Sleep(0500);
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        return;
                    }
                }

                static void MowerMid() //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!MID
                {
                Recycle2: //goto's restart
                    Console.Clear();
                    int Cost2 = 500;
                    string Confirm;
                    Console.WriteLine("\nAre you sure you want to use Mower Mid for $500?");
                    Console.WriteLine("\nYes = yes \nNo = no.");

                    Confirm = Console.ReadLine() ?? "";
                    Confirm = Confirm.ToLower();

                    if (Confirm != "yes" && Confirm != "no")
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nNot a valid yes or no.");
                        Console.WriteLine("Type any key to continue.");
                        Console.ReadKey();
                        goto Recycle2;
                    }
                    else if (Confirm == "yes" && money >= Cost2)
                    {
                        Console.Clear();
                        Console.WriteLine("Thank you for your perchase of Mower 2!");
                        Thread.Sleep(0500);
                        Console.WriteLine("An invoice will be sent to jeb_@mowerCompany.com");
                        Thread.Sleep(0500);
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();

                        money -= Cost2;
                        mowerType = 2;
                        return;
                    }
                    if (money <= Cost2)
                    {
                        Console.WriteLine("NOT ENOUGH MONEY!!!!!");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry that you were not satisfied.");
                        Thread.Sleep(0500);
                        Console.WriteLine("Hope to see you oh so very soon!");
                        Thread.Sleep(0500);
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        return;
                    }
                }
                static void MowerBest() //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!BEST
                {
                Recycle3: //goto's restart
                    Console.Clear();
                    int Cost3 = 1500;
                    string Confirm;
                    Console.WriteLine("\nAre you sure you want to use Mower Best for $1500?");
                    Console.WriteLine("\nYes = yes \nNo = no.");

                    Confirm = Console.ReadLine() ?? "";
                    Confirm = Confirm.ToLower();

                    if (Confirm != "yes" && Confirm != "no")
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nNot a valid yes or no.");
                        Console.WriteLine("Type any key to continue.");
                        Console.ReadKey();
                        goto Recycle3;
                    }
                    else if (Confirm == "yes" && money >= Cost3)
                    {
                        Console.Clear();
                        Console.WriteLine("Thank you for your perchase of Mower 3!");
                        Thread.Sleep(0500);
                        Console.WriteLine("An invoice will be sent to jeb_@mowerCompany.com");
                        Thread.Sleep(0500);
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();

                        money -= Cost3;
                        mowerType = 3;
                        return;
                    }
                    if (money <= Cost3)
                    {
                        Console.WriteLine("NOT ENOUGH MONEY!!!!!");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry that you were not satisfied.");
                        Thread.Sleep(0500);
                        Console.WriteLine("Hope to see you oh so very soon!");
                        Thread.Sleep(0500);
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }
    //made these to make putting in colors easier
    public static void BackColor(string color)
    {
        int r = 0;
        if (color == "rand")
        {
            r = rand.Next(1, 17); //for a randomly generated color
        }
        if (color == "darkred" || r == 1)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }
        else if (color == "red" || r == 2)
        {
            Console.BackgroundColor = ConsoleColor.Red;
        }
        else if (color == "yellow" || r == 3)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
        }
        else if (color == "darkyellow" || r == 4)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
        }
        else if (color == "green" || r == 5)
        {
            Console.BackgroundColor = ConsoleColor.Green;
        }
        else if (color == "darkgreen" || r == 6)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
        }
        else if (color == "blue" || r == 7)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
        }
        else if (color == "darkblue" || r == 8)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
        else if (color == "cyan" || r == 9)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
        }
        else if (color == "darkcyan" || r == 10)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
        }
        else if (color == "purple" || r == 11)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
        }
        else if (color == "darkpurple" || r == 12)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
        }
        else if (color == "white" || r == 13)
        {
            Console.BackgroundColor = ConsoleColor.White;
        }
        else if (color == "gray" || r == 14)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        else if (color == "darkgray" || r == 15)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }
        else if (color == "black" || r == 16)
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ResetColor();
        }
    }
    public static void Color(string color)
    {
        int r = 0;
        if (color == "rand")
        {
            r = rand.Next(1, 17);
        }
        if (color == "darkred" || r == 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else if (color == "red" || r == 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (color == "yellow" || r == 3)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (color == "darkyellow" || r == 4)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else if (color == "green" || r == 5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (color == "darkgreen" || r == 6)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        else if (color == "blue" || r == 7)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        else if (color == "darkblue" || r == 8)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        else if (color == "cyan" || r == 9)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        else if (color == "darkcyan" || r == 10)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        else if (color == "purple" || r == 11)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        else if (color == "darkpurple" || r == 12)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
        else if (color == "white" || r == 13)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (color == "gray" || r == 14)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else if (color == "darkgray" || r == 15)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        else if (color == "black" || r == 16)
        {
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ResetColor();
        }
    }
}