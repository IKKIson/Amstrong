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
        
        <table width="250" boarder="1" cellpadding="0" cellspacing="0">
            <caption>사용자</caption>
            <th>Category</th>
            <td>사물</td>
            <tr></tr>
            <td>animal</td>

            <tr>
                <th>Chapter</th>
                <td>1</td>    
                <td>
                this
                    <div class="progress">
                        <div class="progress-bar progress-bar-danger progress-bar-striped" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
                            <span class="sr-only">80% Complete (danger)</span>
                        </div>
                    </div>
                </td>
            </tr>
            <td>animal</td>

            <tr>
                <th>Chapter</th>
                <td>1</td>    
                <td>
                this
                    <div class="progress">
                        <div class="progress-bar progress-bar-danger progress-bar-striped" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
                            <span class="sr-only">80% Complete (danger)</span>
                        </div>
                    </div>
                </td>
            </tr>
        </table>

        <table>

            <tr>
                <td>fucking</td>
                <td>shit</td>
            </tr>

            
            <tr>
                <th>Email</th>
                <th>Chapter</th>
                <th>Category</th>
                <th>Card Id</th>
                <th>Check</th>
                <td>fucki</td>
                <td>fucki</td>
                <td>fucki</td>
                <td>fucki</td>
            </tr>
            <tr>
                <td>fuck iy</td>
                <td>fuck iy</td>
                <td>fuck iy</td>
            </tr>

        </table>
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

        ##
        $oldEmail;
        $emailCk = false;
        ##

        include "./table_form.php";

        $result = mysqli_query($conn, $sql);
        $count = 1;
        while($row = mysqli_fetch_array($result)){
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
            
            echo " <h4>chapter : " .$row['chapter'] ."</h4>";
            echo " <h4>category : " .$row['category'] ."</h4>";
            echo "   ";
            echo " <h4>category_check : " .$row['category_check']."</h4>";
            echo " <h4>card_id : " .$row['card_id']."</h4>";
            echo "   ";
            echo " <h4>card_id_check : " .$row['card_id_check']."</h4>";
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
