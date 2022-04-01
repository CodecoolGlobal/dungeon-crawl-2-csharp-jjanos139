using System;
using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {


        protected void CheckIfAggro((int x, int y) playerCoords, int agroRange, int loseAgroRange)
        {
            var monsterPos = new Vector3(Position.x, Position.y, Z);
            var playerPos = new Vector3(playerCoords.x, playerCoords.y, Z);
            float dist = Vector3.Distance(monsterPos, playerPos);
            if (!_isAggro && dist <= agroRange)
            {
                _isAggro = true;
            }
            else if (_isAggro && dist >= loseAgroRange)
            {
                _isAggro = false;
            }
        }

        protected (int, int ) PathFind((int x, int y) playerCoords)
        {
            //PathFinding.UpdateGrid();     // TODO This Cause performance issues! Need optimization!
            List<PathNode> path = MapLoader.PathFinding.FindPath(Position.x, Position.y + MapLoader.CurrentMapHeight, playerCoords.x, playerCoords.y + MapLoader.CurrentMapHeight);
            if (path != null && path.Count > 1)
            {
                return (path[1].x, path[1].y - MapLoader.CurrentMapHeight);
            }

            return (0, 0);
        }

        protected Direction GetMoveDirection((int x, int y) playerCoords)
        {

            //------------------------------------------------------------------------------------------------------------------
            if (playerCoords.x - Position.x >= 0)
            {
                if (playerCoords.y - Position.y >= 0)
                {

                    if (Math.Abs(playerCoords.x - Position.x) >= Math.Abs(playerCoords.y - Position.y))
                    {
                        (int x, int y) targetPosition = (Position.x + 1, Position.y);
                        if (ActorManager.Singleton.GetActorAt(targetPosition) is null ||
                            ActorManager.Singleton.GetActorAt(targetPosition).OnCollision(this))
                        {
                            return Direction.Right;
                        }
                        else
                        {
                            return Direction.Up;
                        }
                    }
                    else
                    {
                        (int x, int y) targetPosition = (Position.x, Position.y + 1);
                        if (ActorManager.Singleton.GetActorAt(targetPosition) is null ||
                            ActorManager.Singleton.GetActorAt(targetPosition).OnCollision(this))
                        {
                            return Direction.Up;
                        }
                        else
                        {
                            return Direction.Right;
                        }
                    }
                }//-------------------------------------------------------------------------------------------------------------
                else if (playerCoords.y - Position.y < 0)
                {
                    
                    if (Math.Abs(playerCoords.x - Position.x) >= Math.Abs(playerCoords.y - Position.y))
                    {
                        (int x, int y) targetPosition = (Position.x + 1, Position.y);
                        if (ActorManager.Singleton.GetActorAt(targetPosition) is null ||
                            ActorManager.Singleton.GetActorAt(targetPosition).OnCollision(this))
                        {
                            return Direction.Right;
                        }
                        else
                        {
                            return Direction.Down;
                        }
                    }
                    else
                    {
                        (int x, int y) targetPosition = (Position.x, Position.y - 1);
                        if (ActorManager.Singleton.GetActorAt(targetPosition) is null ||
                            ActorManager.Singleton.GetActorAt(targetPosition).OnCollision(this))
                        {
                            return Direction.Down;
                        }
                        else
                        {
                            return Direction.Right;
                        }
                    }
                }
            }//-----------------------------------------------------------------------------------------------------------------
            else if (playerCoords.x - Position.x < 0)
            {
                if (playerCoords.y - Position.y >= 0)
                {
                    if (Math.Abs(playerCoords.x - Position.x) >= Math.Abs(playerCoords.y - Position.y))
                    {
                        (int x, int y) targetPosition = (Position.x - 1, Position.y);
                        if (ActorManager.Singleton.GetActorAt(targetPosition) is null ||
                            ActorManager.Singleton.GetActorAt(targetPosition).OnCollision(this))
                        {
                            return Direction.Left;
                        }
                        else
                        {
                            return Direction.Up;
                        }
                    }
                    else
                    {
                        (int x, int y) targetPosition = (Position.x, Position.y + 1);
                        if (ActorManager.Singleton.GetActorAt(targetPosition) is null ||
                            ActorManager.Singleton.GetActorAt(targetPosition).OnCollision(this))
                        {
                            return Direction.Up;
                        }
                        else
                        {
                            return Direction.Left;
                        }
                    }
                }//-------------------------------------------------------------------------------------------------------------
                else if (playerCoords.y - Position.y < 0)
                {

                    if (Math.Abs(playerCoords.x - Position.x) >= Math.Abs(playerCoords.y - Position.y))
                    {
                        (int x, int y) targetPosition = (Position.x - 1, Position.y);
                        if (ActorManager.Singleton.GetActorAt(targetPosition) is null ||
                            ActorManager.Singleton.GetActorAt(targetPosition).OnCollision(this))
                        {
                            return Direction.Left;
                        }
                        else
                        {
                            return Direction.Down;
                        }
                    }
                    else
                    {
                        (int x, int y) targetPosition = (Position.x, Position.y - 1);
                        if (ActorManager.Singleton.GetActorAt(targetPosition) is null ||
                            ActorManager.Singleton.GetActorAt(targetPosition).OnCollision(this))
                        {
                            return Direction.Down;
                        }
                        else
                        {
                            return Direction.Left;
                        }
                    }
                }
            }//-----------------------------------------------------------------------------------------------------------------

            throw new Exception("Where on earth  is that drone?");
        }

        protected bool InCombat;
        protected bool _isAggro;
        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
        
        public override char DefaultChar => 'p';
    }
    
}
