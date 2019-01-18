using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using System.Reflection;
using APIQueryLibrary.Attributes;

namespace APIQueryLibrary
{
    /// <summary>
    /// Query 처리를 위한 클래스
    /// </summary>
    // REDESIGNABLE: 에러메시지 수정
    public sealed class QueryRequest
    {
        public static Boolean SuccessExceptionReturn = false;

        #region 생성자와 소멸자(Constructors & Desturctors)
        /// <summary>
        /// 호출 클래스의 <see cref="QueryRequestInfoAttribute"/>을 읽어 인스턴스를 생성합니다.
        /// </summary>
        /// <param name="sender"><see cref="QueryRequestInfoAttribute"/>값을 가진 <see cref="Interfaces.IQueryDocument"/></param>
        public QueryRequest(Interfaces.IQueryDocument sender)
        {
            // QueryRequestAttribute 획득
            foreach (Attribute attr in sender.GetType().GetCustomAttributes())
            {
                if (attr is QueryRequestInfoAttribute)
                {
                    QueryRequestInfoAttribute qrAtt = attr as QueryRequestInfoAttribute;
                    this.Name = qrAtt.Name;
                    this.Description = qrAtt.Description;
                    this.ServiceProvider = qrAtt.ServiceProvider;
                }
            }

            this.Update(sender);
        }
        #endregion


        #region 속성(Properties)
        /// <summary>
        /// 이름
        /// </summary>
        public String Name { get; set; } = String.Empty;

        /// <summary>
        /// 주소
        /// </summary>
        public String URL { get; set; } = String.Empty;

        /// <summary>
        /// 설명
        /// </summary>
        public String Description { get; set; } = String.Empty;

        /// <summary>
        /// 서비스 제공자
        /// </summary>
        public String ServiceProvider { get; set; } = String.Empty;

        /// <summary>
        /// 인증(Authorization)
        /// </summary>
        public Object Authorization { get; set; } = null;

        private Dictionary<String, Object> _Params = new Dictionary<String, Object>();
        /// <summary>
        /// 파라미터(Parameters)
        /// </summary>
        public Dictionary<String, Object> Params
        {
            get { return _Params; }
        }

        private WebHeaderCollection _Headers = new WebHeaderCollection();
        /// <summary>
        /// Headers
        /// </summary>
        public WebHeaderCollection Headers
        {
            get { return _Headers; }
        }

        private Dictionary<String, Object> _Body = new Dictionary<String, Object>();
        /// <summary>
        /// Body
        /// </summary>
        public Dictionary<String, Object> Body
        {
            get { return _Body = new Dictionary<String, Object>(); }
        }

        /// <summary>
        /// 
        /// </summary>
        // UNDONE: 미구현
        public MediaTypes ContentType { get; set; } = MediaTypes.form_data;

        /// <summary>
        /// Pre-request Script
        /// </summary>
        public String PreRequestScript { get; set; } = "";

        /// <summary>
        /// Tests
        /// </summary>
        public String Tests { get; set; } = "";

        /// <summary>
        /// 웹요청방식
        /// </summary>
        public HttpRequestMethods HttpRequestMethod { get; set; } = HttpRequestMethods.GET;
        #endregion


