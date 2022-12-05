namespace AdventOfCode2022.Day02
{
    public class Day02
    {
        private readonly string _input;

        public Day02()
        {
            _input = File.ReadAllText("Day02/Input02.txt");
        }

        public string Stage1()
        {
            List<(char PlayerA, char PlayerB)> input = _input.Split("\r\n").Select(d => (d[0], d[2])).ToList();

            int TotalScoreA = 0;
            int TotalScoreB = 0;

            foreach (var item in input)
            {
                (int score, char move) A = (0, ' ');
                (int score, char move) B = (0, ' ');

                switch (item.PlayerA)
                {
                    case 'A': A = (1, 'Z'); break;  //Rock
                    case 'B': A = (2, 'X'); break;  //Paper
                    case 'C': A = (3, 'Y'); break;  //Scissors
                }

                switch (item.PlayerB)
                {
                    case 'X': B = (1, 'X'); break;  //Rock
                    case 'Y': B = (2, 'Y'); break;  //Paper
                    case 'Z': B = (3, 'Z'); break;  //Scissors
                }

                if (A.score == B.score)
                {
                    TotalScoreA = TotalScoreA + A.score + 3;
                    TotalScoreB = TotalScoreB + B.score + 3;
                }
                else if (A.move == B.move)
                {
                    TotalScoreA = TotalScoreA + A.score + 6;
                    TotalScoreB = TotalScoreB + B.score;
                }
                else
                {
                    TotalScoreA = TotalScoreA + A.score;
                    TotalScoreB = TotalScoreB + B.score + 6;
                }
            }

            return TotalScoreB.ToString();
        }

        public string Stage2()
        {
            List<(char PlayerA, char PlayerB)> input = _input.Split("\r\n").Select(d => (d[0], d[2])).ToList();

            int TotalScoreA = 0;
            int TotalScoreB = 0;

            foreach (var item in input)
            {
                move PlayerAMove = move.Default;
                move PlayerBMove = move.Default;

                switch (item.PlayerA)
                {
                    case 'A':
                        PlayerAMove = move.Rock;
                        break;
                    case 'B':
                        PlayerAMove = move.Paper;
                        break;
                    case 'C':
                        PlayerAMove = move.Scissors;
                        break;
                }

                switch (item.PlayerB)
                {
                    case 'X':
                        PlayerBMove = GetPlayerBMove(strategy.lose, PlayerAMove);
                        TotalScoreA = TotalScoreA + (int)PlayerAMove + 6;
                        TotalScoreB = TotalScoreB + (int)PlayerBMove;
                        break;
                    case 'Y':
                        PlayerBMove = GetPlayerBMove(strategy.draw, PlayerAMove);
                        TotalScoreA = TotalScoreA + (int)PlayerAMove + 3;
                        TotalScoreB = TotalScoreB + (int)PlayerBMove + 3;
                        break;
                    case 'Z':
                        PlayerBMove = GetPlayerBMove(strategy.win, PlayerAMove);
                        TotalScoreA = TotalScoreA + (int)PlayerAMove;
                        TotalScoreB = TotalScoreB + (int)PlayerBMove + 6;
                        break;
                }
            }

            return TotalScoreB.ToString();
        }

        private move GetPlayerBMove(strategy strategy, move playerAMove)
        {
            if (strategy == strategy.draw)
            {
                return playerAMove;
            }

            if (strategy == strategy.win)
            {
                switch (playerAMove)
                {
                    case move.Rock:
                        return move.Paper;
                    case move.Paper:
                        return move.Scissors;
                    case move.Scissors:
                        return move.Rock;
                    default:
                        return move.Default;
                }
            }

            if (strategy == strategy.lose)
            {
                switch (playerAMove)
                {
                    case move.Rock:
                        return move.Scissors;
                    case move.Paper:
                        return move.Rock;
                    case move.Scissors:
                        return move.Paper;
                    default:
                        return move.Default;
                }
            }

            return move.Default;
        }

        enum move
        {
            Default = 0,
            Rock = 1,
            Paper = 2,
            Scissors = 3,
        }

        enum strategy
        {
            lose = 1,
            draw = 2,
            win = 3,
        }
    }
}
