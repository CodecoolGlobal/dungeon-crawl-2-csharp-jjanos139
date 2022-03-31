using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors.Static;
using DungeonCrawl.Core;
using UnityEngine;

namespace Assets.Source.Core
{
    public class PathNode
    {
        private Grid<PathNode> grid;
        public int x;
        public int y;

        public int gCost;
        public int hCost;
        public int fCost;

        public bool isWalkable;
        public PathNode cameFromNode;

        public PathNode(Grid<PathNode> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            UpdateIsWalkable();
        }

        public void UpdateIsWalkable()
        {
            var actorsAtPathNode = ActorManager.Singleton.GetAllActorsAt((x, y - MapLoader.CurrentMapHeight));

            if (actorsAtPathNode.Count > 0)
            {
                int walkable = 0;
                foreach (var actor in actorsAtPathNode)
                {
                    if (!actor.IsWalkable)
                        walkable++;
                }

                if (walkable == 0)
                    isWalkable = true;
                else
                    isWalkable = false;
            }
            else isWalkable = false;
        }

        public void CalculateFCost()
        {
            fCost = gCost + hCost;
        }
    }
}
