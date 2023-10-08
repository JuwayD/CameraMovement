using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建S_String")]
    public class Control_S_String_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(System.String);

    }
}
