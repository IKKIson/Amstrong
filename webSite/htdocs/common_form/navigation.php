<nav>
    
    <ul class="nav nav-tabs">
        <li role="presentation"><a href="../index.php">메인화면</a></li>
        <li role="presentation"><a href="../board/index.php">게시판</a></li>
        <li role="presentation"><a href="../progress/my_progress.php">나의 학습 진행도</a></li>
        <li role="presentation"><a href="../register_user/create_user.php">회원가입</a></li>
        <?php
        if($_SESSION['p_email'] == ""){ 
          ?>
            <li role="presentation"><a href="../login/login.php">로그인</a></li>
          <?php  
        } else {
            ?>
            <li role="presentation"><a href="../login/logout.php">로그아웃</a></li>
            <?php
        }
        ?>
        
        <!--<li role="presentation"><a href="">랭킹</a></li>-->
        
    </ul>
</nav>
