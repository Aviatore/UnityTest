using System;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        public GameObject canvas;
        public GameObject player;
        public GameObject pointWidgetS;
        public GameObject pointWidgetM;
        public GameObject pointWidgetL;
        public GameObject pointWidgetXl;
        public GameObject chip;
        public GameObject playerBullet;
        public GameObject muzzleFlashContainer;
        public GameObject droneBullet;
        public GameObject explosionDrone;
        public GameObject firstAidKitBiohazard;
        public GameObject firstAidKitGreen;
        public GameObject firstAidKitRed;
        public GameObject firstAidKitWhite;
        public GameObject drone;
        public GameObject superDrone;
        public GameObject megaDrone;

        private List<Vector3> _drones;
        private List<Vector3> _superDrones;
        private List<Vector3> _megaDrones;

        private Random _random;
        
        public void Awake()
        {
            player.transform.position = new Vector3(2.27f, 0.8f, 0.4f);

            var newPlayer = Instantiate(player, player.transform.position, Quaternion.identity);
            newPlayer.transform.Rotate(Vector3.up, 90.0f);
            
            CameraController cameraBoxScript = GameObject.FindGameObjectWithTag("CameraBox").GetComponent<CameraController>();
            cameraBoxScript.Player = newPlayer.transform;

            DroneController droneController = drone.GetComponent<DroneController>();
            droneController.canvas = canvas.GetComponent<Canvas>();
            SpawnDrones();
        }

        private void SpawnDrones()
        {
            List<Vector3> positions = new List<Vector3>()
            {
                new Vector3(24.8f, 2.7f, 0.0f),
                //new Vector3(0.29f, 1.75f, 0.0f),
                //new Vector3(1.57f, 1.75f, 0.0f),
                //new Vector3(2.83f, 1.75f, 0.0f),
            };

            List<GameObjectPosition> positions2 = new List<GameObjectPosition>();
            GameObjectPosition drone1 = new GameObjectPosition(new Vector3(0.29f, 1.75f, 0.0f));
            drone1.AddParent("BridgeS01");
            
            positions2.Add(drone1);

            GameObjectPosition[] ppp = new GameObjectPosition[3];
            foreach (var element in ppp)
            {
                
            }

            foreach (var position in positions)
            {
                var newDrone = Instantiate(drone, position, Quaternion.identity);
            }
        }
        
        private class GameObjectPosition
        {
            public Vector3 Position { get; }
            private List<string> _parents;
            
            public GameObjectPosition(Vector3 position)
            {
                _parents = new List<string>();
                Position = position;
            }

            public void AddParent(string parent)
            {
                _parents.Add(parent);
            }
        }

        /*private void SpawnDrones(int droneNumber)
        {
            List<Position> positions = new List<Position>()
            {
                new Position(18, 27, 3),
                new Position(30, 33, 3),
                new Position(36, 42, 4),
            };
            
            for (int i = 0; i < droneNumber; i++)
            {
                int position = _random.Next(0, positions.Count);
                
                
            }
        }
        
        private struct Position
        {
            public int StartX { get; }
            public int StopX { get; }
            public int ConstY { get; }

            public Position(int start, int stop, int con)
            {
                StartX = start;
                StopX = stop;
                ConstY = con;
            }
        }*/
    }
}