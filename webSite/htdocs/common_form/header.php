<div class="header">
<?php


    //TODO: DatabaseManager 주석 풀고 시작
    ////database including
    //include_once($_SERVER['DOCUMENT_ROOT'] . "/model_database/util.php");
    //$dbManager = new DatabaseManager();

    ////database connect to beuron server databae
    //$dbManager->connect_database();

    //session start  for  login system
    session_start();
?>


    <!-- main logo picture -->
    <a href="/index.php"><img src="../files/logo/logo.jpg" alt="" width="200" ></a>
    

    <center>
    <?php
        echo "<h1> Wellcome ".$_SESSION['p_name']."</h1>";
    ?>
    <center>
</div>
