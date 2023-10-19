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
    [SuffixLabel("@$value.ChineseName")]
    public struct ConfigItem<T>
    {
        public string ChineseName;
        [HorizontalGroup(Width = 80)]
        public bool IsUse;
        [HorizontalGroup]
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
        /// <summary>
        /// 对该配置的中文描述
        /// </summary>
        public string Title;
        [TextArea(4, 10)]
        public string Detail;
        public EContextEvent contextEvent;
        [FormerlySerializedAs("Duration")] public float duration;
        public int priority;
        public int id;
        public AnimationCurve alertCurve;
        public CalculatorItem[] Condition;
        public CameraMovementDataConfigBase DataConfigBaseTemplate;
        public CameraMovementControlConfigBase controlConfigBaseTemplate;
    }

}