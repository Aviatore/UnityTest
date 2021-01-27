using System.Collections.Generic;
using System.Text;
using DefaultNamespace;
using UnityEngine;

namespace Spawner
{
    public class MegaDroneData : GameObjectData
    {
        private float _shotTimeRangeFrom;
        private float _shotTimeRangeTo;
        private int _hitPoints;
        private float _maxMoveY;
        private float _moveSpeed;
        private float _maxMoveX;

        private MegaDroneController _megaDroneController;
        
        public MegaDroneData(GameObject drone, Vector3 position, List<string> parents, float shotTimeRangeFrom,
            float shotTimeRangeTo, int hitPoints, float maxMoveY, float moveSpeed, float maxMoveX) : base(drone, position, parents)
        {
            _megaDroneController = drone.GetComponent<MegaDroneController>();
            
            _shotTimeRangeFrom = shotTimeRangeFrom;
            _shotTimeRangeTo = shotTimeRangeTo;
            _hitPoints = hitPoints;
            _maxMoveY = maxMoveY;
            _moveSpeed = moveSpeed;
            _maxMoveX = maxMoveX;
        }
        
        public override void UpdateGoData()
        {
            _megaDroneController.shootTimeRangeFrom = _shotTimeRangeFrom;
            _megaDroneController.shootTimeRangeTo = _shotTimeRangeTo;
            _megaDroneController.hitPoints = _hitPoints;
            _megaDroneController.maxMoveY = _maxMoveY;
            _megaDroneController.moveSpeed = _moveSpeed;
            _megaDroneController.maxMoveX = _maxMoveX;
        }
        
        public static (Vector3, float, float, int, float, float, float) GetMegaDroneParameters(Transform megaDrone)
        {
            MegaDroneController megaDroneController = megaDrone.gameObject.GetComponent<MegaDroneController>();
            
            Vector3 position = megaDrone.position;
            float shotTimeRangeFrom = megaDroneController.shootTimeRangeFrom;
            float shotTimeRangeTo = megaDroneController.shootTimeRangeTo;
            int hitPoints = megaDroneController.hitPoints;
            float maxMoveY = megaDroneController.maxMoveY;
            float moveSpeed = megaDroneController.moveSpeed;
            float maxMoveX = megaDroneController.maxMoveX;

            return (position, shotTimeRangeFrom, shotTimeRangeTo, hitPoints, maxMoveY, moveSpeed, maxMoveX);
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append($"Object name: {Go.name}; ");
            sb.Append($"ShotTimeRangeFrom: {_shotTimeRangeFrom.ToString()}; ");
            sb.Append($"ShotTimeRangeTo: {_shotTimeRangeTo.ToString()}; ");
            sb.Append($"HitPoints: {_hitPoints.ToString()}; ");
            sb.Append($"MaxMoveY: {_maxMoveY.ToString()}; ");
            sb.Append($"MoveSpeed: {_moveSpeed.ToString()}; ");
            sb.Append($"MaxMoveX: {_maxMoveX.ToString()}; ");

            return sb.ToString();
        }
    }
}