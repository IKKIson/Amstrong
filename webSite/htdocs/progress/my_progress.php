<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <?php //bootstrap
    include_once "../style/bootstrap.php";?>
    <title>나의 학습 진행도</title>
</head>
<body>
    <?php //header, navigation
    include_once($_SERVER['DOCUMENT_ROOT'] ."/common_form/path.php");?>
    <?php
    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");

    $conn = db_init();



    ?>

    <div>
        <table class="table table-bordered">
            <tr>
                <th>Email</th>
                <th>Chapter</th>
                <th>Category</th>
                <th>Card Id</th>
                <th>Check</th>
            </tr>
            <tr>
                <td>fuck iy</td>
                <td>fuck iy</td>
                <td>fuck iy</td>
            </tr>

        </table>
    </div>


    <?php
    if($_SERVER['REQUEST_METHOD'] == 'GET') {
        $email = $_SESSION["p_email"];
        //$email = "gkagm2@gmail.com";
        //$email = $_POST['email'];
        echo "my email " . $email;
        $sql = "select * from UserDB u , UserStudyDB us where u.email = us.email and u.email = '$email'";

        ##
        $oldEmail;
        $emailCk = false;
        ##

        $result = mysqli_query($conn, $sql);
        $count = 1;
        while($row = mysqli_fetch_array($result)){
            echo $count . " ";
            echo "<br>";
            $oldEmail = $raw['email'];

            //email flag 설정
            if($raw['email'] == $oldEmail){
                $emailCk = true;
            }
            //한번도 안나왔으면 email을 보여준다.
            if($emailCk == false){
                echo " email : " .$row['email'];
                echo "<br>";
            }
            
            echo " chapter : " .$row['chapter'];
            echo "<br>";
            echo " category : " .$row['category'];
            echo "<br>";
            echo " category_check : " .$row['category_check'];
            echo "<br>";
            echo " card_id : " .$row['card_id'];
            echo "<br>";
            echo " card_id_check : " .$row['card_id_check'];
            echo "<br>";
            $count++;
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
