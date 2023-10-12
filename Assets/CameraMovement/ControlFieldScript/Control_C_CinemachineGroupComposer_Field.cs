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
       [UnityEngine.TooltipAttribute("What screen dimensions to consider when framing.  Can be Horizontal, Vertical, or both")]
            public DataMixer <Cinemachine.CinemachineGroupComposer.FramingMode> m_FramingMode;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to frame the group. Small numbers are more responsive, rapidly adjusting the camera to keep the group in the frame.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_FrameDamping;
        public float m_FrameDampingAlertInit;
       [UnityEngine.TooltipAttribute("How to adjust the camera to get the desired framing.  You can zoom, dolly in/out, or do both.")]
            public DataMixer <Cinemachine.CinemachineGroupComposer.AdjustmentMode> m_AdjustmentMode;
       [UnityEngine.TooltipAttribute("The maximum distance toward the target that this behaviour is allowed to move the camera.")]
            public DataMixer <System.Single> m_MaxDollyIn;
        public float m_MaxDollyInAlertInit;
       [UnityEngine.TooltipAttribute("The maximum distance away the target that this behaviour is allowed to move the camera.")]
            public DataMixer <System.Single> m_MaxDollyOut;
        public float m_MaxDollyOutAlertInit;
       [UnityEngine.TooltipAttribute("Set this to limit how close to the target the camera can get.")]
            public DataMixer <System.Single> m_MinimumDistance;
        public float m_MinimumDistanceAlertInit;
       [UnityEngine.TooltipAttribute("Set this to limit how far from the target the camera can get.")]
            public DataMixer <System.Single> m_MaximumDistance;
        public float m_MaximumDistanceAlertInit;
       [UnityEngine.TooltipAttribute("If adjusting FOV, will not set the FOV lower than this.")]
            public DataMixer <System.Single> m_MinimumFOV;
        public float m_MinimumFOVAlertInit;
       [UnityEngine.TooltipAttribute("If adjusting FOV, will not set the FOV higher than this.")]
            public DataMixer <System.Single> m_MaximumFOV;
        public float m_MaximumFOVAlertInit;
       [UnityEngine.TooltipAttribute("If adjusting Orthographic Size, will not set it lower than this.")]
            public DataMixer <System.Single> m_MinimumOrthoSize;
        public float m_MinimumOrthoSizeAlertInit;
       [UnityEngine.TooltipAttribute("If adjusting Orthographic Size, will not set it higher than this.")]
            public DataMixer <System.Single> m_MaximumOrthoSize;
        public float m_MaximumOrthoSizeAlertInit;
       [UnityEngine.TooltipAttribute("Target offset from the target object's center in target-local space. Use this to fine-tune the tracking target position when the desired area is not the tracked object's center.")]
            public DataMixer <UnityEngine.Vector3> m_TrackedObjectOffset;
       [UnityEngine.TooltipAttribute("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
            public DataMixer <System.Single> m_LookaheadTime;
        public float m_LookaheadTimeAlertInit;
       [UnityEngine.TooltipAttribute("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
            public DataMixer <System.Single> m_LookaheadSmoothing;
        public float m_LookaheadSmoothingAlertInit;
       [UnityEngine.TooltipAttribute("If checked, movement along the Y axis will be ignored for lookahead calculations")]
            public DataMixer <System.Boolean> m_LookaheadIgnoreY;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to follow the target in the screen-horizontal direction. Small numbers are more responsive, rapidly orienting the camera to keep the target in the dead zone. Larger numbers give a more heavy slowly responding camera. Using different vertical and horizontal settings can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_HorizontalDamping;
        public float m_HorizontalDampingAlertInit;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to follow the target in the screen-vertical direction. Small numbers are more responsive, rapidly orienting the camera to keep the target in the dead zone. Larger numbers give a more heavy slowly responding camera. Using different vertical and horizontal settings can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_VerticalDamping;
        public float m_VerticalDampingAlertInit;
       [UnityEngine.TooltipAttribute("Horizontal screen position for target. The camera will rotate to position the tracked object here.")]
            public DataMixer <System.Single> m_ScreenX;
        public float m_ScreenXAlertInit;
       [UnityEngine.TooltipAttribute("Vertical screen position for target, The camera will rotate to position the tracked object here.")]
            public DataMixer <System.Single> m_ScreenY;
        public float m_ScreenYAlertInit;
       [UnityEngine.TooltipAttribute("Camera will not rotate horizontally if the target is within this range of the position.")]
            public DataMixer <System.Single> m_DeadZoneWidth;
        public float m_DeadZoneWidthAlertInit;
       [UnityEngine.TooltipAttribute("Camera will not rotate vertically if the target is within this range of the position.")]
            public DataMixer <System.Single> m_DeadZoneHeight;
        public float m_DeadZoneHeightAlertInit;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually rotate horizontally to re-align towards the desired position, depending on the damping speed.")]
            public DataMixer <System.Single> m_SoftZoneWidth;
        public float m_SoftZoneWidthAlertInit;
       [UnityEngine.TooltipAttribute("When target is within this region, camera will gradually rotate vertically to re-align towards the desired position, depending on the damping speed.")]
            public DataMixer <System.Single> m_SoftZoneHeight;
        public float m_SoftZoneHeightAlertInit;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
            public DataMixer <System.Single> m_BiasX;
        public float m_BiasXAlertInit;
       [UnityEngine.TooltipAttribute("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
            public DataMixer <System.Single> m_BiasY;
        public float m_BiasYAlertInit;
       [UnityEngine.TooltipAttribute("Force target to center of screen when this camera activates.  If false, will clamp target to the edges of the dead zone")]
            public DataMixer <System.Boolean> m_CenterOnActivate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineGroupComposer target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineGroupComposer_Config source = (CameraMovement.Control_C_CinemachineGroupComposer_Config)sourceConfig;
                if(source.m_GroupFramingSize.IsUse)
                {
                    m_GroupFramingSizeAlertInit = target.m_GroupFramingSize;
                    m_GroupFramingSize.Add(new MixItem<System.Single>(id, priority, source.m_GroupFramingSize.CalculatorExpression, source.m_GroupFramingSize.Value, source.m_GroupFramingSize.IsUse));
                }
                if(source.m_FramingMode.IsUse)
                {
                    m_FramingMode.Add(new MixItem<Cinemachine.CinemachineGroupComposer.FramingMode>(id, priority, source.m_FramingMode.CalculatorExpression, source.m_FramingMode.Value, source.m_FramingMode.IsUse));
                }
                if(source.m_FrameDamping.IsUse)
                {
                    m_FrameDampingAlertInit = target.m_FrameDamping;
                    m_FrameDamping.Add(new MixItem<System.Single>(id, priority, source.m_FrameDamping.CalculatorExpression, source.m_FrameDamping.Value, source.m_FrameDamping.IsUse));
                }
                if(source.m_AdjustmentMode.IsUse)
                {
                    m_AdjustmentMode.Add(new MixItem<Cinemachine.CinemachineGroupComposer.AdjustmentMode>(id, priority, source.m_AdjustmentMode.CalculatorExpression, source.m_AdjustmentMode.Value, source.m_AdjustmentMode.IsUse));
                }
                if(source.m_MaxDollyIn.IsUse)
                {
                    m_MaxDollyInAlertInit = target.m_MaxDollyIn;
                    m_MaxDollyIn.Add(new MixItem<System.Single>(id, priority, source.m_MaxDollyIn.CalculatorExpression, source.m_MaxDollyIn.Value, source.m_MaxDollyIn.IsUse));
                }
                if(source.m_MaxDollyOut.IsUse)
                {
                    m_MaxDollyOutAlertInit = target.m_MaxDollyOut;
                    m_MaxDollyOut.Add(new MixItem<System.Single>(id, priority, source.m_MaxDollyOut.CalculatorExpression, source.m_MaxDollyOut.Value, source.m_MaxDollyOut.IsUse));
                }
                if(source.m_MinimumDistance.IsUse)
                {
                    m_MinimumDistanceAlertInit = target.m_MinimumDistance;
                    m_MinimumDistance.Add(new MixItem<System.Single>(id, priority, source.m_MinimumDistance.CalculatorExpression, source.m_MinimumDistance.Value, source.m_MinimumDistance.IsUse));
                }
                if(source.m_MaximumDistance.IsUse)
                {
                    m_MaximumDistanceAlertInit = target.m_MaximumDistance;
                    m_MaximumDistance.Add(new MixItem<System.Single>(id, priority, source.m_MaximumDistance.CalculatorExpression, source.m_MaximumDistance.Value, source.m_MaximumDistance.IsUse));
                }
                if(source.m_MinimumFOV.IsUse)
                {
                    m_MinimumFOVAlertInit = target.m_MinimumFOV;
                    m_MinimumFOV.Add(new MixItem<System.Single>(id, priority, source.m_MinimumFOV.CalculatorExpression, source.m_MinimumFOV.Value, source.m_MinimumFOV.IsUse));
                }
                if(source.m_MaximumFOV.IsUse)
                {
                    m_MaximumFOVAlertInit = target.m_MaximumFOV;
                    m_MaximumFOV.Add(new MixItem<System.Single>(id, priority, source.m_MaximumFOV.CalculatorExpression, source.m_MaximumFOV.Value, source.m_MaximumFOV.IsUse));
                }
                if(source.m_MinimumOrthoSize.IsUse)
                {
                    m_MinimumOrthoSizeAlertInit = target.m_MinimumOrthoSize;
                    m_MinimumOrthoSize.Add(new MixItem<System.Single>(id, priority, source.m_MinimumOrthoSize.CalculatorExpression, source.m_MinimumOrthoSize.Value, source.m_MinimumOrthoSize.IsUse));
                }
                if(source.m_MaximumOrthoSize.IsUse)
                {
                    m_MaximumOrthoSizeAlertInit = target.m_MaximumOrthoSize;
                    m_MaximumOrthoSize.Add(new MixItem<System.Single>(id, priority, source.m_MaximumOrthoSize.CalculatorExpression, source.m_MaximumOrthoSize.Value, source.m_MaximumOrthoSize.IsUse));
                }
                if(source.m_TrackedObjectOffset.IsUse)
                {
                    m_TrackedObjectOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.CalculatorExpression, source.m_TrackedObjectOffset.Value, source.m_TrackedObjectOffset.IsUse));
                }
                if(source.m_LookaheadTime.IsUse)
                {
                    m_LookaheadTimeAlertInit = target.m_LookaheadTime;
                    m_LookaheadTime.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.CalculatorExpression, source.m_LookaheadTime.Value, source.m_LookaheadTime.IsUse));
                }
                if(source.m_LookaheadSmoothing.IsUse)
                {
                    m_LookaheadSmoothingAlertInit = target.m_LookaheadSmoothing;
                    m_LookaheadSmoothing.Add(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.CalculatorExpression, source.m_LookaheadSmoothing.Value, source.m_LookaheadSmoothing.IsUse));
                }
                if(source.m_LookaheadIgnoreY.IsUse)
                {
                    m_LookaheadIgnoreY.Add(new MixItem<System.Boolean>(id, priority, source.m_LookaheadIgnoreY.CalculatorExpression, source.m_LookaheadIgnoreY.Value, source.m_LookaheadIgnoreY.IsUse));
                }
                if(source.m_HorizontalDamping.IsUse)
                {
                    m_HorizontalDampingAlertInit = target.m_HorizontalDamping;
                    m_HorizontalDamping.Add(new MixItem<System.Single>(id, priority, source.m_HorizontalDamping.CalculatorExpression, source.m_HorizontalDamping.Value, source.m_HorizontalDamping.IsUse));
                }
                if(source.m_VerticalDamping.IsUse)
                {
                    m_VerticalDampingAlertInit = target.m_VerticalDamping;
                    m_VerticalDamping.Add(new MixItem<System.Single>(id, priority, source.m_VerticalDamping.CalculatorExpression, source.m_VerticalDamping.Value, source.m_VerticalDamping.IsUse));
                }
                if(source.m_ScreenX.IsUse)
                {
                    m_ScreenXAlertInit = target.m_ScreenX;
                    m_ScreenX.Add(new MixItem<System.Single>(id, priority, source.m_ScreenX.CalculatorExpression, source.m_ScreenX.Value, source.m_ScreenX.IsUse));
                }
                if(source.m_ScreenY.IsUse)
                {
                    m_ScreenYAlertInit = target.m_ScreenY;
                    m_ScreenY.Add(new MixItem<System.Single>(id, priority, source.m_ScreenY.CalculatorExpression, source.m_ScreenY.Value, source.m_ScreenY.IsUse));
                }
                if(source.m_DeadZoneWidth.IsUse)
                {
                    m_DeadZoneWidthAlertInit = target.m_DeadZoneWidth;
                    m_DeadZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.CalculatorExpression, source.m_DeadZoneWidth.Value, source.m_DeadZoneWidth.IsUse));
                }
                if(source.m_DeadZoneHeight.IsUse)
                {
                    m_DeadZoneHeightAlertInit = target.m_DeadZoneHeight;
                    m_DeadZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.CalculatorExpression, source.m_DeadZoneHeight.Value, source.m_DeadZoneHeight.IsUse));
                }
                if(source.m_SoftZoneWidth.IsUse)
                {
                    m_SoftZoneWidthAlertInit = target.m_SoftZoneWidth;
                    m_SoftZoneWidth.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.CalculatorExpression, source.m_SoftZoneWidth.Value, source.m_SoftZoneWidth.IsUse));
                }
                if(source.m_SoftZoneHeight.IsUse)
                {
                    m_SoftZoneHeightAlertInit = target.m_SoftZoneHeight;
                    m_SoftZoneHeight.Add(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.CalculatorExpression, source.m_SoftZoneHeight.Value, source.m_SoftZoneHeight.IsUse));
                }
                if(source.m_BiasX.IsUse)
                {
                    m_BiasXAlertInit = target.m_BiasX;
                    m_BiasX.Add(new MixItem<System.Single>(id, priority, source.m_BiasX.CalculatorExpression, source.m_BiasX.Value, source.m_BiasX.IsUse));
                }
                if(source.m_BiasY.IsUse)
                {
                    m_BiasYAlertInit = target.m_BiasY;
                    m_BiasY.Add(new MixItem<System.Single>(id, priority, source.m_BiasY.CalculatorExpression, source.m_BiasY.Value, source.m_BiasY.IsUse));
                }
                if(source.m_CenterOnActivate.IsUse)
                {
                    m_CenterOnActivate.Add(new MixItem<System.Boolean>(id, priority, source.m_CenterOnActivate.CalculatorExpression, source.m_CenterOnActivate.Value, source.m_CenterOnActivate.IsUse));
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineGroupComposer target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineGroupComposer_Config source = (CameraMovement.Control_C_CinemachineGroupComposer_Config)sourceConfig;
                if(source.m_GroupFramingSize.IsUse)
                {
                    m_GroupFramingSizeAlertInit = target.m_GroupFramingSize;
                    m_GroupFramingSize.Remove(new MixItem<System.Single>(id, priority, source.m_GroupFramingSize.CalculatorExpression, source.m_GroupFramingSize.Value, source.m_GroupFramingSize.IsUse));
                }
                if(source.m_FramingMode.IsUse)
                {
                    m_FramingMode.Remove(new MixItem<Cinemachine.CinemachineGroupComposer.FramingMode>(id, priority, source.m_FramingMode.CalculatorExpression, source.m_FramingMode.Value, source.m_FramingMode.IsUse));
                }
                if(source.m_FrameDamping.IsUse)
                {
                    m_FrameDampingAlertInit = target.m_FrameDamping;
                    m_FrameDamping.Remove(new MixItem<System.Single>(id, priority, source.m_FrameDamping.CalculatorExpression, source.m_FrameDamping.Value, source.m_FrameDamping.IsUse));
                }
                if(source.m_AdjustmentMode.IsUse)
                {
                    m_AdjustmentMode.Remove(new MixItem<Cinemachine.CinemachineGroupComposer.AdjustmentMode>(id, priority, source.m_AdjustmentMode.CalculatorExpression, source.m_AdjustmentMode.Value, source.m_AdjustmentMode.IsUse));
                }
                if(source.m_MaxDollyIn.IsUse)
                {
                    m_MaxDollyInAlertInit = target.m_MaxDollyIn;
                    m_MaxDollyIn.Remove(new MixItem<System.Single>(id, priority, source.m_MaxDollyIn.CalculatorExpression, source.m_MaxDollyIn.Value, source.m_MaxDollyIn.IsUse));
                }
                if(source.m_MaxDollyOut.IsUse)
                {
                    m_MaxDollyOutAlertInit = target.m_MaxDollyOut;
                    m_MaxDollyOut.Remove(new MixItem<System.Single>(id, priority, source.m_MaxDollyOut.CalculatorExpression, source.m_MaxDollyOut.Value, source.m_MaxDollyOut.IsUse));
                }
                if(source.m_MinimumDistance.IsUse)
                {
                    m_MinimumDistanceAlertInit = target.m_MinimumDistance;
                    m_MinimumDistance.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumDistance.CalculatorExpression, source.m_MinimumDistance.Value, source.m_MinimumDistance.IsUse));
                }
                if(source.m_MaximumDistance.IsUse)
                {
                    m_MaximumDistanceAlertInit = target.m_MaximumDistance;
                    m_MaximumDistance.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumDistance.CalculatorExpression, source.m_MaximumDistance.Value, source.m_MaximumDistance.IsUse));
                }
                if(source.m_MinimumFOV.IsUse)
                {
                    m_MinimumFOVAlertInit = target.m_MinimumFOV;
                    m_MinimumFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumFOV.CalculatorExpression, source.m_MinimumFOV.Value, source.m_MinimumFOV.IsUse));
                }
                if(source.m_MaximumFOV.IsUse)
                {
                    m_MaximumFOVAlertInit = target.m_MaximumFOV;
                    m_MaximumFOV.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumFOV.CalculatorExpression, source.m_MaximumFOV.Value, source.m_MaximumFOV.IsUse));
                }
                if(source.m_MinimumOrthoSize.IsUse)
                {
                    m_MinimumOrthoSizeAlertInit = target.m_MinimumOrthoSize;
                    m_MinimumOrthoSize.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumOrthoSize.CalculatorExpression, source.m_MinimumOrthoSize.Value, source.m_MinimumOrthoSize.IsUse));
                }
                if(source.m_MaximumOrthoSize.IsUse)
                {
                    m_MaximumOrthoSizeAlertInit = target.m_MaximumOrthoSize;
                    m_MaximumOrthoSize.Remove(new MixItem<System.Single>(id, priority, source.m_MaximumOrthoSize.CalculatorExpression, source.m_MaximumOrthoSize.Value, source.m_MaximumOrthoSize.IsUse));
                }
                if(source.m_TrackedObjectOffset.IsUse)
                {
                    m_TrackedObjectOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_TrackedObjectOffset.CalculatorExpression, source.m_TrackedObjectOffset.Value, source.m_TrackedObjectOffset.IsUse));
                }
                if(source.m_LookaheadTime.IsUse)
                {
                    m_LookaheadTimeAlertInit = target.m_LookaheadTime;
                    m_LookaheadTime.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadTime.CalculatorExpression, source.m_LookaheadTime.Value, source.m_LookaheadTime.IsUse));
                }
                if(source.m_LookaheadSmoothing.IsUse)
                {
                    m_LookaheadSmoothingAlertInit = target.m_LookaheadSmoothing;
                    m_LookaheadSmoothing.Remove(new MixItem<System.Single>(id, priority, source.m_LookaheadSmoothing.CalculatorExpression, source.m_LookaheadSmoothing.Value, source.m_LookaheadSmoothing.IsUse));
                }
                if(source.m_LookaheadIgnoreY.IsUse)
                {
                    m_LookaheadIgnoreY.Remove(new MixItem<System.Boolean>(id, priority, source.m_LookaheadIgnoreY.CalculatorExpression, source.m_LookaheadIgnoreY.Value, source.m_LookaheadIgnoreY.IsUse));
                }
                if(source.m_HorizontalDamping.IsUse)
                {
                    m_HorizontalDampingAlertInit = target.m_HorizontalDamping;
                    m_HorizontalDamping.Remove(new MixItem<System.Single>(id, priority, source.m_HorizontalDamping.CalculatorExpression, source.m_HorizontalDamping.Value, source.m_HorizontalDamping.IsUse));
                }
                if(source.m_VerticalDamping.IsUse)
                {
                    m_VerticalDampingAlertInit = target.m_VerticalDamping;
                    m_VerticalDamping.Remove(new MixItem<System.Single>(id, priority, source.m_VerticalDamping.CalculatorExpression, source.m_VerticalDamping.Value, source.m_VerticalDamping.IsUse));
                }
                if(source.m_ScreenX.IsUse)
                {
                    m_ScreenXAlertInit = target.m_ScreenX;
                    m_ScreenX.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenX.CalculatorExpression, source.m_ScreenX.Value, source.m_ScreenX.IsUse));
                }
                if(source.m_ScreenY.IsUse)
                {
                    m_ScreenYAlertInit = target.m_ScreenY;
                    m_ScreenY.Remove(new MixItem<System.Single>(id, priority, source.m_ScreenY.CalculatorExpression, source.m_ScreenY.Value, source.m_ScreenY.IsUse));
                }
                if(source.m_DeadZoneWidth.IsUse)
                {
                    m_DeadZoneWidthAlertInit = target.m_DeadZoneWidth;
                    m_DeadZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneWidth.CalculatorExpression, source.m_DeadZoneWidth.Value, source.m_DeadZoneWidth.IsUse));
                }
                if(source.m_DeadZoneHeight.IsUse)
                {
                    m_DeadZoneHeightAlertInit = target.m_DeadZoneHeight;
                    m_DeadZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_DeadZoneHeight.CalculatorExpression, source.m_DeadZoneHeight.Value, source.m_DeadZoneHeight.IsUse));
                }
                if(source.m_SoftZoneWidth.IsUse)
                {
                    m_SoftZoneWidthAlertInit = target.m_SoftZoneWidth;
                    m_SoftZoneWidth.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneWidth.CalculatorExpression, source.m_SoftZoneWidth.Value, source.m_SoftZoneWidth.IsUse));
                }
                if(source.m_SoftZoneHeight.IsUse)
                {
                    m_SoftZoneHeightAlertInit = target.m_SoftZoneHeight;
                    m_SoftZoneHeight.Remove(new MixItem<System.Single>(id, priority, source.m_SoftZoneHeight.CalculatorExpression, source.m_SoftZoneHeight.Value, source.m_SoftZoneHeight.IsUse));
                }
                if(source.m_BiasX.IsUse)
                {
                    m_BiasXAlertInit = target.m_BiasX;
                    m_BiasX.Remove(new MixItem<System.Single>(id, priority, source.m_BiasX.CalculatorExpression, source.m_BiasX.Value, source.m_BiasX.IsUse));
                }
                if(source.m_BiasY.IsUse)
                {
                    m_BiasYAlertInit = target.m_BiasY;
                    m_BiasY.Remove(new MixItem<System.Single>(id, priority, source.m_BiasY.CalculatorExpression, source.m_BiasY.Value, source.m_BiasY.IsUse));
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
                target.m_GroupFramingSize = Mathf.Approximately(0, templateDict[m_GroupFramingSize.Id].Config.duration) ? targetValue : m_GroupFramingSizeAlertInit + templateDict[m_GroupFramingSize.Id].Config.alertCurve.Evaluate(templateDict[m_GroupFramingSize.Id].CostTime / templateDict[m_GroupFramingSize.Id].Config.duration) * (targetValue - m_GroupFramingSizeAlertInit);
            }
            if (m_FramingMode.IsUse) target.m_FramingMode = m_FramingMode.IsExpression ? (Cinemachine.CinemachineGroupComposer.FramingMode)m_FramingMode.Value :m_FramingMode.PrimitiveValue;
            if (m_FrameDamping.IsUse && templateDict.ContainsKey(m_FrameDamping.Id))
            {
                var targetValue = (m_FrameDamping.IsExpression ? m_FrameDamping.Value : m_FrameDamping.PrimitiveValue);
                target.m_FrameDamping = Mathf.Approximately(0, templateDict[m_FrameDamping.Id].Config.duration) ? targetValue : m_FrameDampingAlertInit + templateDict[m_FrameDamping.Id].Config.alertCurve.Evaluate(templateDict[m_FrameDamping.Id].CostTime / templateDict[m_FrameDamping.Id].Config.duration) * (targetValue - m_FrameDampingAlertInit);
            }
            if (m_AdjustmentMode.IsUse) target.m_AdjustmentMode = m_AdjustmentMode.IsExpression ? (Cinemachine.CinemachineGroupComposer.AdjustmentMode)m_AdjustmentMode.Value :m_AdjustmentMode.PrimitiveValue;
            if (m_MaxDollyIn.IsUse && templateDict.ContainsKey(m_MaxDollyIn.Id))
            {
                var targetValue = (m_MaxDollyIn.IsExpression ? m_MaxDollyIn.Value : m_MaxDollyIn.PrimitiveValue);
                target.m_MaxDollyIn = Mathf.Approximately(0, templateDict[m_MaxDollyIn.Id].Config.duration) ? targetValue : m_MaxDollyInAlertInit + templateDict[m_MaxDollyIn.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyIn.Id].CostTime / templateDict[m_MaxDollyIn.Id].Config.duration) * (targetValue - m_MaxDollyInAlertInit);
            }
            if (m_MaxDollyOut.IsUse && templateDict.ContainsKey(m_MaxDollyOut.Id))
            {
                var targetValue = (m_MaxDollyOut.IsExpression ? m_MaxDollyOut.Value : m_MaxDollyOut.PrimitiveValue);
                target.m_MaxDollyOut = Mathf.Approximately(0, templateDict[m_MaxDollyOut.Id].Config.duration) ? targetValue : m_MaxDollyOutAlertInit + templateDict[m_MaxDollyOut.Id].Config.alertCurve.Evaluate(templateDict[m_MaxDollyOut.Id].CostTime / templateDict[m_MaxDollyOut.Id].Config.duration) * (targetValue - m_MaxDollyOutAlertInit);
            }
            if (m_MinimumDistance.IsUse && templateDict.ContainsKey(m_MinimumDistance.Id))
            {
                var targetValue = (m_MinimumDistance.IsExpression ? m_MinimumDistance.Value : m_MinimumDistance.PrimitiveValue);
                target.m_MinimumDistance = Mathf.Approximately(0, templateDict[m_MinimumDistance.Id].Config.duration) ? targetValue : m_MinimumDistanceAlertInit + templateDict[m_MinimumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistance.Id].CostTime / templateDict[m_MinimumDistance.Id].Config.duration) * (targetValue - m_MinimumDistanceAlertInit);
            }
            if (m_MaximumDistance.IsUse && templateDict.ContainsKey(m_MaximumDistance.Id))
            {
                var targetValue = (m_MaximumDistance.IsExpression ? m_MaximumDistance.Value : m_MaximumDistance.PrimitiveValue);
                target.m_MaximumDistance = Mathf.Approximately(0, templateDict[m_MaximumDistance.Id].Config.duration) ? targetValue : m_MaximumDistanceAlertInit + templateDict[m_MaximumDistance.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumDistance.Id].CostTime / templateDict[m_MaximumDistance.Id].Config.duration) * (targetValue - m_MaximumDistanceAlertInit);
            }
            if (m_MinimumFOV.IsUse && templateDict.ContainsKey(m_MinimumFOV.Id))
            {
                var targetValue = (m_MinimumFOV.IsExpression ? m_MinimumFOV.Value : m_MinimumFOV.PrimitiveValue);
                target.m_MinimumFOV = Mathf.Approximately(0, templateDict[m_MinimumFOV.Id].Config.duration) ? targetValue : m_MinimumFOVAlertInit + templateDict[m_MinimumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumFOV.Id].CostTime / templateDict[m_MinimumFOV.Id].Config.duration) * (targetValue - m_MinimumFOVAlertInit);
            }
            if (m_MaximumFOV.IsUse && templateDict.ContainsKey(m_MaximumFOV.Id))
            {
                var targetValue = (m_MaximumFOV.IsExpression ? m_MaximumFOV.Value : m_MaximumFOV.PrimitiveValue);
                target.m_MaximumFOV = Mathf.Approximately(0, templateDict[m_MaximumFOV.Id].Config.duration) ? targetValue : m_MaximumFOVAlertInit + templateDict[m_MaximumFOV.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumFOV.Id].CostTime / templateDict[m_MaximumFOV.Id].Config.duration) * (targetValue - m_MaximumFOVAlertInit);
            }
            if (m_MinimumOrthoSize.IsUse && templateDict.ContainsKey(m_MinimumOrthoSize.Id))
            {
                var targetValue = (m_MinimumOrthoSize.IsExpression ? m_MinimumOrthoSize.Value : m_MinimumOrthoSize.PrimitiveValue);
                target.m_MinimumOrthoSize = Mathf.Approximately(0, templateDict[m_MinimumOrthoSize.Id].Config.duration) ? targetValue : m_MinimumOrthoSizeAlertInit + templateDict[m_MinimumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOrthoSize.Id].CostTime / templateDict[m_MinimumOrthoSize.Id].Config.duration) * (targetValue - m_MinimumOrthoSizeAlertInit);
            }
            if (m_MaximumOrthoSize.IsUse && templateDict.ContainsKey(m_MaximumOrthoSize.Id))
            {
                var targetValue = (m_MaximumOrthoSize.IsExpression ? m_MaximumOrthoSize.Value : m_MaximumOrthoSize.PrimitiveValue);
                target.m_MaximumOrthoSize = Mathf.Approximately(0, templateDict[m_MaximumOrthoSize.Id].Config.duration) ? targetValue : m_MaximumOrthoSizeAlertInit + templateDict[m_MaximumOrthoSize.Id].Config.alertCurve.Evaluate(templateDict[m_MaximumOrthoSize.Id].CostTime / templateDict[m_MaximumOrthoSize.Id].Config.duration) * (targetValue - m_MaximumOrthoSizeAlertInit);
            }
            if (m_LookaheadTime.IsUse && templateDict.ContainsKey(m_LookaheadTime.Id))
            {
                var targetValue = (m_LookaheadTime.IsExpression ? m_LookaheadTime.Value : m_LookaheadTime.PrimitiveValue);
                target.m_LookaheadTime = Mathf.Approximately(0, templateDict[m_LookaheadTime.Id].Config.duration) ? targetValue : m_LookaheadTimeAlertInit + templateDict[m_LookaheadTime.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadTime.Id].CostTime / templateDict[m_LookaheadTime.Id].Config.duration) * (targetValue - m_LookaheadTimeAlertInit);
            }
            if (m_LookaheadSmoothing.IsUse && templateDict.ContainsKey(m_LookaheadSmoothing.Id))
            {
                var targetValue = (m_LookaheadSmoothing.IsExpression ? m_LookaheadSmoothing.Value : m_LookaheadSmoothing.PrimitiveValue);
                target.m_LookaheadSmoothing = Mathf.Approximately(0, templateDict[m_LookaheadSmoothing.Id].Config.duration) ? targetValue : m_LookaheadSmoothingAlertInit + templateDict[m_LookaheadSmoothing.Id].Config.alertCurve.Evaluate(templateDict[m_LookaheadSmoothing.Id].CostTime / templateDict[m_LookaheadSmoothing.Id].Config.duration) * (targetValue - m_LookaheadSmoothingAlertInit);
            }
            if (m_LookaheadIgnoreY.IsUse) target.m_LookaheadIgnoreY = m_LookaheadIgnoreY.IsExpression ? !Mathf.Approximately(m_LookaheadIgnoreY.Value, 0) : m_LookaheadIgnoreY.PrimitiveValue;
            if (m_HorizontalDamping.IsUse && templateDict.ContainsKey(m_HorizontalDamping.Id))
            {
                var targetValue = (m_HorizontalDamping.IsExpression ? m_HorizontalDamping.Value : m_HorizontalDamping.PrimitiveValue);
                target.m_HorizontalDamping = Mathf.Approximately(0, templateDict[m_HorizontalDamping.Id].Config.duration) ? targetValue : m_HorizontalDampingAlertInit + templateDict[m_HorizontalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_HorizontalDamping.Id].CostTime / templateDict[m_HorizontalDamping.Id].Config.duration) * (targetValue - m_HorizontalDampingAlertInit);
            }
            if (m_VerticalDamping.IsUse && templateDict.ContainsKey(m_VerticalDamping.Id))
            {
                var targetValue = (m_VerticalDamping.IsExpression ? m_VerticalDamping.Value : m_VerticalDamping.PrimitiveValue);
                target.m_VerticalDamping = Mathf.Approximately(0, templateDict[m_VerticalDamping.Id].Config.duration) ? targetValue : m_VerticalDampingAlertInit + templateDict[m_VerticalDamping.Id].Config.alertCurve.Evaluate(templateDict[m_VerticalDamping.Id].CostTime / templateDict[m_VerticalDamping.Id].Config.duration) * (targetValue - m_VerticalDampingAlertInit);
            }
            if (m_ScreenX.IsUse && templateDict.ContainsKey(m_ScreenX.Id))
            {
                var targetValue = (m_ScreenX.IsExpression ? m_ScreenX.Value : m_ScreenX.PrimitiveValue);
                target.m_ScreenX = Mathf.Approximately(0, templateDict[m_ScreenX.Id].Config.duration) ? targetValue : m_ScreenXAlertInit + templateDict[m_ScreenX.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenX.Id].CostTime / templateDict[m_ScreenX.Id].Config.duration) * (targetValue - m_ScreenXAlertInit);
            }
            if (m_ScreenY.IsUse && templateDict.ContainsKey(m_ScreenY.Id))
            {
                var targetValue = (m_ScreenY.IsExpression ? m_ScreenY.Value : m_ScreenY.PrimitiveValue);
                target.m_ScreenY = Mathf.Approximately(0, templateDict[m_ScreenY.Id].Config.duration) ? targetValue : m_ScreenYAlertInit + templateDict[m_ScreenY.Id].Config.alertCurve.Evaluate(templateDict[m_ScreenY.Id].CostTime / templateDict[m_ScreenY.Id].Config.duration) * (targetValue - m_ScreenYAlertInit);
            }
            if (m_DeadZoneWidth.IsUse && templateDict.ContainsKey(m_DeadZoneWidth.Id))
            {
                var targetValue = (m_DeadZoneWidth.IsExpression ? m_DeadZoneWidth.Value : m_DeadZoneWidth.PrimitiveValue);
                target.m_DeadZoneWidth = Mathf.Approximately(0, templateDict[m_DeadZoneWidth.Id].Config.duration) ? targetValue : m_DeadZoneWidthAlertInit + templateDict[m_DeadZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneWidth.Id].CostTime / templateDict[m_DeadZoneWidth.Id].Config.duration) * (targetValue - m_DeadZoneWidthAlertInit);
            }
            if (m_DeadZoneHeight.IsUse && templateDict.ContainsKey(m_DeadZoneHeight.Id))
            {
                var targetValue = (m_DeadZoneHeight.IsExpression ? m_DeadZoneHeight.Value : m_DeadZoneHeight.PrimitiveValue);
                target.m_DeadZoneHeight = Mathf.Approximately(0, templateDict[m_DeadZoneHeight.Id].Config.duration) ? targetValue : m_DeadZoneHeightAlertInit + templateDict[m_DeadZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_DeadZoneHeight.Id].CostTime / templateDict[m_DeadZoneHeight.Id].Config.duration) * (targetValue - m_DeadZoneHeightAlertInit);
            }
            if (m_SoftZoneWidth.IsUse && templateDict.ContainsKey(m_SoftZoneWidth.Id))
            {
                var targetValue = (m_SoftZoneWidth.IsExpression ? m_SoftZoneWidth.Value : m_SoftZoneWidth.PrimitiveValue);
                target.m_SoftZoneWidth = Mathf.Approximately(0, templateDict[m_SoftZoneWidth.Id].Config.duration) ? targetValue : m_SoftZoneWidthAlertInit + templateDict[m_SoftZoneWidth.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneWidth.Id].CostTime / templateDict[m_SoftZoneWidth.Id].Config.duration) * (targetValue - m_SoftZoneWidthAlertInit);
            }
            if (m_SoftZoneHeight.IsUse && templateDict.ContainsKey(m_SoftZoneHeight.Id))
            {
                var targetValue = (m_SoftZoneHeight.IsExpression ? m_SoftZoneHeight.Value : m_SoftZoneHeight.PrimitiveValue);
                target.m_SoftZoneHeight = Mathf.Approximately(0, templateDict[m_SoftZoneHeight.Id].Config.duration) ? targetValue : m_SoftZoneHeightAlertInit + templateDict[m_SoftZoneHeight.Id].Config.alertCurve.Evaluate(templateDict[m_SoftZoneHeight.Id].CostTime / templateDict[m_SoftZoneHeight.Id].Config.duration) * (targetValue - m_SoftZoneHeightAlertInit);
            }
            if (m_BiasX.IsUse && templateDict.ContainsKey(m_BiasX.Id))
            {
                var targetValue = (m_BiasX.IsExpression ? m_BiasX.Value : m_BiasX.PrimitiveValue);
                target.m_BiasX = Mathf.Approximately(0, templateDict[m_BiasX.Id].Config.duration) ? targetValue : m_BiasXAlertInit + templateDict[m_BiasX.Id].Config.alertCurve.Evaluate(templateDict[m_BiasX.Id].CostTime / templateDict[m_BiasX.Id].Config.duration) * (targetValue - m_BiasXAlertInit);
            }
            if (m_BiasY.IsUse && templateDict.ContainsKey(m_BiasY.Id))
            {
                var targetValue = (m_BiasY.IsExpression ? m_BiasY.Value : m_BiasY.PrimitiveValue);
                target.m_BiasY = Mathf.Approximately(0, templateDict[m_BiasY.Id].Config.duration) ? targetValue : m_BiasYAlertInit + templateDict[m_BiasY.Id].Config.alertCurve.Evaluate(templateDict[m_BiasY.Id].CostTime / templateDict[m_BiasY.Id].Config.duration) * (targetValue - m_BiasYAlertInit);
            }
            if (m_CenterOnActivate.IsUse) target.m_CenterOnActivate = m_CenterOnActivate.IsExpression ? !Mathf.Approximately(m_CenterOnActivate.Value, 0) : m_CenterOnActivate.PrimitiveValue;
        }
    }
}
