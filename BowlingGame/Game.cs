using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        private const int TOTAL_PINS = 10;
        private int _pinsRemaining = TOTAL_PINS;
        private bool _isNewFrame = true;

        private int _currentMultiplier = 1;
        private int _nextMultiplier = 1;
        private int _frameCount = 1;

        public int Score { get; private set; }

        public void Roll(int number)
        {
            if (number < 0 || number > _pinsRemaining)
                throw new ArgumentOutOfRangeException(nameof(number));

            _pinsRemaining -= number;
            Score += number * _currentMultiplier;

            UpdatePrivateFieldsForNextRoll();
        }

        private void UpdatePrivateFieldsForNextRoll()
        {
            FrameStatus frameStatus = GetFrameStatus();
            _isNewFrame = IsNextRollANewFrame();

            if (_isNewFrame)
            {
                _pinsRemaining = TOTAL_PINS;
                _frameCount++;
            }

            UpdateMultipliers(frameStatus);
        }

        private FrameStatus GetFrameStatus()
        {
            if (_pinsRemaining != 0)
                return FrameStatus.Normal;

            if (!_isNewFrame)
                return FrameStatus.Spare;

            return FrameStatus.Strike;
        }

        private bool IsNextRollANewFrame() => !_isNewFrame || _pinsRemaining == 0;

        private void UpdateMultipliers(FrameStatus frameStatus)
        {
            _currentMultiplier = _nextMultiplier;
            _nextMultiplier = 1;

            if (_frameCount > 10 || frameStatus == FrameStatus.Normal)
                return;

            if (frameStatus == FrameStatus.Spare)
            {
                _currentMultiplier++;
                return;
            }

            if (frameStatus == FrameStatus.Strike)
            {
                _currentMultiplier++;
                _nextMultiplier++;
                return;
            }
        }
    }
}
