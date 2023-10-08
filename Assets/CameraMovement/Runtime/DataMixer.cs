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
    public struct MixItem<T>: IComparable<MixItem<T>>,IEquatable<MixItem<T>>
    {
        public int Id;
        public int Priority;
        public T Value;

        public MixItem(MixItem<T> other)
        {
            Id = other.Id;
            Priority = other.Priority;
            Value = other.Value;
        }

        public MixItem(int id, int priority, T value)
        {
            Id = id;
            Priority = priority;
            Value = value;
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

        /// <summary>
        /// 当前容器的表示的值
        /// </summary>
        public T Value => value_.Value;

        /// <summary>
        /// 当前容器的表示的值
        /// </summary>
        public int Id => value_.Id;

        private MixItem<T> getMax()
        {
            MixItem<T> max = default;
            for (int i = 0; i < dataList_.Count; i++)
            {
                //等于也换保证始终拿到的是最后进的
                if (max.Priority <= dataList_[i].Priority)
                {
                    max = dataList_[i];
                }
            }

            return max;
        }
        
        private void Refresh()
        {
            if (dataList_.Count == 0)
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
        public T Add(MixItem<T> item)
        {
            var index = dataList_.IndexOf(item);
            if (index != -1)
            {
                dataList_.RemoveAt(index);
            }
            dataList_.Add(item);
            Refresh();
            return value_.Value;
        }
        
        /// <summary>
        /// 添加一个新的混合项，返回添加完后的当前值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public T Remove(MixItem<T> item)
        {
            dataList_.Remove(item);
            Refresh();
            return value_.Value;
        }
    }

}