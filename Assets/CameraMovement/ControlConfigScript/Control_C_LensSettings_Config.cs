using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_LensSettings_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.LensSettings);

       [UnityEngine.TooltipAttribute("This is the camera view in degrees. Display will be in vertical degress, unless the associated camera has its FOV axis setting set to Horizontal, in which case display will be in horizontal degress.  Internally, it is always vertical degrees.  For cinematic people, a 50mm lens on a super-35mm sensor would equal a 19.6 degree FOV")]
            public ConfigItem <System.Single> FieldOfView;
       [UnityEngine.TooltipAttribute("When using an orthographic camera, this defines the half-height, in world coordinates, of the camera view.")]
            public ConfigItem <System.Single> OrthographicSize;
       [UnityEngine.TooltipAttribute("This defines the near region in the renderable range of the camera frustum. Raising this value will stop the game from drawing things near the camera, which can sometimes come in handy.  Larger values will also increase your shadow resolution.")]
            public ConfigItem <System.Single> NearClipPlane;
       [UnityEngine.TooltipAttribute("This defines the far region of the renderable range of the camera frustum. Typically you want to set this value as low as possible without cutting off desired distant objects")]
            public ConfigItem <System.Single> FarClipPlane;
       [UnityEngine.TooltipAttribute("Camera Z roll, or tilt, in degrees.")]
            public ConfigItem <System.Single> Dutch;
       [UnityEngine.TooltipAttribute("Allows you to select a different camera mode to apply to the Camera component when Cinemachine activates this Virtual Camera.  The changes applied to the Camera component through this setting will remain after the Virtual Camera deactivation.")]
            public ConfigItem <Cinemachine.LensSettings.OverrideModes> ModeOverride;
        public ConfigItem <UnityEngine.Camera.GateFitMode> GateFit;
        public ConfigItem <System.Single> FocusDistance;
    }
}
