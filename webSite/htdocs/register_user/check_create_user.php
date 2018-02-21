<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <?php
    include_once($_SERVER['DOCUMENT_ROOT'] . "/style/bootstrap.php");
    ?>
    <title>확인</title>
</head>
<body>
    <?php //header, navigation
    include_once($_SERVER['DOCUMENT_ROOT'] ."/common_form/path.php");?>

    <?php
        include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");
        
        $user_name = $_POST['user_name'];
        $user_email = $_POST['user_email'];
        $user_password = $_POST['user_password'];
        echo $user_name;
        echo $user_email;
        echo $user_password;


        if($user_name === ""){
            echo "이름이 비어있습니다.";
        } else if($user_email === "") {
            echo "이메일이 비어있습니다.";
        } else if($user_password === "") {
            echo "패스워드가 비어있습니다.";
        } else{
            $conn = db_init();
            $sql = "insert into UserDB(email, password, name) values('$user_email','$user_password','$user_name')";
            if($conn){
                $result = mysqli_query($conn, $sql);
                echo ($result == true) ? "저장 성공" : "저장 실패";
            }
        }
    ?>

    <script>alert(worning,"성공:");</script>

    
</body>
</html>