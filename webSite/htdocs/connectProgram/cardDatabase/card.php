<?php    
    

    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");

    $conn = db_init();
    $email = $_POST['user_email'];
    $category = $_POST['category'];

    $q[5]; // question 
    for($i = 0 ; $i < 5; $i++){
        $q[$i] = $_POST['q'.$i];
    }
    echo $category;


    // TODO: test
    // $q[0] = "False";
    // $q[1] = "True";
    // $q[2] = "True";
    // $q[3] = "False";
    // $q[4] = "False";

    // $email = "j";
    // $category = "WordMatchingDB";
    /////////////////////////// Test End (나중에 지워)

    if(!$conn){ //if not connected
        die('Could not Connect:' . mysqli_error()); //The die() function prints a message and exits the current script.
    }
    $sql1 = ""; //삭제하기
    $sql2 = ""; //삽입하기

    if($category == "AnimalStudyDB"){
        $sql1 = "delete from AnimalStudyDB where email='$email'";
        $sql2 = "insert AnimalStudyDB (email, q0, q1, q2, q3, q4) values ('$email','$q[0]','$q[1]','$q[2]','$q[3]','$q[4]')";
    }else if($category == "ObjectStudyDB"){ 
        $sql1 = "delete from ObjectStudyDB where email='$email'";     
        $sql2 = "insert ObjectStudyDB (email, q0, q1, q2, q3, q4) values ('$email','$q[0]','$q[1]','$q[2]','$q[3]','$q[4]')";
    }else if($category == "WordMatchingDB"){   
        $sql1 = "delete from WordMatchingDB where email='$email'";        
        $sql2 = "insert WordMatchingDB (email, q0, q1, q2, q3, q4) values ('$email','$q[0]','$q[1]','$q[2]','$q[3]','$q[4]')";
    }else if($category == "MakeSentenceDB"){    
        $sql1 = "delete from MakeSentenceDB where email='$email'";        
        $sql2 = "insert MakeSentenceDB (email, q0, q1, q2, q3, q4) values ('$email','$q[0]','$q[1]','$q[2]','$q[3]','$q[4]')";

    }
    $result = mysqli_query($conn,$sql1); //row 삭제
    $result = mysqli_query($conn, $sql2); //row 삽입
    if($result == true){
        die("success");
    } else {
        die("fail");
    }
?>