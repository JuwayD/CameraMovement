using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineComposer_Field :ICameraMovementControlField<Cinemachine.CinemachineComposer>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineComposer);

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
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineComposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineComposer_Config source = (CameraMovement.Control_C_CinemachineComposer_Config)sourceConfig;
            if(source.m_TrackedObjectOffset.IsUse)
            {
                m_TrackedObjectOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.CalculatorExpression, source.m_TrackedObjectOffset.Value, source.m_TrackedObjectOffset.IsUse));
            }
            if(source.m_LookaheadTime.IsUse)
            {
                m_LookaheadTime.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.CalculatorExpression, source.m_LookaheadTime.Value, source.m_LookaheadTime.IsUse));
               var targetValue = (m_LookaheadTime.IsExpression ? m_LookaheadTime.Value : m_LookaheadTime.PrimitiveValue);
               m_LookaheadTimeDiff = targetValue - target.m_LookaheadTime;
               m_LookaheadTimeAlertInit = target.m_LookaheadTime - templateDict[m_LookaheadTime.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadTime.Id].CostTime / templateDict[m_LookaheadTime.Id].Config.duration) * (m_LookaheadTimeDiff);
            }
            if(source.m_LookaheadSmoothing.IsUse)
            {
                m_LookaheadSmoothing.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.CalculatorExpression, source.m_LookaheadSmoothing.Value, source.m_LookaheadSmoothing.IsUse));
               var targetValue = (m_LookaheadSmoothing.IsExpression ? m_LookaheadSmoothing.Value : m_LookaheadSmoothing.PrimitiveValue);
               m_LookaheadSmoothingDiff = targetValue - target.m_LookaheadSmoothing;
               m_LookaheadSmoothingAlertInit = target.m_LookaheadSmoothing - templateDict[m_LookaheadSmoothing.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadSmoothing.Id].CostTime / templateDict[m_LookaheadSmoothing.Id].Config.duration) * (m_LookaheadSmoothingDiff);
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
               m_HorizontalDampingAlertInit = target.m_HorizontalDamping - templateDict[m_HorizontalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_HorizontalDamping.Id].CostTime / templateDict[m_HorizontalDamping.Id].Config.duration) * (m_HorizontalDampingDiff);
            }
            if(source.m_VerticalDamping.IsUse)
            {
                m_VerticalDamping.Add(new MixItem<System.Single>(id, priority, source.m_VerticalDamping.CalculatorExpression, source.m_VerticalDamping.Value, source.m_VerticalDamping.IsUse));
               var targetValue = (m_VerticalDamping.IsExpression ? m_VerticalDamping.Value : m_VerticalDamping.PrimitiveValue);
               m_VerticalDampingDiff = targetValue - target.m_VerticalDamping;
               m_VerticalDampingAlertInit = target.m_VerticalDamping - templateDict[m_VerticalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_VerticalDamping.Id].CostTime / templateDict[m_VerticalDamping.Id].Config.duration) * (m_VerticalDampingDiff);
            }
            if(source.m_ScreenX.IsUse)
            {
                m_ScreenX.Add(new MixItem<System.Single>(id, priority, source.m_ScreenX.CalculatorExpression, source.m_ScreenX.Value, source.m_ScreenX.IsUse));
               var targetValue = (m_ScreenX.IsExpression ? m_ScreenX.Value : m_ScreenX.PrimitiveValue);
               m_ScreenXDiff = targetValue - target.m_ScreenX;
               m_ScreenXAlertInit = target.m_ScreenX - templateDict[m_ScreenX.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenX.Id].CostTime / templateDict[m_ScreenX.Id].Config.duration) * (m_ScreenXDiff);
            }
            if(source.m_ScreenY.IsUse)
            {
                m_ScreenY.Add(new MixItem<System.Single>(id, priority, source.m_ScreenY.CalculatorExpression, source.m_ScreenY.Value, source.m_ScreenY.IsUse));
               var targetValue = (m_ScreenY.IsExpression ? m_ScreenY.Value : m_ScreenY.PrimitiveValue);
               m_ScreenYDiff = targetValue - target.m_ScreenY;
               m_ScreenYAlertInit = target.m_ScreenY - templateDict[m_ScreenY.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenY.Id].CostTime / templateDict[m_ScreenY.Id].Config.duration) * (m_ScreenYDiff);
            }
            if(source.m_DeadZoneWidth.IsUse)
            {
                m_DeadZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.CalculatorExpression, source.m_DeadZoneWidth.Value, source.m_DeadZoneWidth.IsUse));
               var targetValue = (m_DeadZoneWidth.IsExpression ? m_DeadZoneWidth.Value : m_DeadZoneWidth.PrimitiveValue);
               m_DeadZoneWidthDiff = targetValue - target.m_DeadZoneWidth;
               m_DeadZoneWidthAlertInit = target.m_DeadZoneWidth - templateDict[m_DeadZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneWidth.Id].CostTime / templateDict[m_DeadZoneWidth.Id].Config.duration) * (m_DeadZoneWidthDiff);
            }
            if(source.m_DeadZoneHeight.IsUse)
            {
                m_DeadZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.CalculatorExpression, source.m_DeadZoneHeight.Value, source.m_DeadZoneHeight.IsUse));
               var targetValue = (m_DeadZoneHeight.IsExpression ? m_DeadZoneHeight.Value : m_DeadZoneHeight.PrimitiveValue);
               m_DeadZoneHeightDiff = targetValue - target.m_DeadZoneHeight;
               m_DeadZoneHeightAlertInit = target.m_DeadZoneHeight - templateDict[m_DeadZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneHeight.Id].CostTime / templateDict[m_DeadZoneHeight.Id].Config.duration) * (m_DeadZoneHeightDiff);
            }
            if(source.m_SoftZoneWidth.IsUse)
            {
                m_SoftZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.CalculatorExpression, source.m_SoftZoneWidth.Value, source.m_SoftZoneWidth.IsUse));
               var targetValue = (m_SoftZoneWidth.IsExpression ? m_SoftZoneWidth.Value : m_SoftZoneWidth.PrimitiveValue);
               m_SoftZoneWidthDiff = targetValue - target.m_SoftZoneWidth;
               m_SoftZoneWidthAlertInit = target.m_SoftZoneWidth - templateDict[m_SoftZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneWidth.Id].CostTime / templateDict[m_SoftZoneWidth.Id].Config.duration) * (m_SoftZoneWidthDiff);
            }
            if(source.m_SoftZoneHeight.IsUse)
            {
                m_SoftZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.CalculatorExpression, source.m_SoftZoneHeight.Value, source.m_SoftZoneHeight.IsUse));
               var targetValue = (m_SoftZoneHeight.IsExpression ? m_SoftZoneHeight.Value : m_SoftZoneHeight.PrimitiveValue);
               m_SoftZoneHeightDiff = targetValue - target.m_SoftZoneHeight;
               m_SoftZoneHeightAlertInit = target.m_SoftZoneHeight - templateDict[m_SoftZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneHeight.Id].CostTime / templateDict[m_SoftZoneHeight.Id].Config.duration) * (m_SoftZoneHeightDiff);
            }
            if(source.m_BiasX.IsUse)
            {
                m_BiasX.Add(new MixItem<System.Single>(id, priority, source.m_BiasX.CalculatorExpression, source.m_BiasX.Value, source.m_BiasX.IsUse));
               var targetValue = (m_BiasX.IsExpression ? m_BiasX.Value : m_BiasX.PrimitiveValue);
               m_BiasXDiff = targetValue - target.m_BiasX;
               m_BiasXAlertInit = target.m_BiasX - templateDict[m_BiasX.Id].Config.alertCurve.Evaluate(templateDict[m_BiasX.Id].CostTime / templateDict[m_BiasX.Id].Config.duration) * (m_BiasXDiff);
            }
            if(source.m_BiasY.IsUse)
            {
                m_BiasY.Add(new MixItem<System.Single>(id, priority, source.m_BiasY.CalculatorExpression, source.m_BiasY.Value, source.m_BiasY.IsUse));
               var targetValue = (m_BiasY.IsExpression ? m_BiasY.Value : m_BiasY.PrimitiveValue);
               m_BiasYDiff = targetValue - target.m_BiasY;
               m_BiasYAlertInit = target.m_BiasY - templateDict[m_BiasY.Id].Config.alertCurve.Evaluate(templateDict[m_BiasY.Id].CostTime / templateDict[m_BiasY.Id].Config.duration) * (m_BiasYDiff);
            }
            if(source.m_CenterOnActivate.IsUse)
            {
                m_CenterOnActivate.Add(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.CalculatorExpression, source.m_CenterOnActivate.Value, source.m_CenterOnActivate.IsUse));
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineComposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineComposer_Config source = (CameraMovement.Control_C_CinemachineComposer_Config)sourceConfig;
            if(source.m_TrackedObjectOffset.IsUse)
            {
                m_TrackedObjectOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.CalculatorExpression, source.m_TrackedObjectOffset.Value, source.m_TrackedObjectOffset.IsUse));
            }
            if(source.m_LookaheadTime.IsUse)
            {
                m_LookaheadTime.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.CalculatorExpression, source.m_LookaheadTime.Value, source.m_LookaheadTime.IsUse));
               var targetValue = (m_LookaheadTime.IsExpression ? m_LookaheadTime.Value : m_LookaheadTime.PrimitiveValue);
               m_LookaheadTimeDiff = targetValue - target.m_LookaheadTime;
               m_LookaheadTimeAlertInit = target.m_LookaheadTime - templateDict[m_LookaheadTime.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadTime.Id].CostTime / templateDict[m_LookaheadTime.Id].Config.duration) * (m_LookaheadTimeDiff);
            }
            if(source.m_LookaheadSmoothing.IsUse)
            {
                m_LookaheadSmoothing.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.CalculatorExpression, source.m_LookaheadSmoothing.Value, source.m_LookaheadSmoothing.IsUse));
               var targetValue = (m_LookaheadSmoothing.IsExpression ? m_LookaheadSmoothing.Value : m_LookaheadSmoothing.PrimitiveValue);
               m_LookaheadSmoothingDiff = targetValue - target.m_LookaheadSmoothing;
               m_LookaheadSmoothingAlertInit = target.m_LookaheadSmoothing - templateDict[m_LookaheadSmoothing.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadSmoothing.Id].CostTime / templateDict[m_LookaheadSmoothing.Id].Config.duration) * (m_LookaheadSmoothingDiff);
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
               m_HorizontalDampingAlertInit = target.m_HorizontalDamping - templateDict[m_HorizontalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_HorizontalDamping.Id].CostTime / templateDict[m_HorizontalDamping.Id].Config.duration) * (m_HorizontalDampingDiff);
            }
            if(source.m_VerticalDamping.IsUse)
            {
                m_VerticalDamping.Remove(new MixItem<System.Single>(id, priority, source.m_VerticalDamping.CalculatorExpression, source.m_VerticalDamping.Value, source.m_VerticalDamping.IsUse));
               var targetValue = (m_VerticalDamping.IsExpression ? m_VerticalDamping.Value : m_VerticalDamping.PrimitiveValue);
               m_VerticalDampingDiff = targetValue - target.m_VerticalDamping;
               m_VerticalDampingAlertInit = target.m_VerticalDamping - templateDict[m_VerticalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_VerticalDamping.Id].CostTime / templateDict[m_VerticalDamping.Id].Config.duration) * (m_VerticalDampingDiff);
            }
            if(source.m_ScreenX.IsUse)
            {
                m_ScreenX.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenX.CalculatorExpression, source.m_ScreenX.Value, source.m_ScreenX.IsUse));
               var targetValue = (m_ScreenX.IsExpression ? m_ScreenX.Value : m_ScreenX.PrimitiveValue);
               m_ScreenXDiff = targetValue - target.m_ScreenX;
               m_ScreenXAlertInit = target.m_ScreenX - templateDict[m_ScreenX.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenX.Id].CostTime / templateDict[m_ScreenX.Id].Config.duration) * (m_ScreenXDiff);
            }
            if(source.m_ScreenY.IsUse)
            {
                m_ScreenY.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenY.CalculatorExpression, source.m_ScreenY.Value, source.m_ScreenY.IsUse));
               var targetValue = (m_ScreenY.IsExpression ? m_ScreenY.Value : m_ScreenY.PrimitiveValue);
               m_ScreenYDiff = targetValue - target.m_ScreenY;
               m_ScreenYAlertInit = target.m_ScreenY - templateDict[m_ScreenY.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenY.Id].CostTime / templateDict[m_ScreenY.Id].Config.duration) * (m_ScreenYDiff);
            }
            if(source.m_DeadZoneWidth.IsUse)
            {
                m_DeadZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.CalculatorExpression, source.m_DeadZoneWidth.Value, source.m_DeadZoneWidth.IsUse));
               var targetValue = (m_DeadZoneWidth.IsExpression ? m_DeadZoneWidth.Value : m_DeadZoneWidth.PrimitiveValue);
               m_DeadZoneWidthDiff = targetValue - target.m_DeadZoneWidth;
               m_DeadZoneWidthAlertInit = target.m_DeadZoneWidth - templateDict[m_DeadZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneWidth.Id].CostTime / templateDict[m_DeadZoneWidth.Id].Config.duration) * (m_DeadZoneWidthDiff);
            }
            if(source.m_DeadZoneHeight.IsUse)
            {
                m_DeadZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.CalculatorExpression, source.m_DeadZoneHeight.Value, source.m_DeadZoneHeight.IsUse));
               var targetValue = (m_DeadZoneHeight.IsExpression ? m_DeadZoneHeight.Value : m_DeadZoneHeight.PrimitiveValue);
               m_DeadZoneHeightDiff = targetValue - target.m_DeadZoneHeight;
               m_DeadZoneHeightAlertInit = target.m_DeadZoneHeight - templateDict[m_DeadZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneHeight.Id].CostTime / templateDict[m_DeadZoneHeight.Id].Config.duration) * (m_DeadZoneHeightDiff);
            }
            if(source.m_SoftZoneWidth.IsUse)
            {
                m_SoftZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.CalculatorExpression, source.m_SoftZoneWidth.Value, source.m_SoftZoneWidth.IsUse));
               var targetValue = (m_SoftZoneWidth.IsExpression ? m_SoftZoneWidth.Value : m_SoftZoneWidth.PrimitiveValue);
               m_SoftZoneWidthDiff = targetValue - target.m_SoftZoneWidth;
               m_SoftZoneWidthAlertInit = target.m_SoftZoneWidth - templateDict[m_SoftZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneWidth.Id].CostTime / templateDict[m_SoftZoneWidth.Id].Config.duration) * (m_SoftZoneWidthDiff);
            }
            if(source.m_SoftZoneHeight.IsUse)
            {
                m_SoftZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.CalculatorExpression, source.m_SoftZoneHeight.Value, source.m_SoftZoneHeight.IsUse));
               var targetValue = (m_SoftZoneHeight.IsExpression ? m_SoftZoneHeight.Value : m_SoftZoneHeight.PrimitiveValue);
               m_SoftZoneHeightDiff = targetValue - target.m_SoftZoneHeight;
               m_SoftZoneHeightAlertInit = target.m_SoftZoneHeight - templateDict[m_SoftZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneHeight.Id].CostTime / templateDict[m_SoftZoneHeight.Id].Config.duration) * (m_SoftZoneHeightDiff);
            }
            if(source.m_BiasX.IsUse)
            {
                m_BiasX.Remove(new MixItem<System.Single>(id, priority, source.m_BiasX.CalculatorExpression, source.m_BiasX.Value, source.m_BiasX.IsUse));
               var targetValue = (m_BiasX.IsExpression ? m_BiasX.Value : m_BiasX.PrimitiveValue);
               m_BiasXDiff = targetValue - target.m_BiasX;
               m_BiasXAlertInit = target.m_BiasX - templateDict[m_BiasX.Id].Config.alertCurve.Evaluate(templateDict[m_BiasX.Id].CostTime / templateDict[m_BiasX.Id].Config.duration) * (m_BiasXDiff);
            }
            if(source.m_BiasY.IsUse)
            {
                m_BiasY.Remove(new MixItem<System.Single>(id, priority, source.m_BiasY.CalculatorExpression, source.m_BiasY.Value, source.m_BiasY.IsUse));
               var targetValue = (m_BiasY.IsExpression ? m_BiasY.Value : m_BiasY.PrimitiveValue);
               m_BiasYDiff = targetValue - target.m_BiasY;
               m_BiasYAlertInit = target.m_BiasY - templateDict[m_BiasY.Id].Config.alertCurve.Evaluate(templateDict[m_BiasY.Id].CostTime / templateDict[m_BiasY.Id].Config.duration) * (m_BiasYDiff);
            }
            if(source.m_CenterOnActivate.IsUse)
            {
                m_CenterOnActivate.Remove(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.CalculatorExpression, source.m_CenterOnActivate.Value, source.m_CenterOnActivate.IsUse));
            }
        }
        public void RemoveAll()
        {
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
        public void ControlCinemachine(ref Cinemachine.CinemachineComposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
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
