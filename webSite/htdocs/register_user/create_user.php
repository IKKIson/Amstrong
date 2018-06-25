<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <?php
    include_once($_SERVER['DOCUMENT_ROOT'] . "/style/bootstrap.php");
    ?>
    <title>회원가입</title>
</head>
<body>
    <?php //header, navigation
    include_once($_SERVER['DOCUMENT_ROOT'] ."/common_form/path.php");?>

    <form class="navbar-form navbar-left" role="search" action="" method="post">
        <div class="form-group">
            <input type="text" class="form-control" placeholder="name" name="user_name"><br>
            <input type="text" class="form-control" placeholder="email" name="user_email"> <br>
            <input type="text" class="form-control" placeholder="password" name="user_password"><br>
        </div>
        <button type="submit" class="btn btn-default">회원가입</button>
    </form>
    <?php
    if($_SERVER['REQUEST_METHOD'] == 'GET') {

    }
    if($_SERVER['REQUEST_METHOD'] == 'POST') {
        include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");
        
        $user_name = $_POST['user_name'];
        $user_email = $_POST['user_email'];
        $user_password = $_POST['user_password'];
        echo $user_name;
        echo $user_email;
        echo $user_password;


        if($user_name === ""){
            echo '<script>alert("이름이 비어있습니다.")</script>';
        } else if($user_email === "") {
            echo '<script>alert("이메일이 비어있습니다.")</script>';
        } else if($user_password === "") {
            echo '<script>alert("패스워드가 비어있습니다.")</script>';
        } else{
            $conn = db_init();
            $sql = "insert into UserDB(email, password, name) values('$user_email','$user_password','$user_name')";
            if($conn){
                $result = mysqli_query($conn, $sql);
                echo ($result == true) ? "저장 성공" : "저장 실패";

                //////////1/start
                $sql0 = "insert AnimalStudyDB (email, q0, q1, q2, q3, q4) values ('$user_email','False','False','False','False','False')";
                $sql1 = "insert ObjectStudyDB (email, q0, q1, q2, q3, q4) values ('$user_email','False','False','False','False','False')";
                $sql2 = "insert WordMatchingDB (email, q0, q1, q2, q3, q4) values ('$user_email','False','False','False','False','False')";
                $sql3 = "insert MakeSentenceDB (email, q0, q1, q2, q3, q4) values ('$user_email','False','False','False','False','False')";
            
                //insert 
                $result = mysqli_query($conn, $sql0); //row 삽입
                if($result == true){
                    // die("success");
                } else {

                    die("fail");
                }
                $result = mysqli_query($conn, $sql1); //row 삽입
                if($result == true){
                    // die("success");
                } else {

                    // die("fail");
                }
                $result = mysqli_query($conn, $sql2); //row 삽입
                if($result == true){
                    // die("success");
                } else {

                    die("fail");
                }
                $result = mysqli_query($conn, $sql3); //row 삽입
                if($result == true){
                    // die("success");
                } else {

                    die("fail");
                }
                ///////////end






            }
            
        }
    }
    ?>
</body>
</html>
