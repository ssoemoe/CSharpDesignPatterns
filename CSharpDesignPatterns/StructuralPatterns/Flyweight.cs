using System.Collections.Generic;
using System;

/// <summary>
/// Caches the objects and returns the reference if the same object with the same intrinsic state is requested.
/// Factory pattern creation but caching structural.
/// </summary>

namespace CSharpDesignPatterns.StructuralPatterns
{
    public class Flyweight
    {
        public static void TestDesign()
        {
            var footballPlayer = SportsmanFactory.GetPlayer("football");
            footballPlayer.PlaySports(PlayState.BREAK);

            var footballPlayer2 = SportsmanFactory.GetPlayer("football");
            footballPlayer2.PlaySports(PlayState.PLAYING);

            var cricketPlayer = SportsmanFactory.GetPlayer("cricket");
            cricketPlayer.PlaySports(PlayState.STOP);

            Console.WriteLine($"Objects count: {SportsmanFactory.GetObjectCount()}");
        }
    }

    class SportsmanFactory
    {
        private static Dictionary<string, Sportsman> _cache = new Dictionary<string, Sportsman>();//cache with dictionary
        public static Sportsman GetPlayer(string sports)
        {
            // returns the same reference if the object with the same intrinsic value already exists to reduce the number of objects
            if (_cache.ContainsKey(sports))
                return _cache[sports];
            switch (sports)
            {
                case "football":
                    _cache.Add(sports, new FootballPlayer());
                    return _cache[sports];
                case "cricket":
                    _cache.Add(sports, new CricketPlayer());
                    return _cache[sports];
                default:
                    return null;
            }
        }

        public static int GetObjectCount()
        {
            return _cache.Keys.Count;
        }
    }

    enum PlayState
    {
        BREAK,
        PLAYING,
        STOP
    }

    abstract class Sportsman
    {
        protected string _sports { get; set; } // intrinsic state
        // extrinsic state
        public void PlaySports(PlayState state)
        {
            switch (state)
            {
                case PlayState.BREAK: Console.WriteLine("Player is taking a break"); break;
                case PlayState.PLAYING: Console.WriteLine($"Player is playing {_sports} on the field"); break;
                case PlayState.STOP: Console.WriteLine("Player has stopped playing"); break;
                default: throw new Exception("Invalid player state");
            }
        }
    }

    class FootballPlayer : Sportsman
    {
        public FootballPlayer()
        {
            _sports = "football";
        }
    }

    class CricketPlayer : Sportsman
    {
        public CricketPlayer()
        {
            _sports = "cricket";
        }
    }
}