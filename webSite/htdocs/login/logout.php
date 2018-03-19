<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <?php //bootstrap
    include_once "../style/bootstrap.php";?>
    <title>로그아웃</title>
</head>
<body>
    <?php //header, navigation
    include_once($_SERVER['DOCUMENT_ROOT'] ."/common_form/path.php");?>
    <?php
    //import databaseManager class
    include_once($_SERVER['DOCUMENT_ROOT']."/model_database/util.php");



    if($_SERVER['REQUEST_METHOD'] == 'GET'){
        $_SESSION['p_name'] = "";
        $_SESSION['p_email'] = "";
        $_SESSION['p_password'] = "";
        ?>
        <script>
            alert('로그아웃 완료');
        </script>
        <?php
        //TODO: 메인 화면으로 넘어가는 코드 작성해야 함.
    }

    ?>
    
</body>
</html>