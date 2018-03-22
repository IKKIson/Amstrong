<?php
//import databaseManager class
include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");


$email = $_POST['user_email'];
$password = $_POST['user_password'];

$conn = db_init();

if(!$conn){ //if not connected
    die('Could not Connect:' . mysqli_error()); //The die() function prints a message and exits the current script.
}

$sql = "select * from UserDB where email='".$email."'"; // id값을 찾기

$checkExsistEmail = mysqli_query($conn,$sql);

//Mysqli_num_row()함수는 데이터베이스에서 쿼리를 보내서 나온 레코드의 개수를 알아낼때 쓰임
// 0이 나오면 찾는 ID값이 없다는 뜻.
if(mysqli_num_rows($checkExsistEmail) == 0){ // if not exist id
        die("ID does not exist. \n"); 
} else { //exist id
    while($row = mysqli_fetch_assoc($checkExsistEmail)){ // mysql_fetch_assoc : 연관 배열로 결과 행을 반환
        if($password == $row['password']){
            //load info
            die("success");
        } else {
            die("wrong");
        }

    }
}


?>