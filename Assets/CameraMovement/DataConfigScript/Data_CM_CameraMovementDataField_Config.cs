using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Data_CM_CameraMovementDataField_Config :CameraMovementDataConfigBase
    {
       public override Type AttachDataField => typeof(CameraMovement.CameraMovementDataField);

       [UnityEngine.TooltipAttribute("牛逼")]
            public ConfigItem <System.Single> ZoomMax;
       [UnityEngine.TooltipAttribute("牛逼")]
            public ConfigItem <System.Single> curZoom;
    }
}