        #region 메서드(Methods)
        /// <summary>
        /// 특성(Attribute)를 이용하여 해당 클래스의 쿼리데이터를 추출해옵니다.
        /// </summary>
        /// <param name="source"></param>
        private void Update(Object source)
        {
            // Parameters
            // 초기화
            this._Params.Clear();

            // 프로퍼티 목록 확인
            foreach (PropertyInfo pInfo in source.GetType().GetProperties())
            {
                // 어트리뷰트 확인
                foreach (Attribute att in pInfo.GetCustomAttributes(true)) // 상속포함
                {
                    if (att is QueryParamAttribute)
                    {
                        QueryParamAttribute paramAtt = att as QueryParamAttribute;
                        Object value = pInfo.GetValue(source);
                        
                        try
                        {
                            // 데이터 확인
                            if (paramAtt.GetValueString(value) == String.Empty)
                                continue;

                            _Params.Add(paramAtt.Key, value);   // EXCEPTION: Key 중복(ArgumentException)
                        }

                        catch (ArgumentException e) // Key 중복 예외처리
                        {
                            // TROUBLE: 중복시 처리방법 모호(갱신 혹은 통과처리중)
                            _Params.Remove(paramAtt.Key);
                            _Params.Add(paramAtt.Key, value);
                        }
                    }
                }
            }

            // 필드 목록 확인
            foreach (FieldInfo fInfo in source.GetType().GetFields())
            {
                // 어트리뷰트 확인
                foreach (Attribute att in fInfo.GetCustomAttributes(true)) // 상속포함
                {
                    if (att is QueryParamAttribute)
                    {
                        QueryParamAttribute paramAtt = att as QueryParamAttribute;
                        Object value = fInfo.GetValue(source);

                        try
                        {
                            // 데이터 확인
                            if (paramAtt.GetValueString(value) == String.Empty)
                                continue;

                            _Params.Add(paramAtt.Key, value);   // EXCEPTION: Key 중복(ArgumentException)
                        }

                        catch (ArgumentException e) // Key 중복 예외처리
                        {
                            // TROUBLE: 중복시 처리방법 모호(갱신 혹은 통과처리중)
                            _Params.Remove(paramAtt.Key);
                            _Params.Add(paramAtt.Key, value);
                        }
                    }
                }
            }

            // 메서드 목록 확인
            foreach (MethodInfo mInfo in source.GetType().GetMethods())
            {
                // 어트리뷰트 확인
                foreach (Attribute att in mInfo.GetCustomAttributes(true)) // 상속포함
                {
                    if (att is QueryParamAttribute)
                    {
                        QueryParamAttribute paramAtt = att as QueryParamAttribute;
                        Object value = mInfo.Invoke(source, null);

                        try
                        {
                            // 데이터 확인
                            if (paramAtt.GetValueString(value) == String.Empty)
                                continue;

                            _Params.Add(paramAtt.Key, value);   // EXCEPTION: Key 중복(ArgumentException)
                        }

                        catch (ArgumentException e) // Key 중복 예외처리
                        {
                            // TROUBLE: 중복시 처리방법 모호(갱신 혹은 통과처리중)
                            _Params.Remove(paramAtt.Key);
                            _Params.Add(paramAtt.Key, value);
                        }
                    }
                }
            }

            // TODO: Heders

            // TODO: Body

            // TODO: Pre-requestScript

            // TODO: Tests


        }

        /// <summary>
        /// 질의용 문자열 처리
        /// 크기: 512
        /// </summary>
        /// <returns></returns>
        private String ParamsToQueryString()
        {
            StringBuilder query = new StringBuilder(512);

            // Params
            Boolean isFirst = true; //  첫 항목에 대해서만 
            foreach (var item in Params)
            {
                query.Append(isFirst ? "" : "&");
                query.Append(String.Format("{0}={1}", item.Key, item.Value));
                isFirst = false;
            }
            return query.ToString();
        }

