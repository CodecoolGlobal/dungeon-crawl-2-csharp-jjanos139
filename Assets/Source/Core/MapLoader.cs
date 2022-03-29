using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        /// <summary>
        ///     Constructs map from txt file and spawns actors at appropriate positions
        /// </summary>
        /// <param name="id"></param>
        public static void LoadMap(int id)
        {
            var lines = Regex.Split(Resources.Load<TextAsset>($"map_{id}").text, "\r\n|\r|\n");

            // Read map size from the first line
            var split = lines[0].Split(' ');
            var width = int.Parse(split[0]);
            var height = int.Parse(split[1]);

            // Create actors
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];

                    SpawnActor(character, (x, -y));
                }
            }

            // Set default camera size and position
            CameraController.Singleton.Size = 10;
            //CameraController.Singleton.Position = (width / 2, -height / 2);
        }

        private static void SpawnActor(char c, (int x, int y) position)
        {
            switch (c)
            {
                case '#':
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'p':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'b':
                    ActorManager.Singleton.Spawn<Bat>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'B':
                    ActorManager.Singleton.Spawn<Bear>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'c':
                    ActorManager.Singleton.Spawn<Crocodile>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'g':
                    ActorManager.Singleton.Spawn<Ghoul>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'x':
                    ActorManager.Singleton.Spawn<Scorpion>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'S':
                    ActorManager.Singleton.Spawn<Snake>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'X':
                    ActorManager.Singleton.Spawn<Spider>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'C':
                    ActorManager.Singleton.Spawn<Cactus>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'D':
                    ActorManager.Singleton.Spawn<Diamond>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'd':
                    ActorManager.Singleton.Spawn<Drumstick>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'e':
                    ActorManager.Singleton.Spawn<Explosive>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'G':
                    ActorManager.Singleton.Spawn<Grave>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'K':
                    ActorManager.Singleton.Spawn<Key>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'A':
                    ActorManager.Singleton.Spawn<Apple>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'P':
                    ActorManager.Singleton.Spawn<Potion>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case '|':
                    ActorManager.Singleton.Spawn<Switch>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'R':
                    ActorManager.Singleton.Spawn<Ring>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 't':
                    ActorManager.Singleton.Spawn<Tree1>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'T':
                    ActorManager.Singleton.Spawn<Tree2>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;                
                case 'u':
                    ActorManager.Singleton.Spawn<Tree3>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case ' ':
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
