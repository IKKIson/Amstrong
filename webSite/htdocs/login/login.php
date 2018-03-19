<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <?php //bootstrap
    include_once "../style/bootstrap.php";?>
    <title>로그인</title>
</head>
<body>
    <?php //header, navigation
    include_once($_SERVER['DOCUMENT_ROOT'] ."/common_form/path.php");?>
    <?php
    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");



    if($_SERVER['REQUEST_METHOD'] == 'GET'){

        //if not login state
        if($_SESSION['p_email'] == ""){
            ?>
            <form class="navbar-form navbar-left" role="search" action="" method="post">
            <div class="form-group">
                <input type="text" class="form-control" placeholder="email" name="user_email"> <br>
                <input type="password" class="form-control" placeholder="password" name="user_password"><br>
            </div>
            <button type="submit" class="btn btn-default">로그인</button>
            </form>
            <?php
            
        }
    }

    if($_SERVER['REQUEST_METHOD'] == 'POST'){
        $email = $_POST['user_email'];
        $password = $_POST['user_password'];
        
        if($email == ""){
            echo "email이 입력되지 않았습니다.";

        }
        if($password == ""){
            echo "password가 입력되지 않았습니다.";
        }
        $conn = db_init();

        $sql = "select * from UserDB";
        $result = mysqli_query($conn, $sql);

        //emaiil and password checking
        $emailCheck = false;
        $passwordCheck = false;
        while($row = mysqli_fetch_array($result)){
            if($row['email'] == $email){
                $emailCheck = true;
                if($row['password'] == $password){
                    $passwordCheck = true;
                    $name = $row['name'];
                }
                break; // stop after check .
            }
        }

        //
        if($emailCheck == false){
            echo "해당 아이디가 없습니다.";
        } else if($emailCheck == true && $passwordCheck == false){
            echo "패스워드가 맞지 않습니다.";
        } else if($emailCheck == true && $passwordCheck == true){
            echo "성공적으로 로그인 되었습니다.";
            
    
            //register session 
            $_SESSION["p_email"] = $email;
            $_SESSION["p_name"] = $name;
            $_SESSION["p_password"] = $password;

            ?>
            <script>
                alert('로그인 완료');
            </script>
            <?php
            //TODO: 메인화면으로 넘어가는 코드 작성해야 함
            //move page
            echo "<meta http-equiv='Refresh' content='; URL=/index.php'>";

        }
        
    }
    ?>
    
</body>
</html>