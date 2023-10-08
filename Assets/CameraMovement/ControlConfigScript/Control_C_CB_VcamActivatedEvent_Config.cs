using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CB_VcamActivatedEvent")]
    public class Control_C_CB_VcamActivatedEvent_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineBrain.VcamActivatedEvent);

    }
}