        // HtmlDocument
        /// <summary>
        /// HtmlDocument 요청
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private HtmlAgilityPack.HtmlDocument GetHtmlDocument(String url)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            web.AutoDetectEncoding = false;
            web.OverrideEncoding = Encoding.GetEncoding("euc-kr");
            return web.Load(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public HtmlDocument RequestParsing()
        {
            try
            {
                HttpWebResponse response = this.PostWebResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    /*
                    MessageBox.Show(
                        $"{nameof(RequestParsing)}: {this.Name}에서 오류를 발생하였습니다.", 
                        "Web 호출 오류",
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                    */
                }
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                HtmlDocument hdoc = new HtmlDocument();
                hdoc.LoadHtml(reader.ReadToEnd());

                return hdoc;
            }
            catch(Exception e)
            {
                /*
                MessageBox.Show(
                    $"{nameof(RequestParsing)}: {this.Name}에서 오류를 발생하였습니다. ({e.Message})", 
                    "Web 호출 오류",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                */
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HtmlDocument> RequestParsingAsync()
        {
            try
            {
                HttpWebResponse response = await this.PostWebResponseAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    /*
                    MessageBox.Show(
                        $"{nameof(RequestParsingAsync)}: {this.Name}에서 오류를 발생하였습니다.",
                        "Web 호출 오류",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    */
                }
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                HtmlDocument hdoc = new HtmlDocument();
                hdoc.LoadHtml(await reader.ReadToEndAsync());

                return hdoc;
            }
            catch (Exception e)
            {
                /*
                MessageBox.Show(
                    $"{nameof(RequestParsingAsync)}: {this.Name}에서 오류를 발생하였습니다. ({e.Message})",
                    "Web 호출 오류",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                    */
                return null;
            }
        }


        // Web 처리
        /// <summary>
        /// Get 방식 처리
        /// </summary>
        /// <returns></returns>
        public HttpWebResponse GetWebResponse()
        {
            HttpWebRequest request = WebRequest.Create(URL + "?" + this.ParamsToQueryString()) as HttpWebRequest;
            request.Method = "GET";
            request.Headers = this.Headers;
            // TODO: 쿠키처리 안됨. request.CookieContainer.SetCookies(ToQueryString(), cookieHeader)
            return request.GetResponse() as HttpWebResponse;
        }
        /// <summary>
        /// Get 방식 처리(비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<HttpWebResponse> GetWebResponseAsync()
        {
            HttpWebRequest request = WebRequest.Create(URL + "?" + this.ParamsToQueryString()) as HttpWebRequest;
            request.Method = "GET";
            request.Headers = this.Headers;
            // 쿠키처리 안됨: request.CookieContainer.SetCookies(ToQueryString(), cookieHeader)
            return await request.GetResponseAsync() as HttpWebResponse;
        }

        /// <summary>
        /// Post 방식 처리
        /// </summary>
        /// <returns></returns>
        public HttpWebResponse PostWebResponse()
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(this.ParamsToQueryString());
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Method = "POST";
            request.ContentLength = byteArray.Length;
            request.Headers = this.Headers;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Close();
            return request.GetResponse() as HttpWebResponse;
        }
        /// <summary>
        /// Post 방식 처리(비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<HttpWebResponse> PostWebResponseAsync()
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(this.ParamsToQueryString());
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Method = "POST";
            request.ContentLength = byteArray.Length;
            request.Headers = this.Headers;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Close();
            return await request.GetResponseAsync() as HttpWebResponse;
        }




        // 일반적인 Generic 요청

