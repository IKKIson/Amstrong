<?php
    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");

    $conn = db_init();
    $email = $_POST['user_email'];
    


    $sql0 = "select * q0,q1,q2,q3,q4 from AnimalStudyDB";
    $sql1 = "select * q0,q1,q2,q3,q4 from AnimalStudyDB";
    $sql2 = "select * q0,q1,q2,q3,q4 from AnimalStudyDB";
    $sql3 = "select * q0,q1,q2,q3,q4 from AnimalStudyDB";

    


?>
