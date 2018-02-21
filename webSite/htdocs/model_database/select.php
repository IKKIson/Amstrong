<?php


require("util.php");

$conn = db_init();
kpu();

$sql = "select * from testDB"; //SELECT 쿼리

if($conn){
    $result = mysqli_query($conn, $sql);

    //array 넣어주는 작업을 해줘야 함.  컨버팅해주는 작업이 들어가야 된다. 

    while($result = mysqli_fetch_array($result)){ //fetch_array로 빼줘야 된다. 왜? 
        echo $row['name'],"<br>";
    }
}






//  qli_error();

?>