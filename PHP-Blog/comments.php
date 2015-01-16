<div class="comments">
    <h4>Comments (<?php echo count($comments) ?>): </h4>
    <?php
    require 'config.php';
    if (isset($_SESSION['loggedUser'])):
    $userID = $_SESSION['loggedUserID'];
    $query = "SELECT * FROM users WHERE id = '$userID'";
    $arrUser = $con->query($query);

    while ($row = mysqli_fetch_assoc($arrUser)){
        $type = $row['type_account'];
    }


    if (count($comments) == 0): ?>
        <div class="comment-text"><p><?php echo "Be the first to leave a comment!" ?></p></div>
    <?php else:
    foreach ($comments as $comment): ?>
    <div id="comment<?php echo $comment[0] ?>"">
    <p class="date-and-user">By: <?php echo htmlentities($comment[1]) ?> | Date: <span class="post-date"><?php echo $comment[2] ?></span></p>
    <div class="comment-text"><p><?php echo htmlentities($comment[3]) ?></p></div>
    <?php
    if ($type == 'admin'):?>
        <form method="post" action="" class="del-form">
            <button class="del-comment-btn" type="submit" name="delete-comment" value="<?php echo $comment[0]?>" onclick="return confirm('Are you sure you want to delete this?')">Delete comment</button>
        </form>
    <?php
    endif
    ?>
</div>

<?php
if (isset($_POST['delete-comment'])) {
    $id = $_POST['delete-comment'];
    $query = "DELETE FROM comments WHERE id = $id";
    $con->query($query);
}
endforeach;
endif;
endif
?>

</div>