<?php
require ('../config.php');
session_start();

if (isset($_POST['submit'])) {
    $user = mysqli_real_escape_string($con, $_POST['user']);
    $pass = mysqli_real_escape_string($con, $_POST['password']);
    $pass = hash('sha256', $pass);

    $query = "SELECT id, name FROM users WHERE (username = '$user' AND password = '$pass')";
    $result = mysqli_query($con, $query);

    if ($result -> num_rows > 0) {
        $loggedUser = $result -> fetch_assoc();
        $_SESSION['loggedUser'] = true;
        $_SESSION['loggedUserID'] =$loggedUser['id'];
        $_SESSION['loggedUserName'] =$loggedUser['name'];
        header('Location: ../index.php');
    } else {

        header('Location: ../index.php?login=err');
    }
}