using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRealtor.Commons.Units
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class LimitedUnit<T> where T : IComparable
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly T Max;
        /// <summary>
        /// 
        /// </summary>
        public readonly T Min;

        private T _Value;
        /// <summary>
        /// 
        /// </summary>
        public T Value
        {
            get => _Value;
            set
            {
                if (value.CompareTo(Max) > 0)
                    _Value = Max;
                else if (value.CompareTo(Min) < 0)
                    _Value = Min;
                else
                    _Value = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        public LimitedUnit(T max, T min)
        {
            Max = max;
            Min = min;
        }

    }
}