        /// <summary>
        /// 요청 처리방식
        /// </summary>
        public enum RequestMethods
        {
            /// <summary>
            /// XML
            /// </summary>
            Xml,
            /// <summary>
            /// Runtime XML
            /// </summary>
            RuntimeXml,
            /// <summary>
            /// Runtime Json
            /// </summary>
            RuntimeJson,
            /// <summary>
            /// Newtonsoft Json
            /// </summary>
            JsonByNewtonsoft
        }
        /// <summary>
        /// API 요청처리
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="method">처리방식</param>
        /// <returns></returns>
        public TResponse RequestQuery<TResponse>(RequestMethods method = RequestMethods.Xml)
        {
            try
            {
                HttpWebResponse response = this.GetWebResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }

                switch (method)
                {
                    case RequestMethods.Xml:
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                            // Deserialization from XML
                            XmlSerializer xs = new XmlSerializer(typeof(TResponse));
                            return (TResponse)xs.Deserialize(reader);
                        }
                    case RequestMethods.RuntimeXml:
                        using (Stream stream = response.GetResponseStream())
                        {
                            System.Xml.XmlDictionaryReader reader = System.Xml.XmlDictionaryReader.CreateTextReader(stream, new System.Xml.XmlDictionaryReaderQuotas());
                            System.Runtime.Serialization.DataContractSerializer ser = new System.Runtime.Serialization.DataContractSerializer(typeof(TResponse));

                            // Deserialize the data and read it from the instance.
                            TResponse deserializeResult = (TResponse)ser.ReadObject(reader, true);
                            reader.Close();
                            return deserializeResult;
                        }
                    case RequestMethods.RuntimeJson:
                        using (Stream stream = response.GetResponseStream())
                        {
                            // Deserialization from JSON
                            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TResponse));
                            return (TResponse)js.ReadObject(stream);
                        }
                    case RequestMethods.JsonByNewtonsoft:
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);

                            // Deserialization from JSON
                            return JsonConvert.DeserializeObject<TResponse>(reader.ReadToEnd());
                        }
                    default:
                        throw new NotImplementedException("정의되지 않은 메서드 호출입니다.");
                }
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestQuery)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                if (QueryRequest.SuccessExceptionReturn)
                {
                    throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }
            }
        }
        /// <summary>
        /// API 요청처리(비동기)
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        // UNDONE: 비동기화 불완전
        public async Task<TResponse> RequestQueryAsync<TResponse>(RequestMethods method = RequestMethods.Xml)
        {
            try
            {
                HttpWebResponse response = await this.GetWebResponseAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }

                switch (method)
                {
                    case RequestMethods.Xml:
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                            // Deserialization from XML
                            XmlSerializer xs = new XmlSerializer(typeof(TResponse));
                            return (TResponse)xs.Deserialize(reader);
                        }
                    case RequestMethods.RuntimeXml:
                        using (Stream stream = response.GetResponseStream())
                        {
                            System.Xml.XmlDictionaryReader reader = System.Xml.XmlDictionaryReader.CreateTextReader(stream, new System.Xml.XmlDictionaryReaderQuotas());
                            System.Runtime.Serialization.DataContractSerializer ser = new System.Runtime.Serialization.DataContractSerializer(typeof(TResponse));

                            // Deserialize the data and read it from the instance.
                            TResponse deserializeResult = (TResponse)ser.ReadObject(reader, true);
                            reader.Close();
                            return deserializeResult;
                        }
                    case RequestMethods.RuntimeJson:
                        using (Stream stream = response.GetResponseStream())
                        {
                            // Deserialization from JSON
                            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TResponse));
                            return (TResponse)js.ReadObject(stream);
                        }
                    case RequestMethods.JsonByNewtonsoft:
                        using (Stream stream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(stream);

                            // Deserialization from JSON
                            return JsonConvert.DeserializeObject<TResponse>(await reader.ReadToEndAsync());
                        }
                    default:
                        throw new NotImplementedException("정의되지 않은 메서드 호출입니다.");
                }
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestQueryAsync)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                if (QueryRequest.SuccessExceptionReturn)
                {
                    throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }
            }
        }





        /// <summary>
        /// Static Map API 요청처리
        /// </summary>
        /// <returns>이미지</returns>
        public ImageSource RequestStaticMapApi()
        {
            try
            {
                HttpWebResponse response = this.GetWebResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = response.GetResponseStream();
                bi.EndInit();

                return bi;
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestStaticMapApi)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                {
                    QueryName = this.Name,
                    QueryDescription = this.Description,
                    QueryServiceProivder = this.ServiceProvider
                };
            }
        }
        /// <summary>
        /// Static Map API 요청처리(비동기)
        /// </summary>
        /// <returns>결과반환</returns>
        public async Task<ImageSource> RequestStaticMapApiAsync()
        {
            try
            {
                HttpWebResponse response = await this.GetWebResponseAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = response.GetResponseStream();
                bi.EndInit();

                return bi;
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestStaticMapApiAsync)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                {
                    QueryName = this.Name,
                    QueryDescription = this.Description,
                    QueryServiceProivder = this.ServiceProvider
                };
            }
        }

        /// <summary>
        /// Html 문서 요청
        /// </summary>
        /// <returns></returns>
        public HtmlDocument RequestHtmlDocument()
        {
            try
            {
                HttpWebResponse response = this.PostWebResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                    HtmlDocument hdoc = new HtmlDocument();
                    hdoc.LoadHtml(reader.ReadToEnd());

                    return hdoc;
                }
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestHtmlDocument)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                {
                    QueryName = this.Name,
                    QueryDescription = this.Description,
                    QueryServiceProivder = this.ServiceProvider
                };
            }
        }
        /// <summary>
        /// Html 문서 요청 (비동기)
        /// </summary>
        /// <returns></returns>
        public async Task<HtmlDocument> RequestHtmlDocumentAsync()
        {
            try
            {
                HttpWebResponse response = await this.PostWebResponseAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                    HtmlDocument hdoc = new HtmlDocument();
                    hdoc.LoadHtml(await reader.ReadToEndAsync());

                    return hdoc;
                }
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestHtmlDocumentAsync)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                {
                    QueryName = this.Name,
                    QueryDescription = this.Description,
                    QueryServiceProivder = this.ServiceProvider
                };
            }
        }

        /// <summary>
        /// HtmlParsing 요청 처리 (HtmlAgilityPack)
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        public TResponse RequestHtmlParse<TResponse>()
            where TResponse : Interfaces.IHtmlParseable, new()
        {
            try
            {
                HttpWebResponse response = this.PostWebResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                    HtmlDocument hdoc = new HtmlDocument();
                    hdoc.LoadHtml(reader.ReadToEnd());
                    TResponse res = new TResponse();
                    res.Parse(hdoc);

                    return res;
                }
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestHtmlParse)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                {
                    QueryName = this.Name,
                    QueryDescription = this.Description,
                    QueryServiceProivder = this.ServiceProvider
                };
            }
        }
        /// <summary>
        /// HtmlParsing 요청 처리 (HtmlAgilityPack, 비동기)
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        public async Task<TResponse> RequestHtmlParseAsync<TResponse>()
            where TResponse : Interfaces.IHtmlParseable, new()
        {
            try
            {
                HttpWebResponse response = await this.PostWebResponseAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                    HtmlDocument hdoc = new HtmlDocument();
                    hdoc.LoadHtml(await reader.ReadToEndAsync());
                    TResponse res = new TResponse();
                    res.Parse(hdoc);

                    return res;
                }
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestHtmlParseAsync)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                {
                    QueryName = this.Name,
                    QueryDescription = this.Description,
                    QueryServiceProivder = this.ServiceProvider
                };
            }
        }




        // Static Map
        // TODO: 변환안됨
        /// <summary>
        /// Static Map API 요청처리
        /// </summary>
        /// <param name="query">요청변수</param>
        /// <returns>이미지</returns>
        public ImageSource RequestStaticMapApi(String query)
        {
            HttpWebRequest request = WebRequest.Create(query) as HttpWebRequest;
            request.Method = "GET";

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = response.GetResponseStream();
                bi.EndInit();

                return bi;
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestStaticMapApi)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                {
                    QueryName = this.Name,
                    QueryDescription = this.Description,
                    QueryServiceProivder = this.ServiceProvider
                };
            }
        }

        /// <summary>
        /// Static Map API 요청처리(비동기)
        /// </summary>
        /// <param name="query">요청변수</param>
        /// <returns>결과반환</returns>
        public async Task<ImageSource> RequestStaticMapApiAsync(String query)
        {
            HttpWebRequest request = WebRequest.Create(query) as HttpWebRequest;
            request.Method = "GET";

            try
            {
                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new FailResponseException($"{this.Name}에서 오류를 호출하였습니다. Http 접속에서 오류가 발생하였습니다.")
                    {
                        QueryName = this.Name,
                        QueryDescription = this.Description,
                        QueryServiceProivder = this.ServiceProvider
                    };
                }

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = response.GetResponseStream();
                bi.EndInit();

                return bi;
            }
            catch (QueryResponseException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new FailResponseException($"{nameof(RequestStaticMapApiAsync)}에서 오류를 호출하였습니다. 정의되지 않은 예외입니다.", e);
            }
            finally
            {
                throw new QueryResponseException($"{this.Name}가 정상적으로 처리되었습니다.")
                {
                    QueryName = this.Name,
                    QueryDescription = this.Description,
                    QueryServiceProivder = this.ServiceProvider
                };
            }
        }
        #endregion
    }
}