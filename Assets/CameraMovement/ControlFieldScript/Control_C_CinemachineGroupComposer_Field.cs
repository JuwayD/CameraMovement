using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineGroupComposer_Field :ICameraMovementControlField<Cinemachine.CinemachineGroupComposer>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineGroupComposer);

       [UnityEngine.TooltipAttribute("The bounding box of the targets should occupy this amount of the screen space.  1 means fill the whole screen.  0.5 means fill half the screen, etc.")]
            public DataMixer <System.Single> m_GroupFramingSize;
        public float m_GroupFramingSizeAlertInit;
        public float m_GroupFramingSizeDiff;
       [UnityEngine.TooltipAttribute("What screen dimensions to consider when framing.  Can be Horizontal, Vertical, or both")]
            public DataMixer <Cinemachine.CinemachineGroupComposer.FramingMode> m_FramingMode;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to frame the group. Small numbers are more responsive, rapidly adjusting the camera to keep the group in the frame.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_FrameDamping;
        public float m_FrameDampingAlertInit;
        public float m_FrameDampingDiff;
       [UnityEngine.TooltipAttribute("How to adjust the camera to get the desired framing.  You can zoom, dolly in/out, or do both.")]
            public DataMixer <Cinemachine.CinemachineGroupComposer.AdjustmentMode> m_AdjustmentMode;
       [UnityEngine.TooltipAttribute("The maximum distance toward the target that this behaviour is allowed to move the camera.")]
            public DataMixer <System.Single> m_MaxDollyIn;
        public float m_MaxDollyInAlertInit;
        public float m_MaxDollyInDiff;
       [UnityEngine.TooltipAttribute("The maximum distance away the target that this behaviour is allowed to move the camera.")]
            public DataMixer <System.Single> m_MaxDollyOut;
        public float m_MaxDollyOutAlertInit;
        public float m_MaxDollyOutDiff;
       [UnityEngine.TooltipAttribute("Set this to limit how close to the target the camera can get.")]
            public DataMixer <System.Single> m_MinimumDistance;
        public float m_MinimumDistanceAlertInit;
        public float m_MinimumDistanceDiff;
       [UnityEngine.TooltipAttribute("Set this to limit how far from the target the camera can get.")]
            public DataMixer <System.Single> m_MaximumDistance;
        public float m_MaximumDistanceAlertInit;
        public float m_MaximumDistanceDiff;
       [UnityEngine.TooltipAttribute("If adjusting FOV, will not set the FOV lower than this.")]
            public DataMixer <System.Single> m_MinimumFOV;
        public float m_MinimumFOVAlertInit;
        public float m_MinimumFOVDiff;
       [UnityEngine.TooltipAttribute("If adjusting FOV, will not set the FOV higher than this.")]
            public DataMixer <System.Single> m_MaximumFOV;
        public float m_MaximumFOVAlertInit;
        public float m_MaximumFOVDiff;
       [UnityEngine.TooltipAttribute("If adjusting Orthographic Size, will not set it lower than this.")]
            public DataMixer <System.Single> m_MinimumOrthoSize;
        public float m_MinimumOrthoSizeAlertInit;
        public float m_MinimumOrthoSizeDiff;
       [UnityEngine.TooltipAttribute("If adjusting Orthographic Size, will not set it higher than this.")]
            public DataMixer <System.Single> m_MaximumOrthoSize;
        public float m_MaximumOrthoSizeAlertInit;
        public float m_MaximumOrthoSizeDiff;
       [UnityEngine.TooltipAttribute("Target offset from the target object's center in target-local space. Use this to fine-tune the tracking target position when the desired area is not the tracked object's center.")]
            public DataMixer <UnityEngine.Vector3> m_TrackedObjectOffset;
       [UnityEngine.TooltipAttribute("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
            public DataMixer <System.Single> m_LookaheadTime;
        public float m_LookaheadTimeAlertInit;
        public float m_LookaheadTimeDiff;
       [UnityEngine.TooltipAttribute("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
            public DataMixer <System.Single> m_LookaheadSmoothing;
        public float m_LookaheadSmoothingAlertInit;
        public float m_LookaheadSmoothingDiff;
       [UnityEngine.TooltipAttribute("If checked, movement along the Y axis will be ignored for lookahead calculations")]
            public DataMixer <System.Boolean> m_LookaheadIgnoreY;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to follow the target in the screen-horizontal direction. Small numbers are more responsive, rapidly orienting the camera to keep the target in the dead zone. Larger numbers give a more heavy slowly responding camera. Using different vertical and horizontal settings can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_HorizontalDamping;
        public float m_HorizontalDampingAlertInit;
        public float m_HorizontalDampingDiff;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to follow the target in the screen-vertical direction. Small numbers are more responsive, rapidly orienting the camera to keep the target in the dead zone. Larger numbers give a more heavy slowly responding camera. Using different vertical and horizontal settings can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_VerticalDamping;
        public float m_VerticalDampingAlertInit;
        public float m_VerticalDampingDiff;
       [UnityEngine.TooltipAttribute("Horizontal screen position for target. The camera will rotate to position the tracked object here.")]
            public DataMixer <System.Single> m_ScreenX;
        public float m_ScreenXAlertInit;
        public float m_ScreenXDiff;
       [UnityEngine.TooltipAttribute("Vertical screen position for target, The camera will rotate to position the tracked object here.")]
            public DataMixer <System.Single> m_ScreenY;
        public float m_ScreenYAlertInit;
        public float m_ScreenYDiff;
       [UnityEngine.TooltipAttribute("Camera will not rotate horizontally if the target is within this range of the position.")]
            public DataMixer <System.Single> m_DeadZoneWidth;
        public float m_DeadZoneWidthAlertInit;
        public float m_DeadZoneWidthDiff;
       [UnityEngine.TooltipAttribute("Camera will not rotate vertically if the target is within this range of the position.")]
            public DataMixer <System.Single> m_DeadZoneHeight;
        public float m_DeadZoneHeightAlertInit;
        public float m_DeadZoneHeightDiff;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually rotate horizontally to re-align towards the desired position, depending on the damping speed.")]
            public DataMixer <System.Single> m_SoftZoneWidth;
        public float m_SoftZoneWidthAlertInit;
        public float m_SoftZoneWidthDiff;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually rotate vertically to re-align towards the desired position, depending on the damping speed.")]
            public DataMixer <System.Single> m_SoftZoneHeight;
        public float m_SoftZoneHeightAlertInit;
        public float m_SoftZoneHeightDiff;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
            public DataMixer <System.Single> m_BiasX;
        public float m_BiasXAlertInit;
        public float m_BiasXDiff;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
            public DataMixer <System.Single> m_BiasY;
        public float m_BiasYAlertInit;
        public float m_BiasYDiff;
       [UnityEngine.TooltipAttribute("Force target to center of screen when this camera activates.  If false, will clamp target to the edges of the dead zone")]
            public DataMixer <System.Boolean> m_CenterOnActivate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineGroupComposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineGroupComposer_Config source = (CameraMovement.Control_C_CinemachineGroupComposer_Config)sourceConfig;
            if(source.m_GroupFramingSize.IsUse)
            {
                m_GroupFramingSize.Add(new MixItem<System.Single>(id, priority, source.m_GroupFramingSize.CalculatorExpression, source.m_GroupFramingSize.Value, source.m_GroupFramingSize.IsUse));
               var targetValue = (m_GroupFramingSize.IsExpression ? m_GroupFramingSize.Value : m_GroupFramingSize.PrimitiveValue);
               m_GroupFramingSizeDiff = targetValue - target.m_GroupFramingSize;
               if(templateDict[m_GroupFramingSize.Id].Config.alertCurve != null) m_GroupFramingSizeAlertInit = target.m_GroupFramingSize - templateDict[m_GroupFramingSize.Id].Config.alertCurve.Evaluate(templateDict[m_GroupFramingSize.Id].CostTime / templateDict[m_GroupFramingSize.Id].Config.duration) * (m_GroupFramingSizeDiff);
            }
            if(source.m_FramingMode.IsUse)
            {
                m_FramingMode.Add(new MixItem<Cinemachine.CinemachineGroupComposer.FramingMode>(id, priority, source.m_FramingMode.CalculatorExpression, source.m_FramingMode.Value, source.m_FramingMode.IsUse));
            }
            if(source.m_FrameDamping.IsUse)
            {
                m_FrameDamping.Add(new MixItem<System.Single>(id, priority, source.m_FrameDamping.CalculatorExpression, source.m_FrameDamping.Value, source.m_FrameDamping.IsUse));
               var targetValue = (m_FrameDamping.IsExpression ? m_FrameDamping.Value : m_FrameDamping.PrimitiveValue);
               m_FrameDampingDiff = targetValue - target.m_FrameDamping;
               if(templateDict[m_FrameDamping.Id].Config.alertCurve != null) m_FrameDampingAlertInit = target.m_FrameDamping - templateDict[m_FrameDamping.Id].Config.alertCurve.Evaluate(templateDict[m_FrameDamping.Id].CostTime / templateDict[m_FrameDamping.Id].Config.duration) * (m_FrameDampingDiff);
            }
            if(source.m_AdjustmentMode.IsUse)
            {
                m_AdjustmentMode.Add(new MixItem<Cinemachine.CinemachineGroupComposer.AdjustmentMode>(id, priority, source.m_AdjustmentMode.CalculatorExpression, source.m_AdjustmentMode.Value, source.m_AdjustmentMode.IsUse));
            }
            if(source.m_MaxDollyIn.IsUse)
            {
                m_MaxDollyIn.Add(new MixItem<System.Single>(id, priority, source.m_MaxDollyIn.CalculatorExpression, source.m_MaxDollyIn.Value, source.m_MaxDollyIn.IsUse));
               var targetValue = (m_MaxDollyIn.IsExpression ? m_MaxDollyIn.Value : m_MaxDollyIn.PrimitiveValue);
               m_MaxDollyInDiff = targetValue - target.m_MaxDollyIn;
               if(templateDict[m_MaxDollyIn.Id].Config.alertCurve != null) m_MaxDollyInAlertInit = target.m_MaxDollyIn - templateDict[m_MaxDollyIn.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyIn.Id].CostTime / templateDict[m_MaxDollyIn.Id].Config.duration) * (m_MaxDollyInDiff);
            }
            if(source.m_MaxDollyOut.IsUse)
            {
                m_MaxDollyOut.Add(new MixItem<System.Single>(id, priority, source.m_MaxDollyOut.CalculatorExpression, source.m_MaxDollyOut.Value, source.m_MaxDollyOut.IsUse));
               var targetValue = (m_MaxDollyOut.IsExpression ? m_MaxDollyOut.Value : m_MaxDollyOut.PrimitiveValue);
               m_MaxDollyOutDiff = targetValue - target.m_MaxDollyOut;
               if(templateDict[m_MaxDollyOut.Id].Config.alertCurve != null) m_MaxDollyOutAlertInit = target.m_MaxDollyOut - templateDict[m_MaxDollyOut.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyOut.Id].CostTime / templateDict[m_MaxDollyOut.Id].Config.duration) * (m_MaxDollyOutDiff);
            }
            if(source.m_MinimumDistance.IsUse)
            {
                m_MinimumDistance.Add(new MixItem<System.Single>(id, priority, source.m_MinimumDistance.CalculatorExpression, source.m_MinimumDistance.Value, source.m_MinimumDistance.IsUse));
               var targetValue = (m_MinimumDistance.IsExpression ? m_MinimumDistance.Value : m_MinimumDistance.PrimitiveValue);
               m_MinimumDistanceDiff = targetValue - target.m_MinimumDistance;
               if(templateDict[m_MinimumDistance.Id].Config.alertCurve != null) m_MinimumDistanceAlertInit = target.m_MinimumDistance - templateDict[m_MinimumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistance.Id].CostTime / templateDict[m_MinimumDistance.Id].Config.duration) * (m_MinimumDistanceDiff);
            }
            if(source.m_MaximumDistance.IsUse)
            {
                m_MaximumDistance.Add(new MixItem<System.Single>(id, priority, source.m_MaximumDistance.CalculatorExpression, source.m_MaximumDistance.Value, source.m_MaximumDistance.IsUse));
               var targetValue = (m_MaximumDistance.IsExpression ? m_MaximumDistance.Value : m_MaximumDistance.PrimitiveValue);
               m_MaximumDistanceDiff = targetValue - target.m_MaximumDistance;
               if(templateDict[m_MaximumDistance.Id].Config.alertCurve != null) m_MaximumDistanceAlertInit = target.m_MaximumDistance - templateDict[m_MaximumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumDistance.Id].CostTime / templateDict[m_MaximumDistance.Id].Config.duration) * (m_MaximumDistanceDiff);
            }
            if(source.m_MinimumFOV.IsUse)
            {
                m_MinimumFOV.Add(new MixItem<System.Single>(id, priority, source.m_MinimumFOV.CalculatorExpression, source.m_MinimumFOV.Value, source.m_MinimumFOV.IsUse));
               var targetValue = (m_MinimumFOV.IsExpression ? m_MinimumFOV.Value : m_MinimumFOV.PrimitiveValue);
               m_MinimumFOVDiff = targetValue - target.m_MinimumFOV;
               if(templateDict[m_MinimumFOV.Id].Config.alertCurve != null) m_MinimumFOVAlertInit = target.m_MinimumFOV - templateDict[m_MinimumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumFOV.Id].CostTime / templateDict[m_MinimumFOV.Id].Config.duration) * (m_MinimumFOVDiff);
            }
            if(source.m_MaximumFOV.IsUse)
            {
                m_MaximumFOV.Add(new MixItem<System.Single>(id, priority, source.m_MaximumFOV.CalculatorExpression, source.m_MaximumFOV.Value, source.m_MaximumFOV.IsUse));
               var targetValue = (m_MaximumFOV.IsExpression ? m_MaximumFOV.Value : m_MaximumFOV.PrimitiveValue);
               m_MaximumFOVDiff = targetValue - target.m_MaximumFOV;
               if(templateDict[m_MaximumFOV.Id].Config.alertCurve != null) m_MaximumFOVAlertInit = target.m_MaximumFOV - templateDict[m_MaximumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumFOV.Id].CostTime / templateDict[m_MaximumFOV.Id].Config.duration) * (m_MaximumFOVDiff);
            }
            if(source.m_MinimumOrthoSize.IsUse)
            {
                m_MinimumOrthoSize.Add(new MixItem<System.Single>(id, priority, source.m_MinimumOrthoSize.CalculatorExpression, source.m_MinimumOrthoSize.Value, source.m_MinimumOrthoSize.IsUse));
               var targetValue = (m_MinimumOrthoSize.IsExpression ? m_MinimumOrthoSize.Value : m_MinimumOrthoSize.PrimitiveValue);
               m_MinimumOrthoSizeDiff = targetValue - target.m_MinimumOrthoSize;
               if(templateDict[m_MinimumOrthoSize.Id].Config.alertCurve != null) m_MinimumOrthoSizeAlertInit = target.m_MinimumOrthoSize - templateDict[m_MinimumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOrthoSize.Id].CostTime / templateDict[m_MinimumOrthoSize.Id].Config.duration) * (m_MinimumOrthoSizeDiff);
            }
            if(source.m_MaximumOrthoSize.IsUse)
            {
                m_MaximumOrthoSize.Add(new MixItem<System.Single>(id, priority, source.m_MaximumOrthoSize.CalculatorExpression, source.m_MaximumOrthoSize.Value, source.m_MaximumOrthoSize.IsUse));
               var targetValue = (m_MaximumOrthoSize.IsExpression ? m_MaximumOrthoSize.Value : m_MaximumOrthoSize.PrimitiveValue);
               m_MaximumOrthoSizeDiff = targetValue - target.m_MaximumOrthoSize;
               if(templateDict[m_MaximumOrthoSize.Id].Config.alertCurve != null) m_MaximumOrthoSizeAlertInit = target.m_MaximumOrthoSize - templateDict[m_MaximumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumOrthoSize.Id].CostTime / templateDict[m_MaximumOrthoSize.Id].Config.duration) * (m_MaximumOrthoSizeDiff);
            }
            if(source.m_TrackedObjectOffset.IsUse)
            {
                m_TrackedObjectOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.CalculatorExpression, source.m_TrackedObjectOffset.Value, source.m_TrackedObjectOffset.IsUse));
            }
            if(source.m_LookaheadTime.IsUse)
            {
                m_LookaheadTime.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.CalculatorExpression, source.m_LookaheadTime.Value, source.m_LookaheadTime.IsUse));
               var targetValue = (m_LookaheadTime.IsExpression ? m_LookaheadTime.Value : m_LookaheadTime.PrimitiveValue);
               m_LookaheadTimeDiff = targetValue - target.m_LookaheadTime;
               if(templateDict[m_LookaheadTime.Id].Config.alertCurve != null) m_LookaheadTimeAlertInit = target.m_LookaheadTime - templateDict[m_LookaheadTime.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadTime.Id].CostTime / templateDict[m_LookaheadTime.Id].Config.duration) * (m_LookaheadTimeDiff);
            }
            if(source.m_LookaheadSmoothing.IsUse)
            {
                m_LookaheadSmoothing.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.CalculatorExpression, source.m_LookaheadSmoothing.Value, source.m_LookaheadSmoothing.IsUse));
               var targetValue = (m_LookaheadSmoothing.IsExpression ? m_LookaheadSmoothing.Value : m_LookaheadSmoothing.PrimitiveValue);
               m_LookaheadSmoothingDiff = targetValue - target.m_LookaheadSmoothing;
               if(templateDict[m_LookaheadSmoothing.Id].Config.alertCurve != null) m_LookaheadSmoothingAlertInit = target.m_LookaheadSmoothing - templateDict[m_LookaheadSmoothing.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadSmoothing.Id].CostTime / templateDict[m_LookaheadSmoothing.Id].Config.duration) * (m_LookaheadSmoothingDiff);
            }
            if(source.m_LookaheadIgnoreY.IsUse)
            {
                m_LookaheadIgnoreY.Add(new MixItem<System.Boolean>(id, priority, source.m_LookaheadIgnoreY.CalculatorExpression, source.m_LookaheadIgnoreY.Value, source.m_LookaheadIgnoreY.IsUse));
            }
            if(source.m_HorizontalDamping.IsUse)
            {
                m_HorizontalDamping.Add(new MixItem<System.Single>(id, priority, source.m_HorizontalDamping.CalculatorExpression, source.m_HorizontalDamping.Value, source.m_HorizontalDamping.IsUse));
               var targetValue = (m_HorizontalDamping.IsExpression ? m_HorizontalDamping.Value : m_HorizontalDamping.PrimitiveValue);
               m_HorizontalDampingDiff = targetValue - target.m_HorizontalDamping;
               if(templateDict[m_HorizontalDamping.Id].Config.alertCurve != null) m_HorizontalDampingAlertInit = target.m_HorizontalDamping - templateDict[m_HorizontalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_HorizontalDamping.Id].CostTime / templateDict[m_HorizontalDamping.Id].Config.duration) * (m_HorizontalDampingDiff);
            }
            if(source.m_VerticalDamping.IsUse)
            {
                m_VerticalDamping.Add(new MixItem<System.Single>(id, priority, source.m_VerticalDamping.CalculatorExpression, source.m_VerticalDamping.Value, source.m_VerticalDamping.IsUse));
               var targetValue = (m_VerticalDamping.IsExpression ? m_VerticalDamping.Value : m_VerticalDamping.PrimitiveValue);
               m_VerticalDampingDiff = targetValue - target.m_VerticalDamping;
               if(templateDict[m_VerticalDamping.Id].Config.alertCurve != null) m_VerticalDampingAlertInit = target.m_VerticalDamping - templateDict[m_VerticalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_VerticalDamping.Id].CostTime / templateDict[m_VerticalDamping.Id].Config.duration) * (m_VerticalDampingDiff);
            }
            if(source.m_ScreenX.IsUse)
            {
                m_ScreenX.Add(new MixItem<System.Single>(id, priority, source.m_ScreenX.CalculatorExpression, source.m_ScreenX.Value, source.m_ScreenX.IsUse));
               var targetValue = (m_ScreenX.IsExpression ? m_ScreenX.Value : m_ScreenX.PrimitiveValue);
               m_ScreenXDiff = targetValue - target.m_ScreenX;
               if(templateDict[m_ScreenX.Id].Config.alertCurve != null) m_ScreenXAlertInit = target.m_ScreenX - templateDict[m_ScreenX.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenX.Id].CostTime / templateDict[m_ScreenX.Id].Config.duration) * (m_ScreenXDiff);
            }
            if(source.m_ScreenY.IsUse)
            {
                m_ScreenY.Add(new MixItem<System.Single>(id, priority, source.m_ScreenY.CalculatorExpression, source.m_ScreenY.Value, source.m_ScreenY.IsUse));
               var targetValue = (m_ScreenY.IsExpression ? m_ScreenY.Value : m_ScreenY.PrimitiveValue);
               m_ScreenYDiff = targetValue - target.m_ScreenY;
               if(templateDict[m_ScreenY.Id].Config.alertCurve != null) m_ScreenYAlertInit = target.m_ScreenY - templateDict[m_ScreenY.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenY.Id].CostTime / templateDict[m_ScreenY.Id].Config.duration) * (m_ScreenYDiff);
            }
            if(source.m_DeadZoneWidth.IsUse)
            {
                m_DeadZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.CalculatorExpression, source.m_DeadZoneWidth.Value, source.m_DeadZoneWidth.IsUse));
               var targetValue = (m_DeadZoneWidth.IsExpression ? m_DeadZoneWidth.Value : m_DeadZoneWidth.PrimitiveValue);
               m_DeadZoneWidthDiff = targetValue - target.m_DeadZoneWidth;
               if(templateDict[m_DeadZoneWidth.Id].Config.alertCurve != null) m_DeadZoneWidthAlertInit = target.m_DeadZoneWidth - templateDict[m_DeadZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneWidth.Id].CostTime / templateDict[m_DeadZoneWidth.Id].Config.duration) * (m_DeadZoneWidthDiff);
            }
            if(source.m_DeadZoneHeight.IsUse)
            {
                m_DeadZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.CalculatorExpression, source.m_DeadZoneHeight.Value, source.m_DeadZoneHeight.IsUse));
               var targetValue = (m_DeadZoneHeight.IsExpression ? m_DeadZoneHeight.Value : m_DeadZoneHeight.PrimitiveValue);
               m_DeadZoneHeightDiff = targetValue - target.m_DeadZoneHeight;
               if(templateDict[m_DeadZoneHeight.Id].Config.alertCurve != null) m_DeadZoneHeightAlertInit = target.m_DeadZoneHeight - templateDict[m_DeadZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneHeight.Id].CostTime / templateDict[m_DeadZoneHeight.Id].Config.duration) * (m_DeadZoneHeightDiff);
            }
            if(source.m_SoftZoneWidth.IsUse)
            {
                m_SoftZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.CalculatorExpression, source.m_SoftZoneWidth.Value, source.m_SoftZoneWidth.IsUse));
               var targetValue = (m_SoftZoneWidth.IsExpression ? m_SoftZoneWidth.Value : m_SoftZoneWidth.PrimitiveValue);
               m_SoftZoneWidthDiff = targetValue - target.m_SoftZoneWidth;
               if(templateDict[m_SoftZoneWidth.Id].Config.alertCurve != null) m_SoftZoneWidthAlertInit = target.m_SoftZoneWidth - templateDict[m_SoftZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneWidth.Id].CostTime / templateDict[m_SoftZoneWidth.Id].Config.duration) * (m_SoftZoneWidthDiff);
            }
            if(source.m_SoftZoneHeight.IsUse)
            {
                m_SoftZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.CalculatorExpression, source.m_SoftZoneHeight.Value, source.m_SoftZoneHeight.IsUse));
               var targetValue = (m_SoftZoneHeight.IsExpression ? m_SoftZoneHeight.Value : m_SoftZoneHeight.PrimitiveValue);
               m_SoftZoneHeightDiff = targetValue - target.m_SoftZoneHeight;
               if(templateDict[m_SoftZoneHeight.Id].Config.alertCurve != null) m_SoftZoneHeightAlertInit = target.m_SoftZoneHeight - templateDict[m_SoftZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneHeight.Id].CostTime / templateDict[m_SoftZoneHeight.Id].Config.duration) * (m_SoftZoneHeightDiff);
            }
            if(source.m_BiasX.IsUse)
            {
                m_BiasX.Add(new MixItem<System.Single>(id, priority, source.m_BiasX.CalculatorExpression, source.m_BiasX.Value, source.m_BiasX.IsUse));
               var targetValue = (m_BiasX.IsExpression ? m_BiasX.Value : m_BiasX.PrimitiveValue);
               m_BiasXDiff = targetValue - target.m_BiasX;
               if(templateDict[m_BiasX.Id].Config.alertCurve != null) m_BiasXAlertInit = target.m_BiasX - templateDict[m_BiasX.Id].Config.alertCurve.Evaluate(templateDict[m_BiasX.Id].CostTime / templateDict[m_BiasX.Id].Config.duration) * (m_BiasXDiff);
            }
            if(source.m_BiasY.IsUse)
            {
                m_BiasY.Add(new MixItem<System.Single>(id, priority, source.m_BiasY.CalculatorExpression, source.m_BiasY.Value, source.m_BiasY.IsUse));
               var targetValue = (m_BiasY.IsExpression ? m_BiasY.Value : m_BiasY.PrimitiveValue);
               m_BiasYDiff = targetValue - target.m_BiasY;
               if(templateDict[m_BiasY.Id].Config.alertCurve != null) m_BiasYAlertInit = target.m_BiasY - templateDict[m_BiasY.Id].Config.alertCurve.Evaluate(templateDict[m_BiasY.Id].CostTime / templateDict[m_BiasY.Id].Config.duration) * (m_BiasYDiff);
            }
            if(source.m_CenterOnActivate.IsUse)
            {
                m_CenterOnActivate.Add(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.CalculatorExpression, source.m_CenterOnActivate.Value, source.m_CenterOnActivate.IsUse));
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineGroupComposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineGroupComposer_Config source = (CameraMovement.Control_C_CinemachineGroupComposer_Config)sourceConfig;
            if(source.m_GroupFramingSize.IsUse)
            {
                m_GroupFramingSize.Remove(new MixItem<System.Single>(id, priority, source.m_GroupFramingSize.CalculatorExpression, source.m_GroupFramingSize.Value, source.m_GroupFramingSize.IsUse));
               var targetValue = (m_GroupFramingSize.IsExpression ? m_GroupFramingSize.Value : m_GroupFramingSize.PrimitiveValue);
               m_GroupFramingSizeDiff = targetValue - target.m_GroupFramingSize;
               if(templateDict[m_GroupFramingSize.Id].Config.alertCurve != null) m_GroupFramingSizeAlertInit = target.m_GroupFramingSize - templateDict[m_GroupFramingSize.Id].Config.alertCurve.Evaluate(templateDict[m_GroupFramingSize.Id].CostTime / templateDict[m_GroupFramingSize.Id].Config.duration) * (m_GroupFramingSizeDiff);
            }
            if(source.m_FramingMode.IsUse)
            {
                m_FramingMode.Remove(new MixItem<Cinemachine.CinemachineGroupComposer.FramingMode>(id, priority, source.m_FramingMode.CalculatorExpression, source.m_FramingMode.Value, source.m_FramingMode.IsUse));
            }
            if(source.m_FrameDamping.IsUse)
            {
                m_FrameDamping.Remove(new MixItem<System.Single>(id, priority, source.m_FrameDamping.CalculatorExpression, source.m_FrameDamping.Value, source.m_FrameDamping.IsUse));
               var targetValue = (m_FrameDamping.IsExpression ? m_FrameDamping.Value : m_FrameDamping.PrimitiveValue);
               m_FrameDampingDiff = targetValue - target.m_FrameDamping;
               if(templateDict[m_FrameDamping.Id].Config.alertCurve != null) m_FrameDampingAlertInit = target.m_FrameDamping - templateDict[m_FrameDamping.Id].Config.alertCurve.Evaluate(templateDict[m_FrameDamping.Id].CostTime / templateDict[m_FrameDamping.Id].Config.duration) * (m_FrameDampingDiff);
            }
            if(source.m_AdjustmentMode.IsUse)
            {
                m_AdjustmentMode.Remove(new MixItem<Cinemachine.CinemachineGroupComposer.AdjustmentMode>(id, priority, source.m_AdjustmentMode.CalculatorExpression, source.m_AdjustmentMode.Value, source.m_AdjustmentMode.IsUse));
            }
            if(source.m_MaxDollyIn.IsUse)
            {
                m_MaxDollyIn.Remove(new MixItem<System.Single>(id, priority, source.m_MaxDollyIn.CalculatorExpression, source.m_MaxDollyIn.Value, source.m_MaxDollyIn.IsUse));
               var targetValue = (m_MaxDollyIn.IsExpression ? m_MaxDollyIn.Value : m_MaxDollyIn.PrimitiveValue);
               m_MaxDollyInDiff = targetValue - target.m_MaxDollyIn;
               if(templateDict[m_MaxDollyIn.Id].Config.alertCurve != null) m_MaxDollyInAlertInit = target.m_MaxDollyIn - templateDict[m_MaxDollyIn.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyIn.Id].CostTime / templateDict[m_MaxDollyIn.Id].Config.duration) * (m_MaxDollyInDiff);
            }
            if(source.m_MaxDollyOut.IsUse)
            {
                m_MaxDollyOut.Remove(new MixItem<System.Single>(id, priority, source.m_MaxDollyOut.CalculatorExpression, source.m_MaxDollyOut.Value, source.m_MaxDollyOut.IsUse));
               var targetValue = (m_MaxDollyOut.IsExpression ? m_MaxDollyOut.Value : m_MaxDollyOut.PrimitiveValue);
               m_MaxDollyOutDiff = targetValue - target.m_MaxDollyOut;
               if(templateDict[m_MaxDollyOut.Id].Config.alertCurve != null) m_MaxDollyOutAlertInit = target.m_MaxDollyOut - templateDict[m_MaxDollyOut.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyOut.Id].CostTime / templateDict[m_MaxDollyOut.Id].Config.duration) * (m_MaxDollyOutDiff);
            }
            if(source.m_MinimumDistance.IsUse)
            {
                m_MinimumDistance.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumDistance.CalculatorExpression, source.m_MinimumDistance.Value, source.m_MinimumDistance.IsUse));
               var targetValue = (m_MinimumDistance.IsExpression ? m_MinimumDistance.Value : m_MinimumDistance.PrimitiveValue);
               m_MinimumDistanceDiff = targetValue - target.m_MinimumDistance;
               if(templateDict[m_MinimumDistance.Id].Config.alertCurve != null) m_MinimumDistanceAlertInit = target.m_MinimumDistance - templateDict[m_MinimumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistance.Id].CostTime / templateDict[m_MinimumDistance.Id].Config.duration) * (m_MinimumDistanceDiff);
            }
            if(source.m_MaximumDistance.IsUse)
            {
                m_MaximumDistance.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumDistance.CalculatorExpression, source.m_MaximumDistance.Value, source.m_MaximumDistance.IsUse));
               var targetValue = (m_MaximumDistance.IsExpression ? m_MaximumDistance.Value : m_MaximumDistance.PrimitiveValue);
               m_MaximumDistanceDiff = targetValue - target.m_MaximumDistance;
               if(templateDict[m_MaximumDistance.Id].Config.alertCurve != null) m_MaximumDistanceAlertInit = target.m_MaximumDistance - templateDict[m_MaximumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumDistance.Id].CostTime / templateDict[m_MaximumDistance.Id].Config.duration) * (m_MaximumDistanceDiff);
            }
            if(source.m_MinimumFOV.IsUse)
            {
                m_MinimumFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumFOV.CalculatorExpression, source.m_MinimumFOV.Value, source.m_MinimumFOV.IsUse));
               var targetValue = (m_MinimumFOV.IsExpression ? m_MinimumFOV.Value : m_MinimumFOV.PrimitiveValue);
               m_MinimumFOVDiff = targetValue - target.m_MinimumFOV;
               if(templateDict[m_MinimumFOV.Id].Config.alertCurve != null) m_MinimumFOVAlertInit = target.m_MinimumFOV - templateDict[m_MinimumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumFOV.Id].CostTime / templateDict[m_MinimumFOV.Id].Config.duration) * (m_MinimumFOVDiff);
            }
            if(source.m_MaximumFOV.IsUse)
            {
                m_MaximumFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumFOV.CalculatorExpression, source.m_MaximumFOV.Value, source.m_MaximumFOV.IsUse));
               var targetValue = (m_MaximumFOV.IsExpression ? m_MaximumFOV.Value : m_MaximumFOV.PrimitiveValue);
               m_MaximumFOVDiff = targetValue - target.m_MaximumFOV;
               if(templateDict[m_MaximumFOV.Id].Config.alertCurve != null) m_MaximumFOVAlertInit = target.m_MaximumFOV - templateDict[m_MaximumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumFOV.Id].CostTime / templateDict[m_MaximumFOV.Id].Config.duration) * (m_MaximumFOVDiff);
            }
            if(source.m_MinimumOrthoSize.IsUse)
            {
                m_MinimumOrthoSize.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumOrthoSize.CalculatorExpression, source.m_MinimumOrthoSize.Value, source.m_MinimumOrthoSize.IsUse));
               var targetValue = (m_MinimumOrthoSize.IsExpression ? m_MinimumOrthoSize.Value : m_MinimumOrthoSize.PrimitiveValue);
               m_MinimumOrthoSizeDiff = targetValue - target.m_MinimumOrthoSize;
               if(templateDict[m_MinimumOrthoSize.Id].Config.alertCurve != null) m_MinimumOrthoSizeAlertInit = target.m_MinimumOrthoSize - templateDict[m_MinimumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOrthoSize.Id].CostTime / templateDict[m_MinimumOrthoSize.Id].Config.duration) * (m_MinimumOrthoSizeDiff);
            }
            if(source.m_MaximumOrthoSize.IsUse)
            {
                m_MaximumOrthoSize.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumOrthoSize.CalculatorExpression, source.m_MaximumOrthoSize.Value, source.m_MaximumOrthoSize.IsUse));
               var targetValue = (m_MaximumOrthoSize.IsExpression ? m_MaximumOrthoSize.Value : m_MaximumOrthoSize.PrimitiveValue);
               m_MaximumOrthoSizeDiff = targetValue - target.m_MaximumOrthoSize;
               if(templateDict[m_MaximumOrthoSize.Id].Config.alertCurve != null) m_MaximumOrthoSizeAlertInit = target.m_MaximumOrthoSize - templateDict[m_MaximumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumOrthoSize.Id].CostTime / templateDict[m_MaximumOrthoSize.Id].Config.duration) * (m_MaximumOrthoSizeDiff);
            }
            if(source.m_TrackedObjectOffset.IsUse)
            {
                m_TrackedObjectOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.CalculatorExpression, source.m_TrackedObjectOffset.Value, source.m_TrackedObjectOffset.IsUse));
            }
            if(source.m_LookaheadTime.IsUse)
            {
                m_LookaheadTime.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.CalculatorExpression, source.m_LookaheadTime.Value, source.m_LookaheadTime.IsUse));
               var targetValue = (m_LookaheadTime.IsExpression ? m_LookaheadTime.Value : m_LookaheadTime.PrimitiveValue);
               m_LookaheadTimeDiff = targetValue - target.m_LookaheadTime;
               if(templateDict[m_LookaheadTime.Id].Config.alertCurve != null) m_LookaheadTimeAlertInit = target.m_LookaheadTime - templateDict[m_LookaheadTime.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadTime.Id].CostTime / templateDict[m_LookaheadTime.Id].Config.duration) * (m_LookaheadTimeDiff);
            }
            if(source.m_LookaheadSmoothing.IsUse)
            {
                m_LookaheadSmoothing.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.CalculatorExpression, source.m_LookaheadSmoothing.Value, source.m_LookaheadSmoothing.IsUse));
               var targetValue = (m_LookaheadSmoothing.IsExpression ? m_LookaheadSmoothing.Value : m_LookaheadSmoothing.PrimitiveValue);
               m_LookaheadSmoothingDiff = targetValue - target.m_LookaheadSmoothing;
               if(templateDict[m_LookaheadSmoothing.Id].Config.alertCurve != null) m_LookaheadSmoothingAlertInit = target.m_LookaheadSmoothing - templateDict[m_LookaheadSmoothing.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadSmoothing.Id].CostTime / templateDict[m_LookaheadSmoothing.Id].Config.duration) * (m_LookaheadSmoothingDiff);
            }
            if(source.m_LookaheadIgnoreY.IsUse)
            {
                m_LookaheadIgnoreY.Remove(new MixItem<System.Boolean>(id, priority, source.m_LookaheadIgnoreY.CalculatorExpression, source.m_LookaheadIgnoreY.Value, source.m_LookaheadIgnoreY.IsUse));
            }
            if(source.m_HorizontalDamping.IsUse)
            {
                m_HorizontalDamping.Remove(new MixItem<System.Single>(id, priority, source.m_HorizontalDamping.CalculatorExpression, source.m_HorizontalDamping.Value, source.m_HorizontalDamping.IsUse));
               var targetValue = (m_HorizontalDamping.IsExpression ? m_HorizontalDamping.Value : m_HorizontalDamping.PrimitiveValue);
               m_HorizontalDampingDiff = targetValue - target.m_HorizontalDamping;
               if(templateDict[m_HorizontalDamping.Id].Config.alertCurve != null) m_HorizontalDampingAlertInit = target.m_HorizontalDamping - templateDict[m_HorizontalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_HorizontalDamping.Id].CostTime / templateDict[m_HorizontalDamping.Id].Config.duration) * (m_HorizontalDampingDiff);
            }
            if(source.m_VerticalDamping.IsUse)
            {
                m_VerticalDamping.Remove(new MixItem<System.Single>(id, priority, source.m_VerticalDamping.CalculatorExpression, source.m_VerticalDamping.Value, source.m_VerticalDamping.IsUse));
               var targetValue = (m_VerticalDamping.IsExpression ? m_VerticalDamping.Value : m_VerticalDamping.PrimitiveValue);
               m_VerticalDampingDiff = targetValue - target.m_VerticalDamping;
               if(templateDict[m_VerticalDamping.Id].Config.alertCurve != null) m_VerticalDampingAlertInit = target.m_VerticalDamping - templateDict[m_VerticalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_VerticalDamping.Id].CostTime / templateDict[m_VerticalDamping.Id].Config.duration) * (m_VerticalDampingDiff);
            }
            if(source.m_ScreenX.IsUse)
            {
                m_ScreenX.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenX.CalculatorExpression, source.m_ScreenX.Value, source.m_ScreenX.IsUse));
               var targetValue = (m_ScreenX.IsExpression ? m_ScreenX.Value : m_ScreenX.PrimitiveValue);
               m_ScreenXDiff = targetValue - target.m_ScreenX;
               if(templateDict[m_ScreenX.Id].Config.alertCurve != null) m_ScreenXAlertInit = target.m_ScreenX - templateDict[m_ScreenX.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenX.Id].CostTime / templateDict[m_ScreenX.Id].Config.duration) * (m_ScreenXDiff);
            }
            if(source.m_ScreenY.IsUse)
            {
                m_ScreenY.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenY.CalculatorExpression, source.m_ScreenY.Value, source.m_ScreenY.IsUse));
               var targetValue = (m_ScreenY.IsExpression ? m_ScreenY.Value : m_ScreenY.PrimitiveValue);
               m_ScreenYDiff = targetValue - target.m_ScreenY;
               if(templateDict[m_ScreenY.Id].Config.alertCurve != null) m_ScreenYAlertInit = target.m_ScreenY - templateDict[m_ScreenY.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenY.Id].CostTime / templateDict[m_ScreenY.Id].Config.duration) * (m_ScreenYDiff);
            }
            if(source.m_DeadZoneWidth.IsUse)
            {
                m_DeadZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.CalculatorExpression, source.m_DeadZoneWidth.Value, source.m_DeadZoneWidth.IsUse));
               var targetValue = (m_DeadZoneWidth.IsExpression ? m_DeadZoneWidth.Value : m_DeadZoneWidth.PrimitiveValue);
               m_DeadZoneWidthDiff = targetValue - target.m_DeadZoneWidth;
               if(templateDict[m_DeadZoneWidth.Id].Config.alertCurve != null) m_DeadZoneWidthAlertInit = target.m_DeadZoneWidth - templateDict[m_DeadZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneWidth.Id].CostTime / templateDict[m_DeadZoneWidth.Id].Config.duration) * (m_DeadZoneWidthDiff);
            }
            if(source.m_DeadZoneHeight.IsUse)
            {
                m_DeadZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.CalculatorExpression, source.m_DeadZoneHeight.Value, source.m_DeadZoneHeight.IsUse));
               var targetValue = (m_DeadZoneHeight.IsExpression ? m_DeadZoneHeight.Value : m_DeadZoneHeight.PrimitiveValue);
               m_DeadZoneHeightDiff = targetValue - target.m_DeadZoneHeight;
               if(templateDict[m_DeadZoneHeight.Id].Config.alertCurve != null) m_DeadZoneHeightAlertInit = target.m_DeadZoneHeight - templateDict[m_DeadZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneHeight.Id].CostTime / templateDict[m_DeadZoneHeight.Id].Config.duration) * (m_DeadZoneHeightDiff);
            }
            if(source.m_SoftZoneWidth.IsUse)
            {
                m_SoftZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.CalculatorExpression, source.m_SoftZoneWidth.Value, source.m_SoftZoneWidth.IsUse));
               var targetValue = (m_SoftZoneWidth.IsExpression ? m_SoftZoneWidth.Value : m_SoftZoneWidth.PrimitiveValue);
               m_SoftZoneWidthDiff = targetValue - target.m_SoftZoneWidth;
               if(templateDict[m_SoftZoneWidth.Id].Config.alertCurve != null) m_SoftZoneWidthAlertInit = target.m_SoftZoneWidth - templateDict[m_SoftZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneWidth.Id].CostTime / templateDict[m_SoftZoneWidth.Id].Config.duration) * (m_SoftZoneWidthDiff);
            }
            if(source.m_SoftZoneHeight.IsUse)
            {
                m_SoftZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.CalculatorExpression, source.m_SoftZoneHeight.Value, source.m_SoftZoneHeight.IsUse));
               var targetValue = (m_SoftZoneHeight.IsExpression ? m_SoftZoneHeight.Value : m_SoftZoneHeight.PrimitiveValue);
               m_SoftZoneHeightDiff = targetValue - target.m_SoftZoneHeight;
               if(templateDict[m_SoftZoneHeight.Id].Config.alertCurve != null) m_SoftZoneHeightAlertInit = target.m_SoftZoneHeight - templateDict[m_SoftZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneHeight.Id].CostTime / templateDict[m_SoftZoneHeight.Id].Config.duration) * (m_SoftZoneHeightDiff);
            }
            if(source.m_BiasX.IsUse)
            {
                m_BiasX.Remove(new MixItem<System.Single>(id, priority, source.m_BiasX.CalculatorExpression, source.m_BiasX.Value, source.m_BiasX.IsUse));
               var targetValue = (m_BiasX.IsExpression ? m_BiasX.Value : m_BiasX.PrimitiveValue);
               m_BiasXDiff = targetValue - target.m_BiasX;
               if(templateDict[m_BiasX.Id].Config.alertCurve != null) m_BiasXAlertInit = target.m_BiasX - templateDict[m_BiasX.Id].Config.alertCurve.Evaluate(templateDict[m_BiasX.Id].CostTime / templateDict[m_BiasX.Id].Config.duration) * (m_BiasXDiff);
            }
            if(source.m_BiasY.IsUse)
            {
                m_BiasY.Remove(new MixItem<System.Single>(id, priority, source.m_BiasY.CalculatorExpression, source.m_BiasY.Value, source.m_BiasY.IsUse));
               var targetValue = (m_BiasY.IsExpression ? m_BiasY.Value : m_BiasY.PrimitiveValue);
               m_BiasYDiff = targetValue - target.m_BiasY;
               if(templateDict[m_BiasY.Id].Config.alertCurve != null) m_BiasYAlertInit = target.m_BiasY - templateDict[m_BiasY.Id].Config.alertCurve.Evaluate(templateDict[m_BiasY.Id].CostTime / templateDict[m_BiasY.Id].Config.duration) * (m_BiasYDiff);
            }
            if(source.m_CenterOnActivate.IsUse)
            {
                m_CenterOnActivate.Remove(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.CalculatorExpression, source.m_CenterOnActivate.Value, source.m_CenterOnActivate.IsUse));
            }
        }
        public void RemoveAll()
        {
            m_GroupFramingSize.RemoveAll();
            m_FramingMode.RemoveAll();
            m_FrameDamping.RemoveAll();
            m_AdjustmentMode.RemoveAll();
            m_MaxDollyIn.RemoveAll();
            m_MaxDollyOut.RemoveAll();
            m_MinimumDistance.RemoveAll();
            m_MaximumDistance.RemoveAll();
            m_MinimumFOV.RemoveAll();
            m_MaximumFOV.RemoveAll();
            m_MinimumOrthoSize.RemoveAll();
            m_MaximumOrthoSize.RemoveAll();
            m_TrackedObjectOffset.RemoveAll();
            m_LookaheadTime.RemoveAll();
            m_LookaheadSmoothing.RemoveAll();
            m_LookaheadIgnoreY.RemoveAll();
            m_HorizontalDamping.RemoveAll();
            m_VerticalDamping.RemoveAll();
            m_ScreenX.RemoveAll();
            m_ScreenY.RemoveAll();
            m_DeadZoneWidth.RemoveAll();
            m_DeadZoneHeight.RemoveAll();
            m_SoftZoneWidth.RemoveAll();
            m_SoftZoneHeight.RemoveAll();
            m_BiasX.RemoveAll();
            m_BiasY.RemoveAll();
            m_CenterOnActivate.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineGroupComposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_GroupFramingSize.IsUse && templateDict.ContainsKey(m_GroupFramingSize.Id))
            {
                var targetValue = (m_GroupFramingSize.IsExpression ? m_GroupFramingSize.Value : m_GroupFramingSize.PrimitiveValue);
                target.m_GroupFramingSize = Mathf.Approximately(0, templateDict[m_GroupFramingSize.Id].Config.duration) ? targetValue : m_GroupFramingSizeAlertInit + templateDict[m_GroupFramingSize.Id].Config.alertCurve.Evaluate(templateDict[m_GroupFramingSize.Id].CostTime / templateDict[m_GroupFramingSize.Id].Config.duration) * m_GroupFramingSizeDiff;
            }
            if (m_FramingMode.IsUse) target.m_FramingMode = m_FramingMode.IsExpression ? (Cinemachine.CinemachineGroupComposer.FramingMode)m_FramingMode.Value :m_FramingMode.PrimitiveValue;
            if (m_FrameDamping.IsUse && templateDict.ContainsKey(m_FrameDamping.Id))
            {
                var targetValue = (m_FrameDamping.IsExpression ? m_FrameDamping.Value : m_FrameDamping.PrimitiveValue);
                target.m_FrameDamping = Mathf.Approximately(0, templateDict[m_FrameDamping.Id].Config.duration) ? targetValue : m_FrameDampingAlertInit + templateDict[m_FrameDamping.Id].Config.alertCurve.Evaluate(templateDict[m_FrameDamping.Id].CostTime / templateDict[m_FrameDamping.Id].Config.duration) * m_FrameDampingDiff;
            }
            if (m_AdjustmentMode.IsUse) target.m_AdjustmentMode = m_AdjustmentMode.IsExpression ? (Cinemachine.CinemachineGroupComposer.AdjustmentMode)m_AdjustmentMode.Value :m_AdjustmentMode.PrimitiveValue;
            if (m_MaxDollyIn.IsUse && templateDict.ContainsKey(m_MaxDollyIn.Id))
            {
                var targetValue = (m_MaxDollyIn.IsExpression ? m_MaxDollyIn.Value : m_MaxDollyIn.PrimitiveValue);
                target.m_MaxDollyIn = Mathf.Approximately(0, templateDict[m_MaxDollyIn.Id].Config.duration) ? targetValue : m_MaxDollyInAlertInit + templateDict[m_MaxDollyIn.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyIn.Id].CostTime / templateDict[m_MaxDollyIn.Id].Config.duration) * m_MaxDollyInDiff;
            }
            if (m_MaxDollyOut.IsUse && templateDict.ContainsKey(m_MaxDollyOut.Id))
            {
                var targetValue = (m_MaxDollyOut.IsExpression ? m_MaxDollyOut.Value : m_MaxDollyOut.PrimitiveValue);
                target.m_MaxDollyOut = Mathf.Approximately(0, templateDict[m_MaxDollyOut.Id].Config.duration) ? targetValue : m_MaxDollyOutAlertInit + templateDict[m_MaxDollyOut.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyOut.Id].CostTime / templateDict[m_MaxDollyOut.Id].Config.duration) * m_MaxDollyOutDiff;
            }
            if (m_MinimumDistance.IsUse && templateDict.ContainsKey(m_MinimumDistance.Id))
            {
                var targetValue = (m_MinimumDistance.IsExpression ? m_MinimumDistance.Value : m_MinimumDistance.PrimitiveValue);
                target.m_MinimumDistance = Mathf.Approximately(0, templateDict[m_MinimumDistance.Id].Config.duration) ? targetValue : m_MinimumDistanceAlertInit + templateDict[m_MinimumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistance.Id].CostTime / templateDict[m_MinimumDistance.Id].Config.duration) * m_MinimumDistanceDiff;
            }
            if (m_MaximumDistance.IsUse && templateDict.ContainsKey(m_MaximumDistance.Id))
            {
                var targetValue = (m_MaximumDistance.IsExpression ? m_MaximumDistance.Value : m_MaximumDistance.PrimitiveValue);
                target.m_MaximumDistance = Mathf.Approximately(0, templateDict[m_MaximumDistance.Id].Config.duration) ? targetValue : m_MaximumDistanceAlertInit + templateDict[m_MaximumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumDistance.Id].CostTime / templateDict[m_MaximumDistance.Id].Config.duration) * m_MaximumDistanceDiff;
            }
            if (m_MinimumFOV.IsUse && templateDict.ContainsKey(m_MinimumFOV.Id))
            {
                var targetValue = (m_MinimumFOV.IsExpression ? m_MinimumFOV.Value : m_MinimumFOV.PrimitiveValue);
                target.m_MinimumFOV = Mathf.Approximately(0, templateDict[m_MinimumFOV.Id].Config.duration) ? targetValue : m_MinimumFOVAlertInit + templateDict[m_MinimumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumFOV.Id].CostTime / templateDict[m_MinimumFOV.Id].Config.duration) * m_MinimumFOVDiff;
            }
            if (m_MaximumFOV.IsUse && templateDict.ContainsKey(m_MaximumFOV.Id))
            {
                var targetValue = (m_MaximumFOV.IsExpression ? m_MaximumFOV.Value : m_MaximumFOV.PrimitiveValue);
                target.m_MaximumFOV = Mathf.Approximately(0, templateDict[m_MaximumFOV.Id].Config.duration) ? targetValue : m_MaximumFOVAlertInit + templateDict[m_MaximumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumFOV.Id].CostTime / templateDict[m_MaximumFOV.Id].Config.duration) * m_MaximumFOVDiff;
            }
            if (m_MinimumOrthoSize.IsUse && templateDict.ContainsKey(m_MinimumOrthoSize.Id))
            {
                var targetValue = (m_MinimumOrthoSize.IsExpression ? m_MinimumOrthoSize.Value : m_MinimumOrthoSize.PrimitiveValue);
                target.m_MinimumOrthoSize = Mathf.Approximately(0, templateDict[m_MinimumOrthoSize.Id].Config.duration) ? targetValue : m_MinimumOrthoSizeAlertInit + templateDict[m_MinimumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOrthoSize.Id].CostTime / templateDict[m_MinimumOrthoSize.Id].Config.duration) * m_MinimumOrthoSizeDiff;
            }
            if (m_MaximumOrthoSize.IsUse && templateDict.ContainsKey(m_MaximumOrthoSize.Id))
            {
                var targetValue = (m_MaximumOrthoSize.IsExpression ? m_MaximumOrthoSize.Value : m_MaximumOrthoSize.PrimitiveValue);
                target.m_MaximumOrthoSize = Mathf.Approximately(0, templateDict[m_MaximumOrthoSize.Id].Config.duration) ? targetValue : m_MaximumOrthoSizeAlertInit + templateDict[m_MaximumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumOrthoSize.Id].CostTime / templateDict[m_MaximumOrthoSize.Id].Config.duration) * m_MaximumOrthoSizeDiff;
            }
            if (m_LookaheadTime.IsUse && templateDict.ContainsKey(m_LookaheadTime.Id))
            {
                var targetValue = (m_LookaheadTime.IsExpression ? m_LookaheadTime.Value : m_LookaheadTime.PrimitiveValue);
                target.m_LookaheadTime = Mathf.Approximately(0, templateDict[m_LookaheadTime.Id].Config.duration) ? targetValue : m_LookaheadTimeAlertInit + templateDict[m_LookaheadTime.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadTime.Id].CostTime / templateDict[m_LookaheadTime.Id].Config.duration) * m_LookaheadTimeDiff;
            }
            if (m_LookaheadSmoothing.IsUse && templateDict.ContainsKey(m_LookaheadSmoothing.Id))
            {
                var targetValue = (m_LookaheadSmoothing.IsExpression ? m_LookaheadSmoothing.Value : m_LookaheadSmoothing.PrimitiveValue);
                target.m_LookaheadSmoothing = Mathf.Approximately(0, templateDict[m_LookaheadSmoothing.Id].Config.duration) ? targetValue : m_LookaheadSmoothingAlertInit + templateDict[m_LookaheadSmoothing.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadSmoothing.Id].CostTime / templateDict[m_LookaheadSmoothing.Id].Config.duration) * m_LookaheadSmoothingDiff;
            }
            if (m_LookaheadIgnoreY.IsUse) target.m_LookaheadIgnoreY = m_LookaheadIgnoreY.IsExpression ? !Mathf.Approximately(m_LookaheadIgnoreY.Value, 0) : m_LookaheadIgnoreY.PrimitiveValue;
            if (m_HorizontalDamping.IsUse && templateDict.ContainsKey(m_HorizontalDamping.Id))
            {
                var targetValue = (m_HorizontalDamping.IsExpression ? m_HorizontalDamping.Value : m_HorizontalDamping.PrimitiveValue);
                target.m_HorizontalDamping = Mathf.Approximately(0, templateDict[m_HorizontalDamping.Id].Config.duration) ? targetValue : m_HorizontalDampingAlertInit + templateDict[m_HorizontalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_HorizontalDamping.Id].CostTime / templateDict[m_HorizontalDamping.Id].Config.duration) * m_HorizontalDampingDiff;
            }
            if (m_VerticalDamping.IsUse && templateDict.ContainsKey(m_VerticalDamping.Id))
            {
                var targetValue = (m_VerticalDamping.IsExpression ? m_VerticalDamping.Value : m_VerticalDamping.PrimitiveValue);
                target.m_VerticalDamping = Mathf.Approximately(0, templateDict[m_VerticalDamping.Id].Config.duration) ? targetValue : m_VerticalDampingAlertInit + templateDict[m_VerticalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_VerticalDamping.Id].CostTime / templateDict[m_VerticalDamping.Id].Config.duration) * m_VerticalDampingDiff;
            }
            if (m_ScreenX.IsUse && templateDict.ContainsKey(m_ScreenX.Id))
            {
                var targetValue = (m_ScreenX.IsExpression ? m_ScreenX.Value : m_ScreenX.PrimitiveValue);
                target.m_ScreenX = Mathf.Approximately(0, templateDict[m_ScreenX.Id].Config.duration) ? targetValue : m_ScreenXAlertInit + templateDict[m_ScreenX.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenX.Id].CostTime / templateDict[m_ScreenX.Id].Config.duration) * m_ScreenXDiff;
            }
            if (m_ScreenY.IsUse && templateDict.ContainsKey(m_ScreenY.Id))
            {
                var targetValue = (m_ScreenY.IsExpression ? m_ScreenY.Value : m_ScreenY.PrimitiveValue);
                target.m_ScreenY = Mathf.Approximately(0, templateDict[m_ScreenY.Id].Config.duration) ? targetValue : m_ScreenYAlertInit + templateDict[m_ScreenY.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenY.Id].CostTime / templateDict[m_ScreenY.Id].Config.duration) * m_ScreenYDiff;
            }
            if (m_DeadZoneWidth.IsUse && templateDict.ContainsKey(m_DeadZoneWidth.Id))
            {
                var targetValue = (m_DeadZoneWidth.IsExpression ? m_DeadZoneWidth.Value : m_DeadZoneWidth.PrimitiveValue);
                target.m_DeadZoneWidth = Mathf.Approximately(0, templateDict[m_DeadZoneWidth.Id].Config.duration) ? targetValue : m_DeadZoneWidthAlertInit + templateDict[m_DeadZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneWidth.Id].CostTime / templateDict[m_DeadZoneWidth.Id].Config.duration) * m_DeadZoneWidthDiff;
            }
            if (m_DeadZoneHeight.IsUse && templateDict.ContainsKey(m_DeadZoneHeight.Id))
            {
                var targetValue = (m_DeadZoneHeight.IsExpression ? m_DeadZoneHeight.Value : m_DeadZoneHeight.PrimitiveValue);
                target.m_DeadZoneHeight = Mathf.Approximately(0, templateDict[m_DeadZoneHeight.Id].Config.duration) ? targetValue : m_DeadZoneHeightAlertInit + templateDict[m_DeadZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneHeight.Id].CostTime / templateDict[m_DeadZoneHeight.Id].Config.duration) * m_DeadZoneHeightDiff;
            }
            if (m_SoftZoneWidth.IsUse && templateDict.ContainsKey(m_SoftZoneWidth.Id))
            {
                var targetValue = (m_SoftZoneWidth.IsExpression ? m_SoftZoneWidth.Value : m_SoftZoneWidth.PrimitiveValue);
                target.m_SoftZoneWidth = Mathf.Approximately(0, templateDict[m_SoftZoneWidth.Id].Config.duration) ? targetValue : m_SoftZoneWidthAlertInit + templateDict[m_SoftZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneWidth.Id].CostTime / templateDict[m_SoftZoneWidth.Id].Config.duration) * m_SoftZoneWidthDiff;
            }
            if (m_SoftZoneHeight.IsUse && templateDict.ContainsKey(m_SoftZoneHeight.Id))
            {
                var targetValue = (m_SoftZoneHeight.IsExpression ? m_SoftZoneHeight.Value : m_SoftZoneHeight.PrimitiveValue);
                target.m_SoftZoneHeight = Mathf.Approximately(0, templateDict[m_SoftZoneHeight.Id].Config.duration) ? targetValue : m_SoftZoneHeightAlertInit + templateDict[m_SoftZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneHeight.Id].CostTime / templateDict[m_SoftZoneHeight.Id].Config.duration) * m_SoftZoneHeightDiff;
            }
            if (m_BiasX.IsUse && templateDict.ContainsKey(m_BiasX.Id))
            {
                var targetValue = (m_BiasX.IsExpression ? m_BiasX.Value : m_BiasX.PrimitiveValue);
                target.m_BiasX = Mathf.Approximately(0, templateDict[m_BiasX.Id].Config.duration) ? targetValue : m_BiasXAlertInit + templateDict[m_BiasX.Id].Config.alertCurve.Evaluate(templateDict[m_BiasX.Id].CostTime / templateDict[m_BiasX.Id].Config.duration) * m_BiasXDiff;
            }
            if (m_BiasY.IsUse && templateDict.ContainsKey(m_BiasY.Id))
            {
                var targetValue = (m_BiasY.IsExpression ? m_BiasY.Value : m_BiasY.PrimitiveValue);
                target.m_BiasY = Mathf.Approximately(0, templateDict[m_BiasY.Id].Config.duration) ? targetValue : m_BiasYAlertInit + templateDict[m_BiasY.Id].Config.alertCurve.Evaluate(templateDict[m_BiasY.Id].CostTime / templateDict[m_BiasY.Id].Config.duration) * m_BiasYDiff;
            }
            if (m_CenterOnActivate.IsUse) target.m_CenterOnActivate = m_CenterOnActivate.IsExpression ? !Mathf.Approximately(m_CenterOnActivate.Value, 0) : m_CenterOnActivate.PrimitiveValue;
        }
    }
}
