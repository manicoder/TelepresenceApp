using System;
using System.Collections.Generic;
using System.Text;
using TelepresenceApp.CallHandler;
using Xamarin.Forms.OpenTok.Service;

namespace TelepresenceApp.Utils
{
    public static class AppUtility
    {
        public static string CallerUserId { get; set; }
        public static string MyUserId { get; set; }
        public static string SessionId { get; set; }
        public static string TokenId { get; set; }
        public async static void Init()
        {
            SessionId = "1_MX40NzA3NTcyNH5-MTYxMDM2NzkzNDE2N35xeXk2cHNPMVQ4M3BEMml6d3R5Y3J4V0N-fg";
            CrossOpenTok.Current.ApiKey = "47075724";
            CrossOpenTok.Current.UserToken = "T1==cGFydG5lcl9pZD00NzA3NTcyNCZzaWc9OWE5YzI4ZGFiNGE2ZGJmOWY3ZDFjNTk3ZDZmZTFkOWU0MTU1OGQzZDpzZXNzaW9uX2lkPTFfTVg0ME56QTNOVGN5Tkg1LU1UWXhNRE0yTnprek5ERTJOMzV4ZVhrMmNITlBNVlE0TTNCRU1tbDZkM1I1WTNKNFYwTi1mZyZjcmVhdGVfdGltZT0xNjEwMzY3OTYzJm5vbmNlPTAuNDQ0MTExNTI3ODAyNDYyNzcmcm9sZT1wdWJsaXNoZXImZXhwaXJlX3RpbWU9MTYxMjk1OTk2MyZpbml0aWFsX2xheW91dF9jbGFzc19saXN0PQ==";
            CrossOpenTok.Current.SessionId = SessionId;
            CrossOpenTok.Current.Error += (m) => App.Current.MainPage.DisplayAlert("ERROR", m, "OK");
        } 
        public static bool StartSession(string sessionId = "1_MX40NzA3NTcyNH5-MTYxMDM2NzkzNDE2N35xeXk2cHNPMVQ4M3BEMml6d3R5Y3J4V0N-fg")
        {
            CrossOpenTok.Current.SessionId = sessionId;
            return CrossOpenTok.Current.TryStartSession();
        }
    }
}
