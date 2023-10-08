using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CC_Stage")]
    public class Control_C_CC_Stage_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineCore.Stage);

        public ConfigItem <System.Int32> value__;
    }
}
