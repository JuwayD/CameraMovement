using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineBlenderSettings")]
    public class Control_C_CinemachineBlenderSettings_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineBlenderSettings);

       [UnityEngine.TooltipAttribute("The array containing explicitly defined blends between two Virtual Cameras")]
        public Control_C_CBS_CustomBlend_Config[] m_CustomBlends;
    }
}
