using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_AxisState_Field :ICameraMovementControlField<Cinemachine.AxisState>
    {
       public  Type AttachControlField => typeof(Cinemachine.AxisState);

       [UnityEngine.TooltipAttribute("The current value of the axis.")]
            public DataMixer <System.Single> Value;
        public float ValueAlertInit;
       [UnityEngine.TooltipAttribute("How to interpret the Max Speed setting: in units/second, or as a direct input value multiplier")]
            public DataMixer <Cinemachine.AxisState.SpeedMode> m_SpeedMode;
       [UnityEngine.TooltipAttribute("The maximum speed of this axis in units/second, or the input value multiplier, depending on the Speed Mode")]
            public DataMixer <System.Single> m_MaxSpeed;
        public float m_MaxSpeedAlertInit;
       [UnityEngine.TooltipAttribute("The amount of time in seconds it takes to accelerate to MaxSpeed with the supplied Axis at its maximum value")]
            public DataMixer <System.Single> m_AccelTime;
        public float m_AccelTimeAlertInit;
       [UnityEngine.TooltipAttribute("The amount of time in seconds it takes to decelerate the axis to zero if the supplied axis is in a neutral position")]
            public DataMixer <System.Single> m_DecelTime;
        public float m_DecelTimeAlertInit;
       [UnityEngine.TooltipAttribute("The name of this axis as specified in Unity Input manager. Setting to an empty string will disable the automatic updating of this axis")]
            public DataMixer <System.String> m_InputAxisName;
       [UnityEngine.TooltipAttribute("The value of the input axis.  A value of 0 means no input.  You can drive this directly from a custom input system, or you can set the Axis Name and have the value driven by the internal Input Manager")]
            public DataMixer <System.Single> m_InputAxisValue;
        public float m_InputAxisValueAlertInit;
       [UnityEngine.TooltipAttribute("If checked, then the raw value of the input axis will be inverted before it is used")]
            public DataMixer <System.Boolean> m_InvertInput;
       [UnityEngine.TooltipAttribute("The minimum value for the axis")]
            public DataMixer <System.Single> m_MinValue;
        public float m_MinValueAlertInit;
       [UnityEngine.TooltipAttribute("The maximum value for the axis")]
            public DataMixer <System.Single> m_MaxValue;
        public float m_MaxValueAlertInit;
       [UnityEngine.TooltipAttribute("If checked, then the axis will wrap around at the min/max values, forming a loop")]
            public DataMixer <System.Boolean> m_Wrap;
       [UnityEngine.TooltipAttribute("Automatic recentering to at-rest position")]
        public Control_C_AS_Recentering_Field m_Recentering;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.AxisState target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_AxisState_Config source = (CameraMovement.Control_C_AxisState_Config)sourceConfig;
                if(source.Value.IsUse)
                {
                    ValueAlertInit = target.Value;
                    Value.Add(new MixItem<System.Single>(id, priority, source.Value.CalculatorExpression, source.Value.Value, source.Value.IsUse));
                }
                if(source.m_SpeedMode.IsUse)
                {
                    m_SpeedMode.Add(new MixItem<Cinemachine.AxisState.SpeedMode>(id, priority, source.m_SpeedMode.CalculatorExpression, source.m_SpeedMode.Value, source.m_SpeedMode.IsUse));
                }
                if(source.m_MaxSpeed.IsUse)
                {
                    m_MaxSpeedAlertInit = target.m_MaxSpeed;
                    m_MaxSpeed.Add(new MixItem<System.Single>(id, priority, source.m_MaxSpeed.CalculatorExpression, source.m_MaxSpeed.Value, source.m_MaxSpeed.IsUse));
                }
                if(source.m_AccelTime.IsUse)
                {
                    m_AccelTimeAlertInit = target.m_AccelTime;
                    m_AccelTime.Add(new MixItem<System.Single>(id, priority, source.m_AccelTime.CalculatorExpression, source.m_AccelTime.Value, source.m_AccelTime.IsUse));
                }
                if(source.m_DecelTime.IsUse)
                {
                    m_DecelTimeAlertInit = target.m_DecelTime;
                    m_DecelTime.Add(new MixItem<System.Single>(id, priority, source.m_DecelTime.CalculatorExpression, source.m_DecelTime.Value, source.m_DecelTime.IsUse));
                }
                if(source.m_InputAxisName.IsUse)
                {
                    m_InputAxisName.Add(new MixItem<System.String>(id, priority, source.m_InputAxisName.CalculatorExpression, source.m_InputAxisName.Value, source.m_InputAxisName.IsUse));
                }
                if(source.m_InputAxisValue.IsUse)
                {
                    m_InputAxisValueAlertInit = target.m_InputAxisValue;
                    m_InputAxisValue.Add(new MixItem<System.Single>(id, priority, source.m_InputAxisValue.CalculatorExpression, source.m_InputAxisValue.Value, source.m_InputAxisValue.IsUse));
                }
                if(source.m_InvertInput.IsUse)
                {
                    m_InvertInput.Add(new MixItem<System.Boolean>(id, priority, source.m_InvertInput.CalculatorExpression, source.m_InvertInput.Value, source.m_InvertInput.IsUse));
                }
                if(source.m_MinValue.IsUse)
                {
                    m_MinValueAlertInit = target.m_MinValue;
                    m_MinValue.Add(new MixItem<System.Single>(id, priority, source.m_MinValue.CalculatorExpression, source.m_MinValue.Value, source.m_MinValue.IsUse));
                }
                if(source.m_MaxValue.IsUse)
                {
                    m_MaxValueAlertInit = target.m_MaxValue;
                    m_MaxValue.Add(new MixItem<System.Single>(id, priority, source.m_MaxValue.CalculatorExpression, source.m_MaxValue.Value, source.m_MaxValue.IsUse));
                }
                if(source.m_Wrap.IsUse)
                {
                    m_Wrap.Add(new MixItem<System.Boolean>(id, priority, source.m_Wrap.CalculatorExpression, source.m_Wrap.Value, source.m_Wrap.IsUse));
                }
                if(source.m_Recentering != null && m_Recentering == null) m_Recentering = new Control_C_AS_Recentering_Field();
            m_Recentering?.AddByConfig(source.m_Recentering, id, priority, ref target.m_Recentering);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.AxisState target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_AxisState_Config source = (CameraMovement.Control_C_AxisState_Config)sourceConfig;
                if(source.Value.IsUse)
                {
                    ValueAlertInit = target.Value;
                    Value.Remove(new MixItem<System.Single>(id, priority, source.Value.CalculatorExpression, source.Value.Value, source.Value.IsUse));
                }
                if(source.m_SpeedMode.IsUse)
                {
                    m_SpeedMode.Remove(new MixItem<Cinemachine.AxisState.SpeedMode>(id, priority, source.m_SpeedMode.CalculatorExpression, source.m_SpeedMode.Value, source.m_SpeedMode.IsUse));
                }
                if(source.m_MaxSpeed.IsUse)
                {
                    m_MaxSpeedAlertInit = target.m_MaxSpeed;
                    m_MaxSpeed.Remove(new MixItem<System.Single>(id, priority, source.m_MaxSpeed.CalculatorExpression, source.m_MaxSpeed.Value, source.m_MaxSpeed.IsUse));
                }
                if(source.m_AccelTime.IsUse)
                {
                    m_AccelTimeAlertInit = target.m_AccelTime;
                    m_AccelTime.Remove(new MixItem<System.Single>(id, priority, source.m_AccelTime.CalculatorExpression, source.m_AccelTime.Value, source.m_AccelTime.IsUse));
                }
                if(source.m_DecelTime.IsUse)
                {
                    m_DecelTimeAlertInit = target.m_DecelTime;
                    m_DecelTime.Remove(new MixItem<System.Single>(id, priority, source.m_DecelTime.CalculatorExpression, source.m_DecelTime.Value, source.m_DecelTime.IsUse));
                }
                if(source.m_InputAxisName.IsUse)
                {
                    m_InputAxisName.Remove(new MixItem<System.String>(id, priority, source.m_InputAxisName.CalculatorExpression, source.m_InputAxisName.Value, source.m_InputAxisName.IsUse));
                }
                if(source.m_InputAxisValue.IsUse)
                {
                    m_InputAxisValueAlertInit = target.m_InputAxisValue;
                    m_InputAxisValue.Remove(new MixItem<System.Single>(id, priority, source.m_InputAxisValue.CalculatorExpression, source.m_InputAxisValue.Value, source.m_InputAxisValue.IsUse));
                }
                if(source.m_InvertInput.IsUse)
                {
                    m_InvertInput.Remove(new MixItem<System.Boolean>(id, priority, source.m_InvertInput.CalculatorExpression, source.m_InvertInput.Value, source.m_InvertInput.IsUse));
                }
                if(source.m_MinValue.IsUse)
                {
                    m_MinValueAlertInit = target.m_MinValue;
                    m_MinValue.Remove(new MixItem<System.Single>(id, priority, source.m_MinValue.CalculatorExpression, source.m_MinValue.Value, source.m_MinValue.IsUse));
                }
                if(source.m_MaxValue.IsUse)
                {
                    m_MaxValueAlertInit = target.m_MaxValue;
                    m_MaxValue.Remove(new MixItem<System.Single>(id, priority, source.m_MaxValue.CalculatorExpression, source.m_MaxValue.Value, source.m_MaxValue.IsUse));
                }
                if(source.m_Wrap.IsUse)
                {
                    m_Wrap.Remove(new MixItem<System.Boolean>(id, priority, source.m_Wrap.CalculatorExpression, source.m_Wrap.Value, source.m_Wrap.IsUse));
                }
            m_Recentering?.RemoveByConfig(source.m_Recentering, id, priority, ref target.m_Recentering);
        }
        public void RemoveAll()
        {
            Value.RemoveAll();
            m_SpeedMode.RemoveAll();
            m_MaxSpeed.RemoveAll();
            m_AccelTime.RemoveAll();
            m_DecelTime.RemoveAll();
            m_InputAxisName.RemoveAll();
            m_InputAxisValue.RemoveAll();
            m_InvertInput.RemoveAll();
            m_MinValue.RemoveAll();
            m_MaxValue.RemoveAll();
            m_Wrap.RemoveAll();
            m_Recentering?.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.AxisState target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (Value.IsUse && templateDict.ContainsKey(Value.Id))
            {
                var targetValue = (Value.IsExpression ? Value.Value : Value.PrimitiveValue);
                target.Value = Mathf.Approximately(0, templateDict[Value.Id].Config.duration) ? targetValue : ValueAlertInit + templateDict[Value.Id].Config.alertCurve.Evaluate(templateDict[Value.Id].CostTime / templateDict[Value.Id].Config.duration) * (targetValue - ValueAlertInit);
            }
            if (m_SpeedMode.IsUse) target.m_SpeedMode = m_SpeedMode.IsExpression ? (Cinemachine.AxisState.SpeedMode)m_SpeedMode.Value :m_SpeedMode.PrimitiveValue;
            if (m_MaxSpeed.IsUse && templateDict.ContainsKey(m_MaxSpeed.Id))
            {
                var targetValue = (m_MaxSpeed.IsExpression ? m_MaxSpeed.Value : m_MaxSpeed.PrimitiveValue);
                target.m_MaxSpeed = Mathf.Approximately(0, templateDict[m_MaxSpeed.Id].Config.duration) ? targetValue : m_MaxSpeedAlertInit + templateDict[m_MaxSpeed.Id].Config.alertCurve.Evaluate(templateDict[m_MaxSpeed.Id].CostTime / templateDict[m_MaxSpeed.Id].Config.duration) * (targetValue - m_MaxSpeedAlertInit);
            }
            if (m_AccelTime.IsUse && templateDict.ContainsKey(m_AccelTime.Id))
            {
                var targetValue = (m_AccelTime.IsExpression ? m_AccelTime.Value : m_AccelTime.PrimitiveValue);
                target.m_AccelTime = Mathf.Approximately(0, templateDict[m_AccelTime.Id].Config.duration) ? targetValue : m_AccelTimeAlertInit + templateDict[m_AccelTime.Id].Config.alertCurve.Evaluate(templateDict[m_AccelTime.Id].CostTime / templateDict[m_AccelTime.Id].Config.duration) * (targetValue - m_AccelTimeAlertInit);
            }
            if (m_DecelTime.IsUse && templateDict.ContainsKey(m_DecelTime.Id))
            {
                var targetValue = (m_DecelTime.IsExpression ? m_DecelTime.Value : m_DecelTime.PrimitiveValue);
                target.m_DecelTime = Mathf.Approximately(0, templateDict[m_DecelTime.Id].Config.duration) ? targetValue : m_DecelTimeAlertInit + templateDict[m_DecelTime.Id].Config.alertCurve.Evaluate(templateDict[m_DecelTime.Id].CostTime / templateDict[m_DecelTime.Id].Config.duration) * (targetValue - m_DecelTimeAlertInit);
            }
            if (m_InputAxisName.IsUse) target.m_InputAxisName = m_InputAxisName.PrimitiveValue;
            if (m_InputAxisValue.IsUse && templateDict.ContainsKey(m_InputAxisValue.Id))
            {
                var targetValue = (m_InputAxisValue.IsExpression ? m_InputAxisValue.Value : m_InputAxisValue.PrimitiveValue);
                target.m_InputAxisValue = Mathf.Approximately(0, templateDict[m_InputAxisValue.Id].Config.duration) ? targetValue : m_InputAxisValueAlertInit + templateDict[m_InputAxisValue.Id].Config.alertCurve.Evaluate(templateDict[m_InputAxisValue.Id].CostTime / templateDict[m_InputAxisValue.Id].Config.duration) * (targetValue - m_InputAxisValueAlertInit);
            }
            if (m_InvertInput.IsUse) target.m_InvertInput = m_InvertInput.IsExpression ? !Mathf.Approximately(m_InvertInput.Value, 0) : m_InvertInput.PrimitiveValue;
            if (m_MinValue.IsUse && templateDict.ContainsKey(m_MinValue.Id))
            {
                var targetValue = (m_MinValue.IsExpression ? m_MinValue.Value : m_MinValue.PrimitiveValue);
                target.m_MinValue = Mathf.Approximately(0, templateDict[m_MinValue.Id].Config.duration) ? targetValue : m_MinValueAlertInit + templateDict[m_MinValue.Id].Config.alertCurve.Evaluate(templateDict[m_MinValue.Id].CostTime / templateDict[m_MinValue.Id].Config.duration) * (targetValue - m_MinValueAlertInit);
            }
            if (m_MaxValue.IsUse && templateDict.ContainsKey(m_MaxValue.Id))
            {
                var targetValue = (m_MaxValue.IsExpression ? m_MaxValue.Value : m_MaxValue.PrimitiveValue);
                target.m_MaxValue = Mathf.Approximately(0, templateDict[m_MaxValue.Id].Config.duration) ? targetValue : m_MaxValueAlertInit + templateDict[m_MaxValue.Id].Config.alertCurve.Evaluate(templateDict[m_MaxValue.Id].CostTime / templateDict[m_MaxValue.Id].Config.duration) * (targetValue - m_MaxValueAlertInit);
            }
            if (m_Wrap.IsUse) target.m_Wrap = m_Wrap.IsExpression ? !Mathf.Approximately(m_Wrap.Value, 0) : m_Wrap.PrimitiveValue;
            // 处理字段 m_Recentering
            // 生成递归代码
            m_Recentering?.ControlCinemachine(ref target.m_Recentering, templateDict);
        }
    }
}
