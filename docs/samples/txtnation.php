<?php

// Simple SMS send function
function sendSMS($msisdn, $username, $password, $output) {
    $URL = 'http://smsc.txtnation.com:5002/checkHLR?';
    $URL .= http_build_query([
        'msisdn'    => $msisdn,
        'username'  => $username,
        'password'  => $password,
        'output'    => $output
    ]);
    $fp = fopen($URL, 'r');
    return fread($fp, 1024);
}
// Example of use
$response = sendSMS('msisdn', 'username', 'password', 'xml|json');
echo $response;




