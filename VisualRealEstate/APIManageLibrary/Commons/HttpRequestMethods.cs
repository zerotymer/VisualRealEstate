namespace APIQueryLibrary
{
    /// <summary xml:lang="kr">
    /// 클라이언트가 웹서버에게 사용자 요청의 목적/종류를 알리는 수단
    /// <para>참고: http://www.ktword.co.kr/abbr_view.php?m_temp1=3791 </para>
    /// </summary>
    /// <summary xml:lang="en">
    /// An HTTP request is a class consisting of HTTP style requests, request lines, request methods, request URL, header fields, and body content. The most common methods that are used by a client in an HTTP request are as follows
    /// </summary>
    public enum HttpRequestMethods
    {
        /// <summary xml:lang="kr">URL(URI) 형식으로 웹서버측 리소스(데이터)를 요청</summary>
        /// <summary xml:lang="en">Used when the client is requesting a resource on the Web server.</summary>
        GET,

        /// <summary xml:lang="kr">메시지 헤더(문서정보) 취득</summary>
        /// <summary xml:lang="en">Used when the client is requesting some information about a resource but not requesting the resource itself.</summary>
        HEAD,

        /// <summary xml:lang="kr">내용 전송(파일 전송 가능)</summary>
        /// <summary xml:lang="en">Used when the client is sending information or data to the server—for example, filling out an online form (i.e. Sends a large amount of complex data to the Web Server).</summary>
        POST,

        /// <summary xml:lang="kr">내용 갱신 위주(파일 전송 가능)</summary>
        /// <summary xml:lang="en">Used when the client is sending a replacement document or uploading a new document to the Web server under the request URL.</summary>   
        PUT,
        
        /// <summary xml:lang="kr">웹 리소스를 제거</summary>
        /// <summary xml:lang="en">Used when the client is trying to delete a document from the Web server, identified by the request URL</summary>
        DELETE,

        /// <summary xml:lang="kr">요청 리소스가 수신되는 경로를 보여줌</summary>
        /// <summary xml:lang="en">Used when the client is asking the available proxies or intermediate servers changing the request to announce themselves.</summary>
        TRACE,

        /// <summary xml:lang="kr">웹서버측 제공 메소드에 대한 질의</summary>
        /// <summary xml:lang="en">Used when the client wants to determine other available methods to retrieve or process a document on the Web server.</summary>
        OPTIONS,

        /// <summary xml:lang="kr">프록시와 같은 중간 서버 경유</summary>
        /// <summary xml:lang="en">Used when the client wants to establish a transparent connection to a remote host, usually to facilitate SSL-encrypted communication (HTTPS) through an HTTP proxy.</summary>
        CONNECT
    }
}
