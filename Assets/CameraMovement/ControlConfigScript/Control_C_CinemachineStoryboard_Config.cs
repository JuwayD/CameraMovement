using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    [CreateAssetMenu(menuName = "创建C_CinemachineStoryboard")]
    public class Control_C_CinemachineStoryboard_Config :CameraMovementControlConfigBase
    {
       public override Type AttachControlField => typeof(Cinemachine.CinemachineStoryboard);

       [UnityEngine.TooltipAttribute("If checked, the specified image will be displayed as an overlay over the virtual camera's output")]
            public ConfigItem <System.Boolean> m_ShowImage;
       [UnityEngine.TooltipAttribute("How to handle differences between image aspect and screen aspect")]
            public ConfigItem <Cinemachine.CinemachineStoryboard.FillStrategy> m_Aspect;
       [UnityEngine.TooltipAttribute("The opacity of the image.  0 is transparent, 1 is opaque")]
            public ConfigItem <System.Single> m_Alpha;
       [UnityEngine.TooltipAttribute("The screen-space rotation to apply to the image")]
            public ConfigItem <UnityEngine.Vector3> m_Rotation;
       [UnityEngine.TooltipAttribute("If checked, X and Y scale are synchronized")]
            public ConfigItem <System.Boolean> m_SyncScale;
       [UnityEngine.TooltipAttribute("If checked, Camera transform will not be controlled by this virtual camera")]
            public ConfigItem <System.Boolean> m_MuteCamera;
       [UnityEngine.TooltipAttribute("Wipe the image on and off horizontally")]
            public ConfigItem <System.Single> m_SplitView;
       [UnityEngine.TooltipAttribute("The render mode of the canvas on which the storyboard is drawn.")]
            public ConfigItem <Cinemachine.CinemachineStoryboard.StoryboardRenderMode> m_RenderMode;
       [UnityEngine.TooltipAttribute("Allows ordering canvases to render on top or below other canvases.")]
            public ConfigItem <System.Int32> m_SortingOrder;
       [UnityEngine.TooltipAttribute("How far away from the camera is the Canvas generated.")]
            public ConfigItem <System.Single> m_PlaneDistance;
    }
}
