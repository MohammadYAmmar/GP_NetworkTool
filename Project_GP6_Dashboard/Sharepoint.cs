using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.IdentityModel.Protocols.WSTrust;
using Microsoft.SharePoint.Client;


using Microsoft.IdentityModel.Protocols;
using System.Net.Security;
using System.Security;
using Microsoft.IdentityModel.Protocols.WSTrust.Bindings;
using Microsoft.Office.Server.Search.REST;

namespace Project_GP6_Dashboard
{
    class Sharepoint
    {



        //https://stackoverflow.com/questions/10651304/authenticate-user-by-adfs-active-directory-federation-service
        public void check_new()
        {
            //WSTrustChannelFactory adfsfactory = new WSTrustChannelFactory(new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential).ToString());

            //adfsfactory.TrustVersion = System.ServiceModel.Security.TrustVersion.WSTrust13;

            //// Username and Password here...
            //System.Configuration.ConfigurationManager.us = "domain\username";
            //factory.Credentials.UserName.Password = "password";

            //IWSTrustChannelContract channel = adfsfactory.CreateChannel();

            //// request the token
            //SecurityToken token = channel.Issue(rst);



        }



        //// ClientContext t =  obj1.MSOnlineHelperClassAuth_NEW("sss");


        // obj1.MSOnlineHelperClassAuth_set();

