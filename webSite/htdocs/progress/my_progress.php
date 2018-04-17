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

    // $sql = "select from ";
    // $result = mysql_query($conn, $sql);
    // if(!$result){
    //     echo "error";
    // } else {

    // }

    ?>

    <center>
        



    </center>
    <center>

    <?php
    if($_SERVER['REQUEST_METHOD'] == 'GET') {
        $email = $_SESSION["p_email"];
        //$email = "gkagm2@gmail.com";
        //$email = $_POST['email'];
        if($email == ""){
            echo "<h2>로그인을 해주세요</h2>";
        } else {
            echo "<h3>my email : " . $email . "</h3>";
        }
        
        $sql = "select * from UserDB u , UserStudyDB us where u.email = us.email and u.email = '$email'";
        // $sqlgetChapterInfo = "select chapter from UserDB u , UserStudyDB us where u.email = us.email and u.email = '$email'";
        ##
        $oldEmail;
        $emailCk = false;
        ##

        //include "./table_form.php";

        $result = mysqli_query($conn, $sql);
        $count = 1;
        while($row = mysqli_fetch_array($result)){ 
            //TODO: form 부분과 데이터 출력 부분을 나눌 필요가 있음.
            echo "----".$count . "----"; 
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
            echo "<table width='300'>";

            echo "<th>";
            echo "chapter";
            echo "</th>";
            
            echo "<td>" . $row['chapter'] . "</td>";

            echo "<tr>";
            echo "</tr>";

            echo "<th>";
            echo "category";
            echo "</th>";

            echo "<td>" .$row['category'] ."</td>";

            echo "<tr>";
            echo "</tr>";

            echo "<th>";
            echo "category_check";
            echo "</th>";

            echo "<td>" .$row['category_check'] . "</td>";
            
            echo "<tr>";
            echo "</tr>";

            echo "<th>";
            echo "card_id";
            echo "</th>";

            echo "<td>" .$row['card_id'] . "</td>";

            echo "<tr>";
            echo "</tr>";

            echo "<th>";
            echo "card_id_check";
            echo "</th>";

            
            echo "<td>" .$row['card_id_check']."</td>";

            echo "<tr>";
            echo "</tr";

            echo "<th>";
            echo "graph";
            echo "</th>";

            ?>
            <td>
                    <div class="progress">
                    <div class="progress-bar progress-bar-danger progress-bar-striped" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
                        <span class="sr-only">80% Complete (danger)</span>
                    </div>
                </div>
            </td>
            <?php
            echo "</table>";

            
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
    </center>
    
</body>
</html>
