<?php
    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");



    $conn = db_init();

    if(!$conn){ //if not connected
        die('Could not Connect:' . mysqli_error()); //The die() function prints a message and exits the current script.
    }
    
    $sql = "select * from ObjectDB"; //ObjectDB에 있는 값들 불러오기

    $result = mysqli_query($conn,$sql);

    $string = '';
    $tempString = '';
    while($row = mysqli_fetch_array($result)  ){
        $tempString = $row['english'] . ',' . $row['korean'] . ',' . $row['phonetic_alpabet'] . ',' . $row['part_of_speech'] . ',' . $row['relation_sentence_en'] . ',' .$row['relation_sentence_ko'] ;

        $string = $string . $tempString;
        // echo $row['english'];
        // echo $row['korean'];
        // echo $row['phonetic_alpabet'];
        // echo $row['part_of_speech'];
        // echo $row['relation_sentence_en'];
        // echo $row['relation_sentence_ko'];
        // echo '<br>';

    }

    echo $string;
    // die($string);
    // die($row['english'] + ','+$row['korean'] + ','+$row['phonetic_alpabet'] + ','+$row['part_of_speech'] + ','+$row['relation_sentence_en'] + ','+$row['relation_sentence_ko']);
    
    
    

?>