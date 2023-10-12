using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
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
    public class CameraMovementConfig
    {
        public EContextEvent contextEvent;
        [FormerlySerializedAs("Duration")] public float duration;
        public int priority;
        public int id;
        public AnimationCurve alertCurve;
        public CalculatorItem[] Condition;
        public CameraMovementDataConfigBase DataConfigBaseTemplate;
        public CameraMovementControlConfigBase controlConfigBaseTemplate;
    }

    [CreateAssetMenu(menuName = "创建相机配置状态")]
    public class CameraMovementConfigState : SerializedScriptableObject
    {
        public string TypeName;
        public List<CameraMovementConfig> ConfigList;
    }
}