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

        $email = "gkagm2@gmail.com";
        //$email = $_POST['email'];
        $sql = "select * from UserDB u , UserStudyDB us where u.email = us.email and u.email = '$email'";
        
        

        $result = mysqli_query($conn, $sql);
    
        while($row = mysqli_fetch_array($result)){
            echo "<hr>";
            echo "email : " .$row['email'];
        }

    }
    
    


    if($_SERVER['REQUEST_METHOD'] == 'POST') {

    }
    ?>

    <div>
    <?php
        echo "동물";
        //$sql = "select * from UserDB u , UserStudyDB us where u.email = us.email and u.email = '$email'";
        //$sql = "select * from UserDB"

        echo "사물";
        echo "숫자";
        echo "시간";
    ?>
    </div>


    
</body>
</html>