        //https://www.codesharepoint.com/sharepoint-tutorial/connect-to-sharepoint-online-on-premise-and-extranet-using-csom
        public void AuthenticateUser(Uri TargetSiteUrl, string Environmentvalue, string username, string password)
        {
            //MYA
            //Uri uri_new Uri(SiteURL)
            try
            {
                // Based on the environmentvalue provided it execute the function.
                if (string.Compare(Environmentvalue, "onpremises", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ClientContext Context = LogOn(username, password, TargetSiteUrl);
                    // isAuthenticated = true;
                    // You can write additional methods here which you want to use after authentication
                }
                else if (string.Compare(Environmentvalue, "o365", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ClientContext Context = O365LogOn(username, password, TargetSiteUrl);
                    // isAuthenticated = true;
                    // You can write additional methods here which you want to use after authentication
                }
                else if (string.Compare(Environmentvalue, "extranet", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ClientContext Context = ExtranetLogOn(username, password, TargetSiteUrl);
                    // isAuthenticated = true;
                    // You can write additional methods here which you want to use after authentication
                }
            }
            catch (Exception ex)
            {
                // log error
                //   MessageBox.Show(ex.Message, "AuthenticateUser", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private static ClientContext LogOn(string userName, string password, Uri url)
        {
            ClientContext clientContext = null;
            ClientContext ctx;
            try
            {
                clientContext = new ClientContext(url);

                // Condition to check whether the user name is null or empty.
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    SecureString securestring = new SecureString();
                    password.ToCharArray().ToList().ForEach(s => securestring.AppendChar(s));
                    clientContext.Credentials = new System.Net.NetworkCredential(userName, securestring);
                    clientContext.ExecuteQuery();
                }
                else
                {
                    clientContext.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    clientContext.ExecuteQuery();
                }

                ctx = clientContext;
            }
            finally
            {
                if (clientContext != null)
                {
                    clientContext.Dispose();
                }
            }

            return ctx;
        }

        private static ClientContext O365LogOn(string userName, string password, Uri url)
        {
            ClientContext clientContext = null;
            ClientContext ctx = null;
            try
            {
                clientContext = new ClientContext(url);

                // Condition to check whether the user name is null or empty.
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    SecureString securestring = new SecureString();
                    password.ToCharArray().ToList().ForEach(s => securestring.AppendChar(s));
                    clientContext.Credentials = new SharePointOnlineCredentials(userName, securestring);
                    clientContext.ExecuteQuery();
                }
                else
                {
                    clientContext.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    clientContext.ExecuteQuery();
                }
                ctx = clientContext;
            }
            finally
            {
                if (clientContext != null)
                {
                    clientContext.Dispose();
                }
            }
            return ctx;
        }

        private static ClientContext ExtranetLogOn(string userName, string password, Uri url)
        {
            ClientContext clientContext = null;
            ClientContext ctx;
            try
            {
                clientContext = new ClientContext(url);

                // Condition to check whether the user name is null or empty.
                if (!string.IsNullOrEmpty(userName))
                {
                    NetworkCredential networkCredential = new NetworkCredential(userName, password);
                    CredentialCache cc = new CredentialCache();
                    cc.Add(url, "NTLM", networkCredential);
                    clientContext.Credentials = cc;
                    clientContext.ExecuteQuery();
                }
                else
                {
                    CredentialCache cc = new CredentialCache();
                    cc.Add(url, "NTLM", System.Net.CredentialCache.DefaultNetworkCredentials);
                    clientContext.Credentials = cc;
                    clientContext.ExecuteQuery();
                }
                ctx = clientContext;
            }
            finally
            {
                if (clientContext != null)
                {
                    clientContext.Dispose();
                }
            }
            return ctx;
        }

    }

    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1

    public class MsOnlineClaimsHelper
    {

        public void MSOnlineHelperClassAuth_set()
        {
            MSOnlineHelperClassAuth("https:/taibahuniv.sharepoint.com/sites/GP6_Site/");
        }

        #region Properties

        private readonly string _username;
        private readonly string _password;
        private readonly bool _useRtfa;
        private readonly Uri _host;

        private CookieContainer _cachedCookieContainer = null;
        private DateTime _expires = DateTime.MinValue;

        #endregion Properties

        #region Constructors

        public MsOnlineClaimsHelper(string host, string username, string password)
            : this(new Uri(host), username, password)
        {
        }

        public MsOnlineClaimsHelper(Uri host, string username, string password)
        {
            _host = host;
            _username = username;
            _password = password;
            _useRtfa = true;
        }

        public MsOnlineClaimsHelper(Uri host, string username, string password, bool useRtfa)
        {
            _host = host;
            _username = username;
            _password = password;
            _useRtfa = useRtfa;
        }

        #endregion Constructors

        #region Constants

        public const string office365STS = "https://login.microsoftonline.com/extSTS.srf";
        public const string office365Login = "https://login.microsoftonline.com/login.srf";
        public const string office365Metadata = "https://nexus.microsoftonline-p.com/federationmetadata/2007-06/federationmetadata.xml";
        public const string wsse = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        public const string wsu = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";

        const string saml = "urn:oasis:names:tc:SAML:1.0:assertion";
        const string spowssigninUri = "_forms/default.aspx?wa=wsignin1.0";
        const string contextInfoQuery = "_api/contextinfo";


        private static string userAgent = ConfigurationManager.AppSettings["UserAgent"];

        #endregion Constants

        private class MsoCookies
        {
            public string FedAuth { get; set; }

            public string rtFa { get; set; }

            public DateTime Expires { get; set; }

            public Uri Host { get; set; }
        }

        public static ClientContext MSOnlineHelperClassAuth(string SiteUrl)
        {
            //string userName = System.Configuration.ConfigurationManager.AppSettings["OnlineUserName"];
            //string password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"];


            string userName = System.Configuration.ConfigurationManager.AppSettings["mohammad_y_ammar@taibahu.edu.sa"];
            string password = System.Configuration.ConfigurationManager.AppSettings[""];
            try
            {
                MsOnlineClaimsHelper claimsHelper = new MsOnlineClaimsHelper(SiteUrl, userName, password);
                ClientContext clientContext = new ClientContext(SiteUrl);
                clientContext.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                Console.WriteLine("Connect to: " + SiteUrl);
                return clientContext;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }

        //MYA

  //      public static ClientContext MSOnlineHelperClassAuth_GP6(string username_sharepoint, string password_sharepoint, string SiteUrl)
          public static string MSOnlineHelperClassAuth_GP6(string username_sharepoint, string password_sharepoint, string SiteUrl)

        {
            //string userName = System.Configuration.ConfigurationManager.AppSettings["OnlineUserName"];
            //string password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"];


            string userName = System.Configuration.ConfigurationManager.AppSettings[username_sharepoint];
            string password = System.Configuration.ConfigurationManager.AppSettings[password_sharepoint];
            try
            {
                MsOnlineClaimsHelper claimsHelper = new MsOnlineClaimsHelper(SiteUrl, userName, password);
                ClientContext clientContext = new ClientContext(SiteUrl);
                clientContext.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                Console.WriteLine("Available, Connect to: " + SiteUrl);
                return "Connect to: " + SiteUrl;

              //  return clientContext;
            }
            catch (Exception ex)
            {
                return "Unvailable, " + ex.Message;

               // Console.WriteLine(ex.Message);

              //  throw;
            }
        }


        // Method used to add cookies to CSOM
        public void clientContext_ExecutingWebRequest(object sender, WebRequestEventArgs e)
        {
            e.WebRequestExecutor.WebRequest.CookieContainer = getCookieContainer();
            e.WebRequestExecutor.WebRequest.UserAgent = userAgent;
        }

        // Creates or loads cached cookie container
        private CookieContainer getCookieContainer()
        {
            if (_cachedCookieContainer == null || DateTime.Now > _expires)
            {
                // Get the SAML tokens from SPO STS (via MSO STS) using fed auth passive approach
                MsoCookies cookies = getSamlToken();

                if (!string.IsNullOrEmpty(cookies.FedAuth))
                {
                    // Create cookie collection with the SAML token
                    _expires = cookies.Expires;
                    CookieContainer cc = new CookieContainer();

                    // Set the FedAuth cookie
                    Cookie samlAuth = new Cookie("FedAuth", cookies.FedAuth)
                    {
                        Expires = cookies.Expires,
                        Path = "/",
                        Secure = cookies.Host.Scheme == "https",
                        HttpOnly = true,
                        Domain = cookies.Host.Host
                    };
                    cc.Add(samlAuth);

                    if (_useRtfa)
                    {
                        // Set the rtFA (sign-out) cookie, added march 2011
                        Cookie rtFa = new Cookie("rtFA", cookies.rtFa)
                        {
                            Expires = cookies.Expires,
                            Path = "/",
                            Secure = cookies.Host.Scheme == "https",
                            HttpOnly = true,
                            Domain = cookies.Host.Host
                        };
                        cc.Add(rtFa);
                    }
                    _cachedCookieContainer = cc;
                    return cc;
                }
                return null;
            }
            return _cachedCookieContainer;
        }

        public CookieContainer CookieContainer
        {
            get
            {
                if (_cachedCookieContainer == null || DateTime.Now > _expires)
                {
                    return getCookieContainer();
                }
                return _cachedCookieContainer;
            }
        }

        private MsoCookies getSamlToken()
        {
            MsoCookies ret = new MsoCookies();

            try
            {
                var sharepointSite = new
                {
                    Wctx = office365Login,
                    Wreply = _host.GetLeftPart(UriPartial.Authority) + "/_forms/default.aspx?wa=wsignin1.0"
                };

                //get token from STS
                string stsResponse = getResponse(office365STS, sharepointSite.Wreply);

                // parse the token response
                XDocument doc = XDocument.Parse(stsResponse);

                // get the security token
                var crypt = from result in doc.Descendants()
                            where result.Name == XName.Get("BinarySecurityToken", wsse)
                            select result;

                // get the token expiration
                var expires = from result in doc.Descendants()
                              where result.Name == XName.Get("Expires", wsu)
                              select result;
                ret.Expires = Convert.ToDateTime(expires.First().Value);

                HttpWebRequest request = createRequest(sharepointSite.Wreply);
                byte[] data = Encoding.UTF8.GetBytes(crypt.FirstOrDefault().Value);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();

                    using (HttpWebResponse webResponse = request.GetResponse() as HttpWebResponse)
                    {
                        // Handle redirect, added may 2011 for P-subscriptions
                        if (webResponse.StatusCode == HttpStatusCode.MovedPermanently)
                        {
                            HttpWebRequest request2 = createRequest(webResponse.Headers["Location"]);
                            using (Stream stream2 = request2.GetRequestStream())
                            {
                                stream2.Write(data, 0, data.Length);
                                stream2.Close();

                                using (HttpWebResponse webResponse2 = request2.GetResponse() as HttpWebResponse)
                                {
                                    ret.FedAuth = webResponse2.Cookies["FedAuth"].Value;
                                    ret.rtFa = webResponse2.Cookies["rtFa"].Value;
                                    ret.Host = request2.RequestUri;
                                }
                            }
                        }
                        else
                        {
                            ret.FedAuth = webResponse.Cookies["FedAuth"].Value;
                            ret.rtFa = webResponse.Cookies["rtFa"].Value;
                            ret.Host = request.RequestUri;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return ret;
        }

        private static HttpWebRequest createRequest(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            bool useProxy = bool.Parse(ConfigurationManager.AppSettings["UseProxy"]);
            if (useProxy) request.Proxy = GetWebProxyWithCredentials();

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            request.AllowAutoRedirect = false; // Do NOT automatically redirect
            request.UserAgent = userAgent;
            return request;
        }

        private static System.Net.WebProxy GetWebProxyWithCredentials()
        {
            string proxyAddress = System.Configuration.ConfigurationManager.AppSettings["proxyAddress"];
            string userName = System.Configuration.ConfigurationManager.AppSettings["LoggedInUserName"];
            string password = System.Configuration.ConfigurationManager.AppSettings["LoggedInPassword"];

            ICredentials credentials = new NetworkCredential(userName, password);
            return new System.Net.WebProxy(proxyAddress, false, new string[] { }, credentials);
        }
        //https://searchcode.com/file/116735091/Sobiens.Connectors/Sobiens.Connectors.Services.SharePoint/WcfClientContracts.cs/
        private string getResponse(string stsUrl, string realm)
        {
            RequestSecurityToken rst = new RequestSecurityToken
            {
                RequestType = WSTrustFeb2005Constants.RequestTypes.Issue,
                AppliesTo = new EndpointAddress(realm),
                KeyType = WSTrustFeb2005Constants.KeyTypes.Bearer,
                TokenType = Microsoft.IdentityModel.Tokens.SecurityTokenTypes.Saml11TokenProfile11
            };

            WSTrustFeb2005RequestSerializer trustSerializer = new WSTrustFeb2005RequestSerializer();

            WSHttpBinding binding = new WSHttpBinding();

            binding.Security.Mode = SecurityMode.TransportWithMessageCredential;

            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            binding.Security.Message.EstablishSecurityContext = false;
            binding.Security.Message.NegotiateServiceCredential = false;

            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

            EndpointAddress address = new EndpointAddress(stsUrl);

            using (WSTrustFeb2005ContractClient trustClient = new WSTrustFeb2005ContractClient(binding, address))
            //    using (WSTrustFeb20 trustClient = new WSTrustFeb2005Constants(binding, address))

            {
                trustClient.ClientCredentials.UserName.UserName = _username;
                trustClient.ClientCredentials.UserName.Password = _password;
                Message response = trustClient.EndIssue(
                    trustClient.BeginIssue(
                        Message.CreateMessage(
                            MessageVersion.Default,
                            WSTrustFeb2005Constants.Actions.Issue// ,    //$todo !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11
                          // new RequestBodyWriter(trustSerializer, rst)
                        ),
                        null,
                        null));
                trustClient.Close();
                using (XmlDictionaryReader reader = response.GetReaderAtBodyContents())
                {
                    return reader.ReadOuterXml();
                }
            }
        }
    }


    public partial class WSTrustFeb2005ContractClient : ClientBase<IWSTrustFeb2005Contract>, IWSTrustFeb2005Contract
    {
        public WSTrustFeb2005ContractClient(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        {
        }

        public IAsyncResult BeginIssue(Message request, AsyncCallback callback, object state)
        {
            return base.Channel.BeginIssue(request, callback, state);
        }

        public Message EndIssue(IAsyncResult asyncResult)
        {
            return base.Channel.EndIssue(asyncResult);
        }
    }


    public interface IWSTrustFeb2005Contract
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign, Action = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue", ReplyAction = "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue", AsyncPattern = true)]
        IAsyncResult BeginIssue(System.ServiceModel.Channels.Message request, AsyncCallback callback, object state);
        System.ServiceModel.Channels.Message EndIssue(IAsyncResult asyncResult);
    }

    //https://github.com/auth0/auth0-sharepoint/blob/master/clientcontext-active-authentication/Auth0.SharePoint.ActiveAuthentication/WsTrustFeb2005ContractClient.cs
    //class WsTrustFeb2005ContractClient : ClientBase<IWsTrustFeb2005Contract>, IWsTrustFeb2005Contract
    //{
    //    public WsTrustFeb2005ContractClient(Binding binding, EndpointAddress remoteAddress)
    //        : base(binding, remoteAddress)
    //    {
    //    }

    //    public IAsyncResult BeginIssue(Message request, AsyncCallback callback, object state)
    //    {
    //        return Channel.BeginIssue(request, callback, state);
    //    }

    //    public Message EndIssue(IAsyncResult asyncResult)
    //    {
    //        return Channel.EndIssue(asyncResult);
    //    }
    //}
}
