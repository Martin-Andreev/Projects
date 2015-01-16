<?php
$firstPost = 0;
$lastPost = 5;
$originalQuery = $queryType;
if ($queryType == 'month') {
    $month = mysqli_real_escape_string($con, $_GET['month']);
    $year = mysqli_real_escape_string($con, $_GET['year']);
    $queryType = "SELECT * FROM posts WHERE MONTH(date) = $month AND YEAR(date) = $year";
} else if ($queryType == 'post') {
    $id = mysqli_real_escape_string($con, $_GET['id']);
    $queryType = "SELECT * FROM posts WHERE id = $id";
} else if ($queryType == 'all') {
    $queryType = "SELECT * FROM posts ORDER BY date DESC LIMIT 0, 5";
} else if ($queryType == 'category') {
    $cat = $_GET['cat'];
    $queryType = "SELECT * FROM posts WHERE  category = $cat";
} else if ($queryType == 'older') {
    $firstPost = $_GET['first'] + 5;
    $lastPost = $_GET['last'] + 5;
    $queryType = "SELECT * FROM posts ORDER BY date DESC LIMIT $firstPost, $lastPost";
} else if ($queryType == 'newer') {
    $firstPost = $_GET['first'] - 5;
    $lastPost = $_GET['last'] - 5;
    $queryType = "SELECT * FROM posts ORDER BY date DESC LIMIT $firstPost, $lastPost";
}
?>
