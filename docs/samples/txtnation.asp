<%@ language="JScript" %>
<%
    msisdn    = "msisdn";
    username  = "username";
    password  = "password";
    output    = "xml|json";
    url = "http://smsc.txtnation.com:5002/checkHLR?" + "msisdn=" + msisdn + "&username=" + username + "&password=" + password + "&output=" + output;
    var objSrvHTTP;
    objSrvHTTP = Server.CreateObject("Msxml2.ServerXMLHTTP");
    objSrvHTTP.open(url, false);
    objSrvHTTP.send();
    Response.ContentType = "text/xml";
    xmlResp = objSrvHTTP.responseXML.xml;
    Response.Write(xmlResp);
%>
