using Cinemachine;
using UnityEngine;

namespace CameraMovement
{
    /// <summary>
    /// 最基础的三环相机
    /// </summary>
    public class CameraMovementStateFreeLook: CameraMovementStateBase
    {
        
        
        protected override void OnInit(GameObject go, CameraMovementConfigState configState, CameraMovementStateMachine machine)
        {
            var a = go.GetComponent<CinemachineFreeLook>();
        }

        public override void OnExit(CameraMovementStateBase toState)
        {
        }

        public override void OnEnter(CameraMovementStateBase fromState)
        {
        }
    }
}