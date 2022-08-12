<?php

header("Content-Type: application/json");
require 'functions.php';

$metod = $_SERVER['REQUEST_METHOD'];

if($metod === 'POST') {
    $data = json_decode(file_get_contents("php://input"), true);

    if(!empty($data['userip']) && !empty($data['firstname']) && !empty($data['lastname']) && !empty($data['email']) && !empty($data['phone'])) {

        $userip = $data['userip'];
        $firstname = $data['firstname'];
        $lastname = $data['lastname'];
        $email = $data['email'];
        $phone = $data['phone'];
    
        send_data($userip, $firstname, $lastname, $email, $phone);
    } else {
        http_response_code(404);

        $handler = [
            "message" => 'Some parameters are empty'
        ];

        echo json_encode($handler);
    }
}