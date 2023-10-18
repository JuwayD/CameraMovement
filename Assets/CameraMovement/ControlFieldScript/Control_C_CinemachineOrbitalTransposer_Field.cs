using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineOrbitalTransposer_Field :ICameraMovementControlField<Cinemachine.CinemachineOrbitalTransposer>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineOrbitalTransposer);

       [UnityEngine.TooltipAttribute("The definition of Forward.  Camera will follow behind.")]
        public Control_C_COT_Heading_Field m_Heading;
       [UnityEngine.TooltipAttribute("Automatic heading recentering.  The settings here defines how the camera will reposition itself in the absence of player input.")]
        public Control_C_AS_Recentering_Field m_RecenterToTargetHeading;
       [UnityEngine.TooltipAttribute("Heading Control.  The settings here control the behaviour of the camera in response to the player's input.")]
        public Control_C_AxisState_Field m_XAxis;
       [UnityEngine.HideInInspector]
            public DataMixer <System.Boolean> m_HeadingIsSlave;
       [UnityEngine.TooltipAttribute("The coordinate space to use when interpreting the offset from the target.  This is also used to set the camera's Up vector, which will be maintained when aiming the camera.")]
            public DataMixer <Cinemachine.CinemachineTransposer.BindingMode> m_BindingMode;
       [UnityEngine.TooltipAttribute("The distance vector that the transposer will attempt to maintain from the Follow target")]
            public DataMixer <UnityEngine.Vector3> m_FollowOffset;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the X-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_XDamping;
        public float m_XDampingAlertInit;
        public float m_XDampingDiff;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Y-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_YDamping;
        public float m_YDampingAlertInit;
        public float m_YDampingDiff;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Z-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_ZDamping;
        public float m_ZDampingAlertInit;
        public float m_ZDampingDiff;
        public DataMixer <Cinemachine.CinemachineTransposer.AngularDampingMode> m_AngularDampingMode;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's X angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_PitchDamping;
        public float m_PitchDampingAlertInit;
        public float m_PitchDampingDiff;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Y angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_YawDamping;
        public float m_YawDampingAlertInit;
        public float m_YawDampingDiff;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Z angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_RollDamping;
        public float m_RollDampingAlertInit;
        public float m_RollDampingDiff;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target's orientation.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_AngularDamping;
        public float m_AngularDampingAlertInit;
        public float m_AngularDampingDiff;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineOrbitalTransposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineOrbitalTransposer_Config source = (CameraMovement.Control_C_CinemachineOrbitalTransposer_Config)sourceConfig;
            if(source.m_Heading != null && m_Heading == null) m_Heading = new Control_C_COT_Heading_Field();
            m_Heading?.AddByConfig(source.m_Heading, id, priority, ref target.m_Heading, templateDict);
            if(source.m_RecenterToTargetHeading != null && m_RecenterToTargetHeading == null) m_RecenterToTargetHeading = new Control_C_AS_Recentering_Field();
            m_RecenterToTargetHeading?.AddByConfig(source.m_RecenterToTargetHeading, id, priority, ref target.m_RecenterToTargetHeading, templateDict);
            if(source.m_XAxis != null && m_XAxis == null) m_XAxis = new Control_C_AxisState_Field();
            m_XAxis?.AddByConfig(source.m_XAxis, id, priority, ref target.m_XAxis, templateDict);
            if(source.m_HeadingIsSlave.IsUse)
            {
                m_HeadingIsSlave.Add(new MixItem<System.Boolean>(id, priority, source.m_HeadingIsSlave.CalculatorExpression, source.m_HeadingIsSlave.Value, source.m_HeadingIsSlave.IsUse));
            }
            if(source.m_BindingMode.IsUse)
            {
                m_BindingMode.Add(new MixItem<Cinemachine.CinemachineTransposer.BindingMode>(id, priority, source.m_BindingMode.CalculatorExpression, source.m_BindingMode.Value, source.m_BindingMode.IsUse));
            }
            if(source.m_FollowOffset.IsUse)
            {
                m_FollowOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_FollowOffset.CalculatorExpression, source.m_FollowOffset.Value, source.m_FollowOffset.IsUse));
            }
            if(source.m_XDamping.IsUse)
            {
                m_XDamping.Add(new MixItem<System.Single>(id, priority, source.m_XDamping.CalculatorExpression, source.m_XDamping.Value, source.m_XDamping.IsUse));
               var targetValue = (m_XDamping.IsExpression ? m_XDamping.Value : m_XDamping.PrimitiveValue);
               m_XDampingDiff = targetValue - target.m_XDamping;
               if(templateDict[m_XDamping.Id].Config.alertCurve != null) m_XDampingAlertInit = target.m_XDamping - templateDict[m_XDamping.Id].Config.alertCurve.Evaluate(templateDict[m_XDamping.Id].CostTime / templateDict[m_XDamping.Id].Config.duration) * (m_XDampingDiff);
            }
            if(source.m_YDamping.IsUse)
            {
                m_YDamping.Add(new MixItem<System.Single>(id, priority, source.m_YDamping.CalculatorExpression, source.m_YDamping.Value, source.m_YDamping.IsUse));
               var targetValue = (m_YDamping.IsExpression ? m_YDamping.Value : m_YDamping.PrimitiveValue);
               m_YDampingDiff = targetValue - target.m_YDamping;
               if(templateDict[m_YDamping.Id].Config.alertCurve != null) m_YDampingAlertInit = target.m_YDamping - templateDict[m_YDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YDamping.Id].CostTime / templateDict[m_YDamping.Id].Config.duration) * (m_YDampingDiff);
            }
            if(source.m_ZDamping.IsUse)
            {
                m_ZDamping.Add(new MixItem<System.Single>(id, priority, source.m_ZDamping.CalculatorExpression, source.m_ZDamping.Value, source.m_ZDamping.IsUse));
               var targetValue = (m_ZDamping.IsExpression ? m_ZDamping.Value : m_ZDamping.PrimitiveValue);
               m_ZDampingDiff = targetValue - target.m_ZDamping;
               if(templateDict[m_ZDamping.Id].Config.alertCurve != null) m_ZDampingAlertInit = target.m_ZDamping - templateDict[m_ZDamping.Id].Config.alertCurve.Evaluate(templateDict[m_ZDamping.Id].CostTime / templateDict[m_ZDamping.Id].Config.duration) * (m_ZDampingDiff);
            }
            if(source.m_AngularDampingMode.IsUse)
            {
                m_AngularDampingMode.Add(new MixItem<Cinemachine.CinemachineTransposer.AngularDampingMode>(id, priority, source.m_AngularDampingMode.CalculatorExpression, source.m_AngularDampingMode.Value, source.m_AngularDampingMode.IsUse));
            }
            if(source.m_PitchDamping.IsUse)
            {
                m_PitchDamping.Add(new MixItem<System.Single>(id, priority, source.m_PitchDamping.CalculatorExpression, source.m_PitchDamping.Value, source.m_PitchDamping.IsUse));
               var targetValue = (m_PitchDamping.IsExpression ? m_PitchDamping.Value : m_PitchDamping.PrimitiveValue);
               m_PitchDampingDiff = targetValue - target.m_PitchDamping;
               if(templateDict[m_PitchDamping.Id].Config.alertCurve != null) m_PitchDampingAlertInit = target.m_PitchDamping - templateDict[m_PitchDamping.Id].Config.alertCurve.Evaluate(templateDict[m_PitchDamping.Id].CostTime / templateDict[m_PitchDamping.Id].Config.duration) * (m_PitchDampingDiff);
            }
            if(source.m_YawDamping.IsUse)
            {
                m_YawDamping.Add(new MixItem<System.Single>(id, priority, source.m_YawDamping.CalculatorExpression, source.m_YawDamping.Value, source.m_YawDamping.IsUse));
               var targetValue = (m_YawDamping.IsExpression ? m_YawDamping.Value : m_YawDamping.PrimitiveValue);
               m_YawDampingDiff = targetValue - target.m_YawDamping;
               if(templateDict[m_YawDamping.Id].Config.alertCurve != null) m_YawDampingAlertInit = target.m_YawDamping - templateDict[m_YawDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YawDamping.Id].CostTime / templateDict[m_YawDamping.Id].Config.duration) * (m_YawDampingDiff);
            }
            if(source.m_RollDamping.IsUse)
            {
                m_RollDamping.Add(new MixItem<System.Single>(id, priority, source.m_RollDamping.CalculatorExpression, source.m_RollDamping.Value, source.m_RollDamping.IsUse));
               var targetValue = (m_RollDamping.IsExpression ? m_RollDamping.Value : m_RollDamping.PrimitiveValue);
               m_RollDampingDiff = targetValue - target.m_RollDamping;
               if(templateDict[m_RollDamping.Id].Config.alertCurve != null) m_RollDampingAlertInit = target.m_RollDamping - templateDict[m_RollDamping.Id].Config.alertCurve.Evaluate(templateDict[m_RollDamping.Id].CostTime / templateDict[m_RollDamping.Id].Config.duration) * (m_RollDampingDiff);
            }
            if(source.m_AngularDamping.IsUse)
            {
                m_AngularDamping.Add(new MixItem<System.Single>(id, priority, source.m_AngularDamping.CalculatorExpression, source.m_AngularDamping.Value, source.m_AngularDamping.IsUse));
               var targetValue = (m_AngularDamping.IsExpression ? m_AngularDamping.Value : m_AngularDamping.PrimitiveValue);
               m_AngularDampingDiff = targetValue - target.m_AngularDamping;
               if(templateDict[m_AngularDamping.Id].Config.alertCurve != null) m_AngularDampingAlertInit = target.m_AngularDamping - templateDict[m_AngularDamping.Id].Config.alertCurve.Evaluate(templateDict[m_AngularDamping.Id].CostTime / templateDict[m_AngularDamping.Id].Config.duration) * (m_AngularDampingDiff);
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineOrbitalTransposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineOrbitalTransposer_Config source = (CameraMovement.Control_C_CinemachineOrbitalTransposer_Config)sourceConfig;
            m_Heading?.RemoveByConfig(source.m_Heading, id, priority, ref target.m_Heading, templateDict);
            m_RecenterToTargetHeading?.RemoveByConfig(source.m_RecenterToTargetHeading, id, priority, ref target.m_RecenterToTargetHeading, templateDict);
            m_XAxis?.RemoveByConfig(source.m_XAxis, id, priority, ref target.m_XAxis, templateDict);
            if(source.m_HeadingIsSlave.IsUse)
            {
                m_HeadingIsSlave.Remove(new MixItem<System.Boolean>(id, priority, source.m_HeadingIsSlave.CalculatorExpression, source.m_HeadingIsSlave.Value, source.m_HeadingIsSlave.IsUse));
            }
            if(source.m_BindingMode.IsUse)
            {
                m_BindingMode.Remove(new MixItem<Cinemachine.CinemachineTransposer.BindingMode>(id, priority, source.m_BindingMode.CalculatorExpression, source.m_BindingMode.Value, source.m_BindingMode.IsUse));
            }
            if(source.m_FollowOffset.IsUse)
            {
                m_FollowOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_FollowOffset.CalculatorExpression, source.m_FollowOffset.Value, source.m_FollowOffset.IsUse));
            }
            if(source.m_XDamping.IsUse)
            {
                m_XDamping.Remove(new MixItem<System.Single>(id, priority, source.m_XDamping.CalculatorExpression, source.m_XDamping.Value, source.m_XDamping.IsUse));
               var targetValue = (m_XDamping.IsExpression ? m_XDamping.Value : m_XDamping.PrimitiveValue);
               m_XDampingDiff = targetValue - target.m_XDamping;
               if(templateDict[m_XDamping.Id].Config.alertCurve != null) m_XDampingAlertInit = target.m_XDamping - templateDict[m_XDamping.Id].Config.alertCurve.Evaluate(templateDict[m_XDamping.Id].CostTime / templateDict[m_XDamping.Id].Config.duration) * (m_XDampingDiff);
            }
            if(source.m_YDamping.IsUse)
            {
                m_YDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YDamping.CalculatorExpression, source.m_YDamping.Value, source.m_YDamping.IsUse));
               var targetValue = (m_YDamping.IsExpression ? m_YDamping.Value : m_YDamping.PrimitiveValue);
               m_YDampingDiff = targetValue - target.m_YDamping;
               if(templateDict[m_YDamping.Id].Config.alertCurve != null) m_YDampingAlertInit = target.m_YDamping - templateDict[m_YDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YDamping.Id].CostTime / templateDict[m_YDamping.Id].Config.duration) * (m_YDampingDiff);
            }
            if(source.m_ZDamping.IsUse)
            {
                m_ZDamping.Remove(new MixItem<System.Single>(id, priority, source.m_ZDamping.CalculatorExpression, source.m_ZDamping.Value, source.m_ZDamping.IsUse));
               var targetValue = (m_ZDamping.IsExpression ? m_ZDamping.Value : m_ZDamping.PrimitiveValue);
               m_ZDampingDiff = targetValue - target.m_ZDamping;
               if(templateDict[m_ZDamping.Id].Config.alertCurve != null) m_ZDampingAlertInit = target.m_ZDamping - templateDict[m_ZDamping.Id].Config.alertCurve.Evaluate(templateDict[m_ZDamping.Id].CostTime / templateDict[m_ZDamping.Id].Config.duration) * (m_ZDampingDiff);
            }
            if(source.m_AngularDampingMode.IsUse)
            {
                m_AngularDampingMode.Remove(new MixItem<Cinemachine.CinemachineTransposer.AngularDampingMode>(id, priority, source.m_AngularDampingMode.CalculatorExpression, source.m_AngularDampingMode.Value, source.m_AngularDampingMode.IsUse));
            }
            if(source.m_PitchDamping.IsUse)
            {
                m_PitchDamping.Remove(new MixItem<System.Single>(id, priority, source.m_PitchDamping.CalculatorExpression, source.m_PitchDamping.Value, source.m_PitchDamping.IsUse));
               var targetValue = (m_PitchDamping.IsExpression ? m_PitchDamping.Value : m_PitchDamping.PrimitiveValue);
               m_PitchDampingDiff = targetValue - target.m_PitchDamping;
               if(templateDict[m_PitchDamping.Id].Config.alertCurve != null) m_PitchDampingAlertInit = target.m_PitchDamping - templateDict[m_PitchDamping.Id].Config.alertCurve.Evaluate(templateDict[m_PitchDamping.Id].CostTime / templateDict[m_PitchDamping.Id].Config.duration) * (m_PitchDampingDiff);
            }
            if(source.m_YawDamping.IsUse)
            {
                m_YawDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YawDamping.CalculatorExpression, source.m_YawDamping.Value, source.m_YawDamping.IsUse));
               var targetValue = (m_YawDamping.IsExpression ? m_YawDamping.Value : m_YawDamping.PrimitiveValue);
               m_YawDampingDiff = targetValue - target.m_YawDamping;
               if(templateDict[m_YawDamping.Id].Config.alertCurve != null) m_YawDampingAlertInit = target.m_YawDamping - templateDict[m_YawDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YawDamping.Id].CostTime / templateDict[m_YawDamping.Id].Config.duration) * (m_YawDampingDiff);
            }
            if(source.m_RollDamping.IsUse)
            {
                m_RollDamping.Remove(new MixItem<System.Single>(id, priority, source.m_RollDamping.CalculatorExpression, source.m_RollDamping.Value, source.m_RollDamping.IsUse));
               var targetValue = (m_RollDamping.IsExpression ? m_RollDamping.Value : m_RollDamping.PrimitiveValue);
               m_RollDampingDiff = targetValue - target.m_RollDamping;
               if(templateDict[m_RollDamping.Id].Config.alertCurve != null) m_RollDampingAlertInit = target.m_RollDamping - templateDict[m_RollDamping.Id].Config.alertCurve.Evaluate(templateDict[m_RollDamping.Id].CostTime / templateDict[m_RollDamping.Id].Config.duration) * (m_RollDampingDiff);
            }
            if(source.m_AngularDamping.IsUse)
            {
                m_AngularDamping.Remove(new MixItem<System.Single>(id, priority, source.m_AngularDamping.CalculatorExpression, source.m_AngularDamping.Value, source.m_AngularDamping.IsUse));
               var targetValue = (m_AngularDamping.IsExpression ? m_AngularDamping.Value : m_AngularDamping.PrimitiveValue);
               m_AngularDampingDiff = targetValue - target.m_AngularDamping;
               if(templateDict[m_AngularDamping.Id].Config.alertCurve != null) m_AngularDampingAlertInit = target.m_AngularDamping - templateDict[m_AngularDamping.Id].Config.alertCurve.Evaluate(templateDict[m_AngularDamping.Id].CostTime / templateDict[m_AngularDamping.Id].Config.duration) * (m_AngularDampingDiff);
            }
        }
        public void RemoveAll()
        {
            m_Heading.RemoveAll();
            m_RecenterToTargetHeading.RemoveAll();
            m_XAxis.RemoveAll();
            m_HeadingIsSlave.RemoveAll();
            m_BindingMode.RemoveAll();
            m_FollowOffset.RemoveAll();
            m_XDamping.RemoveAll();
            m_YDamping.RemoveAll();
            m_ZDamping.RemoveAll();
            m_AngularDampingMode.RemoveAll();
            m_PitchDamping.RemoveAll();
            m_YawDamping.RemoveAll();
            m_RollDamping.RemoveAll();
            m_AngularDamping.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineOrbitalTransposer target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            // 处理字段 m_Heading
            // 生成递归代码
            m_Heading?.ControlCinemachine(ref target.m_Heading, templateDict);
            // 处理字段 m_RecenterToTargetHeading
            // 生成递归代码
            m_RecenterToTargetHeading?.ControlCinemachine(ref target.m_RecenterToTargetHeading, templateDict);
            // 处理字段 m_XAxis
            // 生成递归代码
            m_XAxis?.ControlCinemachine(ref target.m_XAxis, templateDict);
            if (m_HeadingIsSlave.IsUse) target.m_HeadingIsSlave = m_HeadingIsSlave.IsExpression ? !Mathf.Approximately(m_HeadingIsSlave.Value, 0) : m_HeadingIsSlave.PrimitiveValue;
            if (m_BindingMode.IsUse) target.m_BindingMode = m_BindingMode.IsExpression ? (Cinemachine.CinemachineTransposer.BindingMode)m_BindingMode.Value :m_BindingMode.PrimitiveValue;
            if (m_XDamping.IsUse && templateDict.ContainsKey(m_XDamping.Id))
            {
                var targetValue = (m_XDamping.IsExpression ? m_XDamping.Value : m_XDamping.PrimitiveValue);
                target.m_XDamping = Mathf.Approximately(0, templateDict[m_XDamping.Id].Config.duration) ? targetValue : m_XDampingAlertInit + templateDict[m_XDamping.Id].Config.alertCurve.Evaluate(templateDict[m_XDamping.Id].CostTime / templateDict[m_XDamping.Id].Config.duration) * m_XDampingDiff;
            }
            if (m_YDamping.IsUse && templateDict.ContainsKey(m_YDamping.Id))
            {
                var targetValue = (m_YDamping.IsExpression ? m_YDamping.Value : m_YDamping.PrimitiveValue);
                target.m_YDamping = Mathf.Approximately(0, templateDict[m_YDamping.Id].Config.duration) ? targetValue : m_YDampingAlertInit + templateDict[m_YDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YDamping.Id].CostTime / templateDict[m_YDamping.Id].Config.duration) * m_YDampingDiff;
            }
            if (m_ZDamping.IsUse && templateDict.ContainsKey(m_ZDamping.Id))
            {
                var targetValue = (m_ZDamping.IsExpression ? m_ZDamping.Value : m_ZDamping.PrimitiveValue);
                target.m_ZDamping = Mathf.Approximately(0, templateDict[m_ZDamping.Id].Config.duration) ? targetValue : m_ZDampingAlertInit + templateDict[m_ZDamping.Id].Config.alertCurve.Evaluate(templateDict[m_ZDamping.Id].CostTime / templateDict[m_ZDamping.Id].Config.duration) * m_ZDampingDiff;
            }
            if (m_AngularDampingMode.IsUse) target.m_AngularDampingMode = m_AngularDampingMode.IsExpression ? (Cinemachine.CinemachineTransposer.AngularDampingMode)m_AngularDampingMode.Value :m_AngularDampingMode.PrimitiveValue;
            if (m_PitchDamping.IsUse && templateDict.ContainsKey(m_PitchDamping.Id))
            {
                var targetValue = (m_PitchDamping.IsExpression ? m_PitchDamping.Value : m_PitchDamping.PrimitiveValue);
                target.m_PitchDamping = Mathf.Approximately(0, templateDict[m_PitchDamping.Id].Config.duration) ? targetValue : m_PitchDampingAlertInit + templateDict[m_PitchDamping.Id].Config.alertCurve.Evaluate(templateDict[m_PitchDamping.Id].CostTime / templateDict[m_PitchDamping.Id].Config.duration) * m_PitchDampingDiff;
            }
            if (m_YawDamping.IsUse && templateDict.ContainsKey(m_YawDamping.Id))
            {
                var targetValue = (m_YawDamping.IsExpression ? m_YawDamping.Value : m_YawDamping.PrimitiveValue);
                target.m_YawDamping = Mathf.Approximately(0, templateDict[m_YawDamping.Id].Config.duration) ? targetValue : m_YawDampingAlertInit + templateDict[m_YawDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YawDamping.Id].CostTime / templateDict[m_YawDamping.Id].Config.duration) * m_YawDampingDiff;
            }
            if (m_RollDamping.IsUse && templateDict.ContainsKey(m_RollDamping.Id))
            {
                var targetValue = (m_RollDamping.IsExpression ? m_RollDamping.Value : m_RollDamping.PrimitiveValue);
                target.m_RollDamping = Mathf.Approximately(0, templateDict[m_RollDamping.Id].Config.duration) ? targetValue : m_RollDampingAlertInit + templateDict[m_RollDamping.Id].Config.alertCurve.Evaluate(templateDict[m_RollDamping.Id].CostTime / templateDict[m_RollDamping.Id].Config.duration) * m_RollDampingDiff;
            }
            if (m_AngularDamping.IsUse && templateDict.ContainsKey(m_AngularDamping.Id))
            {
                var targetValue = (m_AngularDamping.IsExpression ? m_AngularDamping.Value : m_AngularDamping.PrimitiveValue);
                target.m_AngularDamping = Mathf.Approximately(0, templateDict[m_AngularDamping.Id].Config.duration) ? targetValue : m_AngularDampingAlertInit + templateDict[m_AngularDamping.Id].Config.alertCurve.Evaluate(templateDict[m_AngularDamping.Id].CostTime / templateDict[m_AngularDamping.Id].Config.duration) * m_AngularDampingDiff;
            }
        }
    }
}
