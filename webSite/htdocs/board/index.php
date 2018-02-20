<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <?php //bootstrap
    include_once "../style/bootstrap.php";?>
    <title>Amstrong 게시판</title>
</head>
<body>
    <?php //header, navigation
    include_once($_SERVER['DOCUMENT_ROOT'] ."/common_form/path.php");?>
    <?php
    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");

    
    $conn = db_init();
    if($_SERVER['REQUEST_METHOD'] == 'GET') {
        echo "get으로 요청된 상태";

        $sql = "select * from testDB"; //SELECT 쿼리 역순

        $result = mysqli_query($conn, $sql);

        while($row = mysqli_fetch_array($result)){
            echo "<hr>";
            echo "name : " . $row['name'];
            echo "<hr>";            
        }

        $sql = "select * from UserDB";
        $result = mysqli_query($conn, $sql);

        echo "userDB";
        while($row = mysqli_fetch_array($result)){
            echo "<hr>";
            echo "user id : " . $row['user_id'] . "<br>";
            echo "user email: " . $row['email'] . "<br>";
            echo "user password : " . $row['password'] . "<br>";
            echo "user name : " . $row['name'] . "<br>";
            echo "<hr>";
        }
        
    }

    if($_SERVER['REQUEST_METHOD'] == 'POST') {

    }
    ?>    
</body>
</html>
