<?php

function validateRegistrationData() {
    global $name;
    global $username;
    global $password;
    $namePattern = "/^[\\w]{3,}$/";
    $usernamePattern = "/^[^\\s]{3,}$/";
    $passwordPattern = "/^.{4,}$/";

    if (preg_match($namePattern, $name) == 1
        && preg_match($usernamePattern, $username) == 1
        && preg_match($passwordPattern, $password) == 1) {
            return true;
    }

    return false;
}

function validatePost() {
    global $title;
    global $post;

    $pattern = "/^.{3,}$/";

    if (preg_match($pattern, $post) == 1 && preg_match($pattern, $title) == 1) {
        return true;
    }

    return false;
}

function validateComment() {
    global $name;
    global $comment;

    $pattern = "/^.{3,}$/";

    if (preg_match($pattern, $name) == 1 && preg_match($pattern, $comment) == 1) {
        return true;
    }

    return false;
}

?>
