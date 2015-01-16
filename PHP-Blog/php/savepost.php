<?php
require '../config.php';
session_start();

if (isset($_GET['submit'])) {
    $title = mysqli_real_escape_string($con, $_GET['title']);
    $post = mysqli_real_escape_string($con, $_GET['editor1']);
    $userID = mysqli_real_escape_string($con, $_SESSION['loggedUserID']);
    $tags = mysqli_real_escape_string($con, $_GET['tags']);
    $category = mysqli_real_escape_string($con, $_GET['category']);
    $tagsArr = mysqli_real_escape_string($con, explode(", ", $tags));

    require '../validations.php';

    if (validatePost()) {
        $sql = "INSERT INTO posts (title, text, user_id, category) VALUES ('$title', '$post', '$userID', '$category')";
        $con->query($sql);
        $id = mysqli_insert_id($con);

        foreach($tagsArr as $t){
            $tag = "INSERT INTO tags (tags, post_id) VALUES ('$t', '$id')";
            mysqli_query($con, $tag);
        }

        if ($id != 0) {

            header("Location: ../view.php?query=post&id=$id");

        } else {
            echo "Error: " . $sql . "<br>" . $con->error;
        }
    } else {
        echo "Invalid input! Please match the required formats."; ?>
        <br>
        <a href="../writepost.php">Go Back</a>

    <?php
    }


}