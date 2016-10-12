import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.URL;
import java.net.URLConnection;
import java.net.URLEncoder;

// Simple send SMS programm
public class SendSMS {

    public static String sendSMS(String msisdn, String username, String password, String output) {
        String url;
        StringBuilder inBuffer = new StringBuilder();
        try {
            url = "http://smsc.txtnation.com:5002/checkHLR?" + "msisdn=" + msisdn + "&username=" + username + "&password=" + password + "&output=" + output;
        } catch (UnsupportedEncodingException e) {
            return null;
        }
        try {
            URL tmUrl = new URL(url);
            URLConnection tmConnection = tmUrl.openConnection();
            tmConnection.setDoInput(true);
            BufferedReader in = new BufferedReader(new InputStreamReader(tmConnection.getInputStream()));
            String inputLine;
            while ((inputLine = in.readLine()) != null)
                inBuffer.append(inputLine);
            in.close();
        } catch (IOException e) {
            return null;
        }
        return inBuffer.toString();
    }
    public static void main(String[] args) {
        // Example of use
        String response = sendSMS("msisdn", "username", "password", "xml|json");
        System.out.println(response);
    }
}
