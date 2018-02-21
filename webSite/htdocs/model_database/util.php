<?php

//Database connection.
function db_init(){
    $conn = mysqli_connect("218.155.186.13", "amstrong&admin", "amstrong1!");    
    mysqli_select_db($conn, "amstrong"); //database name use라는 말
    
    return $conn;
}

function db_get_card_info(){
    
}











//TODO: doing database refactoring
class DatabaseManager{
    protected $connect;
    protected $result;
   
    function __construct(){
        $this->connect = $this->connect_database(); //connected server database
    }

    //서버 database와 연결한다.
    function connect_database(){
    
        $conn = mysqli_connect("218.155.186.13", "amstrong&admin", "amstrong1!");    
        mysqli_select_db($conn, "amstrong"); //databasee name  (use)
        
        return $conn;
    
    }

    //삽입
    function insert_query(){

    }
    /* get, set function */
     //require server query
     function set_query($sqlQuery){
        $this->result = mysqli_query($this->connect, $sqlQuery);
    }
    //가져온다.
    function get_row_keys(){

    }
}
?>