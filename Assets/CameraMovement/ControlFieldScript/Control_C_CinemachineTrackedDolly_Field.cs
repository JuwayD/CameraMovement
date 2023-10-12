using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineTrackedDolly_Field :ICameraMovementControlField<Cinemachine.CinemachineTrackedDolly>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineTrackedDolly);

       [UnityEngine.TooltipAttribute("The position along the path at which the camera will be placed.  This can be animated directly, or set automatically by the Auto-Dolly feature to get as close as possible to the Follow target.  The value is interpreted according to the Position Units setting.")]
            public DataMixer <System.Single> m_PathPosition;
        public float m_PathPositionAlertInit;
       [UnityEngine.TooltipAttribute("How to interpret Path Position.  If set to Path Units, values are as follows: 0 represents the first waypoint on the path, 1 is the second, and so on.  Values in-between are points on the path in between the waypoints.  If set to Distance, then Path Position represents distance along the path.")]
            public DataMixer <Cinemachine.CinemachinePathBase.PositionUnits> m_PositionUnits;
       [UnityEngine.TooltipAttribute("Where to put the camera relative to the path position.  X is perpendicular to the path, Y is up, and Z is parallel to the path.  This allows the camera to be offset from the path itself (as if on a tripod, for example).")]
            public DataMixer <UnityEngine.Vector3> m_PathOffset;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in a direction perpendicular to the path.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_XDamping;
        public float m_XDampingAlertInit;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in the path-local up direction.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_YDamping;
        public float m_YDampingAlertInit;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in a direction parallel to the path.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_ZDamping;
        public float m_ZDampingAlertInit;
       [UnityEngine.TooltipAttribute("How to set the virtual camera's Up vector.  This will affect the screen composition, because the camera Aim behaviours will always try to respect the Up direction.")]
            public DataMixer <Cinemachine.CinemachineTrackedDolly.CameraUpMode> m_CameraUp;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's X angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_PitchDamping;
        public float m_PitchDampingAlertInit;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Y angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_YawDamping;
        public float m_YawDampingAlertInit;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Z angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_RollDamping;
        public float m_RollDampingAlertInit;
       [UnityEngine.TooltipAttribute("Controls how automatic dollying occurs.  A Follow target is necessary to use this feature.")]
        public Control_C_CTD_AutoDolly_Field m_AutoDolly;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineTrackedDolly target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineTrackedDolly_Config source = (CameraMovement.Control_C_CinemachineTrackedDolly_Config)sourceConfig;
                if(source.m_PathPosition.IsUse)
                {
                    m_PathPositionAlertInit = target.m_PathPosition;
                    m_PathPosition.Add(new MixItem<System.Single>(id, priority, source.m_PathPosition.CalculatorExpression, source.m_PathPosition.Value, source.m_PathPosition.IsUse));
                }
                if(source.m_PositionUnits.IsUse)
                {
                    m_PositionUnits.Add(new MixItem<Cinemachine.CinemachinePathBase.PositionUnits>(id, priority, source.m_PositionUnits.CalculatorExpression, source.m_PositionUnits.Value, source.m_PositionUnits.IsUse));
                }
                if(source.m_PathOffset.IsUse)
                {
                    m_PathOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_PathOffset.CalculatorExpression, source.m_PathOffset.Value, source.m_PathOffset.IsUse));
                }
                if(source.m_XDamping.IsUse)
                {
                    m_XDampingAlertInit = target.m_XDamping;
                    m_XDamping.Add(new MixItem<System.Single>(id, priority, source.m_XDamping.CalculatorExpression, source.m_XDamping.Value, source.m_XDamping.IsUse));
                }
                if(source.m_YDamping.IsUse)
                {
                    m_YDampingAlertInit = target.m_YDamping;
                    m_YDamping.Add(new MixItem<System.Single>(id, priority, source.m_YDamping.CalculatorExpression, source.m_YDamping.Value, source.m_YDamping.IsUse));
                }
                if(source.m_ZDamping.IsUse)
                {
                    m_ZDampingAlertInit = target.m_ZDamping;
                    m_ZDamping.Add(new MixItem<System.Single>(id, priority, source.m_ZDamping.CalculatorExpression, source.m_ZDamping.Value, source.m_ZDamping.IsUse));
                }
                if(source.m_CameraUp.IsUse)
                {
                    m_CameraUp.Add(new MixItem<Cinemachine.CinemachineTrackedDolly.CameraUpMode>(id, priority, source.m_CameraUp.CalculatorExpression, source.m_CameraUp.Value, source.m_CameraUp.IsUse));
                }
                if(source.m_PitchDamping.IsUse)
                {
                    m_PitchDampingAlertInit = target.m_PitchDamping;
                    m_PitchDamping.Add(new MixItem<System.Single>(id, priority, source.m_PitchDamping.CalculatorExpression, source.m_PitchDamping.Value, source.m_PitchDamping.IsUse));
                }
                if(source.m_YawDamping.IsUse)
                {
                    m_YawDampingAlertInit = target.m_YawDamping;
                    m_YawDamping.Add(new MixItem<System.Single>(id, priority, source.m_YawDamping.CalculatorExpression, source.m_YawDamping.Value, source.m_YawDamping.IsUse));
                }
                if(source.m_RollDamping.IsUse)
                {
                    m_RollDampingAlertInit = target.m_RollDamping;
                    m_RollDamping.Add(new MixItem<System.Single>(id, priority, source.m_RollDamping.CalculatorExpression, source.m_RollDamping.Value, source.m_RollDamping.IsUse));
                }
                if(source.m_AutoDolly != null && m_AutoDolly == null) m_AutoDolly = new Control_C_CTD_AutoDolly_Field();
            m_AutoDolly?.AddByConfig(source.m_AutoDolly, id, priority, ref target.m_AutoDolly);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineTrackedDolly target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineTrackedDolly_Config source = (CameraMovement.Control_C_CinemachineTrackedDolly_Config)sourceConfig;
                if(source.m_PathPosition.IsUse)
                {
                    m_PathPositionAlertInit = target.m_PathPosition;
                    m_PathPosition.Remove(new MixItem<System.Single>(id, priority, source.m_PathPosition.CalculatorExpression, source.m_PathPosition.Value, source.m_PathPosition.IsUse));
                }
                if(source.m_PositionUnits.IsUse)
                {
                    m_PositionUnits.Remove(new MixItem<Cinemachine.CinemachinePathBase.PositionUnits>(id, priority, source.m_PositionUnits.CalculatorExpression, source.m_PositionUnits.Value, source.m_PositionUnits.IsUse));
                }
                if(source.m_PathOffset.IsUse)
                {
                    m_PathOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_PathOffset.CalculatorExpression, source.m_PathOffset.Value, source.m_PathOffset.IsUse));
                }
                if(source.m_XDamping.IsUse)
                {
                    m_XDampingAlertInit = target.m_XDamping;
                    m_XDamping.Remove(new MixItem<System.Single>(id, priority, source.m_XDamping.CalculatorExpression, source.m_XDamping.Value, source.m_XDamping.IsUse));
                }
                if(source.m_YDamping.IsUse)
                {
                    m_YDampingAlertInit = target.m_YDamping;
                    m_YDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YDamping.CalculatorExpression, source.m_YDamping.Value, source.m_YDamping.IsUse));
                }
                if(source.m_ZDamping.IsUse)
                {
                    m_ZDampingAlertInit = target.m_ZDamping;
                    m_ZDamping.Remove(new MixItem<System.Single>(id, priority, source.m_ZDamping.CalculatorExpression, source.m_ZDamping.Value, source.m_ZDamping.IsUse));
                }
                if(source.m_CameraUp.IsUse)
                {
                    m_CameraUp.Remove(new MixItem<Cinemachine.CinemachineTrackedDolly.CameraUpMode>(id, priority, source.m_CameraUp.CalculatorExpression, source.m_CameraUp.Value, source.m_CameraUp.IsUse));
                }
                if(source.m_PitchDamping.IsUse)
                {
                    m_PitchDampingAlertInit = target.m_PitchDamping;
                    m_PitchDamping.Remove(new MixItem<System.Single>(id, priority, source.m_PitchDamping.CalculatorExpression, source.m_PitchDamping.Value, source.m_PitchDamping.IsUse));
                }
                if(source.m_YawDamping.IsUse)
                {
                    m_YawDampingAlertInit = target.m_YawDamping;
                    m_YawDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YawDamping.CalculatorExpression, source.m_YawDamping.Value, source.m_YawDamping.IsUse));
                }
                if(source.m_RollDamping.IsUse)
                {
                    m_RollDampingAlertInit = target.m_RollDamping;
                    m_RollDamping.Remove(new MixItem<System.Single>(id, priority, source.m_RollDamping.CalculatorExpression, source.m_RollDamping.Value, source.m_RollDamping.IsUse));
                }
            m_AutoDolly?.RemoveByConfig(source.m_AutoDolly, id, priority, ref target.m_AutoDolly);
        }
        public void RemoveAll()
        {
            m_PathPosition.RemoveAll();
            m_PositionUnits.RemoveAll();
            m_PathOffset.RemoveAll();
            m_XDamping.RemoveAll();
            m_YDamping.RemoveAll();
            m_ZDamping.RemoveAll();
            m_CameraUp.RemoveAll();
            m_PitchDamping.RemoveAll();
            m_YawDamping.RemoveAll();
            m_RollDamping.RemoveAll();
            m_AutoDolly?.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineTrackedDolly target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_PathPosition.IsUse && templateDict.ContainsKey(m_PathPosition.Id))
            {
                var targetValue = (m_PathPosition.IsExpression ? m_PathPosition.Value : m_PathPosition.PrimitiveValue);
                target.m_PathPosition = Mathf.Approximately(0, templateDict[m_PathPosition.Id].Config.duration) ? targetValue : m_PathPositionAlertInit + templateDict[m_PathPosition.Id].Config.alertCurve.Evaluate(templateDict[m_PathPosition.Id].CostTime / templateDict[m_PathPosition.Id].Config.duration) * (targetValue - m_PathPositionAlertInit);
            }
            if (m_PositionUnits.IsUse) target.m_PositionUnits = m_PositionUnits.IsExpression ? (Cinemachine.CinemachinePathBase.PositionUnits)m_PositionUnits.Value :m_PositionUnits.PrimitiveValue;
            if (m_XDamping.IsUse && templateDict.ContainsKey(m_XDamping.Id))
            {
                var targetValue = (m_XDamping.IsExpression ? m_XDamping.Value : m_XDamping.PrimitiveValue);
                target.m_XDamping = Mathf.Approximately(0, templateDict[m_XDamping.Id].Config.duration) ? targetValue : m_XDampingAlertInit + templateDict[m_XDamping.Id].Config.alertCurve.Evaluate(templateDict[m_XDamping.Id].CostTime / templateDict[m_XDamping.Id].Config.duration) * (targetValue - m_XDampingAlertInit);
            }
            if (m_YDamping.IsUse && templateDict.ContainsKey(m_YDamping.Id))
            {
                var targetValue = (m_YDamping.IsExpression ? m_YDamping.Value : m_YDamping.PrimitiveValue);
                target.m_YDamping = Mathf.Approximately(0, templateDict[m_YDamping.Id].Config.duration) ? targetValue : m_YDampingAlertInit + templateDict[m_YDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YDamping.Id].CostTime / templateDict[m_YDamping.Id].Config.duration) * (targetValue - m_YDampingAlertInit);
            }
            if (m_ZDamping.IsUse && templateDict.ContainsKey(m_ZDamping.Id))
            {
                var targetValue = (m_ZDamping.IsExpression ? m_ZDamping.Value : m_ZDamping.PrimitiveValue);
                target.m_ZDamping = Mathf.Approximately(0, templateDict[m_ZDamping.Id].Config.duration) ? targetValue : m_ZDampingAlertInit + templateDict[m_ZDamping.Id].Config.alertCurve.Evaluate(templateDict[m_ZDamping.Id].CostTime / templateDict[m_ZDamping.Id].Config.duration) * (targetValue - m_ZDampingAlertInit);
            }
            if (m_CameraUp.IsUse) target.m_CameraUp = m_CameraUp.IsExpression ? (Cinemachine.CinemachineTrackedDolly.CameraUpMode)m_CameraUp.Value :m_CameraUp.PrimitiveValue;
            if (m_PitchDamping.IsUse && templateDict.ContainsKey(m_PitchDamping.Id))
            {
                var targetValue = (m_PitchDamping.IsExpression ? m_PitchDamping.Value : m_PitchDamping.PrimitiveValue);
                target.m_PitchDamping = Mathf.Approximately(0, templateDict[m_PitchDamping.Id].Config.duration) ? targetValue : m_PitchDampingAlertInit + templateDict[m_PitchDamping.Id].Config.alertCurve.Evaluate(templateDict[m_PitchDamping.Id].CostTime / templateDict[m_PitchDamping.Id].Config.duration) * (targetValue - m_PitchDampingAlertInit);
            }
            if (m_YawDamping.IsUse && templateDict.ContainsKey(m_YawDamping.Id))
            {
                var targetValue = (m_YawDamping.IsExpression ? m_YawDamping.Value : m_YawDamping.PrimitiveValue);
                target.m_YawDamping = Mathf.Approximately(0, templateDict[m_YawDamping.Id].Config.duration) ? targetValue : m_YawDampingAlertInit + templateDict[m_YawDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YawDamping.Id].CostTime / templateDict[m_YawDamping.Id].Config.duration) * (targetValue - m_YawDampingAlertInit);
            }
            if (m_RollDamping.IsUse && templateDict.ContainsKey(m_RollDamping.Id))
            {
                var targetValue = (m_RollDamping.IsExpression ? m_RollDamping.Value : m_RollDamping.PrimitiveValue);
                target.m_RollDamping = Mathf.Approximately(0, templateDict[m_RollDamping.Id].Config.duration) ? targetValue : m_RollDampingAlertInit + templateDict[m_RollDamping.Id].Config.alertCurve.Evaluate(templateDict[m_RollDamping.Id].CostTime / templateDict[m_RollDamping.Id].Config.duration) * (targetValue - m_RollDampingAlertInit);
            }
            // 处理字段 m_AutoDolly
            // 生成递归代码
            m_AutoDolly?.ControlCinemachine(ref target.m_AutoDolly, templateDict);
        }
    }
}
