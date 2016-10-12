#include <iostream>
#include <string>
#using <System.Dll>
#using <System.Web.Dll>

using namespace std;
using namespace System;
using namespace System::Web;
using namespace System::Net;
using namespace System::IO;
using namespace System::Runtime::InteropServices;

ref class SMSSender
{

public:
        SMSSender()
        {}
        String^ SendSMS(String^ msisdn, String^ username, String^ password, String^ output)
        {
                String^ URL = "http://smsc.txtnation.com:5002/checkHLR?" + "msisdn=" + msisdn + "&username=" + username + "&password=" + password + "&output=" + output;
                WebRequest^ Handle = WebRequest::Create(URL);
                WebResponse^ HTTPResponse = Handle->GetResponse();
                StreamReader^ Stream = gcnew StreamReader(HTTPResponse->GetResponseStream());
                String^ Response = Stream->ReadToEnd()->Trim();
                HTTPResponse->Close();
                return Response;
        }
};

int main() {
        SMSSender^ test = gcnew SMSSender();
        String^ resp = test->SendSMS("msisdn", "username", "password", "xml|json");
        Console::WriteLine(resp);
        return 0;
}
