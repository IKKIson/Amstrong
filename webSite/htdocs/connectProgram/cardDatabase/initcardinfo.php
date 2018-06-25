<?php
    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");

    $conn = db_init();
    $email = $_POST['user_email'];
    
    $sql[] = array(4);

    $sql[0] = "insert AnimalStudyDB (email, q0, q1, q2, q3, q4) values ('$email','False','False','False','False','False')";

    $sql[1] = "insert ObjectStudyDB (email, q0, q1, q2, q3, q4) values ('$email','False','False','False','False','False')";

    $sql[2] = "insert WordMatchingDB (email, q0, q1, q2, q3, q4) values ('$email','False','False','False','False','False')";

    $sql[3] = "insert MakeSentenceDB (email, q0, q1, q2, q3, q4) values ('$email','False','False','False','False','False')";

    //insert 
    for($i=0; $i<4; $i++){
        $result = mysqli_query($conn, $sql[$i]); //row 삽입
        if($result == true){
            die("success");
        } else {
            die("fail");
        }
    }

?>
