using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineStoryboard_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineStoryboard);

       [UnityEngine.TooltipAttribute("If checked, the specified image will be displayed as an overlay over the virtual camera's output")]
            public DataMixer <System.Boolean> m_ShowImage;
       [UnityEngine.TooltipAttribute("How to handle differences between image aspect and screen aspect")]
            public DataMixer <Cinemachine.CinemachineStoryboard.FillStrategy> m_Aspect;
       [UnityEngine.TooltipAttribute("The opacity of the image.  0 is transparent, 1 is opaque")]
            public DataMixer <System.Single> m_Alpha;
       [UnityEngine.TooltipAttribute("The screen-space rotation to apply to the image")]
            public DataMixer <UnityEngine.Vector3> m_Rotation;
       [UnityEngine.TooltipAttribute("If checked, X and Y scale are synchronized")]
            public DataMixer <System.Boolean> m_SyncScale;
       [UnityEngine.TooltipAttribute("If checked, Camera transform will not be controlled by this virtual camera")]
            public DataMixer <System.Boolean> m_MuteCamera;
       [UnityEngine.TooltipAttribute("Wipe the image on and off horizontally")]
            public DataMixer <System.Single> m_SplitView;
       [UnityEngine.TooltipAttribute("The render mode of the canvas on which the storyboard is drawn.")]
            public DataMixer <Cinemachine.CinemachineStoryboard.StoryboardRenderMode> m_RenderMode;
       [UnityEngine.TooltipAttribute("Allows ordering canvases to render on top or below other canvases.")]
            public DataMixer <System.Int32> m_SortingOrder;
       [UnityEngine.TooltipAttribute("How far away from the camera is the Canvas generated.")]
            public DataMixer <System.Single> m_PlaneDistance;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineStoryboard_Config source = (CameraMovement.Control_C_CinemachineStoryboard_Config)sourceConfig;
            if(source.m_ShowImage.IsUse) m_ShowImage.Add(new MixItem<System.Boolean>(id, priority, source.m_ShowImage.CalculatorExpression, source.m_ShowImage.Value));
            if(source.m_Aspect.IsUse) m_Aspect.Add(new MixItem<Cinemachine.CinemachineStoryboard.FillStrategy>(id, priority, source.m_Aspect.CalculatorExpression, source.m_Aspect.Value));
            if(source.m_Alpha.IsUse) m_Alpha.Add(new MixItem<System.Single>(id, priority, source.m_Alpha.CalculatorExpression, source.m_Alpha.Value));
            if(source.m_Rotation.IsUse) m_Rotation.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_Rotation.CalculatorExpression, source.m_Rotation.Value));
            if(source.m_SyncScale.IsUse) m_SyncScale.Add(new MixItem<System.Boolean>(id, priority, source.m_SyncScale.CalculatorExpression, source.m_SyncScale.Value));
            if(source.m_MuteCamera.IsUse) m_MuteCamera.Add(new MixItem<System.Boolean>(id, priority, source.m_MuteCamera.CalculatorExpression, source.m_MuteCamera.Value));
            if(source.m_SplitView.IsUse) m_SplitView.Add(new MixItem<System.Single>(id, priority, source.m_SplitView.CalculatorExpression, source.m_SplitView.Value));
            if(source.m_RenderMode.IsUse) m_RenderMode.Add(new MixItem<Cinemachine.CinemachineStoryboard.StoryboardRenderMode>(id, priority, source.m_RenderMode.CalculatorExpression, source.m_RenderMode.Value));
            if(source.m_SortingOrder.IsUse) m_SortingOrder.Add(new MixItem<System.Int32>(id, priority, source.m_SortingOrder.CalculatorExpression, source.m_SortingOrder.Value));
            if(source.m_PlaneDistance.IsUse) m_PlaneDistance.Add(new MixItem<System.Single>(id, priority, source.m_PlaneDistance.CalculatorExpression, source.m_PlaneDistance.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineStoryboard_Config source = (CameraMovement.Control_C_CinemachineStoryboard_Config)sourceConfig;
            if(source.m_ShowImage.IsUse) m_ShowImage.Remove(new MixItem<System.Boolean>(id, priority, source.m_ShowImage.CalculatorExpression, source.m_ShowImage.Value));
            if(source.m_Aspect.IsUse) m_Aspect.Remove(new MixItem<Cinemachine.CinemachineStoryboard.FillStrategy>(id, priority, source.m_Aspect.CalculatorExpression, source.m_Aspect.Value));
            if(source.m_Alpha.IsUse) m_Alpha.Remove(new MixItem<System.Single>(id, priority, source.m_Alpha.CalculatorExpression, source.m_Alpha.Value));
            if(source.m_Rotation.IsUse) m_Rotation.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_Rotation.CalculatorExpression, source.m_Rotation.Value));
            if(source.m_SyncScale.IsUse) m_SyncScale.Remove(new MixItem<System.Boolean>(id, priority, source.m_SyncScale.CalculatorExpression, source.m_SyncScale.Value));
            if(source.m_MuteCamera.IsUse) m_MuteCamera.Remove(new MixItem<System.Boolean>(id, priority, source.m_MuteCamera.CalculatorExpression, source.m_MuteCamera.Value));
            if(source.m_SplitView.IsUse) m_SplitView.Remove(new MixItem<System.Single>(id, priority, source.m_SplitView.CalculatorExpression, source.m_SplitView.Value));
            if(source.m_RenderMode.IsUse) m_RenderMode.Remove(new MixItem<Cinemachine.CinemachineStoryboard.StoryboardRenderMode>(id, priority, source.m_RenderMode.CalculatorExpression, source.m_RenderMode.Value));
            if(source.m_SortingOrder.IsUse) m_SortingOrder.Remove(new MixItem<System.Int32>(id, priority, source.m_SortingOrder.CalculatorExpression, source.m_SortingOrder.Value));
            if(source.m_PlaneDistance.IsUse) m_PlaneDistance.Remove(new MixItem<System.Single>(id, priority, source.m_PlaneDistance.CalculatorExpression, source.m_PlaneDistance.Value));
        }
        public void RemoveAll()
        {
            m_ShowImage.RemoveAll();
            m_Aspect.RemoveAll();
            m_Alpha.RemoveAll();
            m_Rotation.RemoveAll();
            m_SyncScale.RemoveAll();
            m_MuteCamera.RemoveAll();
            m_SplitView.RemoveAll();
            m_RenderMode.RemoveAll();
            m_SortingOrder.RemoveAll();
            m_PlaneDistance.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineStoryboard)targetObj;
            target.m_ShowImage = !Mathf.Approximately(m_ShowImage.Value, 0);
            target.m_Aspect = (Cinemachine.CinemachineStoryboard.FillStrategy)m_Aspect.Value;
            if (templateDict.ContainsKey(m_Alpha.Id))
                target.m_Alpha = templateDict[m_Alpha.Id].Config.alertCurve.Evaluate(templateDict[m_Alpha.Id].CostTime / templateDict[m_Alpha.Id].Config.duration) * m_Alpha.Value;
            target.m_Alpha = (System.Single)m_Alpha.Value;
            target.m_SyncScale = !Mathf.Approximately(m_SyncScale.Value, 0);
            target.m_MuteCamera = !Mathf.Approximately(m_MuteCamera.Value, 0);
            if (templateDict.ContainsKey(m_SplitView.Id))
                target.m_SplitView = templateDict[m_SplitView.Id].Config.alertCurve.Evaluate(templateDict[m_SplitView.Id].CostTime / templateDict[m_SplitView.Id].Config.duration) * m_SplitView.Value;
            target.m_SplitView = (System.Single)m_SplitView.Value;
            target.m_RenderMode = (Cinemachine.CinemachineStoryboard.StoryboardRenderMode)m_RenderMode.Value;
            target.m_SortingOrder = (System.Int32)m_SortingOrder.Value;
            if (templateDict.ContainsKey(m_PlaneDistance.Id))
                target.m_PlaneDistance = templateDict[m_PlaneDistance.Id].Config.alertCurve.Evaluate(templateDict[m_PlaneDistance.Id].CostTime / templateDict[m_PlaneDistance.Id].Config.duration) * m_PlaneDistance.Value;
            target.m_PlaneDistance = (System.Single)m_PlaneDistance.Value;
        }
    }
}
