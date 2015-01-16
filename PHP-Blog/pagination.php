<?php if($originalQuery == 'all' || $originalQuery == 'older' || $originalQuery == 'newer') { ?>

<p class="page-count">Showing posts <?php echo ($firstPost + 1) ?> - <?php echo ($lastPost) ?></p>

<?php

if ($firstPost != 0):
    $checkFirst = $firstPost - 5;
    $checkLast = $lastPost - 5;
    $queryType = "SELECT * FROM posts ORDER BY date DESC LIMIT $checkFirst, $checkLast";
    $arr = $con->query($queryType);
    $posts = $arr->fetch_all();

    if (count($posts) != 0): ?>
        <div class="newer-posts"><a href="view.php?query=newer&first=<?php echo $firstPost?>&last=<?php echo $lastPost ?>">&lt;&lt;&lt; Show newer posts</a></div>
    <?php endif;
endif;

$checkFirst = $firstPost + 5;
$checkLast = $lastPost + 5;
$queryType = "SELECT * FROM posts ORDER BY date DESC LIMIT $checkFirst, $checkLast";
$arr = $con->query($queryType);
$posts = $arr->fetch_all();

if (count($posts) != 0): ?>
    <div class="older-posts"><a href="view.php?query=older&first=<?php echo $firstPost?>&last=<?php echo $lastPost ?>">Show older posts &gt;&gt;&gt;</a></div>
<?php endif;
}
?>
