using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_Cinemachine3rdPersonAim_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.Cinemachine3rdPersonAim);

       [UnityEngine.TooltipAttribute("Objects with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public ConfigItem <System.String> IgnoreTag;
       [UnityEngine.TooltipAttribute("How far to project the object detection ray")]
            public ConfigItem <System.Single> AimDistance;
    }
}
