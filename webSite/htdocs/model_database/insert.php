<?php
//$dbName = $_POST['dbName'];
//$element = $_POST['elemenet'];

require("util.php");
include_once("util.php");
$conn = db_init();
if($conn){
    $result = mysqli_query($conn, $sql);
    echo $result;
}
// $sql = "insert into $dbName($element[0]) values('', 'descriptsample2')";
$sql = "insert into testDB(name) values('insertTest')";


?>