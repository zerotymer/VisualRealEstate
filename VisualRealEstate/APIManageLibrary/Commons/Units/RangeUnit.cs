namespace APIQueryLibrary
{
    /// <summary>
    /// 범위를 제한한 구조체를 정의합니다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class RangeUnit<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly T Max;
        /// <summary>
        /// 
        /// </summary>
        public readonly T Min;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public RangeUnit(T max, T min)
        {
            Max = max;
            Min = min;
        }
    }
}
