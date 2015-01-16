<?php
require '../config.php';

if (isset($_POST['submit'])){
    $name = mysqli_real_escape_string($con, $_POST['name']);
    $username = mysqli_real_escape_string($con, $_POST['username']);
    $email = mysqli_real_escape_string($con, $_POST['email']);
    $password = mysqli_real_escape_string($con, $_POST['password']);
    $city = mysqli_real_escape_string($con, $_POST['city']);
    $country = mysqli_real_escape_string($con, $_POST['country']);

    require '../validations.php';

    $password = hash('sha256', $password);

    $query = "SELECT id FROM users WHERE username = '$username' LIMIT 1";
    $userResult = mysqli_query($con, $query);
    $query = "SELECT id FROM users WHERE email = '$email' LIMIT 1";
    $emailResult = mysqli_query($con, $query);

    if (($userResult->num_rows != 0) || ($emailResult->num_rows != 0)){
        echo "User already registered"; ?>
        <br>
        <br>
        <a href="../registration.php">Go Back</a>
    <?php
    } else if (validateRegistrationData() == false) {
        echo "Data did not match requirements. Please retry."; ?>
        <br>
        <br>
        <a href="../registration.php">Go Back</a>
    <?php
    } else {
        $query = "INSERT INTO users (name, username, email, password, city, country) VALUES('$name', '$username', '$email', '$password', '$city', '$country')";

        if (mysqli_query($con, $query) == true){
            header('Location: ../index.php');
        } else {
            echo mysqli_error($query);
            echo 'ERROR'; ?>
            <br>
            <br>
            <a href="../registration.php">Go Back</a>
        <?php
        }
    }
}
?>
