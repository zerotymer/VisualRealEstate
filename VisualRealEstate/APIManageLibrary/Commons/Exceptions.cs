using System;


namespace APIQueryLibrary
{
    /// <summary>
    /// <seealso cref="QueryRequest"/>요청시 응답결과에 대한 반응입니다.
    /// </summary>
    [Serializable()]
    public class QueryResponseException : Exception
    {
        public QueryResponseException() : base() { }
        public QueryResponseException(string message) : base(message) { }
        public QueryResponseException(string message, System.Exception inner) : base(message, inner) { }

        protected QueryResponseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public String QueryName { get; set; } = String.Empty;
        public String QueryServiceProivder { get; set; } = String.Empty;
        public String QueryDescription { get; set; } = String.Empty;
    }

    /// <summary>
    /// 성공적으로 응답하였을때 발생합니다.
    /// </summary>
    [Serializable()]
    public class SuccessResponseException : QueryResponseException
    {
        public SuccessResponseException() : base() { }
        public SuccessResponseException(string message) : base(message) { }
        public SuccessResponseException(string message, System.Exception inner) : base(message, inner) { }

        protected SuccessResponseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// 응답이 실패한 경우 발생됩니다.
    /// </summary>
    [Serializable()]
    public class FailResponseException : QueryResponseException
    {
        public FailResponseException() : base() { }
        public FailResponseException(string message) : base(message) { }
        public FailResponseException(string message, System.Exception inner) : base(message, inner) { }

        protected FailResponseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// 에러메시지가 포함된 응답을 받은 경우 발생된빈다.
    /// </summary>
    [Serializable()]
    public class ErrorResponseException : QueryResponseException
    {
        public ErrorResponseException() : base() { }
        public ErrorResponseException(string message) : base(message) { }
        public ErrorResponseException(string message, System.Exception inner) : base(message, inner) { }

        protected ErrorResponseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }

    /// <summary>
    /// 금칙어가 포함된 경우 발생합니다.
    /// </summary>
    [Serializable()]
    public class ProhibitedWordsException : QueryResponseException
    {
        public ProhibitedWordsException() : base() { }
        public ProhibitedWordsException(string message) : base(message) { }
        public ProhibitedWordsException(string message, System.Exception inner) : base(message, inner) { }

        protected ProhibitedWordsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public string ProhibitedWords { get; set; } = string.Empty;
    }

}
