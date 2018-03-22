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
    echo $sql;

    $checkExistEmail = mysqli_query($conn, $sql);

    //Mysqli_num_row()함수는 데이터베이스에서 쿼리를 보내서 나온 레코드의 개수를 알아낼때 쓰임
    // 0이 나오면 찾는 ID값이 없다는 뜻.
    if(!$checkExistEmail || mysqli_num_rows($checkExistEmail) == 0){ //if not exist same email
        $sql = "insert UserDB (email, password, name) values('$newEmail','$newPassword','$newName')";
        $result = mysqli_query($conn, $sql);
        echo ($result == true) ? "저장 성공" : "저장 실패";
        echo "not exist id Create-Success!!!";
        die("not Exist ID Create-Success!");
    } else {
        echo "exist id";
        die("already exist ID. Input other ID");
    }

?>