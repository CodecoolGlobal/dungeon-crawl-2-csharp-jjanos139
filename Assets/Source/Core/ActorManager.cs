﻿using System;
using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Static;
using UnityEngine;
using UnityEngine.U2D;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Main class for Actor management - spawning, destroying, detecting at positions, etc
    /// </summary>
    public class ActorManager : MonoBehaviour
    {
        /// <summary>
        ///     ActorManager singleton
        /// </summary>
        public static ActorManager Singleton { get; private set; }

        private SpriteAtlas _spriteAtlas;
        private HashSet<Actor> _allActors;
        public bool IsCombat;


        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;

            _allActors = new HashSet<Actor>();
            _spriteAtlas = Resources.Load<SpriteAtlas>("Spritesheet");
            IsCombat = false;
        }

        /// <summary>
        ///     Returns actor present at given position (returns null if no actor is present)
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Actor GetActorAt((int x, int y) position)
        {
            return _allActors.FirstOrDefault(actor => actor.Detectable && actor.Position == position);
        }

        public List<Actor> GetAllActorsAt((int x, int y) position)
        {
            List<Actor> list = new List<Actor>();
            foreach (Actor actor in _allActors)
            {
                if (actor.Position == position)
                    list.Add(actor);
            }
            return list;
        }

        /// <summary>
        ///     Returns actor of specific subclass present at given position (returns null if no actor is present)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <returns></returns>
        public T GetActorAt<T>((int x, int y) position) where T : Actor
        {
            return _allActors.FirstOrDefault(actor =>
                actor.Detectable && actor is T && actor.Position == position) as T;
        }

        /// <summary>
        ///     Unregisters given actor (use when killing/destroying)
        /// </summary>
        /// <param name="actor"></param>
        public void DestroyActor(Actor actor)
        {
            _allActors.Remove(actor);
            Destroy(actor.gameObject);
        }

        /// <summary>
        ///     Used for cleaning up the scene before loading a new map
        /// </summary>
        public void DestroyAllActors()
        {
            var actors = _allActors.ToArray();

            foreach (var actor in actors)
                if (actor.DefaultName != "Player")
                    DestroyActor(actor);
        }

        public void FreezeActualMap(int mapId)
        {
            if (mapId == 1)
            {
                MapLoader.AllActorsFirstMap = _allActors.ToList();
            }
            else if (mapId == 2)
            {
                MapLoader.AllActorsSecondMap = _allActors.ToList(); ;
            }
            else if (mapId == 3)
            {
                MapLoader.AllActorsThirdNMap = _allActors.ToList(); ;
            }
        }

        /// <summary>
        ///     Returns sprite with given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sprite GetSprite(int id)
        {
            return _spriteAtlas.GetSprite($"kenney_transparent_{id}");
        }

        /// <summary>
        ///     Spawns given Actor type at given position
        /// </summary>
        /// <typeparam name="T">Actor type</typeparam>
        /// <param name="position">Position</param>
        /// <param name="actorName">Actor's name (optional)</param>
        /// <returns></returns>
        public T Spawn<T>((int x, int y) position, string actorName = null) where T : Actor
        {
            return Spawn<T>(position.x, position.y, actorName);
        }

        /// <summary>
        ///     Spawns given Actor type at given position
        /// </summary>
        /// <typeparam name="T">Actor type</typeparam>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="actorName">Actor's name (optional)</param>
        /// <returns></returns>
        public T Spawn<T>(int x, int y, string actorName = null) where T : Actor
        {
            var go = new GameObject();
            go.AddComponent<SpriteRenderer>();

            var component = go.AddComponent<T>();

            if (component.GetType() == typeof(Wall))
            {
                BoxCollider2D boxCollider = go.AddComponent<BoxCollider2D>();
                go.layer = 3;
            }

            go.name = actorName ?? component.DefaultName;
            component.Position = (x, y);
            if (component.DefaultName == "Player")
            {
                Rigidbody2D _rigidbody2D = go.AddComponent<Rigidbody2D>();
                _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                _rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            }
            BoxCollider2D _boxCollider2D = go.AddComponent<BoxCollider2D>();
            _boxCollider2D.isTrigger = true;
            _boxCollider2D.size = new Vector2(0.5f, 0.5f);
            _allActors.Add(component);

            return component;
        }

        public Actor GetPlayer()
        {
            foreach (var actor in _allActors)
            {
                if (actor.DefaultName == "Player")
                {
                    return actor;
                }
            }

            throw new Exception("There is no player on the map!");
        }
    }
}
