using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Game
    {
        private readonly List<Frame> _frames = new List<Frame> {new Frame(null)};

        public void AddRoll(int i)
        {
            Frame frame = _frames.Last();
            frame.AddRoll(i);
            if (frame.IsComplete())
            {
                _frames.Add(new Frame(frame));
            }
        }

        public int GetScore()
        {
            return _frames.Sum(x => x.GetScore());
        }
    }

    public class Frame
    {
        private readonly Frame _previous;
        private int _frameScore;
        private int _rolls;

        public Frame(Frame previous)
        {
            _previous = previous;
        }

        public void AddRoll(int pins)
        {
            _frameScore += pins;
            _rolls++;

            if (_previous != null) 
                _previous.AcceptBonus(pins);
        }

        public bool IsComplete()
        {
            return _frameScore == 10 || _rolls == 2;
        }

        public int GetScore()
        {
            return _frameScore;
        }

        private void AcceptBonus(int i)
        {
            if (Spare()) 
                _frameScore += i;
        }

        private bool Spare()
        {
            return _frameScore == 10 && _rolls == 2;
        }
    }
}