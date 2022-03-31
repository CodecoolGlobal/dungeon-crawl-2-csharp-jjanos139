using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Core
{
    public class Pathfinding
    {
        private const int MOVE_STRAIGHT_COST = 10;

        private Grid<PathNode> _grid;
        private List<PathNode> _openList;
        private List<PathNode> _closedList;
        public Pathfinding(int width, int height)
        {
            _grid = new Grid<PathNode>(width, height, (g, x, y) => new PathNode(g, x, y));
        }

        public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
        {
            PathNode startNode = _grid.GetGridObject(startX, startY);   // get own cords?
            PathNode endNode = _grid.GetGridObject(endX, endY);         // get player cords?

            startNode.isWalkable = true;
            endNode.isWalkable = true;

            _openList = new List<PathNode> {startNode};
            _closedList = new List<PathNode>();

            for (int x = 0; x < _grid.GetWidth(); x++)
            {
                for (int y = 0; y < _grid.GetHeight(); y++)
                {
                    PathNode pathNode = _grid.GetGridObject(x, y);
                    pathNode.gCost = int.MaxValue;
                    pathNode.CalculateFCost();
                    pathNode.cameFromNode = null;
                }
            }

            startNode.gCost = 0;
            startNode.hCost = CalculateDistanceCost(startNode, endNode);
            startNode.CalculateFCost();

            while (_openList.Count > 0)
            {
                PathNode currentNode = GetLowesFCostNode(_openList);
                if (currentNode == endNode)
                {
                    // Reached final node
                    return CalculatePath(endNode);
                }

                _openList.Remove(currentNode);
                _closedList.Add(currentNode);

                foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
                {
                    if (_closedList.Contains(neighbourNode)) continue;
                    if (!neighbourNode.isWalkable)
                    {
                        _closedList.Add(neighbourNode);
                        continue;
                    }

                    int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                    if (tentativeGCost < neighbourNode.gCost)
                    {
                        neighbourNode.cameFromNode = currentNode;
                        neighbourNode.gCost = tentativeGCost;
                        neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                        neighbourNode.CalculateFCost();

                        if (!_openList.Contains(neighbourNode))
                        {
                            _openList.Add(neighbourNode);
                        }
                    }
                }
            }

            // Out of nodes on the openList
            return null;
        }

        public Grid<PathNode> GetGrid()
        {
            return _grid;
        }

        // TODO This Cause performance issues! Need optimization!
        //public void UpdateGrid()
        //{
        //    for (int x = 0; x < _grid.GetWidth(); x++)
        //    {
        //        for (int y = 0; y < _grid.GetHeight(); y++)
        //        {
        //            _grid.GetGridObject(x, y).UpdateIsWalkable();
        //        }
        //    }
        //}

        private List<PathNode> GetNeighbourList(PathNode currentNode)
        {
            List<PathNode> neighbourList = new List<PathNode>();
            // Left
            if (currentNode.x - 1 >= 0) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));
            // Right
            if (currentNode.x + 1 < _grid.GetWidth()) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));
            // Down --------------------------------------------------------------------------------------------------------------------( + / - )------
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1));
            // Up ----------------------------------------------------------------------------------------------------------------------( + / - )------
            if (currentNode.y + 1 < _grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1));

            return neighbourList;
        }

        private PathNode GetNode(int x, int y)
        {
            return _grid.GetGridObject(x, y);
        }

        private List<PathNode> CalculatePath(PathNode endNode)
        {
            List<PathNode> path = new List<PathNode>();
            path.Add(endNode);
            PathNode currentNode = endNode;
            while (currentNode.cameFromNode != null)
            {
                path.Add(currentNode.cameFromNode);
                currentNode = currentNode.cameFromNode;
            }

            path.Reverse();
            return path;
        }

        private int CalculateDistanceCost(PathNode a, PathNode b)
        {
            int xDistance = Mathf.Abs(a.x - b.x);
            int yDistance = Mathf.Abs(a.y - b.y);
            int remaining = xDistance + yDistance;
            return MOVE_STRAIGHT_COST * remaining;
        }

        private PathNode GetLowesFCostNode(List<PathNode> pathNodeList)
        {
            PathNode lowestFCostNode = pathNodeList[0];
            for (int i = 0; i < pathNodeList.Count; i++)
            {
                if (pathNodeList[i].fCost < lowestFCostNode.fCost)
                {
                    lowestFCostNode = pathNodeList[i];
                }
            }

            return lowestFCostNode;
        }
    }
}
