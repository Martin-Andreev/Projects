<?php
$tagQuery = "SELECT tags FROM tags WHERE post_id = $post[0] ";
$tagList = $con->query($tagQuery);

$tagList = $tagList->fetch_all(); ?>

<div class="tag-info">Tags:
    <?php
    if (count($tagList) != 0) {
        foreach ($tagList as $tagEntry) { ;?>
            <a href="viewbytags.php?tag=<?php echo htmlentities($tagEntry[0]) ?>" class="tag-entries"><?php echo  htmlentities($tagEntry[0]) ?></a>
        <?php
        }
    } else {
        echo " (no tags for this post)";
    }
    ?>
</div>

