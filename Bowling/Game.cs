using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    class Game
    {
        private const int perfect = 10;
        
        private List<int> lstPins = new List<int>();
        public void Roll(int pins)
        {
            lstPins.Add(pins);
        }

        public int Score()
        {
            int score = 0;
            int sessionRoll = 0;
            for (int frame = 0; frame < 10;frame++ )
            {
                if (IsStrike(sessionRoll))
                {
                    score += 10 + GetNextTwoPinsForStrike(sessionRoll);
                    sessionRoll += 1;
                }
                else if (IsSpare(sessionRoll))
                {
                    score += 10 + GetNextPinForSpare(sessionRoll);
                    sessionRoll += 2;
                }
                else
                {
                    score += GetTwoPinInFrame(sessionRoll);
                    sessionRoll += 2;
                }
            }

            return score;
        }

        private int GetNextTwoPinsForStrike(int sessionRoll)
        {
            return GetPinOfNextSession(sessionRoll) + GetPinOfTwoNextSession(sessionRoll);
        }

        private int GetPinOfTwoNextSession(int sessionRoll)
        {
            int twoNextSession = 0;
            if (IsSessionNotOutListPins(sessionRoll + 2))
                twoNextSession = lstPins[sessionRoll + 2];
            return twoNextSession;
        }

        private int GetPinOfNextSession(int sessionRoll)
        {
            int nextSession = 0;
            if (IsSessionNotOutListPins(sessionRoll + 1))
                nextSession = lstPins[sessionRoll + 1];
            return nextSession;
        }

        private bool IsSessionNotOutListPins(int sessionCheck)
        {
            return lstPins.Count() > sessionCheck;
        }

        private bool IsStrike(int sessionRoll)
        {
            return lstPins[sessionRoll] == perfect;
        }

        private int GetTwoPinInFrame(int sessionRoll)
        {
            return GetPinOfSession(sessionRoll) + GetPinOfNextSession(sessionRoll);
        }

        private int GetPinOfSession(int sessionRoll)
        {
            return lstPins[sessionRoll];
        }

        private int GetNextPinForSpare(int sessionRoll)
        {
            return GetPinOfTwoNextSession(sessionRoll);
        }

        private bool IsSpare(int sessionRoll)
        {
            return lstPins[sessionRoll] + lstPins[sessionRoll + 1] == perfect;
        }
    }
}
