<?php

function send_data($userip, $firstname, $lastname, $email, $phone) {
    $url = "https://fg.trafficvision.network/api/signup/procform";

    $filedata = file_get_contents('template.json');
    $data = json_decode($filedata);

    $data['userip'] = $userip;
    $data['firstname'] = $firstname;
    $data['lastname'] = $lastname;
    $data['email'] = $email;
    $data['phone'] = $phone;

    $ch = curl_init();

    curl_setopt($ch, CURLOPT_URL,$url);
    curl_setopt($ch, CURLOPT_POST, true);
    curl_setopt($ch, CURLOPT_POSTFIELDS , $data);
    curl_setopt($ch, CURLOPT_HEADER, array(
        'x-trackbox-username: internalOB',
        'x-trackbox-password: Aa123456',
        'x-api-key: 2643889w34df345676ssdas323tgc738'
    ));
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

    $response =  curl_exec($ch);
    curl_close($ch);

    echo $response;
}