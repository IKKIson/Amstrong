<?php
    class ConnectApp{

        function setSelect($select){
            
        }

        function getDBQuery($select){
            return "select * from $select";
        }
    }

    //앱과 연결하는 클래스 객체 생성
    $connApp = new ConnectApp;

    //앱으로부터 받아옴
    $select = $_POST['menu'];
    //해당되는 선택문을 선택하여 데이터베이스에서 가져온다
    $sql = $connApp.getDBQuery($seslect);

    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");

    $conn = db_init();

    if(!$conn){ //if not connected
        die('Could not Connect:' . mysqli_error()); //The die() function prints a message and exits the current script.
    }
    
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
    die($string);
    // die($row['english'] + ','+$row['korean'] + ','+$row['phonetic_alpabet'] + ','+$row['part_of_speech'] + ','+$row['relation_sentence_en'] + ','+$row['relation_sentence_ko']);
?>