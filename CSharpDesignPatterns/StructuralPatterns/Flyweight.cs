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
            footballPlayer.HasSportsmanship = false; //sets extrinsic value
            footballPlayer.PlaySports();

            var cricketPlayer = SportsmanFactory.GetPlayer("cricket");
            cricketPlayer.HasSportsmanship = true;//sets extrinsic value
            cricketPlayer.PlaySports();
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
    }

    abstract class Sportsman
    {
        public bool HasSportsmanship { get; set; } = true; // extrinsic state
        public abstract void PlaySports();
    }

    class FootballPlayer : Sportsman
    {
        private readonly string _sports; // intrinsic state
        public FootballPlayer()
        {
            _sports = "football";
        }

        public override void PlaySports()
        {
            Console.WriteLine($"Plays {_sports}. Does he/she have sportsmanship? {HasSportsmanship}");
        }
    }

    class CricketPlayer : Sportsman
    {
        private readonly string _sports; // intrinsic state
        public CricketPlayer()
        {
            _sports = "cricket";
        }

        public override void PlaySports()
        {
            Console.WriteLine($"Plays {_sports}. Does he/she have sportsmanship? {HasSportsmanship}");
        }
    }
}