using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Bowling
    {
        private enum FrameStatusEnum
        {
            strike,
            spare,
            normal
        }

        public static int CalculateScore(string gamePins)
        {
            int score = 0;

            int[] numOfPinsDownAtRoll = GetNumOfPinsDownForEveryRoll(gamePins);
            FrameStatusEnum[] firstTenFrameStatuses = GetFirstTenFrameStatuses(gamePins);

            int rollCount = 0;
            foreach (FrameStatusEnum frameStatus in firstTenFrameStatuses)
            {
                int frameScore;
                int bonusScore;

                if (frameStatus == FrameStatusEnum.strike)
                {
                    frameScore = numOfPinsDownAtRoll[rollCount];
                    bonusScore = numOfPinsDownAtRoll[rollCount + 1] + numOfPinsDownAtRoll[rollCount + 2];
                    rollCount++;
                }
                else if (frameStatus == FrameStatusEnum.spare)
                {
                    frameScore = numOfPinsDownAtRoll[rollCount] + numOfPinsDownAtRoll[rollCount + 1];
                    bonusScore = numOfPinsDownAtRoll[rollCount + 2];
                    rollCount += 2;
                }
                else
                {
                    frameScore = numOfPinsDownAtRoll[rollCount] + numOfPinsDownAtRoll[rollCount + 1];
                    bonusScore = 0;
                    rollCount += 2;
                }
                score += frameScore + bonusScore;
            }

            return score;
        }

        private static int[] GetNumOfPinsDownForEveryRoll(string gamePins)
        {
            List<int> rollPins = new();
            foreach (char c in gamePins)
            {
                if (c == 'X')
                    rollPins.Add(10);
                else if (c == '/')
                    rollPins.Add(10 - rollPins.Last());
                else if (c == '-')
                    rollPins.Add(0);
                else if (c != ' ')
                    rollPins.Add(int.Parse(c.ToString()));
            }

            return rollPins.ToArray();
        }

        private static FrameStatusEnum[] GetFirstTenFrameStatuses(string gamePins)
        {
            return gamePins.Split(' ').ToList().GetRange(0, 10).Select(item =>
            {
                if (item == "X")
                    return FrameStatusEnum.strike;

                if (item.Contains('/'))
                    return FrameStatusEnum.spare;

                return FrameStatusEnum.normal;
            }).ToArray();
        }
    }
}
