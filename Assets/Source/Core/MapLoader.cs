using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using DungeonCrawl.Actors;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    ///
    public static class MapLoader
    {
        public static List<Actor> AllActorsFirstMap;
        public static List<Actor> AllActorsSecondMap;
        public static List<Actor> AllActorsThirdNMap;
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

        public static void ReLoadMap(int mapId)
        {
            if (mapId == 1)
            {
                foreach (Actor actor in AllActorsFirstMap)
                {
                    if (actor.DefaultName != "Player")
                        SpawnActor(actor.DefaultChar, (actor.Position.x, actor.Position.y));
                }
            }
            else if (mapId == 2)
            {
                foreach (Actor actor in AllActorsSecondMap)
                {
                    if (actor.DefaultName != "Player")
                        SpawnActor(actor.DefaultChar, (actor.Position.x, actor.Position.y));
                }
            }
            else if (mapId == 3)
            {
                foreach (Actor actor in AllActorsThirdNMap)
                {
                    if (actor.DefaultName != "Player")
                        SpawnActor(actor.DefaultChar, (actor.Position.x, actor.Position.y));
                }
            }
        }
        private static void SpawnActor(char c, (int x, int y) position)
        {
            switch (c)
            {
                // 1. palya elemek
                case '#':
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'p':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'B':
                    ActorManager.Singleton.Spawn<Bear>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'c':
                    ActorManager.Singleton.Spawn<Crocodile>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'S':
                    ActorManager.Singleton.Spawn<Snake>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'X':
                    ActorManager.Singleton.Spawn<Spider>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
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
                case 'K':
                    ActorManager.Singleton.Spawn<Key>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'P':
                    ActorManager.Singleton.Spawn<Potion>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '|':
                    ActorManager.Singleton.Spawn<Switch>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'R':
                    ActorManager.Singleton.Spawn<Ring>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'f':
                    ActorManager.Singleton.Spawn<Tree1>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'F':
                    ActorManager.Singleton.Spawn<Tree2>(position);
                    break;
                case 'u':
                    ActorManager.Singleton.Spawn<Tree3>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'O':
                    ActorManager.Singleton.Spawn<Ork>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'r':
                    ActorManager.Singleton.Spawn<Ogre>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'n':
                    ActorManager.Singleton.Spawn<Trapdoor>(position);
                    break;
                case 'N':
                    ActorManager.Singleton.Spawn<Tent>(position);
                    break;
                case 'z':
                    ActorManager.Singleton.Spawn<Bush>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'v':
                    ActorManager.Singleton.Spawn<Wizard>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '-':
                    ActorManager.Singleton.Spawn<Bridge>(position);
                    break;
                case 'Z':
                    ActorManager.Singleton.Spawn<Danger>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '_':
                    ActorManager.Singleton.Spawn<Gate>(position);
                    break;
                case 'k':
                    ActorManager.Singleton.Spawn<Gate2>(position);
                    break;
                case 'l':
                    ActorManager.Singleton.Spawn<Gate3>(position);
                    break;
                case '1':
                    ActorManager.Singleton.Spawn<Shield1>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '3':
                    ActorManager.Singleton.Spawn<Sword1>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '4':
                    ActorManager.Singleton.Spawn<Sword2>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'W':
                    ActorManager.Singleton.Spawn<Water>(position);
                    break;
                case 'w':
                    ActorManager.Singleton.Spawn<Water2>(position);
                    break;
                case 'V':
                    ActorManager.Singleton.Spawn<Water3>(position);
                    break;
                case 'm':
                    ActorManager.Singleton.Spawn<Water4>(position);
                    break;
                case 'Q':
                    ActorManager.Singleton.Spawn<Walter>(position);
                    break;
                case 'E':
                    ActorManager.Singleton.Spawn<Walter2>(position);
                    break;
                case ',':
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 't':
                    ActorManager.Singleton.Spawn<Campfire>(position);
                    break;
                case 'a':
                    ActorManager.Singleton.Spawn<Amulet>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'q':
                    ActorManager.Singleton.Spawn<Armor>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                //2. palya elemek
                case 'x':
                    ActorManager.Singleton.Spawn<Scorpion>(position);
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
                case 'Ő':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'A':
                    ActorManager.Singleton.Spawn<Apple>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'M':
                    ActorManager.Singleton.Spawn<Potion>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'ű':
                    ActorManager.Singleton.Spawn<Ring>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'o':
                    ActorManager.Singleton.Spawn<Bow>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'H':
                    ActorManager.Singleton.Spawn<Heart>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '6':
                    ActorManager.Singleton.Spawn<Shield1>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '2':
                    ActorManager.Singleton.Spawn<Shield2>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'y':
                    ActorManager.Singleton.Spawn<Sword2>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'T':
                    ActorManager.Singleton.Spawn<Fireplace>(position);
                    break;
                case 'Ö':
                    ActorManager.Singleton.Spawn<Armor>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '+':
                    ActorManager.Singleton.Spawn<Armor2>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'ő':
                    ActorManager.Singleton.Spawn<Torch>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'Ü':
                    ActorManager.Singleton.Spawn<Chair>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '8':
                    ActorManager.Singleton.Spawn<IronDoor>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'U':
                    ActorManager.Singleton.Spawn<Table>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '*':
                    ActorManager.Singleton.Spawn<Chair2>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '9':
                    ActorManager.Singleton.Spawn<IronBars>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '0':
                    ActorManager.Singleton.Spawn<BrokenIronBars>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'ú':
                    ActorManager.Singleton.Spawn<Stairs>(position);
                    break;
                case 'é':
                    ActorManager.Singleton.Spawn<Web>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'Ú':
                    ActorManager.Singleton.Spawn<Skull>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                // 3. palya elemek
                case 'g':
                    ActorManager.Singleton.Spawn<Ghoul>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '/':
                    ActorManager.Singleton.Spawn<Knight>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '%':
                    ActorManager.Singleton.Spawn<Priest>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '!':
                    ActorManager.Singleton.Spawn<Demon>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '"':
                    ActorManager.Singleton.Spawn<Soul>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '§':
                    ActorManager.Singleton.Spawn<LastBoss>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '=':
                    ActorManager.Singleton.Spawn<Battleaxe>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'G':
                    ActorManager.Singleton.Spawn<Grave>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '(':
                    ActorManager.Singleton.Spawn<Grave2>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case ')':
                    ActorManager.Singleton.Spawn<House>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'Ó':
                    ActorManager.Singleton.Spawn<House2>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'Ä':
                    ActorManager.Singleton.Spawn<House3>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '7':
                    ActorManager.Singleton.Spawn<IronBars>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case 'j':
                    ActorManager.Singleton.Spawn<IronDoor>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '<':
                    ActorManager.Singleton.Spawn<Road>(position);
                    break;
                case '>':
                    ActorManager.Singleton.Spawn<Road2>(position);
                    break;
                case '@':
                    ActorManager.Singleton.Spawn<Road3>(position);
                    break;
                case '{':
                    ActorManager.Singleton.Spawn<RoadHorizontal>(position);
                    break;
                case 'Ł':
                    ActorManager.Singleton.Spawn<RoadTurn>(position);
                    break;
                case 'ß':
                    ActorManager.Singleton.Spawn<RoadTurn2>(position);
                    break;
                case '×':
                    ActorManager.Singleton.Spawn<Bush2>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case '&':
                    ActorManager.Singleton.Spawn<Helm>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '¤':
                    ActorManager.Singleton.Spawn<Mace>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case '$':
                    ActorManager.Singleton.Spawn<Chest>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'L':
                    ActorManager.Singleton.Spawn<Soul>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'Á':
                    ActorManager.Singleton.Spawn<Knight>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'É':
                    ActorManager.Singleton.Spawn<Priest>(position);
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
                case ' ':
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
