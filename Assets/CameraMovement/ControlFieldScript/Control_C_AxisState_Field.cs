using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_AxisState_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.AxisState);

       [UnityEngine.TooltipAttribute("The current value of the axis.")]
            public DataMixer <System.Single> Value;
       [UnityEngine.TooltipAttribute("How to interpret the Max Speed setting: in units/second, or as a direct input value multiplier")]
            public DataMixer <Cinemachine.AxisState.SpeedMode> m_SpeedMode;
       [UnityEngine.TooltipAttribute("The maximum speed of this axis in units/second, or the input value multiplier, depending on the Speed Mode")]
            public DataMixer <System.Single> m_MaxSpeed;
       [UnityEngine.TooltipAttribute("The amount of time in seconds it takes to accelerate to MaxSpeed with the supplied Axis at its maximum value")]
            public DataMixer <System.Single> m_AccelTime;
       [UnityEngine.TooltipAttribute("The amount of time in seconds it takes to decelerate the axis to zero if the supplied axis is in a neutral position")]
            public DataMixer <System.Single> m_DecelTime;
       [UnityEngine.TooltipAttribute("The name of this axis as specified in Unity Input manager. Setting to an empty string will disable the automatic updating of this axis")]
            public DataMixer <System.String> m_InputAxisName;
       [UnityEngine.TooltipAttribute("The value of the input axis.  A value of 0 means no input.  You can drive this directly from a custom input system, or you can set the Axis Name and have the value driven by the internal Input Manager")]
            public DataMixer <System.Single> m_InputAxisValue;
       [UnityEngine.TooltipAttribute("If checked, then the raw value of the input axis will be inverted before it is used")]
            public DataMixer <System.Boolean> m_InvertInput;
       [UnityEngine.TooltipAttribute("The minimum value for the axis")]
            public DataMixer <System.Single> m_MinValue;
       [UnityEngine.TooltipAttribute("The maximum value for the axis")]
            public DataMixer <System.Single> m_MaxValue;
       [UnityEngine.TooltipAttribute("If checked, then the axis will wrap around at the min/max values, forming a loop")]
            public DataMixer <System.Boolean> m_Wrap;
       [UnityEngine.TooltipAttribute("Automatic recentering to at-rest position")]
        public Control_C_AS_Recentering_Field m_Recentering;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_AxisState_Config source = (CameraMovement.Control_C_AxisState_Config)sourceConfig;
            if(source.Value.IsUse) Value.Add(new MixItem<System.Single>(id, priority, source.Value.CalculatorExpression, source.Value.Value));
            if(source.m_SpeedMode.IsUse) m_SpeedMode.Add(new MixItem<Cinemachine.AxisState.SpeedMode>(id, priority, source.m_SpeedMode.CalculatorExpression, source.m_SpeedMode.Value));
            if(source.m_MaxSpeed.IsUse) m_MaxSpeed.Add(new MixItem<System.Single>(id, priority, source.m_MaxSpeed.CalculatorExpression, source.m_MaxSpeed.Value));
            if(source.m_AccelTime.IsUse) m_AccelTime.Add(new MixItem<System.Single>(id, priority, source.m_AccelTime.CalculatorExpression, source.m_AccelTime.Value));
            if(source.m_DecelTime.IsUse) m_DecelTime.Add(new MixItem<System.Single>(id, priority, source.m_DecelTime.CalculatorExpression, source.m_DecelTime.Value));
            if(source.m_InputAxisName.IsUse) m_InputAxisName.Add(new MixItem<System.String>(id, priority, source.m_InputAxisName.CalculatorExpression, source.m_InputAxisName.Value));
            if(source.m_InputAxisValue.IsUse) m_InputAxisValue.Add(new MixItem<System.Single>(id, priority, source.m_InputAxisValue.CalculatorExpression, source.m_InputAxisValue.Value));
            if(source.m_InvertInput.IsUse) m_InvertInput.Add(new MixItem<System.Boolean>(id, priority, source.m_InvertInput.CalculatorExpression, source.m_InvertInput.Value));
            if(source.m_MinValue.IsUse) m_MinValue.Add(new MixItem<System.Single>(id, priority, source.m_MinValue.CalculatorExpression, source.m_MinValue.Value));
            if(source.m_MaxValue.IsUse) m_MaxValue.Add(new MixItem<System.Single>(id, priority, source.m_MaxValue.CalculatorExpression, source.m_MaxValue.Value));
            if(source.m_Wrap.IsUse) m_Wrap.Add(new MixItem<System.Boolean>(id, priority, source.m_Wrap.CalculatorExpression, source.m_Wrap.Value));
            m_Recentering.AddByConfig(source.m_Recentering, id, priority);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_AxisState_Config source = (CameraMovement.Control_C_AxisState_Config)sourceConfig;
            if(source.Value.IsUse) Value.Remove(new MixItem<System.Single>(id, priority, source.Value.CalculatorExpression, source.Value.Value));
            if(source.m_SpeedMode.IsUse) m_SpeedMode.Remove(new MixItem<Cinemachine.AxisState.SpeedMode>(id, priority, source.m_SpeedMode.CalculatorExpression, source.m_SpeedMode.Value));
            if(source.m_MaxSpeed.IsUse) m_MaxSpeed.Remove(new MixItem<System.Single>(id, priority, source.m_MaxSpeed.CalculatorExpression, source.m_MaxSpeed.Value));
            if(source.m_AccelTime.IsUse) m_AccelTime.Remove(new MixItem<System.Single>(id, priority, source.m_AccelTime.CalculatorExpression, source.m_AccelTime.Value));
            if(source.m_DecelTime.IsUse) m_DecelTime.Remove(new MixItem<System.Single>(id, priority, source.m_DecelTime.CalculatorExpression, source.m_DecelTime.Value));
            if(source.m_InputAxisName.IsUse) m_InputAxisName.Remove(new MixItem<System.String>(id, priority, source.m_InputAxisName.CalculatorExpression, source.m_InputAxisName.Value));
            if(source.m_InputAxisValue.IsUse) m_InputAxisValue.Remove(new MixItem<System.Single>(id, priority, source.m_InputAxisValue.CalculatorExpression, source.m_InputAxisValue.Value));
            if(source.m_InvertInput.IsUse) m_InvertInput.Remove(new MixItem<System.Boolean>(id, priority, source.m_InvertInput.CalculatorExpression, source.m_InvertInput.Value));
            if(source.m_MinValue.IsUse) m_MinValue.Remove(new MixItem<System.Single>(id, priority, source.m_MinValue.CalculatorExpression, source.m_MinValue.Value));
            if(source.m_MaxValue.IsUse) m_MaxValue.Remove(new MixItem<System.Single>(id, priority, source.m_MaxValue.CalculatorExpression, source.m_MaxValue.Value));
            if(source.m_Wrap.IsUse) m_Wrap.Remove(new MixItem<System.Boolean>(id, priority, source.m_Wrap.CalculatorExpression, source.m_Wrap.Value));
            m_Recentering.RemoveByConfig(source.m_Recentering, id, priority);
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
            m_Recentering.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.AxisState)targetObj;
            target.m_SpeedMode = (Cinemachine.AxisState.SpeedMode)m_SpeedMode.Value;
            if (templateDict.ContainsKey(m_MaxSpeed.Id))
                target.m_MaxSpeed = templateDict[m_MaxSpeed.Id].Config.alertCurve.Evaluate(templateDict[m_MaxSpeed.Id].CostTime / templateDict[m_MaxSpeed.Id].Config.duration) * m_MaxSpeed.Value;
            target.m_MaxSpeed = (System.Single)m_MaxSpeed.Value;
            if (templateDict.ContainsKey(m_AccelTime.Id))
                target.m_AccelTime = templateDict[m_AccelTime.Id].Config.alertCurve.Evaluate(templateDict[m_AccelTime.Id].CostTime / templateDict[m_AccelTime.Id].Config.duration) * m_AccelTime.Value;
            target.m_AccelTime = (System.Single)m_AccelTime.Value;
            if (templateDict.ContainsKey(m_DecelTime.Id))
                target.m_DecelTime = templateDict[m_DecelTime.Id].Config.alertCurve.Evaluate(templateDict[m_DecelTime.Id].CostTime / templateDict[m_DecelTime.Id].Config.duration) * m_DecelTime.Value;
            target.m_DecelTime = (System.Single)m_DecelTime.Value;
            target.m_InputAxisName = (String)m_InputAxisName.PrimitiveValue;
            if (templateDict.ContainsKey(m_InputAxisValue.Id))
                target.m_InputAxisValue = templateDict[m_InputAxisValue.Id].Config.alertCurve.Evaluate(templateDict[m_InputAxisValue.Id].CostTime / templateDict[m_InputAxisValue.Id].Config.duration) * m_InputAxisValue.Value;
            target.m_InputAxisValue = (System.Single)m_InputAxisValue.Value;
            target.m_InvertInput = !Mathf.Approximately(m_InvertInput.Value, 0);
            if (templateDict.ContainsKey(m_MinValue.Id))
                target.m_MinValue = templateDict[m_MinValue.Id].Config.alertCurve.Evaluate(templateDict[m_MinValue.Id].CostTime / templateDict[m_MinValue.Id].Config.duration) * m_MinValue.Value;
            target.m_MinValue = (System.Single)m_MinValue.Value;
            if (templateDict.ContainsKey(m_MaxValue.Id))
                target.m_MaxValue = templateDict[m_MaxValue.Id].Config.alertCurve.Evaluate(templateDict[m_MaxValue.Id].CostTime / templateDict[m_MaxValue.Id].Config.duration) * m_MaxValue.Value;
            target.m_MaxValue = (System.Single)m_MaxValue.Value;
            target.m_Wrap = !Mathf.Approximately(m_Wrap.Value, 0);
            // 处理字段 m_Recentering
            // 生成递归代码
            m_Recentering.ControlCinemachine(target.m_Recentering, templateDict);
        }
    }
}
