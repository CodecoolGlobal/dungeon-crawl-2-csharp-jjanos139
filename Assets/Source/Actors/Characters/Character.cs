using System;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; private set; }

        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

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
                            ActorManager.Singleton.GetActorAt(targetPosition).DefaultName != "Wall")
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
                            ActorManager.Singleton.GetActorAt(targetPosition).DefaultName != "Wall")
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
                            ActorManager.Singleton.GetActorAt(targetPosition).DefaultName != "Wall")
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
                            ActorManager.Singleton.GetActorAt(targetPosition).DefaultName != "Wall")
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
                            ActorManager.Singleton.GetActorAt(targetPosition).DefaultName != "Wall")
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
                            ActorManager.Singleton.GetActorAt(targetPosition).DefaultName != "Wall")
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
                            ActorManager.Singleton.GetActorAt(targetPosition).DefaultName != "Wall")
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
                            ActorManager.Singleton.GetActorAt(targetPosition).DefaultName != "Wall")
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

        protected bool _isAggro;

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
    }
}
