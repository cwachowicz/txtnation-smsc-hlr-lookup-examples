import urllib.parse
import urllib.request

url = 'http://smsc.txtnation.com:5002/checkHLR'
values = {
	"msisdn"    : "msisdn"
	"username"  : "username"
	"password"  : "password"
	"output"    : "xml|json"
}
data = urllib.parse.urlencode(values).encode("utf-8")
req = urllib.request.Request(url, data)
response = urllib.request.urlopen(req)
the_page = response.read()







