<?php
    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");

    $newEmail = $_POST['user_email'];
    $newPassword = $_POST['user_password'];
    $newName = $_POST['user_name'];

    if($newEmail === "" || $newPassword === "" || $newName === ""){
        die("빈칸이 있으면 안됩니다. 모두 입력해 주세요.");
    }
    $conn = db_init();

    if(!$conn){ //if not connected
        die("Could not Connect:" . mysqli_error());
    }

    $sql = "select email UserDB where email='".$newEmail."'";
    

    $checkExistEmail = mysqli_query($conn, $sql);

    //Mysqli_num_row()함수는 데이터베이스에서 쿼리를 보내서 나온 레코드의 개수를 알아낼때 쓰임
    // 0이 나오면 찾는 ID값이 없다는 뜻.
    if(!$checkExistEmail || mysqli_num_rows($checkExistEmail) == 0){ //if not exist same email
        $sql = "insert UserDB (email, password, name) values('$newEmail','$newPassword','$newName')";
        $result = mysqli_query($conn, $sql);
        if($result == true){
            die("success");
        } else {
            die("existId"); //TODO: 이부분 조건문 없앨 수 있으면 없애야 될 듯.나중에 
        }
    } else {
        die("existId");
    }

?>