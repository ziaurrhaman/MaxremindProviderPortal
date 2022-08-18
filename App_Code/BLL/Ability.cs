using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;
using System.Net;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for AbilityConnection
/// </summary>
public class Ability
{
    public string GetEligibilityResponse(string Eligibility270String)
    {
        string response = string.Empty;
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            X509Store certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.OpenExistingOnly & OpenFlags.ReadOnly);
            X509CertificateCollection clientCertificates = (X509CertificateCollection)certStore.Certificates;



            X509Certificate certificate = new X509Certificate();
            foreach (X509Certificate Cert in clientCertificates)
            {
                if (Cert.Subject.Contains("ID:TXMARI001"))
                {
                    certificate = Cert;
                }
            }

            HttpWebRequest objWebRequest = (HttpWebRequest)WebRequest.Create("https://portal.visionshareinc.com/portal/seapi/services/RealtimeMedicareEligibility/84");


            objWebRequest.Method = "POST";
            objWebRequest.UserAgent = "Max Remind Incorporation/1.0";
            objWebRequest.Headers.Add("X-SEAPI-Version", "1");
            objWebRequest.ClientCertificates.Add(certificate);

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = Eligibility270String;
            byte[] data = encoding.GetBytes(postData);

            objWebRequest.ContentType = "application/EDI-X12";
            objWebRequest.ContentLength = postData.Length;

            using (Stream stream = objWebRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse objHttpWebResponse = (HttpWebResponse)objWebRequest.GetResponse();

            Stream streamResponse = objHttpWebResponse.GetResponseStream();

            StreamReader streamRead = new StreamReader(streamResponse);
            Char[] readBuff = new Char[256];
            int count = streamRead.Read(readBuff, 0, 256);

            while (count > 0)
            {
                String outputData = new String(readBuff, 0, count);
                response += outputData;
                count = streamRead.Read(readBuff, 0, 256);
            }
            // Release the response object resources.
            streamRead.Close();
            streamResponse.Close();
            objHttpWebResponse.Close();
        }
        catch (WebException WE)
        {
            using (var stream = WE.Response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                response = reader.ReadToEnd();
            }
        }

        return response;
    }


    public string GetCommercialInsuranceEligibilityResponse(string Eligibility270String)
    {
        string response = string.Empty;
        try
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            X509Store certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            // X509Store certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.OpenExistingOnly & OpenFlags.ReadOnly);
            X509CertificateCollection clientCertificates = (X509CertificateCollection)certStore.Certificates;



            X509Certificate certificate = new X509Certificate();
            foreach (X509Certificate Cert in clientCertificates)
            {
                if (Cert.Subject.Contains("ID:TXMARI001"))
                {
                    certificate = Cert;
                }
            }

            HttpWebRequest objWebRequest = (HttpWebRequest)WebRequest.Create("https://portal.visionshareinc.com/portal/seapi/services/RealtimeCommercialEligibility/318");

            //HttpWebRequest objWebRequest = (HttpWebRequest)WebRequest.Create("https://seapitest.visionshareinc.com/portal/seapi/services/RealtimeMedicareEligibility/11000");
            objWebRequest.Method = "POST";
            objWebRequest.UserAgent = "Max Remind Incorporation/1.0";
            objWebRequest.Headers.Add("X-SEAPI-Version", "1");
            objWebRequest.ClientCertificates.Add(certificate);

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = Eligibility270String;
            byte[] data = encoding.GetBytes(postData);

            objWebRequest.ContentType = "application/EDI-X12";
            objWebRequest.ContentLength = postData.Length;

            using (Stream stream = objWebRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse objHttpWebResponse = (HttpWebResponse)objWebRequest.GetResponse();

            Stream streamResponse = objHttpWebResponse.GetResponseStream();

            StreamReader streamRead = new StreamReader(streamResponse);
            Char[] readBuff = new Char[256];
            int count = streamRead.Read(readBuff, 0, 256);

            while (count > 0)
            {
                String outputData = new String(readBuff, 0, count);
                response += outputData;
                count = streamRead.Read(readBuff, 0, 256);
            }
            // Release the response object resources.
            streamRead.Close();
            streamResponse.Close();
            objHttpWebResponse.Close();
        }
        catch (WebException WE)
        {
            using (var stream = WE.Response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                response = reader.ReadToEnd();
            }
        }

        return response;
    }

    static private Boolean OnValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
        return true;
    }

    static private X509Certificate2 SelectLocalCertificate(object sender, string targetHost, X509CertificateCollection localCertificates, X509Certificate remoteCertificate, string[] acceptableIssuers)
    {
        X509Certificate2 certificate = new X509Certificate2();
        foreach (X509Certificate2 Cert in localCertificates)
        {
            if (Cert.Subject.Contains("ID:TXRCSI001"))
            {
                certificate = Cert;
            }
        }
        return certificate;
    }

    public string CerticateTest()
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

        X509Store certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
        certStore.Open(OpenFlags.OpenExistingOnly & OpenFlags.ReadOnly);
        X509CertificateCollection clientCertificates = (X509CertificateCollection)certStore.Certificates;

        string result = "NO";

        X509Certificate certificate = new X509Certificate();
        foreach (X509Certificate Cert in clientCertificates)
        {
            if (Cert.Subject.Contains("ID:TXRCSI001"))
            {
                certificate = Cert;
                result = "YEs";
            }
        }

        return result;
    }
}