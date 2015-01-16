<?php
require 'config.php';
if(isset($_GET['tag'])) {

    $tagName = mysqli_real_escape_string($con, $_GET['tag']);
}
    $sql = "SELECT * FROM tags WHERE tags ='$tagName'";
    $arrTags = $con->query($sql);

    while ($tags = mysqli_fetch_row($arrTags)) :
        $posts = "SELECT * FROM posts WHERE id ='$tags[1]'";
        $postArr = $con -> query($posts);
        while ($post = mysqli_fetch_assoc($postArr)):
?>
<article>
    <ul>
    <li><a href="view.php?query=post&id=<?php echo $post['id'] ?>"><h1><?php echo htmlentities($post['title']) ?></h1></a>
    <div class="article-text"><?php echo $post['text'] ?></div>
        <div class=""><a href="view.php?query=post&id=<?php echo $post['id'] ?>"><p>See details...</p></li>

        <ul>
</article>
<?php
        endwhile;
    endwhile;
?>