using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CameraMovement
{
    /// <summary>
    /// 基础配置项
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public struct ConfigItem<T>
    {
        public bool IsUse;
        public T Value;
        public CalculatorItem[] CalculatorExpression;
    }

    /// <summary>
    /// 计算项 operator不为None时值为operator，否则为contextMember 都为None则是Value表示立即数
    /// </summary>
    [Serializable]
    public struct CalculatorItem
    {
        public ECalculatorOperator Operator;
        public EContextMember ContextMember;
        public float Value;
    }
    
    /// <summary>
    /// 运镜配置模板
    /// </summary>
    [CreateAssetMenu(menuName = "创配置脚本")]
    public class CameraMovementConfig : ScriptableObject
    {
        public EContextEvent contextEvent;
        public float duration;
        public int priority;
        public int id;
        public AnimationCurve alertCurve;
        public CameraMovementDataConfigBase DataConfigBaseTemplate;
        [FormerlySerializedAs("ControlConfigTemplate")] public CameraMovementControlConfigBase controlConfigBaseTemplate;
    }

    [CreateAssetMenu(menuName = "创建配置脚本")]
    public class CameraMovementConfigState : ScriptableObject
    {
        public CameraMovementStateBase RuntimeState;
        public List<CameraMovementConfig> configList;
    }
}