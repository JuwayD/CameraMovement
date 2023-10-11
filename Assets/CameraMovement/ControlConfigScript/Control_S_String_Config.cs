using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_S_String_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(System.String[]);

    }
}
