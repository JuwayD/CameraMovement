using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineComposer_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineComposer);

       [UnityEngine.TooltipAttribute("Target offset from the target object's center in target-local space. Use this to fine-tune the tracking target position when the desired area is not the tracked object's center.")]
            public DataMixer <UnityEngine.Vector3> m_TrackedObjectOffset;
       [UnityEngine.TooltipAttribute("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
            public DataMixer <System.Single> m_LookaheadTime;
       [UnityEngine.TooltipAttribute("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
            public DataMixer <System.Single> m_LookaheadSmoothing;
       [UnityEngine.TooltipAttribute("If checked, movement along the Y axis will be ignored for lookahead calculations")]
            public DataMixer <System.Boolean> m_LookaheadIgnoreY;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to follow the target in the screen-horizontal direction. Small numbers are more responsive, rapidly orienting the camera to keep the target in the dead zone. Larger numbers give a more heavy slowly responding camera. Using different vertical and horizontal settings can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_HorizontalDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to follow the target in the screen-vertical direction. Small numbers are more responsive, rapidly orienting the camera to keep the target in the dead zone. Larger numbers give a more heavy slowly responding camera. Using different vertical and horizontal settings can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_VerticalDamping;
       [UnityEngine.TooltipAttribute("Horizontal screen position for target. The camera will rotate to position the tracked object here.")]
            public DataMixer <System.Single> m_ScreenX;
       [UnityEngine.TooltipAttribute("Vertical screen position for target, The camera will rotate to position the tracked object here.")]
            public DataMixer <System.Single> m_ScreenY;
       [UnityEngine.TooltipAttribute("Camera will not rotate horizontally if the target is within this range of the position.")]
            public DataMixer <System.Single> m_DeadZoneWidth;
       [UnityEngine.TooltipAttribute("Camera will not rotate vertically if the target is within this range of the position.")]
            public DataMixer <System.Single> m_DeadZoneHeight;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually rotate horizontally to re-align towards the desired position, depending on the damping speed.")]
            public DataMixer <System.Single> m_SoftZoneWidth;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually rotate vertically to re-align towards the desired position, depending on the damping speed.")]
            public DataMixer <System.Single> m_SoftZoneHeight;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
            public DataMixer <System.Single> m_BiasX;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
            public DataMixer <System.Single> m_BiasY;
       [UnityEngine.TooltipAttribute("Force target to center of screen when this camera activates.  If false, will clamp target to the edges of the dead zone")]
            public DataMixer <System.Boolean> m_CenterOnActivate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineComposer_Config source = (CameraMovement.Control_C_CinemachineComposer_Config)sourceConfig;
            if(source.m_TrackedObjectOffset.IsUse) m_TrackedObjectOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.Value));
            if(source.m_LookaheadTime.IsUse) m_LookaheadTime.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.Value));
            if(source.m_LookaheadSmoothing.IsUse) m_LookaheadSmoothing.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.Value));
            if(source.m_LookaheadIgnoreY.IsUse) m_LookaheadIgnoreY.Add(new MixItem<System.Boolean>(id, priority, source.m_LookaheadIgnoreY.Value));
            if(source.m_HorizontalDamping.IsUse) m_HorizontalDamping.Add(new MixItem<System.Single>(id, priority, source.m_HorizontalDamping.Value));
            if(source.m_VerticalDamping.IsUse) m_VerticalDamping.Add(new MixItem<System.Single>(id, priority, source.m_VerticalDamping.Value));
            if(source.m_ScreenX.IsUse) m_ScreenX.Add(new MixItem<System.Single>(id, priority, source.m_ScreenX.Value));
            if(source.m_ScreenY.IsUse) m_ScreenY.Add(new MixItem<System.Single>(id, priority, source.m_ScreenY.Value));
            if(source.m_DeadZoneWidth.IsUse) m_DeadZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.Value));
            if(source.m_DeadZoneHeight.IsUse) m_DeadZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.Value));
            if(source.m_SoftZoneWidth.IsUse) m_SoftZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.Value));
            if(source.m_SoftZoneHeight.IsUse) m_SoftZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.Value));
            if(source.m_BiasX.IsUse) m_BiasX.Add(new MixItem<System.Single>(id, priority, source.m_BiasX.Value));
            if(source.m_BiasY.IsUse) m_BiasY.Add(new MixItem<System.Single>(id, priority, source.m_BiasY.Value));
            if(source.m_CenterOnActivate.IsUse) m_CenterOnActivate.Add(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineComposer_Config source = (CameraMovement.Control_C_CinemachineComposer_Config)sourceConfig;
            if(source.m_TrackedObjectOffset.IsUse) m_TrackedObjectOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.Value));
            if(source.m_LookaheadTime.IsUse) m_LookaheadTime.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.Value));
            if(source.m_LookaheadSmoothing.IsUse) m_LookaheadSmoothing.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.Value));
            if(source.m_LookaheadIgnoreY.IsUse) m_LookaheadIgnoreY.Remove(new MixItem<System.Boolean>(id, priority, source.m_LookaheadIgnoreY.Value));
            if(source.m_HorizontalDamping.IsUse) m_HorizontalDamping.Remove(new MixItem<System.Single>(id, priority, source.m_HorizontalDamping.Value));
            if(source.m_VerticalDamping.IsUse) m_VerticalDamping.Remove(new MixItem<System.Single>(id, priority, source.m_VerticalDamping.Value));
            if(source.m_ScreenX.IsUse) m_ScreenX.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenX.Value));
            if(source.m_ScreenY.IsUse) m_ScreenY.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenY.Value));
            if(source.m_DeadZoneWidth.IsUse) m_DeadZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.Value));
            if(source.m_DeadZoneHeight.IsUse) m_DeadZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.Value));
            if(source.m_SoftZoneWidth.IsUse) m_SoftZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.Value));
            if(source.m_SoftZoneHeight.IsUse) m_SoftZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.Value));
            if(source.m_BiasX.IsUse) m_BiasX.Remove(new MixItem<System.Single>(id, priority, source.m_BiasX.Value));
            if(source.m_BiasY.IsUse) m_BiasY.Remove(new MixItem<System.Single>(id, priority, source.m_BiasY.Value));
            if(source.m_CenterOnActivate.IsUse) m_CenterOnActivate.Remove(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineComposer)targetObj;
            if (templateDict.ContainsKey(m_LookaheadTime.Id))
                target.m_LookaheadTime = templateDict[m_LookaheadTime.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadTime.Id].CostTime / templateDict[m_LookaheadTime.Id].Config.duration);
            target.m_LookaheadTime = m_LookaheadTime.Value;
            if (templateDict.ContainsKey(m_LookaheadSmoothing.Id))
                target.m_LookaheadSmoothing = templateDict[m_LookaheadSmoothing.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadSmoothing.Id].CostTime / templateDict[m_LookaheadSmoothing.Id].Config.duration);
            target.m_LookaheadSmoothing = m_LookaheadSmoothing.Value;
            target.m_LookaheadIgnoreY = m_LookaheadIgnoreY.Value;
            if (templateDict.ContainsKey(m_HorizontalDamping.Id))
                target.m_HorizontalDamping = templateDict[m_HorizontalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_HorizontalDamping.Id].CostTime / templateDict[m_HorizontalDamping.Id].Config.duration);
            target.m_HorizontalDamping = m_HorizontalDamping.Value;
            if (templateDict.ContainsKey(m_VerticalDamping.Id))
                target.m_VerticalDamping = templateDict[m_VerticalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_VerticalDamping.Id].CostTime / templateDict[m_VerticalDamping.Id].Config.duration);
            target.m_VerticalDamping = m_VerticalDamping.Value;
            if (templateDict.ContainsKey(m_ScreenX.Id))
                target.m_ScreenX = templateDict[m_ScreenX.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenX.Id].CostTime / templateDict[m_ScreenX.Id].Config.duration);
            target.m_ScreenX = m_ScreenX.Value;
            if (templateDict.ContainsKey(m_ScreenY.Id))
                target.m_ScreenY = templateDict[m_ScreenY.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenY.Id].CostTime / templateDict[m_ScreenY.Id].Config.duration);
            target.m_ScreenY = m_ScreenY.Value;
            if (templateDict.ContainsKey(m_DeadZoneWidth.Id))
                target.m_DeadZoneWidth = templateDict[m_DeadZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneWidth.Id].CostTime / templateDict[m_DeadZoneWidth.Id].Config.duration);
            target.m_DeadZoneWidth = m_DeadZoneWidth.Value;
            if (templateDict.ContainsKey(m_DeadZoneHeight.Id))
                target.m_DeadZoneHeight = templateDict[m_DeadZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneHeight.Id].CostTime / templateDict[m_DeadZoneHeight.Id].Config.duration);
            target.m_DeadZoneHeight = m_DeadZoneHeight.Value;
            if (templateDict.ContainsKey(m_SoftZoneWidth.Id))
                target.m_SoftZoneWidth = templateDict[m_SoftZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneWidth.Id].CostTime / templateDict[m_SoftZoneWidth.Id].Config.duration);
            target.m_SoftZoneWidth = m_SoftZoneWidth.Value;
            if (templateDict.ContainsKey(m_SoftZoneHeight.Id))
                target.m_SoftZoneHeight = templateDict[m_SoftZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneHeight.Id].CostTime / templateDict[m_SoftZoneHeight.Id].Config.duration);
            target.m_SoftZoneHeight = m_SoftZoneHeight.Value;
            if (templateDict.ContainsKey(m_BiasX.Id))
                target.m_BiasX = templateDict[m_BiasX.Id].Config.alertCurve.Evaluate(templateDict[m_BiasX.Id].CostTime / templateDict[m_BiasX.Id].Config.duration);
            target.m_BiasX = m_BiasX.Value;
            if (templateDict.ContainsKey(m_BiasY.Id))
                target.m_BiasY = templateDict[m_BiasY.Id].Config.alertCurve.Evaluate(templateDict[m_BiasY.Id].CostTime / templateDict[m_BiasY.Id].Config.duration);
            target.m_BiasY = m_BiasY.Value;
            target.m_CenterOnActivate = m_CenterOnActivate.Value;
        }
    }
}
