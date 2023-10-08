using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineFramingTransposer_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineFramingTransposer);

       [UnityEngine.TooltipAttribute("Offset from the Follow Target object (in target-local co-ordinates).  The camera will attempt to frame the point which is the target's position plus this offset.  Use it to correct for cases when the target's origin is not the point of interest for the camera.")]
            public DataMixer <UnityEngine.Vector3> m_TrackedObjectOffset;
       [UnityEngine.TooltipAttribute("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
            public DataMixer <System.Single> m_LookaheadTime;
       [UnityEngine.TooltipAttribute("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
            public DataMixer <System.Single> m_LookaheadSmoothing;
       [UnityEngine.TooltipAttribute("If checked, movement along the Y axis will be ignored for lookahead calculations")]
            public DataMixer <System.Boolean> m_LookaheadIgnoreY;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the X-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera.  Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_XDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Y-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera.  Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_YDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Z-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera.  Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_ZDamping;
       [UnityEngine.TooltipAttribute("If set, damping will apply  only to target motion, but not to camera rotation changes.  Turn this on to get an instant response when the rotation changes.  ")]
            public DataMixer <System.Boolean> m_TargetMovementOnly;
       [UnityEngine.TooltipAttribute("Horizontal screen position for target. The camera will move to position the tracked object here.")]
            public DataMixer <System.Single> m_ScreenX;
       [UnityEngine.TooltipAttribute("Vertical screen position for target, The camera will move to position the tracked object here.")]
            public DataMixer <System.Single> m_ScreenY;
       [UnityEngine.TooltipAttribute("The distance along the camera axis that will be maintained from the Follow target")]
            public DataMixer <System.Single> m_CameraDistance;
       [UnityEngine.TooltipAttribute("Camera will not move horizontally if the target is within this range of the position.")]
            public DataMixer <System.Single> m_DeadZoneWidth;
       [UnityEngine.TooltipAttribute("Camera will not move vertically if the target is within this range of the position.")]
            public DataMixer <System.Single> m_DeadZoneHeight;
       [UnityEngine.TooltipAttribute("The camera will not move along its z-axis if the Follow target is within this distance of the specified camera distance")]
            public DataMixer <System.Single> m_DeadZoneDepth;
       [UnityEngine.TooltipAttribute("If checked, then then soft zone will be unlimited in size.")]
            public DataMixer <System.Boolean> m_UnlimitedSoftZone;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually move horizontally to re-align towards the desired position, depending on the damping speed.")]
            public DataMixer <System.Single> m_SoftZoneWidth;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually move vertically to re-align towards the desired position, depending on the damping speed.")]
            public DataMixer <System.Single> m_SoftZoneHeight;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
            public DataMixer <System.Single> m_BiasX;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
            public DataMixer <System.Single> m_BiasY;
       [UnityEngine.TooltipAttribute("Force target to center of screen when this camera activates.  If false, will clamp target to the edges of the dead zone")]
            public DataMixer <System.Boolean> m_CenterOnActivate;
       [UnityEngine.TooltipAttribute("What screen dimensions to consider when framing.  Can be Horizontal, Vertical, or both")]
            public DataMixer <Cinemachine.CinemachineFramingTransposer.FramingMode> m_GroupFramingMode;
       [UnityEngine.TooltipAttribute("How to adjust the camera to get the desired framing.  You can zoom, dolly in/out, or do both.")]
            public DataMixer <Cinemachine.CinemachineFramingTransposer.AdjustmentMode> m_AdjustmentMode;
       [UnityEngine.TooltipAttribute("The bounding box of the targets should occupy this amount of the screen space.  1 means fill the whole screen.  0.5 means fill half the screen, etc.")]
            public DataMixer <System.Single> m_GroupFramingSize;
       [UnityEngine.TooltipAttribute("The maximum distance toward the target that this behaviour is allowed to move the camera.")]
            public DataMixer <System.Single> m_MaxDollyIn;
       [UnityEngine.TooltipAttribute("The maximum distance away the target that this behaviour is allowed to move the camera.")]
            public DataMixer <System.Single> m_MaxDollyOut;
       [UnityEngine.TooltipAttribute("Set this to limit how close to the target the camera can get.")]
            public DataMixer <System.Single> m_MinimumDistance;
       [UnityEngine.TooltipAttribute("Set this to limit how far from the target the camera can get.")]
            public DataMixer <System.Single> m_MaximumDistance;
       [UnityEngine.TooltipAttribute("If adjusting FOV, will not set the FOV lower than this.")]
            public DataMixer <System.Single> m_MinimumFOV;
       [UnityEngine.TooltipAttribute("If adjusting FOV, will not set the FOV higher than this.")]
            public DataMixer <System.Single> m_MaximumFOV;
       [UnityEngine.TooltipAttribute("If adjusting Orthographic Size, will not set it lower than this.")]
            public DataMixer <System.Single> m_MinimumOrthoSize;
       [UnityEngine.TooltipAttribute("If adjusting Orthographic Size, will not set it higher than this.")]
            public DataMixer <System.Single> m_MaximumOrthoSize;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFramingTransposer_Config source = (CameraMovement.Control_C_CinemachineFramingTransposer_Config)sourceConfig;
            if(source.m_TrackedObjectOffset.IsUse) m_TrackedObjectOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.Value));
            if(source.m_LookaheadTime.IsUse) m_LookaheadTime.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.Value));
            if(source.m_LookaheadSmoothing.IsUse) m_LookaheadSmoothing.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.Value));
            if(source.m_LookaheadIgnoreY.IsUse) m_LookaheadIgnoreY.Add(new MixItem<System.Boolean>(id, priority, source.m_LookaheadIgnoreY.Value));
            if(source.m_XDamping.IsUse) m_XDamping.Add(new MixItem<System.Single>(id, priority, source.m_XDamping.Value));
            if(source.m_YDamping.IsUse) m_YDamping.Add(new MixItem<System.Single>(id, priority, source.m_YDamping.Value));
            if(source.m_ZDamping.IsUse) m_ZDamping.Add(new MixItem<System.Single>(id, priority, source.m_ZDamping.Value));
            if(source.m_TargetMovementOnly.IsUse) m_TargetMovementOnly.Add(new MixItem<System.Boolean>(id, priority, source.m_TargetMovementOnly.Value));
            if(source.m_ScreenX.IsUse) m_ScreenX.Add(new MixItem<System.Single>(id, priority, source.m_ScreenX.Value));
            if(source.m_ScreenY.IsUse) m_ScreenY.Add(new MixItem<System.Single>(id, priority, source.m_ScreenY.Value));
            if(source.m_CameraDistance.IsUse) m_CameraDistance.Add(new MixItem<System.Single>(id, priority, source.m_CameraDistance.Value));
            if(source.m_DeadZoneWidth.IsUse) m_DeadZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.Value));
            if(source.m_DeadZoneHeight.IsUse) m_DeadZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.Value));
            if(source.m_DeadZoneDepth.IsUse) m_DeadZoneDepth.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneDepth.Value));
            if(source.m_UnlimitedSoftZone.IsUse) m_UnlimitedSoftZone.Add(new MixItem<System.Boolean>(id, priority, source.m_UnlimitedSoftZone.Value));
            if(source.m_SoftZoneWidth.IsUse) m_SoftZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.Value));
            if(source.m_SoftZoneHeight.IsUse) m_SoftZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.Value));
            if(source.m_BiasX.IsUse) m_BiasX.Add(new MixItem<System.Single>(id, priority, source.m_BiasX.Value));
            if(source.m_BiasY.IsUse) m_BiasY.Add(new MixItem<System.Single>(id, priority, source.m_BiasY.Value));
            if(source.m_CenterOnActivate.IsUse) m_CenterOnActivate.Add(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.Value));
            if(source.m_GroupFramingMode.IsUse) m_GroupFramingMode.Add(new MixItem<Cinemachine.CinemachineFramingTransposer.FramingMode>(id, priority, source.m_GroupFramingMode.Value));
            if(source.m_AdjustmentMode.IsUse) m_AdjustmentMode.Add(new MixItem<Cinemachine.CinemachineFramingTransposer.AdjustmentMode>(id, priority, source.m_AdjustmentMode.Value));
            if(source.m_GroupFramingSize.IsUse) m_GroupFramingSize.Add(new MixItem<System.Single>(id, priority, source.m_GroupFramingSize.Value));
            if(source.m_MaxDollyIn.IsUse) m_MaxDollyIn.Add(new MixItem<System.Single>(id, priority, source.m_MaxDollyIn.Value));
            if(source.m_MaxDollyOut.IsUse) m_MaxDollyOut.Add(new MixItem<System.Single>(id, priority, source.m_MaxDollyOut.Value));
            if(source.m_MinimumDistance.IsUse) m_MinimumDistance.Add(new MixItem<System.Single>(id, priority, source.m_MinimumDistance.Value));
            if(source.m_MaximumDistance.IsUse) m_MaximumDistance.Add(new MixItem<System.Single>(id, priority, source.m_MaximumDistance.Value));
            if(source.m_MinimumFOV.IsUse) m_MinimumFOV.Add(new MixItem<System.Single>(id, priority, source.m_MinimumFOV.Value));
            if(source.m_MaximumFOV.IsUse) m_MaximumFOV.Add(new MixItem<System.Single>(id, priority, source.m_MaximumFOV.Value));
            if(source.m_MinimumOrthoSize.IsUse) m_MinimumOrthoSize.Add(new MixItem<System.Single>(id, priority, source.m_MinimumOrthoSize.Value));
            if(source.m_MaximumOrthoSize.IsUse) m_MaximumOrthoSize.Add(new MixItem<System.Single>(id, priority, source.m_MaximumOrthoSize.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineFramingTransposer_Config source = (CameraMovement.Control_C_CinemachineFramingTransposer_Config)sourceConfig;
            if(source.m_TrackedObjectOffset.IsUse) m_TrackedObjectOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.Value));
            if(source.m_LookaheadTime.IsUse) m_LookaheadTime.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.Value));
            if(source.m_LookaheadSmoothing.IsUse) m_LookaheadSmoothing.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.Value));
            if(source.m_LookaheadIgnoreY.IsUse) m_LookaheadIgnoreY.Remove(new MixItem<System.Boolean>(id, priority, source.m_LookaheadIgnoreY.Value));
            if(source.m_XDamping.IsUse) m_XDamping.Remove(new MixItem<System.Single>(id, priority, source.m_XDamping.Value));
            if(source.m_YDamping.IsUse) m_YDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YDamping.Value));
            if(source.m_ZDamping.IsUse) m_ZDamping.Remove(new MixItem<System.Single>(id, priority, source.m_ZDamping.Value));
            if(source.m_TargetMovementOnly.IsUse) m_TargetMovementOnly.Remove(new MixItem<System.Boolean>(id, priority, source.m_TargetMovementOnly.Value));
            if(source.m_ScreenX.IsUse) m_ScreenX.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenX.Value));
            if(source.m_ScreenY.IsUse) m_ScreenY.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenY.Value));
            if(source.m_CameraDistance.IsUse) m_CameraDistance.Remove(new MixItem<System.Single>(id, priority, source.m_CameraDistance.Value));
            if(source.m_DeadZoneWidth.IsUse) m_DeadZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.Value));
            if(source.m_DeadZoneHeight.IsUse) m_DeadZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.Value));
            if(source.m_DeadZoneDepth.IsUse) m_DeadZoneDepth.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneDepth.Value));
            if(source.m_UnlimitedSoftZone.IsUse) m_UnlimitedSoftZone.Remove(new MixItem<System.Boolean>(id, priority, source.m_UnlimitedSoftZone.Value));
            if(source.m_SoftZoneWidth.IsUse) m_SoftZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.Value));
            if(source.m_SoftZoneHeight.IsUse) m_SoftZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.Value));
            if(source.m_BiasX.IsUse) m_BiasX.Remove(new MixItem<System.Single>(id, priority, source.m_BiasX.Value));
            if(source.m_BiasY.IsUse) m_BiasY.Remove(new MixItem<System.Single>(id, priority, source.m_BiasY.Value));
            if(source.m_CenterOnActivate.IsUse) m_CenterOnActivate.Remove(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.Value));
            if(source.m_GroupFramingMode.IsUse) m_GroupFramingMode.Remove(new MixItem<Cinemachine.CinemachineFramingTransposer.FramingMode>(id, priority, source.m_GroupFramingMode.Value));
            if(source.m_AdjustmentMode.IsUse) m_AdjustmentMode.Remove(new MixItem<Cinemachine.CinemachineFramingTransposer.AdjustmentMode>(id, priority, source.m_AdjustmentMode.Value));
            if(source.m_GroupFramingSize.IsUse) m_GroupFramingSize.Remove(new MixItem<System.Single>(id, priority, source.m_GroupFramingSize.Value));
            if(source.m_MaxDollyIn.IsUse) m_MaxDollyIn.Remove(new MixItem<System.Single>(id, priority, source.m_MaxDollyIn.Value));
            if(source.m_MaxDollyOut.IsUse) m_MaxDollyOut.Remove(new MixItem<System.Single>(id, priority, source.m_MaxDollyOut.Value));
            if(source.m_MinimumDistance.IsUse) m_MinimumDistance.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumDistance.Value));
            if(source.m_MaximumDistance.IsUse) m_MaximumDistance.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumDistance.Value));
            if(source.m_MinimumFOV.IsUse) m_MinimumFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumFOV.Value));
            if(source.m_MaximumFOV.IsUse) m_MaximumFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumFOV.Value));
            if(source.m_MinimumOrthoSize.IsUse) m_MinimumOrthoSize.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumOrthoSize.Value));
            if(source.m_MaximumOrthoSize.IsUse) m_MaximumOrthoSize.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumOrthoSize.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineFramingTransposer)targetObj;
            if (templateDict.ContainsKey(m_LookaheadTime.Id))
                target.m_LookaheadTime = templateDict[m_LookaheadTime.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadTime.Id].CostTime / templateDict[m_LookaheadTime.Id].Config.duration);
            target.m_LookaheadTime = m_LookaheadTime.Value;
            if (templateDict.ContainsKey(m_LookaheadSmoothing.Id))
                target.m_LookaheadSmoothing = templateDict[m_LookaheadSmoothing.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadSmoothing.Id].CostTime / templateDict[m_LookaheadSmoothing.Id].Config.duration);
            target.m_LookaheadSmoothing = m_LookaheadSmoothing.Value;
            target.m_LookaheadIgnoreY = m_LookaheadIgnoreY.Value;
            if (templateDict.ContainsKey(m_XDamping.Id))
                target.m_XDamping = templateDict[m_XDamping.Id].Config.alertCurve.Evaluate(templateDict[m_XDamping.Id].CostTime / templateDict[m_XDamping.Id].Config.duration);
            target.m_XDamping = m_XDamping.Value;
            if (templateDict.ContainsKey(m_YDamping.Id))
                target.m_YDamping = templateDict[m_YDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YDamping.Id].CostTime / templateDict[m_YDamping.Id].Config.duration);
            target.m_YDamping = m_YDamping.Value;
            if (templateDict.ContainsKey(m_ZDamping.Id))
                target.m_ZDamping = templateDict[m_ZDamping.Id].Config.alertCurve.Evaluate(templateDict[m_ZDamping.Id].CostTime / templateDict[m_ZDamping.Id].Config.duration);
            target.m_ZDamping = m_ZDamping.Value;
            target.m_TargetMovementOnly = m_TargetMovementOnly.Value;
            if (templateDict.ContainsKey(m_ScreenX.Id))
                target.m_ScreenX = templateDict[m_ScreenX.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenX.Id].CostTime / templateDict[m_ScreenX.Id].Config.duration);
            target.m_ScreenX = m_ScreenX.Value;
            if (templateDict.ContainsKey(m_ScreenY.Id))
                target.m_ScreenY = templateDict[m_ScreenY.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenY.Id].CostTime / templateDict[m_ScreenY.Id].Config.duration);
            target.m_ScreenY = m_ScreenY.Value;
            if (templateDict.ContainsKey(m_CameraDistance.Id))
                target.m_CameraDistance = templateDict[m_CameraDistance.Id].Config.alertCurve.Evaluate(templateDict[m_CameraDistance.Id].CostTime / templateDict[m_CameraDistance.Id].Config.duration);
            target.m_CameraDistance = m_CameraDistance.Value;
            if (templateDict.ContainsKey(m_DeadZoneWidth.Id))
                target.m_DeadZoneWidth = templateDict[m_DeadZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneWidth.Id].CostTime / templateDict[m_DeadZoneWidth.Id].Config.duration);
            target.m_DeadZoneWidth = m_DeadZoneWidth.Value;
            if (templateDict.ContainsKey(m_DeadZoneHeight.Id))
                target.m_DeadZoneHeight = templateDict[m_DeadZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneHeight.Id].CostTime / templateDict[m_DeadZoneHeight.Id].Config.duration);
            target.m_DeadZoneHeight = m_DeadZoneHeight.Value;
            if (templateDict.ContainsKey(m_DeadZoneDepth.Id))
                target.m_DeadZoneDepth = templateDict[m_DeadZoneDepth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneDepth.Id].CostTime / templateDict[m_DeadZoneDepth.Id].Config.duration);
            target.m_DeadZoneDepth = m_DeadZoneDepth.Value;
            target.m_UnlimitedSoftZone = m_UnlimitedSoftZone.Value;
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
            target.m_GroupFramingMode = m_GroupFramingMode.Value;
            target.m_AdjustmentMode = m_AdjustmentMode.Value;
            if (templateDict.ContainsKey(m_GroupFramingSize.Id))
                target.m_GroupFramingSize = templateDict[m_GroupFramingSize.Id].Config.alertCurve.Evaluate(templateDict[m_GroupFramingSize.Id].CostTime / templateDict[m_GroupFramingSize.Id].Config.duration);
            target.m_GroupFramingSize = m_GroupFramingSize.Value;
            if (templateDict.ContainsKey(m_MaxDollyIn.Id))
                target.m_MaxDollyIn = templateDict[m_MaxDollyIn.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyIn.Id].CostTime / templateDict[m_MaxDollyIn.Id].Config.duration);
            target.m_MaxDollyIn = m_MaxDollyIn.Value;
            if (templateDict.ContainsKey(m_MaxDollyOut.Id))
                target.m_MaxDollyOut = templateDict[m_MaxDollyOut.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyOut.Id].CostTime / templateDict[m_MaxDollyOut.Id].Config.duration);
            target.m_MaxDollyOut = m_MaxDollyOut.Value;
            if (templateDict.ContainsKey(m_MinimumDistance.Id))
                target.m_MinimumDistance = templateDict[m_MinimumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistance.Id].CostTime / templateDict[m_MinimumDistance.Id].Config.duration);
            target.m_MinimumDistance = m_MinimumDistance.Value;
            if (templateDict.ContainsKey(m_MaximumDistance.Id))
                target.m_MaximumDistance = templateDict[m_MaximumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumDistance.Id].CostTime / templateDict[m_MaximumDistance.Id].Config.duration);
            target.m_MaximumDistance = m_MaximumDistance.Value;
            if (templateDict.ContainsKey(m_MinimumFOV.Id))
                target.m_MinimumFOV = templateDict[m_MinimumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumFOV.Id].CostTime / templateDict[m_MinimumFOV.Id].Config.duration);
            target.m_MinimumFOV = m_MinimumFOV.Value;
            if (templateDict.ContainsKey(m_MaximumFOV.Id))
                target.m_MaximumFOV = templateDict[m_MaximumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumFOV.Id].CostTime / templateDict[m_MaximumFOV.Id].Config.duration);
            target.m_MaximumFOV = m_MaximumFOV.Value;
            if (templateDict.ContainsKey(m_MinimumOrthoSize.Id))
                target.m_MinimumOrthoSize = templateDict[m_MinimumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOrthoSize.Id].CostTime / templateDict[m_MinimumOrthoSize.Id].Config.duration);
            target.m_MinimumOrthoSize = m_MinimumOrthoSize.Value;
            if (templateDict.ContainsKey(m_MaximumOrthoSize.Id))
                target.m_MaximumOrthoSize = templateDict[m_MaximumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumOrthoSize.Id].CostTime / templateDict[m_MaximumOrthoSize.Id].Config.duration);
            target.m_MaximumOrthoSize = m_MaximumOrthoSize.Value;
        }
    }
}