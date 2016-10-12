var http = require('http');

function getTestPersonaLoginCredentials(callback) {

	return http.get({
		host: 'http://smsc.txtnation.com',
		port: 5002,
		path: '/checkHLR',
		qs:{
			msisdn    : "msisdn"
			username  : "username"
			password  : "password"
			output    : "xml|json"
		}
	}, function(response) {
		// Continuously update stream with data
		var body = '';
		response.on('data', function(d) {
			body += d;
		});
		response.on('end', function() {
			callback(body);
		});
	});

}
