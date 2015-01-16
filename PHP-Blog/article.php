<?php

require 'article_selection.php';

$arr = $con->query($queryType);
$posts = $arr->fetch_all();
$countPosts = count($posts);
require 'ip-check.php';
$ip = getUserIP();

if (count($posts) == 0): ?>
    <h2><?php  echo "No posts match your choice!"; ?></h2>

<?php endif;
foreach ($posts as $post):
    $userID = $post[4];
    $userName = $con->query("SELECT username FROM users WHERE id = $userID")->fetch_all();
    $userName = $userName[0][0];
    $postID = $post[0];

    $query = "INSERT INTO views (post_id, ip) VALUES ('$postID', '$ip')";
    mysqli_query($con, $query);

    $viewQuery = $con->query("SELECT ip FROM views WHERE post_id = $postID")->fetch_all();
    $totalViews = count($viewQuery);
    $uniqueIPS = array();

    foreach ($viewQuery as $view) {
        $uniqueIPS[] = $view[0];
    }
    $uniqueViews = count(array_unique($uniqueIPS));

    $commentQuery = "SELECT * FROM comments WHERE post_id = $post[0]";
    $comments = $con->query($commentQuery)->fetch_all();
    ?>

    <article>
        <a href="view.php?query=post&id=<?php echo $post[0] ?>"><h1><?php echo htmlentities($post[2]) ?></h1></a>
        <p class="date-and-user">Posted by: <?php echo htmlentities($userName) ?> | <span class="post-date"><?php echo $post[1] ?></span> |
                                 Total views: <?php echo $totalViews ?> | Unique views: <?php echo $uniqueViews ?></p>

        <div class="article-text"><?php echo $post[3] ?></div>
        <?php
        require 'article_tags.php';
        require 'comments.php' ?>

        <button class="comment-btn" onclick="showCommentForm(<?php echo $post[0]?>)" id="btn-<?php echo $post[0]?>">Write a comment</button>

        <?php require 'comment_form.php' ?>
    </article>

<?php

endforeach;

require 'pagination.php' ?>

