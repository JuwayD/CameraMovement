using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_PFX_CinemachinePostProcessing_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.PostFX.CinemachinePostProcessing);

    }
}
