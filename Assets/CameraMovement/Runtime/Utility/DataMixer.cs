using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CameraMovement
{
    /// <summary>
    /// 操作混合容器的基本单位
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct MixItem<T> : IComparable<MixItem<T>>, IEquatable<MixItem<T>>
    {
        public int Id;
        public int Priority;
        public T PrimitiveValue;
        public List<CalculatorItem> Value;
        public bool IsUse;

        public MixItem(MixItem<T> other)
        {
            Id = other.Id;
            Priority = other.Priority;
            Value = other.Value;
            PrimitiveValue = other.PrimitiveValue;
            IsUse = other.IsUse;
        }

        public MixItem(int id, int priority, List<CalculatorItem> value, T primitiveValue, bool isUse)
        {
            Id = id;
            Priority = priority;
            Value = value;
            PrimitiveValue = primitiveValue;
            IsUse = isUse;
        }

        // 实现IComparable<T>接口
        public int CompareTo(MixItem<T> other)
        {
            // 根据priority字段进行比较
            return other.Priority.CompareTo(Priority); // 降序排序
        }

        public bool Equals(MixItem<T> other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

    /// <summary>
    /// 基于优先级的数据混合器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct DataMixer<T>
    {
        private List<MixItem<T>> dataList_;
        private MixItem<T> value_;
        private readonly EContextMember storeContextMember_;
        public float Cache;

        public DataMixer(EContextMember storeContextMember)
        {
            storeContextMember_ = storeContextMember;
            dataList_ = null;
            value_ = default;
            Cache = default;
        }


        /// <summary>
        /// 当前容器的表示的值
        /// </summary>
        public float Value {
            get
            {
                Cache = Calculator.CalculatePoland(value_.Value, (int)storeContextMember_);
                return Cache;
            }}

        /// <summary>
        /// 是否是个表达式
        /// </summary>
        public bool IsExpression => value_.Value != null && value_.Value.Count != 0;

        /// <summary>
        /// 是否需要使用
        /// </summary>
        public bool IsUse => value_.IsUse;
        
        /// <summary>
        /// 当前容器的表示的值
        /// </summary>
        public T PrimitiveValue => value_.PrimitiveValue;

        /// <summary>
        /// 当前容器的表示的值
        /// </summary>
        public int Id => value_.Id;

        private List<MixItem<T>> DataList
        {
            get
            {
                if (dataList_ == null)
                {
                    dataList_ = new List<MixItem<T>>();
                }

                return dataList_;
            }
        }

        private MixItem<T> getMax()
        {
            MixItem<T> max = default;
            for (int i = 0; i < DataList.Count; i++)
            {
                //等于也换保证始终拿到的是最后进的
                if (max.Priority <= DataList[i].Priority)
                {
                    max = DataList[i];
                }
            }

            return max;
        }
        
        private void Refresh()
        {
            if (DataList.Count == 0)
            {
                return;
            }
            value_ = getMax();
        }

        /// <summary>
        /// 添加一个新的混合项，返回添加完后的当前值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(MixItem<T> item)
        {
            var index = DataList.IndexOf(item);
            if (index != -1)
            {
                DataList.RemoveAt(index);
            }
            DataList.Add(item);
            Refresh();
        }
        
        /// <summary>
        /// 移除一个混合项
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Remove(MixItem<T> item)
        {
            DataList.Remove(item);
            Refresh();
        }
        
        /// <summary>
        /// 移除所有混合项
        /// </summary>
        /// <returns></returns>
        public void RemoveAll()
        {
            DataList.Clear();
            value_ = default;
        }
    }

}