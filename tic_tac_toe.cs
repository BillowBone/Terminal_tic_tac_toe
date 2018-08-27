using System;

class billow
{
    static void display_map(int[,] map)
    {
        int i = 0;
        int j = 0;

        Console.WriteLine("-------------");
        while (i < 3)
        {
            Console.Write("| ");
            while (j < 3)
            {
                if (map[i, j] > 0)
                    Console.Write(map[i, j]);
                else if (map[i, j] == 0)
                    Console.Write("X");
                else if (map[i, j] == -1)
                    Console.Write("O");
                if (j != 2)
                    Console.Write(" | ");
                else
                    Console.Write(" |\n");
                j++;
            }
            i++;
            j = 0;
        }
        Console.WriteLine("-------------");
    }


    static bool possible_or_not(int[,] map, int place)
    {
        int i = 0;
        int j = 0;

        if (place <= 3)
            j = place - 1;
        if (place > 3 && place <= 6)
        {
            i = 1;
            j = place - 4;
        }
        if (place > 6 && place <= 9)
        {
            i = 2;
            j = place - 7;
        }
        if (map[i, j] > 0)
            return (true);
        else
            return (false);
    }


    static void make_turn(int[,] map, int player)
    {
        if (player == 0)
            Console.Write("Player 1, please choose the number you want to take : ");
        if (player == -1)
            Console.Write("Player 2, please choose the number you want to take : ");
        string response = Console.ReadLine();
        int choice = response[0] - 48;
        Console.Write("\n");

        while (choice < 1 || choice > 9)
        {
            Console.Write("Incorrect number please enter again : ");
            response = Console.ReadLine();
            choice = response[0] - 48;
            Console.Write("\n");
        }
        while (!possible_or_not(map, choice))
        {
            Console.Write("This place is already taken, please choose another : ");
            response = Console.ReadLine();
            choice = response[0] - 48;
            Console.Write("\n");
        }
        if (choice > 0 && choice < 4)
            map[0, choice - 1] = player;
        else if (choice > 3 && choice < 7)
            map[1, choice - 4] = player;
        else if (choice > 6 && choice < 10)
            map[2, choice - 7] = player;
    }


    static bool game_finished(int[,] map)
    {
        int i = 0;
        int j = 0;

        if (map[0, 0] == map[0, 1] && map[0, 1] == map[0, 2])
            return (true);
        if (map[1, 0] == map[1, 1] && map[1, 1] == map[1, 2])
            return (true);
        if (map[2, 0] == map[2, 1] && map[2, 1] == map[2, 2])
            return (true);
        if (map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2])
            return (true);
        if (map[0, 2] == map[1, 1] && map[1, 1] == map[2, 0])
            return (true);
        if (map[0, 0] == map[1, 0] && map[1, 0] == map[2, 0])
            return (true);
        if (map[0, 1] == map[1, 1] && map[1, 1] == map[2, 1])
            return (true);
        if (map[0, 2] == map[1, 2] && map[1, 2] == map[2, 2])
            return (true);
        while (i < 3)
        {
            while (j < 3)
            {
                if (map[i, j] != 0 && map[i, j] != -1)
                    return (false);
                j++;
            }
            i++;
            j = 0;
        }
        return (true);
    }


    static bool has_won(int[,] map)
    {
        if (map[0, 0] == map[0, 1] && map[0, 1] == map[0, 2])
            return (true);
        if (map[1, 0] == map[1, 1] && map[1, 1] == map[1, 2])
            return (true);
        if (map[2, 0] == map[2, 1] && map[2, 1] == map[2, 2])
            return (true);
        if (map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2])
            return (true);
        if (map[0, 2] == map[1, 1] && map[1, 1] == map[2, 0])
            return (true);
        if (map[0, 0] == map[1, 0] && map[1, 0] == map[2, 0])
            return (true);
        if (map[0, 1] == map[1, 1] && map[1, 1] == map[2, 1])
            return (true);
        if (map[0, 2] == map[1, 2] && map[1, 2] == map[2, 2])
            return (true);
        return (false);
    }


    static void who_won(int[,] map, int turn)
    {
        if (turn == 0 && has_won(map))
            Console.WriteLine("The player 2 (O) has won !");
        else if (turn == -1 && has_won(map))
            Console.WriteLine("The player 1 (X) has won !");
        else
            Console.WriteLine("Nobody Won :(");
        Console.Read();
    }


    static void Main()
    {
        int[,] map = new int[,]
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        int turn = 0;

        while (!game_finished(map))
        {
            display_map(map);
            make_turn(map, turn);
            if (turn == 0)
                turn = -1;
            else if (turn == -1)
                turn = 0;
        }
        display_map(map);
        who_won(map, turn);
    }
}